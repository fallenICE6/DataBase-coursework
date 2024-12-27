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
using static DataBaseCoursWork.AdminMainForm;

namespace DataBaseCoursWork
{
    public partial class ApprovalForm : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=your_password;Database=PublishDB";
        private OrderDetails orderDetails;
        private int currentImageIndex = 0;
        public ApprovalForm(OrderDetails orderDetails)
        {
            InitializeComponent();
            this.orderDetails = orderDetails;

            // Отображение данных
            lblTitle.Text = orderDetails.Title;
            lblCirculation.Text = orderDetails.quantity.ToString();
            lblVolume.Text = orderDetails.volume.ToString(); // Добавьте это Label в вашу форму
            lblAuthors.Text = orderDetails.Authors;
            lblProductType.Text = orderDetails.ProductTypeName; // Добавьте это Label в вашу форму

            // Загрузка изображений
            LoadImages(orderDetails.Images);
        }
        private List<OrderImage> images = new List<OrderImage>();
        private void LoadImages(List<OrderImage> images)
        {
            this.images = images;
            DisplayImage(currentImageIndex);
            UpdateImageCountLabel();
        }
        private void UpdateImageCountLabel()
        {
            lblImageCount.Text = $"{currentImageIndex + 1} из {images.Count}";
        }
        private void DisplayImage(int index)
        {
            if (images.Count > 0 && index >= 0 && index < images.Count)
            {
                // Для этого примера предполагается, что у вас есть OrderImage с ImageData типа byte[]
                using (var stream = new MemoryStream(images[index].ImageData))
                {
                    pictureBox1.Image = Image.FromStream(stream);
                }
            }
            else
            {
                pictureBox1.Image = null; // Очистим PictureBox если изображения нет
            }
        }

        private void btnSendToPrint_Click(object sender, EventArgs e)
        {
            UpdateOrderStatus(orderDetails.OrderID, "Распечатан");
            MessageBox.Show($"Статус заказа обновлен на 'Распечатан'.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnRejectPrint_Click(object sender, EventArgs e)
        {
            UpdateOrderStatus(orderDetails.OrderID, "Отменен");
            MessageBox.Show($"Статус заказа обновлен на 'Отменен'.");
            this.DialogResult = DialogResult.OK; 
            this.Close();
        }
        private void UpdateOrderStatus(int orderID, string newStatus)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE publishing.orders SET status = @newStatus WHERE orderid = @orderID";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("newStatus", newStatus);
                    cmd.Parameters.AddWithValue("orderID", orderID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                DisplayImage(currentImageIndex);
                UpdateImageCountLabel();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentImageIndex < images.Count - 1)
            {
                currentImageIndex++;
                DisplayImage(currentImageIndex);
                UpdateImageCountLabel();
            }
        }
    }
}
