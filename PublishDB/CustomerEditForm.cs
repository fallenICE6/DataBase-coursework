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
using System.Xml.Linq;

namespace DataBaseCoursWork
{
    public partial class CustomerEditForm : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=your_password;Database=PublishDB";
        private int customerID;

        public CustomerEditForm(int customerID)
        {
            InitializeComponent();
            this.customerID = customerID;
        }

        private void LoadCustomerData1()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Name, Type, ContactDetails, FirstName, LastName, MiddleName FROM publishing.Customers WHERE CustomerID = @customerID";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("customerID", customerID);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string type = reader.GetString(1);
                                txtType.Text = type == "individual" ? "физическое лицо" : "организация"; // Устанавливаем тип в TextBox

                                if (type == "individual") // Если это физическое лицо
                                {
                                    txtName.Visible = false; // Скрываем поле для имени организации
                                    txtFirstName.Visible = true; // Показываем поле для имени
                                    txtLastName.Visible = true; // Показываем поле для фамилии
                                    txtMiddleName.Visible = true; // Показываем поле для отчества
                                    label1.Visible = true;
                                    label6.Visible = true;
                                    label7.Visible = true;
                                    label2.Visible = false;
                                    btnAddRepresentative.Visible = false;

                                    txtFirstName.Text = reader.GetString(3); // FirstName
                                    txtLastName.Text = reader.GetString(4); // LastName
                                    txtMiddleName.Text = reader.GetString(5); // MiddleName
                                }
                                else if (type == "organization") // Если это организация
                                {
                                    txtName.Text = reader.GetString(0); // Name
                                    txtName.Visible = true; // Показываем поле для имени организации
                                    txtFirstName.Visible = false; // Скрываем поля для физического лица
                                    txtLastName.Visible = false;
                                    txtMiddleName.Visible = false;
                                    label1.Visible = false;
                                    label6.Visible = false;
                                    label7.Visible = false;
                                    label2.Visible = true;
                                    btnAddRepresentative.Visible = true;
                                }

                                txtContactDetails.Text = reader.GetString(2); // ContactDetails
                            }
                            else
                            {
                                MessageBox.Show("Не удалось найти заказчика с данным ID.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных заказчика: " + ex.Message);
            }
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                string contactDetails = txtContactDetails.Text?.Trim();
                string type = txtType.Text?.Trim(); // Получаем значение типа из TextBox

                // Проверяем, что все поля заполнены
                if (type == "физическое лицо")
                {
                    string firstName = txtFirstName.Text?.Trim();
                    string lastName = txtLastName.Text?.Trim();
                    string middleName = txtMiddleName.Text?.Trim();

                    if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(contactDetails))
                    {
                        MessageBox.Show("Пожалуйста, заполните все поля физического лица.");
                        return;
                    }

                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();

                        // Обновляем данные заказчика как физическое лицо
                        string query = "UPDATE publishing.Customers SET Name = @fullName, Type = @type::customer_type, ContactDetails = @contactDetails, FirstName = @firstName, LastName = @lastName, MiddleName = @middleName WHERE CustomerID = @customerID";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("fullName", $"{firstName} {lastName} {middleName}"); // Полное имя
                            cmd.Parameters.AddWithValue("type", "individual");
                            cmd.Parameters.AddWithValue("contactDetails", contactDetails);
                            cmd.Parameters.AddWithValue("firstName", firstName);
                            cmd.Parameters.AddWithValue("lastName", lastName);
                            cmd.Parameters.AddWithValue("middleName", middleName);
                            cmd.Parameters.AddWithValue("customerID", customerID);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Данные физического лица успешно обновлены!");
                                DialogResult = DialogResult.OK;
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка при обновлении данных физического лица.");
                            }
                        }
                    }
                }
                else if (type == "организация")
                {
                    string name = txtName.Text?.Trim();

                    if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(contactDetails))
                    {
                        MessageBox.Show("Пожалуйста, заполните все поля организации.");
                        return;
                    }

                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();

                        // Обновляем данные заказчика как организацию
                        string query = "UPDATE publishing.Customers SET Name = @name, Type = @type::customer_type, ContactDetails = @contactDetails WHERE CustomerID = @customerID";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("name", name);
                            cmd.Parameters.AddWithValue("type", "organization");
                            cmd.Parameters.AddWithValue("contactDetails", contactDetails);
                            cmd.Parameters.AddWithValue("customerID", customerID);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Данные организации успешно обновлены!");
                                DialogResult = DialogResult.OK;
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка при обновлении данных организации.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomerEditForm_Load_1(object sender, EventArgs e)
        {
            LoadCustomerData1();
        }

        private void btnAddRepresentative_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, является ли текущий заказчик организацией
                if (txtType.Text?.Trim() == "организация")
                {
                    // Открываем форму для добавления представителя
                    var representativeForm = new RepresentativeForm();

                    if (representativeForm.ShowDialog() == DialogResult.OK)
                    {
                        string firstName = representativeForm.FirstName?.Trim();
                        string lastName = representativeForm.LastName?.Trim();
                        string representativeContactDetails = representativeForm.ContactDetails?.Trim();

                        // Проверяем, что все данные для представителя заполнены
                        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(representativeContactDetails))
                        {
                            MessageBox.Show("Пожалуйста, заполните все данные для представителя.");
                            return;
                        }

                        // Добавляем представителя в базу данных
                        using (var conn = new NpgsqlConnection(connectionString))
                        {
                            conn.Open();

                            string insertRepQuery = "INSERT INTO publishing.Representatives (CustomerID, FirstName, LastName, ContactDetails) " +
                                                    "VALUES (@customerID, @firstName, @lastName, @contactDetails) RETURNING RepresentativeID";
                            using (var repCmd = new NpgsqlCommand(insertRepQuery, conn))
                            {
                                repCmd.Parameters.AddWithValue("customerID", customerID);
                                repCmd.Parameters.AddWithValue("firstName", firstName);
                                repCmd.Parameters.AddWithValue("lastName", lastName);
                                repCmd.Parameters.AddWithValue("contactDetails", representativeContactDetails);

                                // Получаем ID нового представителя
                                int representativeID = (int)repCmd.ExecuteScalar();

                                // Выводим сообщение с ID представителя и связанного заказчика
                                MessageBox.Show($"Представитель добавлен, его ID: {representativeID}, связанный с заказчиком ID: {customerID}");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Представители могут быть добавлены только для организаций.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении представителя: " + ex.Message);
            }
        }
    }
}
