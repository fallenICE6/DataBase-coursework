using System.Drawing;
using System.Windows.Forms;

namespace DataBaseCoursWork
{
    partial class authorization
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(authorization));
            this.rbLogin = new System.Windows.Forms.RadioButton();
            this.rbRegister = new System.Windows.Forms.RadioButton();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.btnSubmit1 = new System.Windows.Forms.Button();
            this.btnSubmit2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboRole = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbPrivatePerson = new System.Windows.Forms.RadioButton();
            this.rbOrganization = new System.Windows.Forms.RadioButton();
            this.panelPrivate = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPatronymic = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtContactDetails = new System.Windows.Forms.TextBox();
            this.panelOrganization = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOrganizationName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtContactDetailsO = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRepresentativeName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRepresentativeLastName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRepresentativeMiddleName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRepresentativeContact = new System.Windows.Forms.TextBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelPrivate.SuspendLayout();
            this.panelOrganization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // rbLogin
            // 
            this.rbLogin.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbLogin.AutoSize = true;
            this.rbLogin.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbLogin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.rbLogin.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.rbLogin.Location = new System.Drawing.Point(320, 57);
            this.rbLogin.MaximumSize = new System.Drawing.Size(170, 150);
            this.rbLogin.MinimumSize = new System.Drawing.Size(180, 25);
            this.rbLogin.Name = "rbLogin";
            this.rbLogin.Size = new System.Drawing.Size(180, 31);
            this.rbLogin.TabIndex = 0;
            this.rbLogin.TabStop = true;
            this.rbLogin.Text = "Войти";
            this.rbLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbLogin.UseVisualStyleBackColor = false;
            this.rbLogin.Click += new System.EventHandler(this.rbLogin_Click);
            // 
            // rbRegister
            // 
            this.rbRegister.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbRegister.AutoSize = true;
            this.rbRegister.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbRegister.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.rbRegister.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.rbRegister.Location = new System.Drawing.Point(151, 57);
            this.rbRegister.MaximumSize = new System.Drawing.Size(200, 150);
            this.rbRegister.MinimumSize = new System.Drawing.Size(180, 25);
            this.rbRegister.Name = "rbRegister";
            this.rbRegister.Size = new System.Drawing.Size(180, 31);
            this.rbRegister.TabIndex = 1;
            this.rbRegister.TabStop = true;
            this.rbRegister.Text = "Регистрация";
            this.rbRegister.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbRegister.UseVisualStyleBackColor = false;
            this.rbRegister.Click += new System.EventHandler(this.rbRegister_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtUsername.Location = new System.Drawing.Point(31, 167);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(300, 26);
            this.txtUsername.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label1.Location = new System.Drawing.Point(31, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Имя пользователя:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPassword.Location = new System.Drawing.Point(31, 207);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(65, 20);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Пароль:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPassword.Location = new System.Drawing.Point(31, 230);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(300, 26);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged_1);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblConfirmPassword.Location = new System.Drawing.Point(31, 267);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(179, 20);
            this.lblConfirmPassword.TabIndex = 6;
            this.lblConfirmPassword.Text = "Подтверждение пароля:";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(31, 290);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(300, 26);
            this.txtConfirmPassword.TabIndex = 7;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblRole.Location = new System.Drawing.Point(31, 338);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(166, 20);
            this.lblRole.TabIndex = 8;
            this.lblRole.Text = "Роль (Admin или User):";
            // 
            // btnSubmit1
            // 
            this.btnSubmit1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSubmit1.FlatAppearance.BorderSize = 0;
            this.btnSubmit1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSubmit1.ForeColor = System.Drawing.Color.White;
            this.btnSubmit1.Location = new System.Drawing.Point(261, 380);
            this.btnSubmit1.Name = "btnSubmit1";
            this.btnSubmit1.Size = new System.Drawing.Size(180, 45);
            this.btnSubmit1.TabIndex = 10;
            this.btnSubmit1.Text = "Войти";
            this.btnSubmit1.UseVisualStyleBackColor = false;
            this.btnSubmit1.Click += new System.EventHandler(this.btnSubmit1_Click);
            // 
            // btnSubmit2
            // 
            this.btnSubmit2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSubmit2.FlatAppearance.BorderSize = 0;
            this.btnSubmit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSubmit2.ForeColor = System.Drawing.Color.White;
            this.btnSubmit2.Location = new System.Drawing.Point(89, 418);
            this.btnSubmit2.Name = "btnSubmit2";
            this.btnSubmit2.Size = new System.Drawing.Size(180, 45);
            this.btnSubmit2.TabIndex = 11;
            this.btnSubmit2.Text = "Зарегистрироваться";
            this.btnSubmit2.UseVisualStyleBackColor = false;
            this.btnSubmit2.Click += new System.EventHandler(this.btnSubmit2_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Menu;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(197, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(290, 45);
            this.label5.TabIndex = 12;
            this.label5.Text = "АИС Издательства";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(337, 230);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(337, 230);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // comboRole
            // 
            this.comboRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboRole.FormattingEnabled = true;
            this.comboRole.Items.AddRange(new object[] {
            "Admin",
            "User"});
            this.comboRole.Location = new System.Drawing.Point(31, 371);
            this.comboRole.Name = "comboRole";
            this.comboRole.Size = new System.Drawing.Size(300, 28);
            this.comboRole.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(381, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Заполните данные о заказчике:";
            // 
            // rbPrivatePerson
            // 
            this.rbPrivatePerson.AutoSize = true;
            this.rbPrivatePerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbPrivatePerson.Location = new System.Drawing.Point(405, 135);
            this.rbPrivatePerson.Name = "rbPrivatePerson";
            this.rbPrivatePerson.Size = new System.Drawing.Size(115, 20);
            this.rbPrivatePerson.TabIndex = 18;
            this.rbPrivatePerson.TabStop = true;
            this.rbPrivatePerson.Text = "Частное лицо";
            this.rbPrivatePerson.UseVisualStyleBackColor = true;
            this.rbPrivatePerson.Click += new System.EventHandler(this.rbCustomerType_CheckedChanged);
            // 
            // rbOrganization
            // 
            this.rbOrganization.AutoSize = true;
            this.rbOrganization.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbOrganization.Location = new System.Drawing.Point(526, 135);
            this.rbOrganization.Name = "rbOrganization";
            this.rbOrganization.Size = new System.Drawing.Size(112, 20);
            this.rbOrganization.TabIndex = 19;
            this.rbOrganization.TabStop = true;
            this.rbOrganization.Text = "Организация";
            this.rbOrganization.UseVisualStyleBackColor = true;
            this.rbOrganization.Click += new System.EventHandler(this.rbCustomerType_CheckedChanged);
            // 
            // panelPrivate
            // 
            this.panelPrivate.Controls.Add(this.txtContactDetails);
            this.panelPrivate.Controls.Add(this.label7);
            this.panelPrivate.Controls.Add(this.txtPatronymic);
            this.panelPrivate.Controls.Add(this.label6);
            this.panelPrivate.Controls.Add(this.txtLastname);
            this.panelPrivate.Controls.Add(this.label4);
            this.panelPrivate.Controls.Add(this.txtFirstname);
            this.panelPrivate.Controls.Add(this.label3);
            this.panelPrivate.Location = new System.Drawing.Point(386, 158);
            this.panelPrivate.Name = "panelPrivate";
            this.panelPrivate.Size = new System.Drawing.Size(300, 218);
            this.panelPrivate.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label3.Location = new System.Drawing.Point(-1, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Имя заказчика:";
            // 
            // txtFirstname
            // 
            this.txtFirstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtFirstname.Location = new System.Drawing.Point(-1, 35);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(294, 26);
            this.txtFirstname.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label4.Location = new System.Drawing.Point(-1, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Фамилия заказчика:";
            // 
            // txtLastname
            // 
            this.txtLastname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLastname.Location = new System.Drawing.Point(-1, 87);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(294, 26);
            this.txtLastname.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label6.Location = new System.Drawing.Point(-1, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "Отчество заказчика:";
            // 
            // txtPatronymic
            // 
            this.txtPatronymic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPatronymic.Location = new System.Drawing.Point(-1, 139);
            this.txtPatronymic.Name = "txtPatronymic";
            this.txtPatronymic.Size = new System.Drawing.Size(294, 26);
            this.txtPatronymic.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label7.Location = new System.Drawing.Point(-1, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "Контактные данные:";
            // 
            // txtContactDetails
            // 
            this.txtContactDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtContactDetails.Location = new System.Drawing.Point(-1, 191);
            this.txtContactDetails.Name = "txtContactDetails";
            this.txtContactDetails.Size = new System.Drawing.Size(294, 26);
            this.txtContactDetails.TabIndex = 27;
            // 
            // panelOrganization
            // 
            this.panelOrganization.Controls.Add(this.txtRepresentativeContact);
            this.panelOrganization.Controls.Add(this.label13);
            this.panelOrganization.Controls.Add(this.txtRepresentativeMiddleName);
            this.panelOrganization.Controls.Add(this.label12);
            this.panelOrganization.Controls.Add(this.txtRepresentativeLastName);
            this.panelOrganization.Controls.Add(this.label11);
            this.panelOrganization.Controls.Add(this.txtRepresentativeName);
            this.panelOrganization.Controls.Add(this.label10);
            this.panelOrganization.Controls.Add(this.txtContactDetailsO);
            this.panelOrganization.Controls.Add(this.label9);
            this.panelOrganization.Controls.Add(this.txtOrganizationName);
            this.panelOrganization.Controls.Add(this.label8);
            this.panelOrganization.Location = new System.Drawing.Point(386, 158);
            this.panelOrganization.Name = "panelOrganization";
            this.panelOrganization.Size = new System.Drawing.Size(300, 316);
            this.panelOrganization.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label8.Location = new System.Drawing.Point(0, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 20);
            this.label8.TabIndex = 28;
            this.label8.Text = "Название организации:";
            // 
            // txtOrganizationName
            // 
            this.txtOrganizationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtOrganizationName.Location = new System.Drawing.Point(0, 28);
            this.txtOrganizationName.Name = "txtOrganizationName";
            this.txtOrganizationName.Size = new System.Drawing.Size(294, 26);
            this.txtOrganizationName.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label9.Location = new System.Drawing.Point(0, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(247, 20);
            this.label9.TabIndex = 30;
            this.label9.Text = "Контактные данные организации:";
            // 
            // txtContactDetailsO
            // 
            this.txtContactDetailsO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtContactDetailsO.Location = new System.Drawing.Point(0, 80);
            this.txtContactDetailsO.Name = "txtContactDetailsO";
            this.txtContactDetailsO.Size = new System.Drawing.Size(294, 26);
            this.txtContactDetailsO.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label10.Location = new System.Drawing.Point(-1, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 20);
            this.label10.TabIndex = 28;
            this.label10.Text = "Имя представителя:";
            // 
            // txtRepresentativeName
            // 
            this.txtRepresentativeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtRepresentativeName.Location = new System.Drawing.Point(0, 132);
            this.txtRepresentativeName.Name = "txtRepresentativeName";
            this.txtRepresentativeName.Size = new System.Drawing.Size(294, 26);
            this.txtRepresentativeName.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label11.Location = new System.Drawing.Point(-1, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(182, 20);
            this.label11.TabIndex = 33;
            this.label11.Text = "Фамилия представителя:";
            // 
            // txtRepresentativeLastName
            // 
            this.txtRepresentativeLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtRepresentativeLastName.Location = new System.Drawing.Point(0, 184);
            this.txtRepresentativeLastName.Name = "txtRepresentativeLastName";
            this.txtRepresentativeLastName.Size = new System.Drawing.Size(294, 26);
            this.txtRepresentativeLastName.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label12.Location = new System.Drawing.Point(0, 213);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(181, 20);
            this.label12.TabIndex = 35;
            this.label12.Text = "Отчество представителя:";
            // 
            // txtRepresentativeMiddleName
            // 
            this.txtRepresentativeMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtRepresentativeMiddleName.Location = new System.Drawing.Point(0, 236);
            this.txtRepresentativeMiddleName.Name = "txtRepresentativeMiddleName";
            this.txtRepresentativeMiddleName.Size = new System.Drawing.Size(294, 26);
            this.txtRepresentativeMiddleName.TabIndex = 36;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label13.Location = new System.Drawing.Point(-1, 264);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(257, 20);
            this.label13.TabIndex = 37;
            this.label13.Text = "Контактные данные представителя:";
            // 
            // txtRepresentativeContact
            // 
            this.txtRepresentativeContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtRepresentativeContact.Location = new System.Drawing.Point(0, 287);
            this.txtRepresentativeContact.Name = "txtRepresentativeContact";
            this.txtRepresentativeContact.Size = new System.Drawing.Size(294, 26);
            this.txtRepresentativeContact.TabIndex = 38;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(538, 9);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(148, 95);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 22;
            this.pictureBoxLogo.TabStop = false;
            // 
            // authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 475);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.panelOrganization);
            this.Controls.Add(this.btnSubmit1);
            this.Controls.Add(this.panelPrivate);
            this.Controls.Add(this.rbOrganization);
            this.Controls.Add(this.rbPrivatePerson);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboRole);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSubmit2);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.rbRegister);
            this.Controls.Add(this.rbLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "authorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "authorization";
            this.Load += new System.EventHandler(this.authorization_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelPrivate.ResumeLayout(false);
            this.panelPrivate.PerformLayout();
            this.panelOrganization.ResumeLayout(false);
            this.panelOrganization.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbLogin;
        private System.Windows.Forms.RadioButton rbRegister;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnSubmit1;
        private System.Windows.Forms.Button btnSubmit2;
        private System.Windows.Forms.Label label5;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ComboBox comboRole;
        private Label label2;
        private RadioButton rbPrivatePerson;
        private RadioButton rbOrganization;
        private Panel panelPrivate;
        private Label label3;
        private TextBox txtFirstname;
        private TextBox txtPatronymic;
        private Label label6;
        private TextBox txtLastname;
        private Label label4;
        private TextBox txtContactDetails;
        private Label label7;
        private Panel panelOrganization;
        private TextBox txtContactDetailsO;
        private Label label9;
        private TextBox txtOrganizationName;
        private Label label8;
        private Label label13;
        private TextBox txtRepresentativeMiddleName;
        private Label label12;
        private TextBox txtRepresentativeLastName;
        private Label label11;
        private TextBox txtRepresentativeName;
        private Label label10;
        private TextBox txtRepresentativeContact;
        private PictureBox pictureBoxLogo;
    }
}

