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
    public partial class AuthorEditForm : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=your_password;Database=PublishDB";
        public int AuthorID { get; set; }
        public AuthorEditForm(int authorId)
        {
            InitializeComponent();
            AuthorID = authorId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем измененные данные из формы
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string middleName = textBox3.Text;
                string contactDetails = txtContactDetails.Text;

                // Проверяем, что все поля заполнены
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(contactDetails))
                {
                    MessageBox.Show("Заполните имя, фамилию и контактную информацию!");
                    return;
                }

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE publishing.Authors SET FirstName = @FirstName, LastName = @LastName, ContactDetails = @ContactDetails, MiddleName = @MiddleName  WHERE authorid = @authorid";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("FirstName", firstName);
                        cmd.Parameters.AddWithValue("LastName", lastName);
                        cmd.Parameters.AddWithValue("ContactDetails", contactDetails);
                        cmd.Parameters.AddWithValue("MiddleName", middleName);
                        cmd.Parameters.AddWithValue("authorid", AuthorID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Данные автора успешно обновлены.");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при обновлении данных автора.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении данных автора: " + ex.Message);
            }
        }

    private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AuthorEditForm_Load(object sender, EventArgs e)
        {
            LoadAuthorData();
        }

        private void LoadAuthorData()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT FirstName, LastName, ContactDetails, MiddleName FROM publishing.Authors WHERE authorid = @authorid";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("authorid", AuthorID);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtFirstName.Text = reader["FirstName"].ToString();
                                txtLastName.Text = reader["LastName"].ToString();
                                txtContactDetails.Text = reader["ContactDetails"].ToString();
                                textBox3.Text = reader["MiddleName"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Автор не найден.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных автора: " + ex.Message);
            }
        }
    }
}
