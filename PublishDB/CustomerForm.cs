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
    public partial class CustomerForm : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=your_password;Database=PublishDB";
        public CustomerForm()
        {
            InitializeComponent();
        }

        // Конструктор для редактирования данных, если требуется
        public CustomerForm(int customerID, string name, string type, string contactDetails)
            : this()
        {
            // Заполняем поля формы данными для редактирования
            txtUsername.Text = name;
            comboBox1.SelectedItem = type;
            textBox1.Text = contactDetails;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Получаем данные из формы
            string fullName = txtUsername.Text.Trim();
            string type = comboBox1.SelectedItem?.ToString();
            string contactDetails = textBox1.Text.Trim();

            // Проверка на обязательные поля
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(contactDetails))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            string firstName = string.Empty;
            string middleName = string.Empty;
            string lastName = string.Empty;
            string name = string.Empty;

            // Присваиваем значения для типа
            string customerType = null;
            if (type.Equals("физическое лицо", StringComparison.OrdinalIgnoreCase))
            {
                // Разбиваем строку на слова для физического лица
                var names = fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (names.Length > 0)
                    lastName = names[0]; // Фамилия
                if (names.Length > 1)
                    firstName = names[1]; // Имя
                if (names.Length > 2)
                    middleName = names[2]; // Отчество
                customerType = "individual";
            }
            else if (type.Equals("организация", StringComparison.OrdinalIgnoreCase))
            {
                // Все имя записывается в поле name для организации
                name = fullName;
                customerType = "organization";
            }

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Вставляем нового заказчика в таблицу Customers
                    string customerQuery = "INSERT INTO publishing.Customers (CustomerID, Name, Type, ContactDetails, RepresentativeID, FirstName, LastName, MiddleName) " +
                                           "VALUES (nextval('publishing.customers_customerid_seq'), @name, @type::customer_type, @contactDetails, NULL, @firstName, @lastName, @middleName) RETURNING CustomerID";

                    using (var cmd = new NpgsqlCommand(customerQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("name", string.IsNullOrWhiteSpace(name) ? (object)DBNull.Value : name);  // Записываем name только для организаций
                        cmd.Parameters.AddWithValue("type", customerType);  // Используем переменную customerType
                        cmd.Parameters.AddWithValue("contactDetails", contactDetails);
                        cmd.Parameters.AddWithValue("firstName", string.IsNullOrWhiteSpace(firstName) ? (object)DBNull.Value : firstName);
                        cmd.Parameters.AddWithValue("lastName", string.IsNullOrWhiteSpace(lastName) ? (object)DBNull.Value : lastName);
                        cmd.Parameters.AddWithValue("middleName", string.IsNullOrWhiteSpace(middleName) ? (object)DBNull.Value : middleName);

                        // Получаем уникальный ID заказчика
                        int customerID = (int)cmd.ExecuteScalar();

                        // 2. Если заказчик - организация, добавляем представителя, если это нужно
                        if (customerType == "organization")
                        {
                            // Запрашиваем данные для представителя
                            var representativeForm = new RepresentativeForm();
                            if (representativeForm.ShowDialog() == DialogResult.OK)
                            {
                                string representativeFirstName = representativeForm.FirstName;
                                string representativeLastName = representativeForm.LastName;
                                string representativeMiddleName = representativeForm.MiddleName; // Отчество для представителя
                                string representativeContactDetails = representativeForm.ContactDetails;

                                // Добавляем представителя в таблицу Representatives
                                string representativeQuery = "INSERT INTO publishing.Representatives (CustomerID, FirstName, LastName, MiddleName, ContactDetails) " +
                                                             "VALUES (@customerID, @firstName, @lastName, @middleName, @contactDetails) RETURNING RepresentativeID";

                                using (var repCmd = new NpgsqlCommand(representativeQuery, conn))
                                {
                                    repCmd.Parameters.AddWithValue("customerID", customerID);
                                    repCmd.Parameters.AddWithValue("firstName", representativeFirstName);
                                    repCmd.Parameters.AddWithValue("lastName", representativeLastName);
                                    repCmd.Parameters.AddWithValue("middleName", representativeMiddleName); // Отчество представителя
                                    repCmd.Parameters.AddWithValue("contactDetails", representativeContactDetails);

                                    // Получаем ID представителя, если вставка успешна
                                    int representativeID = (int)repCmd.ExecuteScalar();

                                    // Сообщение об успешном добавлении представителя
                                    MessageBox.Show($"Представитель добавлен, его ID: {representativeID}, связанный с заказчиком ID: {customerID}");
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("Заказчик успешно добавлен!");
                this.DialogResult = DialogResult.OK; // Возвращаем OK, чтобы родительская форма обновила данные
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении заказчика: " + ex.Message);
            }
        }
    }
}
