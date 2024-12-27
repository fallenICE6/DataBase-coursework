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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataBaseCoursWork
{
    public partial class AuthorsForm : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=your_password;Database=PublishDB";
        public AuthorsForm()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем данные из формы
                string firstName = txtUsername.Text;
                string lastName = textBox1.Text;
                string middleName = textBox3.Text;
                string contactDetails = textBox2.Text;

                // Проверяем, что все поля заполнены
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(contactDetails))
                {
                    MessageBox.Show("Заполните имя, фамилию и контактную информацию.");
                    return;
                }

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    // Вставляем данные, при этом ID будет автоматически назначен с помощью последовательности
                    string query = @"
                INSERT INTO publishing.Authors (FirstName, LastName, ContactDetails, MiddleName)
                VALUES (@FirstName, @LastName, @ContactDetails, @MiddleName)
                RETURNING authorid";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("FirstName", firstName);
                        cmd.Parameters.AddWithValue("LastName", lastName);
                        cmd.Parameters.AddWithValue("ContactDetails", contactDetails);
                        cmd.Parameters.AddWithValue("MiddleName", middleName);

                        var authorId = cmd.ExecuteScalar(); // Получаем сгенерированный authorid

                        if (authorId != null)
                        {
                            MessageBox.Show($"Автор успешно добавлен с ID: {authorId}.");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при добавлении автора.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении автора: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
