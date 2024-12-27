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
    public partial class CalculateFrom : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=your_password;Database=PublishDB";
        public CalculateFrom()
        {
            InitializeComponent();
            LoadProductTypes();
        }
        private void LoadProductTypes()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ProductTypeID, Name, Price FROM publishing.producttypes";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var productType = new ProductType
                                {
                                    ProductTypeID = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Price = reader.GetDecimal(2)
                                };
                                comboBoxProductType.Items.Add(productType);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке типов продукции: " + ex.Message);
            }
        }
        private class ProductType
        {
            public int ProductTypeID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем выбранный тип продукции
                var selectedProductType = comboBoxProductType.SelectedItem as ProductType;
                if (selectedProductType == null)
                {
                    MessageBox.Show("Пожалуйста, выберите тип продукции.");
                    return;
                }

                // Проверка на корректность ввода для количества (тираж)
                if (!int.TryParse(textBoxQuantity.Text, out int quantity))
                {
                    MessageBox.Show("Пожалуйста, введите корректное число для тиража.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Прерываем выполнение метода, если введены некорректные данные
                }

                // Проверка на корректность ввода для объема
                if (!int.TryParse(textBoxVolume.Text, out int volume))
                {
                    MessageBox.Show("Пожалуйста, введите корректное число для объема.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal price = selectedProductType.Price;

                price += volume * 0.5m;

                if (quantity > 1000)
                {
                    price *= 0.9m;
                }

                // Общая стоимость
                decimal totalPrice = price * quantity;

                // Выводим рассчитанную цену в поле
                textBoxTotalPrice.Text = totalPrice.ToString("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при расчете цены: " + ex.Message);
            }
        }
    }
}
