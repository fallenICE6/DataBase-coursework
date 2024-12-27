using Npgsql;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataBaseCoursWork
{
    public partial class authorization : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=your_password;Database=PublishDB";

        public authorization()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            comboRole.SelectedIndexChanged += comboRole_SelectedIndexChanged;
        }

        private void authorization_Load(object sender, EventArgs e)
        {
            rbRegister.Checked = true;
            ToggleFields();
        }

        #region [ Authorization ]
        #region fields
        // Обработчик для переключения между входом и регистрацией
        private void rbLogin_CheckedChanged(object sender, EventArgs e)
        {
            ToggleFields();
        }

        private void rbRegister_CheckedChanged(object sender, EventArgs e)
        {
            ToggleFields();
        }
        private void rbRegister_Click(object sender, EventArgs e)
        {
            ToggleFields();
        }

        private void rbLogin_Click(object sender, EventArgs e)
        {
            ToggleFields();
        }
        // Метод для переключения видимости полей
        private void ToggleFields()
        {
            if (rbLogin.Checked)
            {
                // Вход: скрываем подтверждение пароля и роль
                lblConfirmPassword.Visible = false;
                txtConfirmPassword.Visible = false;
                lblRole.Visible = false;
                comboRole.Visible = false;
                label2.Visible = false;
                rbPrivatePerson.Visible = false;
                rbOrganization.Visible = false;
                panelOrganization.Visible = false;
                panelPrivate.Visible = false;
                btnSubmit2.Visible = false;
                btnSubmit1.Visible = true;
            }
            else if (rbRegister.Checked)
            {
                // Регистрация: показываем подтверждение пароля и выбор роли
                lblConfirmPassword.Visible = true;
                txtConfirmPassword.Visible = true;
                lblRole.Visible = true;
                comboRole.Visible = true;
                // Логика для роли "User"
                if (comboRole.Text.ToLower() == "user")
                {
                    label2.Visible = true;
                    rbPrivatePerson.Visible = true;
                    rbOrganization.Visible = true;
                }
                else
                {
                    // Скрываем радио кнопки и панели для "Admin"
                    label2.Visible = false;
                    rbPrivatePerson.Visible = false;
                    rbOrganization.Visible = false;
                    panelPrivate.Visible = false;
                    panelOrganization.Visible = false;
                }

                btnSubmit1.Visible = false;
                btnSubmit2.Visible = true; // Кнопка для регистрации
            }
        }
        private void comboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRole = comboRole.Text.ToLower();
            if (selectedRole == "user")
            {
                // Показываем радиокнопки для выбора типа клиента
                label2.Visible = true;
                rbPrivatePerson.Visible = true;
                rbOrganization.Visible = true;
            }
            else
            {
                // Скрываем радиокнопки и панели, если роль не "user"
                label2.Visible = false;
                rbPrivatePerson.Visible = false;
                rbOrganization.Visible = false;

                // Скрываем панели
                panelPrivate.Visible = false;
                panelOrganization.Visible = false;
            }
        }
        private void rbCustomerType_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrivatePerson.Checked)
            {
                ShowCustomerFields("individual");
            }
            else if (rbOrganization.Checked)
            {
                ShowCustomerFields("organization");
            }
        }
        private void ShowCustomerFields(string customerType)
        {
            if (customerType == "individual")
            {
                panelOrganization.Visible = false;   
                panelPrivate.Visible = true;
                
            }
            else if (customerType == "organization")
            {
                panelPrivate.Visible = false;
                panelOrganization.Visible = true;
            }
        }
        #endregion
        // Обработчик для кнопки регистрации
        private void btnSubmit2_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string role = comboRole.Text.ToLower();
            string type = null;

            // Проверка на совпадение паролей
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Укажите имя пользователя");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Укажите пароль");
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            // Проверка на корректность ввода данных для создания заказчика (если роль не Admin)
            if (role == "user")
            {
                if (rbPrivatePerson.Checked)
                {
                    type = "individual"; // Тип заказчика - частное лицо

                    // Проверка, что все поля заполнены
                    if (string.IsNullOrWhiteSpace(txtFirstname.Text) || string.IsNullOrWhiteSpace(txtLastname.Text) || string.IsNullOrWhiteSpace(txtContactDetails.Text))
                    {
                        MessageBox.Show("Необходимо заполнить все обязательные поля для частного лица.");
                        return;
                    }
                }
                else if (rbOrganization.Checked)
                {
                    type = "organization"; // Тип заказчика - организация

                    // Проверка, что все поля заполнены для представителя
                    if (string.IsNullOrWhiteSpace(txtRepresentativeName.Text) || string.IsNullOrWhiteSpace(txtRepresentativeLastName.Text) || string.IsNullOrWhiteSpace(txtRepresentativeContact.Text))
                    {
                        MessageBox.Show("Необходимо заполнить все обязательные поля для представителя организации.");
                        return;
                    }
                }
            }
            else if (role == "admin")
            {
                // Для админа не нужно создавать заказчика
                type = "admin";
            }
            else
            {
                MessageBox.Show("Неизвестная роль пользователя");
                return;
            }

            try
            {
                // Создание представителя, если это организация
                int? customerId = null;
                if (role != "admin" && type == "organization")
                {
                    // Создание представителя сначала
                    customerId = CreateRepresentativeAndGetCustomerId();

                    if (customerId == null)
                    {
                        // Ошибка при создании представителя
                        MessageBox.Show("Ошибка при создании представителя.");
                        return;
                    }
                }

                //// Создание заказчика, если это не admin
                if (role != "admin" && type == "individual")
                {
                    customerId = CreateCustomer(type, username);

                    if (customerId == -1)
                    {
                        // Если заказчик уже существует, останавливаем дальнейшую регистрацию
                        MessageBox.Show("Ошибка: заказчик уже существует!");
                        return;
                    }
                }

                // Создание пользователя
                int userId = CreateUser(username, password, role, customerId ?? 0);

                if (userId == -1)
                {
                    // Если произошла ошибка при создании пользователя
                    MessageBox.Show("Ошибка при создании пользователя.");
                    return;
                }

                MessageBox.Show("Регистрация успешна!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при регистрации: " + ex.Message);
            }
        }
        private int? CreateRepresentativeAndGetCustomerId()
        {
            try
            {
                string repFirstname = txtRepresentativeName.Text;
                string repLastname = txtRepresentativeLastName.Text;
                string repContactDetails = txtRepresentativeContact.Text;
                string repMiddlename = txtRepresentativeMiddleName.Text;

                if (string.IsNullOrWhiteSpace(repFirstname) || string.IsNullOrWhiteSpace(repLastname) || string.IsNullOrWhiteSpace(repContactDetails))
                {
                    throw new Exception("Для представителя необходимо указать имя, фамилию и контактную информацию.");
                }

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    // Создаем заказчика (организацию)
                    string insertCustomerQuery = "INSERT INTO publishing.customers (name, type, contactdetails) " +
                                                 "VALUES (@name, 'organization', @contactdetails) RETURNING customerid";

                    int customerId;
                    using (var cmdCustomer = new NpgsqlCommand(insertCustomerQuery, conn))
                    {
                        cmdCustomer.Parameters.AddWithValue("name", txtOrganizationName.Text);
                        cmdCustomer.Parameters.AddWithValue("contactdetails", txtContactDetailsO.Text);

                        customerId = (int)cmdCustomer.ExecuteScalar(); // Получаем ID организации
                    }

                    if (customerId == 0)
                    {
                        throw new Exception("Не удалось создать заказчика.");
                    }

                    // Создаем представителя и связываем его с заказчиком
                    string insertRepQuery = "INSERT INTO publishing.representatives (customerid, firstname, lastname, middlename, contactdetails) " +
                                            "VALUES (@customerid, @firstname, @lastname, @middlename, @contactdetails) RETURNING representativeid";

                    int repId;
                    using (var cmdRep = new NpgsqlCommand(insertRepQuery, conn))
                    {
                        cmdRep.Parameters.AddWithValue("customerid", customerId);
                        cmdRep.Parameters.AddWithValue("firstname", repFirstname);
                        cmdRep.Parameters.AddWithValue("lastname", repLastname);
                        cmdRep.Parameters.AddWithValue("middlename", (object)repMiddlename ?? DBNull.Value);
                        cmdRep.Parameters.AddWithValue("contactdetails", repContactDetails);

                        repId = (int)cmdRep.ExecuteScalar(); // Получаем ID представителя
                    }

                    if (repId == 0)
                    {
                        throw new Exception("Не удалось создать представителя.");
                    }

                    // Связываем заказчика с представителем
                    string updateCustomerQuery = "UPDATE publishing.customers SET representativeid = @representativeid WHERE customerid = @customerid";
                    using (var cmdUpdate = new NpgsqlCommand(updateCustomerQuery, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("representativeid", repId);
                        cmdUpdate.Parameters.AddWithValue("customerid", customerId);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    return customerId; // Возвращаем ID заказчика
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при создании представителя и заказчика: " + ex.Message);
            }
        }
        private int? CreateCustomer(string type, string username)
        {
            // Для admin заказчик не создается
            if (type == "admin")
            {
                return null;
            }

            string name = type == "individual" ? null : txtOrganizationName.Text;  // Для частного лица имя будет null
            string contactDetails = type == "individual" ? txtContactDetails.Text : txtContactDetailsO.Text;  // Для частного лица другой контакт

            // Заполнение полей для частного лица
            string firstname = type == "individual" ? txtFirstname.Text : null;
            string lastname = type == "individual" ? txtLastname.Text : null;
            string middlename = type == "individual" ? txtPatronymic.Text : null;

            // Для организации заполняем имя организации
            string organizationName = type == "organization" ? txtOrganizationName.Text : null;

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    // Проверка на существование заказчика
                    string checkCustomerQuery = string.Empty;

                    if (type == "individual")
                    {
                        // Для частного лица проверяем по имени и фамилии
                        checkCustomerQuery = "SELECT COUNT(*) FROM publishing.customers WHERE firstname = @firstname AND lastname = @lastname AND middlename = @middlename";
                    }
                    else if (type == "organization")
                    {
                        // Для организации проверяем по имени организации
                        checkCustomerQuery = "SELECT COUNT(*) FROM publishing.customers WHERE name = @name";
                    }

                    using (var cmd = new NpgsqlCommand(checkCustomerQuery, conn))
                    {
                        // В зависимости от типа передаем нужные параметры
                        if (type == "individual")
                        {
                            cmd.Parameters.AddWithValue("firstname", firstname);
                            cmd.Parameters.AddWithValue("lastname", lastname);
                            cmd.Parameters.AddWithValue("middlename", (object)middlename ?? DBNull.Value);
                        }
                        else if (type == "organization")
                        {
                            cmd.Parameters.AddWithValue("name", organizationName);
                        }

                        var customerExists = (long)cmd.ExecuteScalar();

                        if (customerExists > 0)
                        {
                            return -1; // Возвращаем -1, чтобы показать, что заказчик уже существует
                        }
                    }

                    // Вставка данных в таблицу customers
                    string insertCustomerQuery = "INSERT INTO publishing.customers (name, type, contactdetails, firstname, lastname, middlename) " +
                                                 "VALUES (@name, @type::customer_type, @contactdetails, @firstname, @lastname, @middlename) RETURNING customerid";

                    using (var cmd = new NpgsqlCommand(insertCustomerQuery, conn))
                    {
                        // Передаем параметры в зависимости от типа заказчика
                        cmd.Parameters.AddWithValue("name", (object)name ?? DBNull.Value);  // Для частного лица null
                        cmd.Parameters.AddWithValue("type", type);  // Передаем тип как строку (individual или organization)
                        cmd.Parameters.AddWithValue("contactdetails", contactDetails);
                        cmd.Parameters.AddWithValue("firstname", (object)firstname ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("lastname", (object)lastname ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("middlename", (object)middlename ?? DBNull.Value);

                        var customerId = (int)cmd.ExecuteScalar(); // Возвращаем ID нового заказчика
                        return customerId;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при создании заказчика: " + ex.Message);
            }
        }
        private int CreateUser(string username, string password, string role, int customerId)
        {
            try
            {
                // Для роли "admin" customerId может быть NULL
                if (role.ToLower() == "admin")
                {
                    customerId = 0; // Администратор не связан с заказчиком
                }

                string checkUsernameQuery = "SELECT COUNT(*) FROM publishing.users WHERE username = @Username";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    // Преобразуем строку роли в нужный тип ENUM
                    string roleEnum = role.ToLower() == "admin" ? "admin" : "user";

                    // Если роль admin, проверяем, существует ли уже такой администратор
                    if (roleEnum == "admin")
                    {
                        // Проверка существующего администратора по имени
                        string checkAdminQuery = "SELECT COUNT(*) FROM publishing.users WHERE username = @Username AND role = 'admin'";
                        using (var cmd = new NpgsqlCommand(checkAdminQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("Username", username);
                            var adminExists = (long)cmd.ExecuteScalar();

                            if (adminExists > 0)
                            {
                                MessageBox.Show("Администратор с таким именем уже существует.");
                                return -1; // Возвращаем -1, чтобы показать, что не удалось создать администратора
                            }
                        }
                    }

                    // Вставка нового пользователя с ролью
                    string insertUserQuery = @"
            INSERT INTO publishing.users (username, password, role, customerid)
            VALUES (@Username, @Password, @Role::user_role, @CustomerId)
            RETURNING userid";

                    using (var cmd = new NpgsqlCommand(insertUserQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("Username", username);
                        cmd.Parameters.AddWithValue("Password", password);
                        cmd.Parameters.AddWithValue("Role", roleEnum); // Передаем строку (например, "admin" или "user")

                        // Передаем customerId только если это не администратор
                        cmd.Parameters.AddWithValue("CustomerId", customerId == 0 ? DBNull.Value : (object)customerId);

                        // Выполнение запроса и получение возвращаемого значения
                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            return Convert.ToInt32(result); // Возвращаем id созданного пользователя
                        }
                        else
                        {
                            MessageBox.Show("Не удалось создать пользователя.");
                            return -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании пользователя: " + ex.Message);
                return -1;
            }
        }
        #region button1
        private void btnSubmit1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                // Проверка существования пользователя
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string loginQuery = "SELECT Role, customerid FROM publishing.Users WHERE Username = @Username AND Password = @Password";
                    using (var cmd = new NpgsqlCommand(loginQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("Username", username);
                        cmd.Parameters.AddWithValue("Password", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var role = reader["Role"].ToString();
                                int customerid;

                                // Проверяем, есть ли значение для customerid
                                if (reader["customerid"] != DBNull.Value)
                                {
                                    customerid = Convert.ToInt32(reader["customerid"]);
                                }
                                else
                                {
                                    customerid = 0; // Устанавливаем по умолчанию или обрабатываем это значение, если нужно
                                }

                                OpenMainForm(role, customerid);
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при входе: " + ex.Message);
            }
        }

        #endregion
        //Метод для открытия основной формы в зависимости от роли
        #region Openmain
        private void OpenMainForm(string role, int customerid)
        {
            if (role == "admin")
            {
                AdminMainForm adminForm = new AdminMainForm();
                adminForm.Show();
            }
            else if (role == "user")
            {
                UserMainForm userForm = new UserMainForm(customerid);
                userForm.Show();
            }
            else
            {
                MessageBox.Show("Ошибка при входе!");
                return;
            }
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            string text = txtPassword.Text;
            txtPassword.Text += "1";
            txtPassword.Text = text;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            string text = txtPassword.Text;
            txtPassword.Text += "1";
            txtPassword.Text = text;
        }

        private void txtPassword_TextChanged_1(object sender, EventArgs e)
        {
            if (pictureBox2.Visible == true)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }
        #endregion
        #endregion

    }
}
