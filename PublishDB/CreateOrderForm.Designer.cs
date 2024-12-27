namespace DataBaseCoursWork
{
    partial class CreateOrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateOrderForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContactDetails = new System.Windows.Forms.TextBox();
            this.comboBoxProductType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOrgName = new System.Windows.Forms.TextBox();
            this.txtRepresentativeContact = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.panelAdminTop = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panelPrivate = new System.Windows.Forms.Panel();
            this.txtCustomerMiddleName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCustomerLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelOrganize = new System.Windows.Forms.Panel();
            this.txtRepresentativeName = new System.Windows.Forms.TextBox();
            this.txtOrgContact = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panelAdminTop.SuspendLayout();
            this.panelPrivate.SuspendLayout();
            this.panelOrganize.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(342, 600);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(149, 45);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(2, 600);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(149, 45);
            this.btnNext.TabIndex = 19;
            this.btnNext.Text = "Далее";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 102);
            this.label2.MaximumSize = new System.Drawing.Size(1500, 0);
            this.label2.MinimumSize = new System.Drawing.Size(500, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(500, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "Проверьте свои данные:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Имя заказчика:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCustomerName.Location = new System.Drawing.Point(3, 34);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(300, 26);
            this.txtCustomerName.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label4.Location = new System.Drawing.Point(3, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Контактная информация заказчика:";
            // 
            // txtContactDetails
            // 
            this.txtContactDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtContactDetails.Location = new System.Drawing.Point(3, 190);
            this.txtContactDetails.Name = "txtContactDetails";
            this.txtContactDetails.Size = new System.Drawing.Size(300, 26);
            this.txtContactDetails.TabIndex = 25;
            // 
            // comboBoxProductType
            // 
            this.comboBoxProductType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxProductType.FormattingEnabled = true;
            this.comboBoxProductType.Location = new System.Drawing.Point(9, 435);
            this.comboBoxProductType.Name = "comboBoxProductType";
            this.comboBoxProductType.Size = new System.Drawing.Size(300, 28);
            this.comboBoxProductType.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label6.Location = new System.Drawing.Point(12, 412);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Выберите тип продукции:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Gainsboro;
            this.label8.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(3, 376);
            this.label8.MaximumSize = new System.Drawing.Size(1500, 0);
            this.label8.MinimumSize = new System.Drawing.Size(500, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(500, 24);
            this.label8.TabIndex = 31;
            this.label8.Text = "Заполните данные о заказе:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label7.Location = new System.Drawing.Point(168, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 20);
            this.label7.TabIndex = 32;
            this.label7.Text = "Фио представителя:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label10.Location = new System.Drawing.Point(111, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(257, 20);
            this.label10.TabIndex = 34;
            this.label10.Text = "Контактные данные представителя:";
            // 
            // txtOrgName
            // 
            this.txtOrgName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtOrgName.Location = new System.Drawing.Point(7, 34);
            this.txtOrgName.Name = "txtOrgName";
            this.txtOrgName.Size = new System.Drawing.Size(482, 26);
            this.txtOrgName.TabIndex = 36;
            this.txtOrgName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRepresentativeContact
            // 
            this.txtRepresentativeContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtRepresentativeContact.Location = new System.Drawing.Point(7, 190);
            this.txtRepresentativeContact.Name = "txtRepresentativeContact";
            this.txtRepresentativeContact.Size = new System.Drawing.Size(482, 26);
            this.txtRepresentativeContact.TabIndex = 37;
            this.txtRepresentativeContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label11.Location = new System.Drawing.Point(12, 487);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(173, 20);
            this.label11.TabIndex = 38;
            this.label11.Text = "Количество продукции:";
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownQuantity.Location = new System.Drawing.Point(12, 510);
            this.numericUpDownQuantity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(169, 26);
            this.numericUpDownQuantity.TabIndex = 40;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label12.Location = new System.Drawing.Point(329, 487);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 20);
            this.label12.TabIndex = 41;
            this.label12.Text = " Объем в листах:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown1.Location = new System.Drawing.Point(322, 510);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(169, 26);
            this.numericUpDown1.TabIndex = 42;
            // 
            // panelAdminTop
            // 
            this.panelAdminTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelAdminTop.BackgroundImage")));
            this.panelAdminTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelAdminTop.Controls.Add(this.label5);
            this.panelAdminTop.Location = new System.Drawing.Point(0, 0);
            this.panelAdminTop.Name = "panelAdminTop";
            this.panelAdminTop.Size = new System.Drawing.Size(503, 99);
            this.panelAdminTop.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(88, 9);
            this.label5.MaximumSize = new System.Drawing.Size(400, 0);
            this.label5.MinimumSize = new System.Drawing.Size(290, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(366, 44);
            this.label5.TabIndex = 13;
            this.label5.Text = "АИС Издательства";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPrivate
            // 
            this.panelPrivate.Controls.Add(this.txtCustomerMiddleName);
            this.panelPrivate.Controls.Add(this.txtContactDetails);
            this.panelPrivate.Controls.Add(this.label13);
            this.panelPrivate.Controls.Add(this.txtCustomerLastName);
            this.panelPrivate.Controls.Add(this.label3);
            this.panelPrivate.Controls.Add(this.label1);
            this.panelPrivate.Controls.Add(this.txtCustomerName);
            this.panelPrivate.Controls.Add(this.label4);
            this.panelPrivate.Location = new System.Drawing.Point(7, 127);
            this.panelPrivate.Name = "panelPrivate";
            this.panelPrivate.Size = new System.Drawing.Size(501, 243);
            this.panelPrivate.TabIndex = 43;
            // 
            // txtCustomerMiddleName
            // 
            this.txtCustomerMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCustomerMiddleName.Location = new System.Drawing.Point(3, 138);
            this.txtCustomerMiddleName.Name = "txtCustomerMiddleName";
            this.txtCustomerMiddleName.Size = new System.Drawing.Size(300, 26);
            this.txtCustomerMiddleName.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label13.Location = new System.Drawing.Point(3, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(148, 20);
            this.label13.TabIndex = 25;
            this.label13.Text = "Отчество заказчика:";
            // 
            // txtCustomerLastName
            // 
            this.txtCustomerLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCustomerLastName.Location = new System.Drawing.Point(3, 86);
            this.txtCustomerLastName.Name = "txtCustomerLastName";
            this.txtCustomerLastName.Size = new System.Drawing.Size(300, 26);
            this.txtCustomerLastName.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Фамилия заказчика:";
            // 
            // panelOrganize
            // 
            this.panelOrganize.Controls.Add(this.txtRepresentativeName);
            this.panelOrganize.Controls.Add(this.txtOrgContact);
            this.panelOrganize.Controls.Add(this.label15);
            this.panelOrganize.Controls.Add(this.label14);
            this.panelOrganize.Controls.Add(this.txtOrgName);
            this.panelOrganize.Controls.Add(this.txtRepresentativeContact);
            this.panelOrganize.Controls.Add(this.label7);
            this.panelOrganize.Controls.Add(this.label10);
            this.panelOrganize.Location = new System.Drawing.Point(7, 130);
            this.panelOrganize.Name = "panelOrganize";
            this.panelOrganize.Size = new System.Drawing.Size(501, 243);
            this.panelOrganize.TabIndex = 44;
            // 
            // txtRepresentativeName
            // 
            this.txtRepresentativeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtRepresentativeName.Location = new System.Drawing.Point(7, 138);
            this.txtRepresentativeName.Name = "txtRepresentativeName";
            this.txtRepresentativeName.Size = new System.Drawing.Size(482, 26);
            this.txtRepresentativeName.TabIndex = 47;
            this.txtRepresentativeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtOrgContact
            // 
            this.txtOrgContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtOrgContact.Location = new System.Drawing.Point(7, 86);
            this.txtOrgContact.Name = "txtOrgContact";
            this.txtOrgContact.Size = new System.Drawing.Size(482, 26);
            this.txtOrgContact.TabIndex = 46;
            this.txtOrgContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label15.Location = new System.Drawing.Point(111, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(247, 20);
            this.label15.TabIndex = 45;
            this.label15.Text = "Контактные данные организации:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label14.Location = new System.Drawing.Point(168, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(138, 20);
            this.label14.TabIndex = 44;
            this.label14.Text = "Имя организации:";
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 657);
            this.Controls.Add(this.panelPrivate);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.panelOrganize);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxProductType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panelAdminTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "1/3 Создание заказа";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panelAdminTop.ResumeLayout(false);
            this.panelAdminTop.PerformLayout();
            this.panelPrivate.ResumeLayout(false);
            this.panelPrivate.PerformLayout();
            this.panelOrganize.ResumeLayout(false);
            this.panelOrganize.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelAdminTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContactDetails;
        private System.Windows.Forms.ComboBox comboBoxProductType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtOrgName;
        private System.Windows.Forms.TextBox txtRepresentativeContact;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Panel panelPrivate;
        private System.Windows.Forms.TextBox txtCustomerMiddleName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCustomerLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelOrganize;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRepresentativeName;
        private System.Windows.Forms.TextBox txtOrgContact;
        private System.Windows.Forms.Label label15;
    }
}