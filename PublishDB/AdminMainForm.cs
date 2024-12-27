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

namespace DataBaseCoursWork
{
    public partial class AdminMainForm : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=your_password;Database=PublishDB";
        private int selectedCustomerID = -1;
       
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            LoadCustomersData();
            LoadTabsData();
            LoadOrdersData();
            LoadAuthorsData();
            LoadPublicationsData();

            panelTabs.Visible = true;  // Например, скрываем панельTabs при запуске
            panelTrg.Visible = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Создаем новый экземпляр формы авторизации
            authorization authForm = new authorization();

            // Показываем форму авторизации
            authForm.Show();

            // Скрываем текущую форму (AdminForm)
            this.Hide();
        }

        private void btnTabs_Click(object sender, EventArgs e)
        {
            panelTabs.Visible = true;
            panelTrg.Visible = false;
            LoadCustomersData();
        }

        private void btnReports_Click_1(object sender, EventArgs e)
        {
            panelTabs.Visible=false;
            panelTrg.Visible=true;
            LoadTabsData();
        }

        #region Customers

        private void LoadCustomersData()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
            SELECT c.CustomerID,
                   c.Name AS OrganizationName,
                   c.Type,
                   c.FirstName,
                   c.LastName,
                   c.MiddleName,
                   r.FirstName AS FirstNamePr,
                   r.LastName AS LastNamePr,
                   r.MiddleName AS MiddleNamePr,
                   c.ContactDetails
            FROM publishing.Customers c
            LEFT JOIN publishing.Representatives r ON c.CustomerID = r.CustomerID";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            // Создаем новый DataTable для обработки данных
                            DataTable dataTable = new DataTable();
                            dataTable.Columns.Add("CustomerID", typeof(int));
                            dataTable.Columns.Add("DisplayName", typeof(string));
                            dataTable.Columns.Add("Type", typeof(string));
                            dataTable.Columns.Add("ContactDetails", typeof(string));
                            dataTable.Columns.Add("Representative", typeof(string)); // Новый столбец для представителя

                            while (reader.Read())
                            {
                                // Создаем новую строку
                                DataRow row = dataTable.NewRow();
                                row["CustomerID"] = reader["CustomerID"];
                                row["ContactDetails"] = reader["ContactDetails"];

                                string customerType = reader["Type"].ToString().Trim();

                                // В зависимости от типа определяем, какое имя использовать и тип клиента
                                if (customerType.Equals("organization", StringComparison.OrdinalIgnoreCase))
                                {
                                    row["DisplayName"] = reader["OrganizationName"]; // Используем поле Name для организаций
                                    row["Type"] = "организация"; // Устанавливаем тип как "организация"

                                    // Формируем строку представителя
                                    if (reader["FirstNamePr"] != DBNull.Value && reader["LastNamePr"] != DBNull.Value)
                                    {
                                        row["Representative"] = $"{reader["LastNamePr"]} {reader["FirstNamePr"]} {reader["MiddleNamePr"]}";
                                    }
                                    else
                                    {
                                        row["Representative"] = "Нет представителя";
                                    }
                                }
                                else
                                {
                                    // Используем FirstName, LastName и MiddleName для частных лиц
                                    row["DisplayName"] = $"{reader["LastName"]} {reader["FirstName"]} {reader["MiddleName"]}".Trim();

                                    // Для физических лиц устанавливаем тип как "физическое лицо"
                                    row["Type"] = "физическое лицо";

                                    // Для физических лиц представителя не будет
                                    row["Representative"] = "N/A"; // Указываем, что для частных лиц нет представителя
                                }

                                // Добавляем строку в DataTable
                                dataTable.Rows.Add(row);
                            }
                            dataGridView2.DataSource = dataTable;
                            dataGridView2.Columns["CustomerID"].HeaderText = "ID заказчика";
                            dataGridView2.Columns["DisplayName"].HeaderText = "Имя заказчика";
                            dataGridView2.Columns["Type"].HeaderText = "Тип заказчика";
                            dataGridView2.Columns["ContactDetails"].HeaderText = "Контактные данные";
                            dataGridView2.Columns["Representative"].HeaderText = "Представитель";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных заказчиков: " + ex.Message);
            }
        }

        private void Customers_Click(object sender, EventArgs e)
        {
            try
            {
                // Предполагаем, что вы используете форму для ввода данных нового представителя
                var customerAddForm = new CustomerForm();  // Это форма, на которой пользователь вводит данные
                if (customerAddForm.ShowDialog() == DialogResult.OK)
                {
                    // Если данные были успешно сохранены, обновим DataGridView
                    LoadCustomersData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении представителя: " + ex.Message);
            }
        }

        private void CustomersUpdate_Click(object sender, EventArgs e)
        {
            // Получаем выбранный ID из DataGridView
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView2.SelectedRows[0];
                int customerID = Convert.ToInt32(selectedRow.Cells["CustomerID"].Value);

                // Открываем форму редактирования с передачей CustomerID
                var customerEditForm = new CustomerEditForm(customerID);
                if (customerEditForm.ShowDialog() == DialogResult.OK)
                {
                    // Обновляем данные после изменения
                    LoadCustomersData();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заказчика для изменения.");
            }
        }

        private void CustomersDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView2.SelectedRows[0];
                int customerID = Convert.ToInt32(selectedRow.Cells["CustomerID"].Value);
                string customerType = selectedRow.Cells["Type"].Value.ToString();  // Получаем тип заказчика

                try
                {
                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();

                        // Начинаем транзакцию для обеспечения целостности данных
                        using (var transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                // 1. Удаляем все изображения, связанные с изданиями
                                string deleteImagesQuery = "DELETE FROM publishing.Images WHERE PublicationID IN (SELECT PublicationID FROM publishing.Publications WHERE OrderID IN (SELECT OrderID FROM publishing.Orders WHERE CustomerID = @customerID))";
                                using (var deleteImagesCmd = new NpgsqlCommand(deleteImagesQuery, conn, transaction))
                                {
                                    deleteImagesCmd.Parameters.AddWithValue("customerID", customerID);
                                    int affectedRows = deleteImagesCmd.ExecuteNonQuery();
                                    if (affectedRows == 0)
                                    {
                                        // Можно для отладки: вывести в случае, если изображения не были найдены
                                        Console.WriteLine($"Не найдены изображения для удаляемого заказчика с ID: {customerID}");
                                    }
                                }

                                // 2. Удаляем все публикации, связанные с заказами заказчика
                                string deletePublicationsQuery = "DELETE FROM publishing.Publications WHERE OrderID IN (SELECT OrderID FROM publishing.Orders WHERE CustomerID = @customerID)";
                                using (var deletePublicationsCmd = new NpgsqlCommand(deletePublicationsQuery, conn, transaction))
                                {
                                    deletePublicationsCmd.Parameters.AddWithValue("customerID", customerID);
                                    deletePublicationsCmd.ExecuteNonQuery();
                                }

                                // 3. Удаляем все заказы, связанные с заказчиком
                                string deleteOrdersQuery = "DELETE FROM publishing.Orders WHERE CustomerID = @customerID";
                                using (var deleteOrdersCmd = new NpgsqlCommand(deleteOrdersQuery, conn, transaction))
                                {
                                    deleteOrdersCmd.Parameters.AddWithValue("customerID", customerID);
                                    deleteOrdersCmd.ExecuteNonQuery();
                                }
                                // 4. Если это организация, удаляем представителя
                                
                                if(customerType == "Организация") customerType = customerType.ToLower();
                                if (customerType == "организация")
                                {
                                    string deleteRepQuery = "DELETE FROM publishing.Representatives WHERE CustomerID = @customerID";
                                    using (var deleteRepCmd = new NpgsqlCommand(deleteRepQuery, conn, transaction))
                                    {
                                        deleteRepCmd.Parameters.AddWithValue("customerID", customerID);
                                        deleteRepCmd.ExecuteNonQuery();
                                    }
                                }

                                // 5. Удаляем самого заказчика
                                string deleteCustomerQuery = "DELETE FROM publishing.Customers WHERE CustomerID = @customerID";
                                using (var deleteCustomerCmd = new NpgsqlCommand(deleteCustomerQuery, conn, transaction))
                                {
                                    deleteCustomerCmd.Parameters.AddWithValue("customerID", customerID);
                                    deleteCustomerCmd.ExecuteNonQuery();
                                }

                                // Завершаем транзакцию
                                transaction.Commit();

                                MessageBox.Show($"Заказчик с ID {customerID} и все его данные были успешно удалены.");
                                LoadCustomersData();
                                LoadTabsData();
                                LoadOrdersData();
                                LoadAuthorsData();
                                LoadPublicationsData();// Перезагружаем данные в DataGridView
                            }
                            catch (Exception ex)
                            {
                                // В случае ошибки откатываем транзакцию
                                transaction.Rollback();
                                MessageBox.Show("Ошибка при удалении заказчика: " + ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении заказчика: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заказчика для удаления.");
            }
        }
        

        private void dataGridView2_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Скрыть столбец CustomerID, если необходимо
            dataGridView2.Columns["CustomerID"].Visible = false;  // Столбец скрыт, но он доступен для работы
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Получаем ID выбранного заказчика из первой ячейки выбранной строки (предполагаем, что CustomerID в первой ячейке)
                selectedCustomerID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["CustomerID"].Value);
            }
            else
            {
                selectedCustomerID = -1;  // Если нет выбранной строки, сбрасываем ID
            }
        }
        #endregion

        #region TrgTabs
        private void LoadTabsData()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT table_name, operation_type, record_id, old_data, new_data, operation_time, user_name FROM publishing.audit_log";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dataGridView5.DataSource = dataTable;

                            dataGridView5.Columns["table_name"].HeaderText = "Таблица";
                            dataGridView5.Columns["operation_type"].HeaderText = "Тип операции";
                            dataGridView5.Columns["record_id"].HeaderText = "ID записи";
                            dataGridView5.Columns["old_data"].HeaderText = "Старые данные";
                            dataGridView5.Columns["new_data"].HeaderText = "Новые данные";
                            dataGridView5.Columns["operation_time"].HeaderText = "Время операции";
                            dataGridView5.Columns["user_name"].HeaderText = "Имя пользователя";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }
        #endregion

        #region Orders

        private void LoadOrdersData()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
            SELECT 
                o.OrderID, 
                o.CustomerID, 
                CASE 
                    WHEN c.Type = 'organization' THEN c.Name 
                    ELSE CONCAT_WS(' ', c.LastName, c.FirstName, c.MiddleName) 
                END AS CustomerName,
                pt.Name AS ProductTypeName, 
                o.Quantity, 
                o.OrderDate, 
                o.Status 
            FROM 
                publishing.Orders o
            JOIN 
                publishing.Customers c ON o.CustomerID = c.CustomerID
            JOIN 
                publishing.ProductTypes pt ON o.ProductTypeID = pt.ProductTypeID";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dataGridView3.DataSource = dataTable;

                            // Устанавливаем заголовки столбцов
                            dataGridView3.Columns["OrderID"].HeaderText = "ID заказа";
                            dataGridView3.Columns["CustomerName"].HeaderText = "Имя заказчика";
                            dataGridView3.Columns["ProductTypeName"].HeaderText = "Тип продукции";
                            dataGridView3.Columns["Quantity"].HeaderText = "Количество";
                            dataGridView3.Columns["OrderDate"].HeaderText = "Дата заказа";
                            dataGridView3.Columns["Status"].HeaderText = "Статус";
                            dataGridView3.Columns["CustomerID"].Visible = false;  // Скрываем столбец CustomerID в таблице
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных заказов: " + ex.Message);
            }
        }
        private void btnPull_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем выбранный заказ
                if (dataGridView3.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridView3.SelectedRows[0];
                    int orderID = Convert.ToInt32(selectedRow.Cells["OrderID"].Value);
                    string currentStatus = selectedRow.Cells["Status"].Value.ToString();

                    // Проверяем, что статус заказа позволяет просмотр материалов
                    if (currentStatus == "Зарегистрирован" || currentStatus == "В процессе")
                    {
                        // Получаем детали заказа
                        var orderDetails = GetOrderDetails(orderID);

                        // Открываем форму для действий с заказом
                        using (var approvalForm = new ApprovalForm(orderDetails))
                        {
                            if (approvalForm.ShowDialog() == DialogResult.OK)
                            {
                                LoadOrdersData(); // Обновляем данные, если статус был изменён
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Материалы можно просматривать только для заказов со статусом 'Зарегистрирован' или 'В процессе'.");
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите заказ.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при просмотре материалов: " + ex.Message);
            }
        }
        private OrderDetails GetOrderDetails(int orderID)
        {
            var orderDetails = new OrderDetails
            {
                OrderID = orderID // Инициализируем OrderID
            };

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                // Получаем детали о заказе включая полное имя авторов
                string queryOrder = @"
            SELECT p.title, o.quantity, p.volume, 
                   STRING_AGG(CONCAT(a.lastname, ' ',a.firstname, ' ',COALESCE(a.middlename, '')), ', ') AS authors, 
                   o.producttypeid, 
                   pt.name AS product_name, pt.subtype AS product_subtype
            FROM publishing.orders o
            JOIN publishing.publications p ON o.orderid = p.orderid
            LEFT JOIN publishing.publications_authors pa ON p.publicationid = pa.publicationid
            LEFT JOIN publishing.authors a ON pa.authorid = a.authorid
            LEFT JOIN publishing.producttypes pt ON o.producttypeid = pt.producttypeid
            WHERE o.orderid = @orderID
            GROUP BY p.title, o.quantity, p.volume, o.producttypeid, pt.name, pt.subtype;";

                using (var cmd = new NpgsqlCommand(queryOrder, conn))
                {
                    cmd.Parameters.AddWithValue("orderID", orderID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            orderDetails.Title = reader["title"].ToString();
                            orderDetails.quantity = (int)reader["quantity"];
                            orderDetails.volume = (int)reader["volume"];
                            orderDetails.Authors = reader["authors"]?.ToString() ?? string.Empty;
                            orderDetails.ProductTypeName = reader["product_name"].ToString();
                            orderDetails.ProductSubtype = reader["product_subtype"].ToString();
                        }
                    }
                }

                // Получаем изображения
                string queryImages = "SELECT imageid, imagetype, imagedata FROM publishing.images WHERE publicationid = (SELECT publicationid FROM publishing.publications WHERE orderid = @orderID)";
                using (var cmd = new NpgsqlCommand(queryImages, conn))
                {
                    cmd.Parameters.AddWithValue("orderID", orderID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var image = new OrderImage()
                            {
                                ImageID = (int)reader["imageid"],
                                ImageType = reader["imagetype"].ToString(),
                                ImageData = (byte[])reader["imagedata"]
                            };
                            orderDetails.Images.Add(image);
                        }
                    }
                }
            }

            return orderDetails;
        }

        public class OrderDetails
        {
            public string Title { get; set; }
            public int quantity { get; set; }
            public int volume { get; set; }
            public string Authors { get; set; }
            public string ProductTypeName { get; set; } // тип продукции
            public string ProductSubtype { get; set; } // подтип продукции
            public int OrderID { get; set; } // Добавляем OrderID
            public List<OrderImage> Images { get; set; } = new List<OrderImage>();
        }

        public class OrderImage
        {
            public int ImageID { get; set; }
            public string ImageType { get; set; }
            public byte[] ImageData { get; set; }
        }
        private void btnStatus_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем выбранный заказ
                if (dataGridView3.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridView3.SelectedRows[0];
                    int orderID = Convert.ToInt32(selectedRow.Cells["OrderID"].Value); // Получаем OrderID
                    string currentStatus = selectedRow.Cells["Status"].Value.ToString(); // Получаем текущий статус заказа

                    // Сформируем список возможных статусов в зависимости от текущего статуса
                    List<string> availableStatuses = GetAvailableStatuses(currentStatus);

                    // Открываем форму для выбора статуса
                    using (var statusForm = new StatusSelectionForm(availableStatuses, currentStatus))
                    {
                        if (statusForm.ShowDialog() == DialogResult.OK)
                        {
                            string newStatus = statusForm.SelectedStatus;

                            // Если выбран статус, то обновляем его
                            if (!string.IsNullOrEmpty(newStatus))
                            {
                                using (var conn = new NpgsqlConnection(connectionString))
                                {
                                    conn.Open();
                                    string query = "UPDATE publishing.Orders SET Status = @newStatus WHERE OrderID = @orderID";
                                    using (var cmd = new NpgsqlCommand(query, conn))
                                    {
                                        cmd.Parameters.AddWithValue("newStatus", newStatus);
                                        cmd.Parameters.AddWithValue("orderID", orderID);

                                        int rowsAffected = cmd.ExecuteNonQuery();
                                        if (rowsAffected > 0)
                                        {
                                            MessageBox.Show($"Статус заказа успешно обновлен на '{newStatus}'.");
                                            LoadOrdersData(); // Обновляем данные
                                        }
                                        else
                                        {
                                            MessageBox.Show("Ошибка при обновлении статуса.");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Статус не был изменен.");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите заказ.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при изменении статуса заказа: " + ex.Message);
            }
        }

        // Функция для получения доступных статусов в зависимости от текущего
        private List<string> GetAvailableStatuses(string currentStatus)
        {
            var allStatuses = new List<string>
    {
        "Зарегистрирован",
        "В процессе",
        "Отменен",
        "На проверке",
        "Распечатан"
    };

            // В зависимости от текущего статуса заказа возвращаем доступные статусы
            switch (currentStatus)
            {
                case "Зарегистрирован":
                    return new List<string> { "В процессе", "Отменен" };
                case "В процессе":
                    return new List<string> { "На проверке", "Отменен", "Распечатан" };
                case "Отменен":
                    return new List<string> { "Зарегистрирован" }; // Статус нельзя изменить
                case "На проверке":
                    return new List<string> { "Распечатан", "Отменен" };
                case "Распечатан":
                    return new List<string> { "Распечатан" }; // Уже распечатан, изменить нельзя
                default:
                    return new List<string>(); // Нет доступных статусов
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, выбран ли хотя бы один заказ
                if (dataGridView3.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridView3.SelectedRows[0];
                    int orderID = Convert.ToInt32(selectedRow.Cells["OrderID"].Value); // Получаем OrderID

                    // Получаем CustomerID, связанный с данным заказом
                    int customerID = Convert.ToInt32(selectedRow.Cells["CustomerID"].Value); // Получаем CustomerID

                    // Подтверждаем удаление
                    var confirmation = MessageBox.Show($"Вы уверены, что хотите удалить заказ {orderID} со всеми связанными данными?", "Удаление заказа", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmation == DialogResult.Yes)
                    {
                        // Создаем подключение к базе данных и начинаем транзакцию
                        using (var conn = new NpgsqlConnection(connectionString))
                        {
                            conn.Open();
                            var transaction = conn.BeginTransaction();

                            try
                            {
                                // Удаляем изображения, связанные с заказом через Publications
                                string deleteImagesQuery = @"
                        DELETE FROM publishing.Images
                        WHERE PublicationID IN 
                        (SELECT PublicationID FROM publishing.Publications WHERE OrderID = @orderID)";
                                using (var cmd = new NpgsqlCommand(deleteImagesQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("orderID", orderID);
                                    cmd.ExecuteNonQuery();
                                }

                                // Удаляем публикации, связанные с заказом
                                string deletePublicationsQuery = "DELETE FROM publishing.Publications WHERE OrderID = @orderID";
                                using (var cmd = new NpgsqlCommand(deletePublicationsQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("orderID", orderID);
                                    cmd.ExecuteNonQuery();
                                }

                                // Удаляем сам заказ из таблицы Orders
                                string deleteOrderQuery = "DELETE FROM publishing.Orders WHERE OrderID = @orderID";
                                using (var cmd = new NpgsqlCommand(deleteOrderQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("orderID", orderID);
                                    cmd.ExecuteNonQuery();
                                }

                                // Если все прошло успешно, подтверждаем транзакцию
                                transaction.Commit();
                                MessageBox.Show($"Заказ {orderID} успешно удален вместе со всеми связанными данными.");

                                // Перезагружаем данные после удаления
                                LoadOrdersData();  // Перезагрузить заказы
                                LoadCustomersData();  // Перезагрузить данные клиентов
                                LoadTabsData();  // Перезагрузить вкладки
                                LoadAuthorsData();  // Перезагрузить данные авторов
                                LoadPublicationsData();  // Перезагрузить данные публикаций
                            }
                            catch (Exception ex)
                            {
                                // Если возникла ошибка, откатываем транзакцию
                                transaction.Rollback();
                                MessageBox.Show("Ошибка при удалении заказа: " + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    // Если заказ не выбран
                    MessageBox.Show("Пожалуйста, выберите заказ.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении заказа: " + ex.Message);
            }
        }
        private void dataGridView3_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView3.Columns["OrderID"].Visible = false;  // Столбец скрыт, но он доступен для работы
        }


        #endregion

        #region Authors

        private void LoadAuthorsData()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT AuthorID, FirstName, LastName, MiddleName, ContactDetails FROM publishing.Authors";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dataGridView4.DataSource = dataTable;

                            // Устанавливаем заголовки столбцов
                            dataGridView4.Columns["AuthorID"].HeaderText = "ID автора";
                            dataGridView4.Columns["FirstName"].HeaderText = "Имя автора";
                            dataGridView4.Columns["LastName"].HeaderText = "Фамилия автора";
                            dataGridView4.Columns["MiddleName"].HeaderText = "Отчество автора";
                            dataGridView4.Columns["ContactDetails"].HeaderText = "Контактные данные";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных автора: " + ex.Message);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                
                var AuthorsAddForm = new AuthorsForm(); 
                if (AuthorsAddForm.ShowDialog() == DialogResult.OK)
                {
                    
                    LoadAuthorsData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении автора: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Получаем выбранный ID из DataGridView
            if (dataGridView4.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView4.SelectedRows[0];
                int authorID = Convert.ToInt32(selectedRow.Cells["AuthorID"].Value);

                // Открываем форму редактирования с передачей CustomerID
                var authorEditForm = new AuthorEditForm(authorID);
                if (authorEditForm.ShowDialog() == DialogResult.OK)
                {
                    // Обновляем данные после изменения
                    LoadAuthorsData();
                    LoadPublicationsData();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите автора для изменения.");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, выбран ли автор
                if (dataGridView4.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridView4.SelectedRows[0];
                    int authorID = Convert.ToInt32(selectedRow.Cells["authorid"].Value); // Получаем authorid из выбранной строки

                    // Подтверждаем удаление
                    var confirmation = MessageBox.Show($"Вы уверены, что хотите удалить автора с ID {authorID}?", "Удаление автора", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmation == DialogResult.Yes)
                    {
                        using (var conn = new NpgsqlConnection(connectionString))
                        {
                            conn.Open();
                            var transaction = conn.BeginTransaction();

                            try
                            {
                                // Удаляем автора из таблицы Authors
                                string deleteAuthorQuery = "DELETE FROM publishing.Authors WHERE authorid = @authorID";
                                using (var cmd = new NpgsqlCommand(deleteAuthorQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("authorID", authorID);
                                    cmd.ExecuteNonQuery();
                                }

                                // Если все прошло успешно, подтверждаем транзакцию
                                transaction.Commit();
                                MessageBox.Show($"Автор с ID {authorID} успешно удален.");
                                LoadAuthorsData();
                                LoadPublicationsData();// Обновляем данные в DataGridView
                            }
                            catch (Exception ex)
                            {
                                // Если возникла ошибка, откатываем транзакцию
                                transaction.Rollback();
                                MessageBox.Show("Ошибка при удалении автора: " + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите автора для удаления.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении автора: " + ex.Message);
            }
        }

        private void dataGridView4_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView4.Columns["AuthorID"].Visible = false;  // Столбец скрыт, но он доступен для работы
        }
        #endregion

        #region Publications
        private void LoadPublicationsData()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    p.publicationid, 
                    p.title, 
                    p.volume, 
                    p.printrun, 
                    p.orderid,
                    (a.lastname || ' ' || a.firstname || ' ' || a.middlename) AS author_fullname
                FROM 
                    publishing.publications p 
                LEFT JOIN 
                    publishing.publications_authors pa ON p.publicationid = pa.publicationid 
                LEFT JOIN 
                    publishing.authors a ON pa.authorid = a.authorid 
                LEFT JOIN 
                    publishing.orders o ON p.orderid = o.orderid 
                ORDER BY 
                    p.publicationid;";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dataGridView1.DataSource = dataTable;

                            // Устанавливаем заголовки столбцов
                            dataGridView1.Columns["publicationid"].HeaderText = "ID издания";
                            dataGridView1.Columns["title"].HeaderText = "Название издания";
                            dataGridView1.Columns["volume"].HeaderText = "Объем издания (лист.)";
                            dataGridView1.Columns["printrun"].HeaderText = "Тираж издания";
                            dataGridView1.Columns["orderid"].HeaderText = "Номер договора";
                            dataGridView1.Columns["author_fullname"].HeaderText = "ФИО автора";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных публикаций: " + ex.Message);
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns["publicationid"].Visible = false;
        }

        private void btnUpadatePub_Click(object sender, EventArgs e)
        {
            {
                // Получаем выбранный ID из DataGridView
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridView1.SelectedRows[0];
                    int publicationID = Convert.ToInt32(selectedRow.Cells["publicationid"].Value);

                    
                    var pubicationsEditForm = new PublicationsForm(publicationID);
                    if (pubicationsEditForm.ShowDialog() == DialogResult.OK)
                    {
                        // Обновляем данные после изменения
                        LoadPublicationsData();
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите издание для редактирования.");
                }
            }
        }

        private void btnDeletePub_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridView1.SelectedRows[0];
                    int publicationID = Convert.ToInt32(selectedRow.Cells["publicationid"].Value);

                    var confirmation = MessageBox.Show($"Вы уверены, что хотите удалить публикацию и связанные с ней изображения?", "Удаление публикации", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmation == DialogResult.Yes)
                    {
                        using (var conn = new NpgsqlConnection(connectionString))
                        {
                            conn.Open();

                            // Удаляем связанное изображение
                            string deleteImageQuery = "DELETE FROM publishing.images WHERE PublicationID = @PublicationID";
                            using (var cmd = new NpgsqlCommand(deleteImageQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("PublicationID", publicationID);
                                cmd.ExecuteNonQuery();
                            }

                            // Удаляем публикацию
                            string deletePublicationQuery = "DELETE FROM publishing.publications WHERE PublicationID = @PublicationID";
                            using (var cmd = new NpgsqlCommand(deletePublicationQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("PublicationID", publicationID);
                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Публикация и её изображения успешно удалены.");
                            LoadPublicationsData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите публикацию для удаления.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении публикации: " + ex.Message);
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridView1.SelectedRows[0];
                    int publicationID = Convert.ToInt32(selectedRow.Cells["publicationid"].Value);

                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();

                        string query = "SELECT ImageData FROM publishing.images WHERE PublicationID = @PublicationID LIMIT 1";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("PublicationID", publicationID);

                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    byte[] imageData = reader["ImageData"] as byte[];

                                    if (imageData != null)
                                    {
                                        using (MemoryStream ms = new MemoryStream(imageData))
                                        {
                                            pictureBox1.Image = Image.FromStream(ms);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Изображение для этой публикации не найдено.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Изображение для выбранной публикации не найдено.");
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите публикацию.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
            }
        }

        #endregion

        
    }
}
