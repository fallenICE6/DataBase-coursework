using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataBaseCoursWork
{
    public partial class PublicationForm : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=your_password;Database=PublishDB";
        private int orderId;
        private int volume;
        private int quantity;
        private List<PublicationImage> imagesList = new List<PublicationImage>();
        public PublicationForm(int orderId, int volume, int quantity)
        {
            InitializeComponent();
            this.orderId = orderId;
            this.volume = volume;
            this.quantity = quantity;

            radioButtonExistingAuthor.CheckedChanged += RadioButton_CheckedChanged;
            radioButtonNewAuthor.CheckedChanged += RadioButton_CheckedChanged;

            textBox3.Text = volume.ToString();
            textBox2.Text = quantity.ToString();
            LoadExistingAuthors();
            UpdateAuthorFieldsVisibility();
            comboBoxImageType.Items.AddRange(new[] { "Обложка", "Иллюстрация", "Фото", "Картинка" });
            comboBoxImageType.SelectedIndex = 0;
            LoadExistingAuthors();
        }
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAuthorFieldsVisibility();
        }
        private void UpdateAuthorFieldsVisibility()
        {
            if (radioButtonExistingAuthor.Checked)
            {
                // Отображаем CheckedListBox для выбора существующих авторов
                checkedListBoxAuthors.Visible = true;
                textBoxFirstName.Visible = false;
                textBoxLastName.Visible = false;
                textBoxMiddleName.Visible = false; // Отчество
                textBoxContactDetails.Visible = false;
                labelLastName.Visible = false;
                labelMiddleName.Visible = false;
                labelContactDetails.Visible = false;
                btnAddNewAuthor.Visible = false; // Кнопка для добавления нового автора не видна
            }
            else if (radioButtonNewAuthor.Checked)
            {
                // Скрываем CheckedListBox и показываем поля для ввода нового автора
                checkedListBoxAuthors.Visible = false;
                textBoxFirstName.Visible = true;
                textBoxLastName.Visible = true;
                textBoxMiddleName.Visible = true; // Отчество
                textBoxContactDetails.Visible = true;
                labelLastName.Visible = true;
                labelMiddleName.Visible = true;
                labelContactDetails.Visible = true;
                btnAddNewAuthor.Visible = true; // Показываем кнопку для добавления нового автора
            }
        }
        private void LoadExistingAuthors()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT AuthorID, FirstName, LastName, MiddleName FROM publishing.Authors";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            checkedListBoxAuthors.Items.Clear();
                            while (reader.Read())
                            {
                                var author = new Author
                                {
                                    AuthorID = reader.GetInt32(0),
                                    FirstName = reader.GetString(1),
                                    LastName = reader.GetString(2),
                                    MiddleName = reader.IsDBNull(3) ? null : reader.GetString(3)
                                };
                                checkedListBoxAuthors.Items.Add(author);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке авторов: " + ex.Message);
            }
        }

        private void btnSaveAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                ValidatePublicationFields();

                // Получаем выбранных авторов
                List<int> selectedAuthorIds = new List<int>();

                foreach (var item in checkedListBoxAuthors.CheckedItems)
                {
                    var author = (Author)item;
                    selectedAuthorIds.Add(author.AuthorID);
                }

                if (selectedAuthorIds.Count == 0)
                {
                    MessageBox.Show("Пожалуйста, выберите хотя бы одного автора.");
                    return;
                }

                // Добавляем публикацию для всех выбранных авторов
                int publicationId = AddPublicationForMultipleAuthors(selectedAuthorIds);

                // Добавляем изображение
                AddImage(publicationId);

                MessageBox.Show("Материалы успешно добавлены.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении автора или публикации: " + ex.Message);
            }
        }
        private int AddPublicationForMultipleAuthors(List<int> authorIds)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO publishing.Publications (Title, PrintRun, Volume, OrderID) " +
                               "VALUES (@Title, @PrintRun, @Volume, @OrderID) RETURNING PublicationID";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Title", textBoxTitle.Text);
                    cmd.Parameters.AddWithValue("PrintRun", quantity);
                    cmd.Parameters.AddWithValue("Volume", volume);
                    cmd.Parameters.AddWithValue("OrderID", orderId);

                    int publicationId = (int)cmd.ExecuteScalar();

                    // Сохраняем связь каждого автора с публикацией
                    foreach (var authorId in authorIds)
                    {
                        AddPublicationAuthor(publicationId, authorId);
                    }

                    return publicationId;
                }
            }
        }
        private void ValidatePublicationFields()
        {
            if (string.IsNullOrEmpty(textBoxTitle.Text))
            {
                throw new Exception("Пожалуйста, укажите название публикации!");
            }
        }
        private void ValidateNewAuthorFields()
        {
            if (string.IsNullOrEmpty(textBoxFirstName.Text) || string.IsNullOrEmpty(textBoxLastName.Text))
            {
                throw new Exception("Пожалуйста, заполните все поля для нового автора.");
            }
        }
       
        private void AddPublicationAuthor(int publicationId, int authorId)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO publishing.publications_authors (PublicationID, AuthorID) VALUES (@PublicationID, @AuthorID)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("PublicationID", publicationId);
                    cmd.Parameters.AddWithValue("AuthorID", authorId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private int InsertNewAuthor(string firstName, string lastName, string middleName, string contactDetails)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO publishing.Authors (FirstName, LastName, MiddleName, ContactDetails) " +
                               "VALUES (@FirstName, @LastName, @MiddleName, @ContactDetails) RETURNING AuthorID";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("FirstName", firstName);
                    cmd.Parameters.AddWithValue("LastName", lastName);
                    cmd.Parameters.AddWithValue("MiddleName", middleName);
                    cmd.Parameters.AddWithValue("ContactDetails", contactDetails);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
        private void AddImage(int publicationId)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                foreach (var image in imagesList) // Проходимся по всем изображениям
                {
                    if (image.Data != null && !string.IsNullOrEmpty(image.Type))
                    {
                        string query = "INSERT INTO publishing.Images (PublicationID, ImageType, ImageData) VALUES (@PublicationID, @ImageType, @ImageData)";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("PublicationID", publicationId);
                            cmd.Parameters.AddWithValue("ImageType", image.Type);
                            cmd.Parameters.AddWithValue("ImageData", image.Data);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, загрузите изображение и выберите его тип.");
                    }
                }
            }
        }
            private bool IsAuthorExist(string firstName, string lastName, string middleName)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM publishing.Authors WHERE FirstName = @FirstName AND LastName = @LastName AND MiddleName = @MiddleName";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("FirstName", firstName);
                    cmd.Parameters.AddWithValue("LastName", lastName);
                    cmd.Parameters.AddWithValue("MiddleName", middleName);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0; // Если автор существует, возвращаем true
                }
            }
        }

        private class Author
        {
            public int AuthorID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; } // Новое поле для отчества

            public override string ToString()
            {
                return $"{FirstName} {MiddleName} {LastName}".Trim(); // Обновим отображение, добавив отчество
            }
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Multiselect = true; // Разрешаем множественный выбор файлов

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        foreach (string file in openFileDialog.FileNames)
                        {
                            // Чтение изображения в байты
                            byte[] imageData = File.ReadAllBytes(file);
                            // Сохраняем выбранный тип изображения
                            string imageType = comboBoxImageType.SelectedItem.ToString();

                            imagesList.Add(new PublicationImage { Data = imageData, Type = imageType });

                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                // Показываем изображение в pictureBoxCover (можно добавить pictureBox для каждого изображения)
                                PictureBox pictureBox = new PictureBox
                                {
                                    Image = Image.FromStream(ms),
                                    SizeMode = PictureBoxSizeMode.StretchImage,
                                    Height = 100,
                                    Width = 100
                                };
                                flowLayoutPanelImages.Controls.Add(pictureBox); // Добавляем в FlowLayoutPanel или другой контейнер для изображений
                            }
                        }

                        MessageBox.Show("Изображение(я) загружено(ы).");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
                    }
                }
            }
        }
        private class PublicationImage
        {
            public byte[] Data { get; set; }
            public string Type { get; set; }
        }

        private void btnAddNewAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateNewAuthorFields(); // Проверяем вводимые данные

                // Проверяем, существует ли автор
                if (IsAuthorExist(textBoxFirstName.Text, textBoxLastName.Text, textBoxMiddleName.Text))
                {
                    MessageBox.Show("Автор с такими данными уже существует.");
                    return;
                }

                // Если автор не существует, добавляем его в БД
                int authorId = InsertNewAuthor(
                    textBoxFirstName.Text,
                    textBoxLastName.Text,
                    textBoxMiddleName.Text,
                    textBoxContactDetails.Text
                );

                // После добавления обновляем список авторов
                LoadExistingAuthors();
                MessageBox.Show($"Автор успешно добавлен.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении автора: " + ex.Message);
            }
        }
    }

}
