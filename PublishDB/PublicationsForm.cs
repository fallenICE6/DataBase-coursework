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
    public partial class PublicationsForm : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=your_password;Database=PublishDB";
        private int publicationID;
        public PublicationsForm(int publicationID)
        {
            InitializeComponent();
            this.publicationID = publicationID;

            // Загружаем данные из базы данных для данного publicationID
            LoadPublicationData(publicationID);
        }

        private void LoadPublicationData(int publicationID)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    // Загружаем данные о публикации
                    string query = @"
                    SELECT 
                        p.publicationid,
                        p.title,
                        p.volume,
                        p.printrun
                    FROM 
                        publishing.publications p";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("PublicationID", publicationID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Заполняем поля на форме данными из базы данных
                                txtTitle.Text = reader["title"].ToString();
                                txtVolume.Text = reader["volume"].ToString();
                                txtPrintRun.Text = reader["printrun"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных издания: " + ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string title = txtTitle.Text;
                int volume = Convert.ToInt32(txtVolume.Text);
                int printrun = Convert.ToInt32(txtPrintRun.Text);

                // Проверка на заполненность
                if (string.IsNullOrEmpty(title) || volume <= 0 || printrun <= 0)
                {
                    MessageBox.Show("Все поля должны быть заполнены корректно.");
                    return;
                }

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                    UPDATE publishing.publications
                    SET title = @Title, volume = @Volume, printrun = @PrintRun
                    WHERE publicationid = @PublicationID";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("Title", title);
                        cmd.Parameters.AddWithValue("Volume", volume);
                        cmd.Parameters.AddWithValue("PrintRun", printrun);
                        cmd.Parameters.AddWithValue("PublicationID", publicationID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Данные издания успешно обновлены.");
                            this.DialogResult = DialogResult.OK; // Закрываем форму с результатом OK
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при обновлении данных издания.");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message);
            }
        }
    }
}
