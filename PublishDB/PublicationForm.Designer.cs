namespace DataBaseCoursWork
{
    partial class PublicationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PublicationForm));
            this.btnSaveAuthor = new System.Windows.Forms.Button();
            this.panelAdminTop = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonExistingAuthor = new System.Windows.Forms.RadioButton();
            this.radioButtonNewAuthor = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.labelContactDetails = new System.Windows.Forms.Label();
            this.textBoxContactDetails = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labeltitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxImageType = new System.Windows.Forms.ComboBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.labelMiddleName = new System.Windows.Forms.Label();
            this.textBoxMiddleName = new System.Windows.Forms.TextBox();
            this.checkedListBoxAuthors = new System.Windows.Forms.CheckedListBox();
            this.btnAddNewAuthor = new System.Windows.Forms.Button();
            this.flowLayoutPanelImages = new System.Windows.Forms.FlowLayoutPanel();
            this.panelAdminTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveAuthor
            // 
            this.btnSaveAuthor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSaveAuthor.FlatAppearance.BorderSize = 0;
            this.btnSaveAuthor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAuthor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSaveAuthor.ForeColor = System.Drawing.Color.White;
            this.btnSaveAuthor.Location = new System.Drawing.Point(303, 445);
            this.btnSaveAuthor.Name = "btnSaveAuthor";
            this.btnSaveAuthor.Size = new System.Drawing.Size(210, 45);
            this.btnSaveAuthor.TabIndex = 34;
            this.btnSaveAuthor.Text = "Загрузить материалы";
            this.btnSaveAuthor.UseVisualStyleBackColor = false;
            this.btnSaveAuthor.Click += new System.EventHandler(this.btnSaveAuthor_Click);
            // 
            // panelAdminTop
            // 
            this.panelAdminTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelAdminTop.BackgroundImage")));
            this.panelAdminTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelAdminTop.Controls.Add(this.label5);
            this.panelAdminTop.Location = new System.Drawing.Point(0, 0);
            this.panelAdminTop.Name = "panelAdminTop";
            this.panelAdminTop.Size = new System.Drawing.Size(802, 75);
            this.panelAdminTop.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(245, 22);
            this.label5.MaximumSize = new System.Drawing.Size(400, 0);
            this.label5.MinimumSize = new System.Drawing.Size(290, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(366, 44);
            this.label5.TabIndex = 13;
            this.label5.Text = "АИС Издательства";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.Location = new System.Drawing.Point(574, 255);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(223, 263);
            this.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCover.TabIndex = 1;
            this.pictureBoxCover.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 78);
            this.label2.MaximumSize = new System.Drawing.Size(1500, 0);
            this.label2.MinimumSize = new System.Drawing.Size(800, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(800, 24);
            this.label2.TabIndex = 26;
            this.label2.Text = "Укажите данные:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioButtonExistingAuthor
            // 
            this.radioButtonExistingAuthor.AutoSize = true;
            this.radioButtonExistingAuthor.BackColor = System.Drawing.Color.LightSkyBlue;
            this.radioButtonExistingAuthor.Checked = true;
            this.radioButtonExistingAuthor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonExistingAuthor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.radioButtonExistingAuthor.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.radioButtonExistingAuthor.Location = new System.Drawing.Point(6, 119);
            this.radioButtonExistingAuthor.MaximumSize = new System.Drawing.Size(500, 150);
            this.radioButtonExistingAuthor.MinimumSize = new System.Drawing.Size(180, 25);
            this.radioButtonExistingAuthor.Name = "radioButtonExistingAuthor";
            this.radioButtonExistingAuthor.Size = new System.Drawing.Size(219, 25);
            this.radioButtonExistingAuthor.TabIndex = 37;
            this.radioButtonExistingAuthor.TabStop = true;
            this.radioButtonExistingAuthor.Text = "Я уже являюсь автором";
            this.radioButtonExistingAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonExistingAuthor.UseVisualStyleBackColor = false;
            // 
            // radioButtonNewAuthor
            // 
            this.radioButtonNewAuthor.AutoSize = true;
            this.radioButtonNewAuthor.BackColor = System.Drawing.Color.LightSkyBlue;
            this.radioButtonNewAuthor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonNewAuthor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.radioButtonNewAuthor.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.radioButtonNewAuthor.Location = new System.Drawing.Point(6, 150);
            this.radioButtonNewAuthor.MaximumSize = new System.Drawing.Size(500, 150);
            this.radioButtonNewAuthor.MinimumSize = new System.Drawing.Size(180, 25);
            this.radioButtonNewAuthor.Name = "radioButtonNewAuthor";
            this.radioButtonNewAuthor.Size = new System.Drawing.Size(180, 25);
            this.radioButtonNewAuthor.TabIndex = 38;
            this.radioButtonNewAuthor.Text = "Я новый автор";
            this.radioButtonNewAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonNewAuthor.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label1.Location = new System.Drawing.Point(2, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "Укажите свое имя:";
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelLastName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelLastName.Location = new System.Drawing.Point(2, 260);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(181, 20);
            this.labelLastName.TabIndex = 41;
            this.labelLastName.Text = "Укажите свою фамилию:";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFirstName.Location = new System.Drawing.Point(0, 219);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(225, 26);
            this.textBoxFirstName.TabIndex = 42;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLastName.Location = new System.Drawing.Point(0, 283);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(225, 26);
            this.textBoxLastName.TabIndex = 43;
            // 
            // labelContactDetails
            // 
            this.labelContactDetails.AutoSize = true;
            this.labelContactDetails.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelContactDetails.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelContactDetails.Location = new System.Drawing.Point(2, 380);
            this.labelContactDetails.MaximumSize = new System.Drawing.Size(250, 0);
            this.labelContactDetails.Name = "labelContactDetails";
            this.labelContactDetails.Size = new System.Drawing.Size(249, 40);
            this.labelContactDetails.TabIndex = 44;
            this.labelContactDetails.Text = "Оставьте свои контактные данные (email, телефон и т. д.):";
            // 
            // textBoxContactDetails
            // 
            this.textBoxContactDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxContactDetails.Location = new System.Drawing.Point(0, 423);
            this.textBoxContactDetails.Name = "textBoxContactDetails";
            this.textBoxContactDetails.Size = new System.Drawing.Size(225, 26);
            this.textBoxContactDetails.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Gainsboro;
            this.label8.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(258, 117);
            this.label8.MaximumSize = new System.Drawing.Size(1500, 0);
            this.label8.MinimumSize = new System.Drawing.Size(250, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(320, 24);
            this.label8.TabIndex = 46;
            this.label8.Text = "Материалы для публикации:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labeltitle
            // 
            this.labeltitle.AutoSize = true;
            this.labeltitle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.labeltitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labeltitle.Location = new System.Drawing.Point(312, 150);
            this.labeltitle.Name = "labeltitle";
            this.labeltitle.Size = new System.Drawing.Size(228, 20);
            this.labeltitle.TabIndex = 47;
            this.labeltitle.Text = "Укажите название публикации:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTitle.Location = new System.Drawing.Point(315, 173);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(225, 26);
            this.textBoxTitle.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label3.Location = new System.Drawing.Point(393, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 49;
            this.label3.Text = "Тираж:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(315, 242);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(225, 26);
            this.textBox2.TabIndex = 50;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label4.Location = new System.Drawing.Point(299, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(253, 20);
            this.label4.TabIndex = 51;
            this.label4.Text = "Объем издания в печатных листах:";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(315, 312);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(225, 26);
            this.textBox3.TabIndex = 52;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label6.Location = new System.Drawing.Point(588, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(209, 20);
            this.label6.TabIndex = 53;
            this.label6.Text = "Выберите тип изображения:";
            // 
            // comboBoxImageType
            // 
            this.comboBoxImageType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxImageType.FormattingEnabled = true;
            this.comboBoxImageType.Location = new System.Drawing.Point(592, 175);
            this.comboBoxImageType.Name = "comboBoxImageType";
            this.comboBoxImageType.Size = new System.Drawing.Size(196, 28);
            this.comboBoxImageType.TabIndex = 56;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLoadImage.FlatAppearance.BorderSize = 0;
            this.btnLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLoadImage.ForeColor = System.Drawing.Color.White;
            this.btnLoadImage.Location = new System.Drawing.Point(614, 214);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(156, 35);
            this.btnLoadImage.TabIndex = 57;
            this.btnLoadImage.Text = "Загрузить макет:";
            this.btnLoadImage.UseVisualStyleBackColor = false;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // labelMiddleName
            // 
            this.labelMiddleName.AutoSize = true;
            this.labelMiddleName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelMiddleName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelMiddleName.Location = new System.Drawing.Point(2, 318);
            this.labelMiddleName.Name = "labelMiddleName";
            this.labelMiddleName.Size = new System.Drawing.Size(171, 20);
            this.labelMiddleName.TabIndex = 58;
            this.labelMiddleName.Text = "Укажите свое отчество:";
            // 
            // textBoxMiddleName
            // 
            this.textBoxMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMiddleName.Location = new System.Drawing.Point(0, 341);
            this.textBoxMiddleName.Name = "textBoxMiddleName";
            this.textBoxMiddleName.Size = new System.Drawing.Size(225, 26);
            this.textBoxMiddleName.TabIndex = 59;
            // 
            // checkedListBoxAuthors
            // 
            this.checkedListBoxAuthors.FormattingEnabled = true;
            this.checkedListBoxAuthors.Location = new System.Drawing.Point(6, 196);
            this.checkedListBoxAuthors.Name = "checkedListBoxAuthors";
            this.checkedListBoxAuthors.Size = new System.Drawing.Size(225, 244);
            this.checkedListBoxAuthors.TabIndex = 60;
            // 
            // btnAddNewAuthor
            // 
            this.btnAddNewAuthor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAddNewAuthor.FlatAppearance.BorderSize = 0;
            this.btnAddNewAuthor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewAuthor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddNewAuthor.ForeColor = System.Drawing.Color.White;
            this.btnAddNewAuthor.Location = new System.Drawing.Point(0, 455);
            this.btnAddNewAuthor.Name = "btnAddNewAuthor";
            this.btnAddNewAuthor.Size = new System.Drawing.Size(210, 45);
            this.btnAddNewAuthor.TabIndex = 61;
            this.btnAddNewAuthor.Text = "Добавить автора";
            this.btnAddNewAuthor.UseVisualStyleBackColor = false;
            this.btnAddNewAuthor.Click += new System.EventHandler(this.btnAddNewAuthor_Click);
            // 
            // flowLayoutPanelImages
            // 
            this.flowLayoutPanelImages.Location = new System.Drawing.Point(574, 255);
            this.flowLayoutPanelImages.Name = "flowLayoutPanelImages";
            this.flowLayoutPanelImages.Size = new System.Drawing.Size(223, 263);
            this.flowLayoutPanelImages.TabIndex = 62;
            // 
            // PublicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.flowLayoutPanelImages);
            this.Controls.Add(this.btnAddNewAuthor);
            this.Controls.Add(this.checkedListBoxAuthors);
            this.Controls.Add(this.textBoxMiddleName);
            this.Controls.Add(this.labelMiddleName);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.comboBoxImageType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.labeltitle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxContactDetails);
            this.Controls.Add(this.labelContactDetails);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonNewAuthor);
            this.Controls.Add(this.radioButtonExistingAuthor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelAdminTop);
            this.Controls.Add(this.btnSaveAuthor);
            this.Controls.Add(this.pictureBoxCover);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PublicationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3/3 Загрузка материалов";
            this.panelAdminTop.ResumeLayout(false);
            this.panelAdminTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.Button btnSaveAuthor;
        private System.Windows.Forms.Panel panelAdminTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonExistingAuthor;
        private System.Windows.Forms.RadioButton radioButtonNewAuthor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label labelContactDetails;
        private System.Windows.Forms.TextBox textBoxContactDetails;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labeltitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxImageType;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Label labelMiddleName;
        private System.Windows.Forms.TextBox textBoxMiddleName;
        private System.Windows.Forms.CheckedListBox checkedListBoxAuthors;
        private System.Windows.Forms.Button btnAddNewAuthor;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelImages;
    }
}