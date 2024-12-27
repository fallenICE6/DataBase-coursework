using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseCoursWork
{
    public partial class ViewOrdersForm : Form
    {
        private int customerID;
        public ViewOrdersForm(int customerID)
        {
            InitializeComponent();
            this.customerID = customerID;
            LoadCustomerData();
            LoadOrderData();
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadCustomerData()
        {
            // Строка подключения для PostgreSQL
            string connectionString = "Host=localhost;Username=postgres;Password=your_password;Database=PublishDB";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string customerQuery = @"
                SELECT Name, FirstName, LastName, MiddleName, Type
                FROM publishing.Customers
                WHERE CustomerID = @CustomerID";

                    using (var command = new NpgsqlCommand(customerQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerID);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader["Type"].ToString() == "individual") // Проверка, является ли клиент физическим лицом
                                {
                                    txtCustomerName.Text = $"{reader["LastName"]} {reader["FirstName"]} {reader["MiddleName"]}".Trim();
                                }
                                else
                                {
                                    txtCustomerName.Text = reader["Name"].ToString(); // Имя организации
                                }
                            }
                            else
                            {
                                MessageBox.Show("Заказчик не найден.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных о заказчике: " + ex.Message);
                }
            }
        }
        private void LoadOrderData()
        {
            // Строка подключения для PostgreSQL
            string connectionString = "Host=localhost;Username=postgres;Password=your_password;Database=PublishDB";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string orderQuery = @"
                SELECT o.OrderID, pt.Name AS ProductTypeName, o.Quantity, o.OrderDate, o.Status, pub.Title AS PublicationTitle
                FROM publishing.Orders o
                JOIN publishing.ProductTypes pt ON o.ProductTypeID = pt.ProductTypeID
                LEFT JOIN publishing.Publications pub ON o.OrderID = pub.OrderID
                WHERE o.CustomerID = @CustomerID";

                    using (var command = new NpgsqlCommand(orderQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerID);

                        // Заполнение DataGridView
                        using (var dataAdapter = new NpgsqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);

                            // Проверка на наличие данных
                            if (dataTable.Rows.Count == 0)
                            {
                                dataGridView1.DataSource = null; // Очистка DataGridView
                            }
                            else
                            {
                                // Если данные найдены, отображаем их в DataGridView
                                dataGridView1.DataSource = dataTable;
                                dataGridView1.Columns["OrderID"].HeaderText = "ID Заказа";
                                dataGridView1.Columns["ProductTypeName"].HeaderText = "Тип продукции";
                                dataGridView1.Columns["Quantity"].HeaderText = "Тираж";
                                dataGridView1.Columns["OrderDate"].HeaderText = "Дата заказа";
                                dataGridView1.Columns["Status"].HeaderText = "Статус заказа";
                                dataGridView1.Columns["PublicationTitle"].HeaderText = "Название публикации";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных о заказах: " + ex.Message);
                }
            }
        }


        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns["OrderID"].Visible = false;
        }

    }
}
