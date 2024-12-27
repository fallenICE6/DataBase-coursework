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
    public partial class ContractForm : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=your_password;Database=PublishDB";
        public int CustomerId { get; set; }
        private decimal ProductPrice { get; set; }
        private int ProductVolume { get; set; }
        private int ProductQuantity { get; set; }
        private int ProductTypeId { get; set; }

        public ContractForm(int customerId, int productTypeId, decimal price, int volume, int quantity)
        {
            InitializeComponent();
            CustomerId = customerId;
            ProductTypeId = productTypeId;
            ProductPrice = price;
            ProductVolume = volume;
            ProductQuantity = quantity;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ContractForm_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString();
            
            decimal price = ProductPrice;
            int volume = ProductVolume;
            int quantity = ProductQuantity;
            
            // Учет объема
            price += volume * 0.5m;

            // Скидка на большое количество
            if (quantity > 1000)
            {
                price *= 0.9m;
            }

            // Итоговая стоимость
            decimal totalPrice = price * quantity;
            txtPrice.Text = totalPrice.ToString("C");
        }

        private void btnSaveContract_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Проверяем данные контракта
                if (string.IsNullOrEmpty(txtPod.Text))
                {
                    MessageBox.Show("Нужна подпись с вашей стороны.");
                    return;
                }

                // Создаем заказ
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    // Создаем заказ
                    string query = "INSERT INTO publishing.orders (customerid, producttypeid, quantity, orderdate, status) " +
                                   "VALUES (@customerid, @producttypeid, @quantity, @orderdate, @status) RETURNING orderid";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@customerid", CustomerId);
                        cmd.Parameters.AddWithValue("@producttypeid", ProductTypeId);
                        cmd.Parameters.AddWithValue("@quantity", ProductQuantity);
                        cmd.Parameters.AddWithValue("@orderdate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@status", "Зарегистрирован");

                        int orderId = (int)cmd.ExecuteScalar();

                        MessageBox.Show("Договор успешно подписан!");

                
                        this.DialogResult = DialogResult.OK;
                        this.Tag = orderId;
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании заказа: " + ex.Message);
            }
        }
    }
}
