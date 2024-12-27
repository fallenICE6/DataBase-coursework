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

namespace DataBaseCoursWork
{
    public partial class ViewPubForm : Form
    {
        public ViewPubForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Получаем данные из текстового поля
            string inputName = txtName.Text.Trim(); // Имя или ФИО автора

            // Проверка на пустое поле ввода
            if (string.IsNullOrEmpty(inputName))
            {
                MessageBox.Show("Введите фамилию, имя или полное ФИО автора.");
                return;
            }

            // Разделяем ввод на части (слова)
            var nameParts = inputName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Строка подключения для PostgreSQL
            string connectionString = "Host=localhost;Username=postgres;Password=your_password;Database=PublishDB";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Начинаем построение SQL-запроса
                    string query = @"
                    SELECT p.PublicationID, p.Title, a.FirstName, a.LastName, a.MiddleName, p.Volume, p.PrintRun, p.OrderID
                    FROM publishing.Publications p
                    JOIN publishing.publications_authors pa ON p.PublicationID = pa.PublicationID
                    JOIN publishing.Authors a ON pa.AuthorID = a.AuthorID WHERE 1=1";

                    if (nameParts.Length == 1)
                    {
                        // Один элемент - поиск по имени и фамилии
                        query += " AND (a.FirstName ILIKE @SingleName OR a.LastName ILIKE @SingleName)";
                    }
                    else if (nameParts.Length >= 2)
                    {
                        // Условия для "Имя Фамилия"
                        query += " AND ((a.FirstName ILIKE @FirstName AND a.LastName ILIKE @LastName) OR (a.LastName ILIKE @FirstName AND a.FirstName ILIKE @LastName))";

                        if (nameParts.Length == 3)
                        {
                            // Полное ФИО - добавляем условие для отчества
                            query += " AND (a.FirstName ILIKE @FirstName AND a.LastName ILIKE @LastName AND a.MiddleName ILIKE @MiddleName) OR (a.LastName ILIKE @FirstName AND a.LastName ILIKE @LastName AND a.MiddleName ILIKE @MiddleName)";
                        }
                    }

                        using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Установка параметров для запроса
                        if (nameParts.Length == 1)
                        {
                            command.Parameters.AddWithValue("@SingleName", "%" + nameParts[0] + "%");
                        }
                        else
                        {
                            // Установим параметры для двух слов
                            command.Parameters.AddWithValue("@FirstName", "%" + nameParts[0] + "%");
                            command.Parameters.AddWithValue("@LastName", "%" + nameParts[1] + "%");

                            if (nameParts.Length == 3)
                            {
                                command.Parameters.AddWithValue("@MiddleName", "%" + nameParts[2] + "%");
                            }
                        }

                        // Заполнение DataGridView
                        using (var dataAdapter = new NpgsqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);

                            // Проверка на наличие данных
                            if (dataTable.Rows.Count == 0)
                            {
                                MessageBox.Show("Издания для указанного автора не найдены.");
                                dataGridView1.DataSource = null; // Очистка DataGridView
                            }
                            else
                            {
                                // Если данные найдены, отображаем их в DataGridView
                                dataGridView1.DataSource = dataTable;
                                dataGridView1.Columns["PublicationID"].HeaderText = "ID Издания";
                                dataGridView1.Columns["Title"].HeaderText = "Название издания";
                                dataGridView1.Columns["FirstName"].HeaderText = "Имя автора";
                                dataGridView1.Columns["LastName"].HeaderText = "Фамилия автора";
                                dataGridView1.Columns["MiddleName"].HeaderText = "Отчество автора";
                                dataGridView1.Columns["Volume"].HeaderText = "Объем издания в печатных листах";
                                dataGridView1.Columns["PrintRun"].HeaderText = "Тираж";
                                dataGridView1.Columns["OrderID"].HeaderText = "Nº Заказа";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок подключения и выполнения запроса
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
                }
            }
        }
    

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns["PublicationID"].Visible = false;
            dataGridView1.Columns["OrderID"].Visible = false;
        }
    }
    }
