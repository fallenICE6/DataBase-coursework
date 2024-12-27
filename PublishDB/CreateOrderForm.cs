using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DataBaseCoursWork
{
    public partial class CreateOrderForm : Form
    {
        private int customerID;
        private string connectionString = "Host=localhost;Username=postgres;Password=your_password;Database=PublishDB";
        public CreateOrderForm(int customerid)
        {
            InitializeComponent();
            this.customerID = customerid;
            LoadProductTypes();
            LoadCustomerInfo();
        }
        private void LoadCustomerInfo()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT c.type, c.firstname, c.lastname, c.middlename, c.contactdetails, c.name,
                           r.firstname AS rep_firstname, r.lastname AS rep_lastname, r.middlename AS rep_middlename, r.contactdetails AS rep_contact
                    FROM publishing.customers c
                    LEFT JOIN publishing.representatives r ON c.representativeid = r.representativeid
                    WHERE c.customerid = @CustomerId";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerID);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Получаем данные о заказчике
                                string customerType = reader.GetFieldValue<string>(0); // Получаем тип заказчика

                                // В зависимости от типа заказчика загружаем данные
                                if (customerType == "individual")
                                {
                                    // Заполняем поля для частного лица
                                    panelPrivate.Visible = true;
                                    panelOrganize.Visible = false;
                                    txtCustomerName.Text = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                                    txtCustomerLastName.Text = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                                    txtCustomerMiddleName.Text = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                                    txtContactDetails.Text = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                                }
                                else if (customerType == "organization")
                                {
                                    // Заполняем поля для организации
                                    panelOrganize.Visible = true;
                                    panelPrivate.Visible = false;
                                    txtOrgName.Text = reader.IsDBNull(4) ? string.Empty : reader.GetString(5);
                                    txtOrgContact.Text = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);

                                    // Заполняем поля для представителя
                                    string repFirstName = reader.IsDBNull(5) ? string.Empty : reader.GetString(6);
                                    string repLastName = reader.IsDBNull(6) ? string.Empty : reader.GetString(7);
                                    string repMiddleName = reader.IsDBNull(7) ? string.Empty : reader.GetString(8);
                                    txtRepresentativeName.Text = $"{repFirstName} {repLastName} {repMiddleName}".Trim(); // Объединяем ФИО
                                    txtRepresentativeContact.Text = reader.IsDBNull(8) ? string.Empty : reader.GetString(9);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Заказчик не найден.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке информации о заказчике: " + ex.Message);
            }
        }
        private void LoadProductTypes()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ProductTypeID, Name, Price FROM publishing.producttypes";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var productType = new ProductType
                                {
                                    ProductTypeID = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Price = reader.GetDecimal(2)
                                };
                                comboBoxProductType.Items.Add(productType);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке типов продукции: " + ex.Message);
            }
        }
        private class ProductType
        {
            public int ProductTypeID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {

                int quantity = (int)numericUpDownQuantity.Value;
                if (quantity <= 0)
                {
                    MessageBox.Show("Количество продукции должно быть больше 0. Заказ не будет создан.");
                    return;
                }

                int volume = (int)numericUpDown1.Value;
                if (volume <= 0)
                {
                    MessageBox.Show("Объем продукции должен быть больше 0. Заказ не будет создан.");
                    return;
                }

                // Определяем тип заказчика
                string customerType = panelPrivate.Visible ? "Private" : "Organization";

                // Проверяем, что данные представителя были введены, если это организация
                if (customerType == "Organization")
                {
                    if (string.IsNullOrEmpty(txtRepresentativeName.Text) || string.IsNullOrEmpty(txtOrgName.Text))
                    {
                        MessageBox.Show("Для организации необходимо указать представителя и его контактные данные.");
                        return;
                    }
                    if (string.IsNullOrEmpty(txtOrgContact.Text))
                    {
                        MessageBox.Show("Пожалуйста, укажите контактные данные заказчика.");
                        return;
                    }
                }
                if (customerType == "Private")
                {
                    if (string.IsNullOrEmpty(txtCustomerName.Text) || string.IsNullOrEmpty(txtCustomerLastName.Text))
                    {
                        MessageBox.Show("Необходимо указать имя, фамилию заказчика и его контактные данные.");
                        return;
                    }
                    if (string.IsNullOrEmpty(txtContactDetails.Text))
                    {
                        MessageBox.Show("Пожалуйста, укажите контактные данные заказчика.");
                        return;
                    }
                }

                // Проверка на выбор типа продукции
                var selectedProductType = (dynamic)comboBoxProductType.SelectedItem;
                if (selectedProductType == null)
                {
                    MessageBox.Show("Ошибка: не выбран тип продукции.");
                    return;
                }

                UpdateCustomerInfo(customerType, volume, quantity);

                // Переходим к оформлению договора и получаем orderId
                var contractForm = new ContractForm(customerID, selectedProductType.ProductTypeID, selectedProductType.Price, volume, quantity);
                if (contractForm.ShowDialog() == DialogResult.OK)
                {
                    // Получаем ID созданного заказа
                    int orderId = (int)contractForm.Tag;
                    AfterContractSigned(orderId, volume, quantity);
                }

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при оформлении заказа: " + ex.Message);
            }
        }

        private void UpdateCustomerInfo(string customerType, int volume, int quantity)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                if (customerType == "Private")
                {
                    string query = @"
                UPDATE publishing.customers 
                SET firstname = @Firstname, lastname = @Lastname, middlename = @Middlename, 
                    contactdetails = @ContactDetails 
                WHERE customerid = @CustomerId";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Firstname", txtCustomerName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Lastname", txtCustomerLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Middlename", txtCustomerMiddleName.Text.Trim());
                        cmd.Parameters.AddWithValue("@ContactDetails", txtContactDetails.Text.Trim());
                        cmd.Parameters.AddWithValue("@CustomerId", customerID);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (customerType == "Organization")
                {
                    string query = @"
                UPDATE publishing.customers 
                SET name = @OrgName, contactdetails = @ContactDetails 
                WHERE customerid = @CustomerId;

                UPDATE publishing.representatives 
                SET firstname = @RepFirstname, lastname = @RepLastname, 
                    middlename = @RepMiddlename, contactdetails = @RepContactDetails 
                WHERE customerid = @CustomerId";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrgName", txtOrgName.Text.Trim());
                        cmd.Parameters.AddWithValue("@ContactDetails", txtOrgContact.Text.Trim());
                        cmd.Parameters.AddWithValue("@CustomerId", customerID);
                        cmd.Parameters.AddWithValue("@RepFirstname", GetRepresentativeFirstname());
                        cmd.Parameters.AddWithValue("@RepLastname", GetRepresentativeLastname());
                        cmd.Parameters.AddWithValue("@RepMiddlename", GetRepresentativeMiddlename());
                        cmd.Parameters.AddWithValue("@RepContactDetails", txtRepresentativeContact.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private string GetRepresentativeFirstname()
        {
            var splitName = txtRepresentativeName.Text.Trim().Split(' ');
            return splitName.Length > 0 ? splitName[0] : string.Empty;
        }

        private string GetRepresentativeLastname()
        {
            var splitName = txtRepresentativeName.Text.Trim().Split(' ');
            return splitName.Length > 1 ? splitName[1] : string.Empty;
        }

        private string GetRepresentativeMiddlename()
        {
            var splitName = txtRepresentativeName.Text.Trim().Split(' ');
            return splitName.Length > 2 ? splitName[2] : string.Empty;
        }


        private void AfterContractSigned(int orderId, int volume, int quantity)
        {
            PublicationForm publicationForm = new PublicationForm(orderId, volume, quantity);
            publicationForm.ShowDialog();
        }
      
    }
    }


