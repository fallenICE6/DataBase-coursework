using System.Drawing;

namespace DataBaseCoursWork
{
    partial class UserMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserMainForm));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnSearchPub = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelAdminTop = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panelAdminTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMenu.BackgroundImage")));
            this.panelMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelMenu.Controls.Add(this.btnSearchPub);
            this.panelMenu.Controls.Add(this.btnSearch);
            this.panelMenu.Controls.Add(this.btnCalculate);
            this.panelMenu.Controls.Add(this.btnCreate);
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Location = new System.Drawing.Point(0, 90);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(971, 478);
            this.panelMenu.TabIndex = 18;
            // 
            // btnSearchPub
            // 
            this.btnSearchPub.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSearchPub.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearchPub.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSearchPub.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearchPub.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSearchPub.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearchPub.Location = new System.Drawing.Point(350, 260);
            this.btnSearchPub.Name = "btnSearchPub";
            this.btnSearchPub.Size = new System.Drawing.Size(290, 65);
            this.btnSearchPub.TabIndex = 22;
            this.btnSearchPub.Text = "Найти издания";
            this.btnSearchPub.UseVisualStyleBackColor = false;
            this.btnSearchPub.Click += new System.EventHandler(this.btnSearchPub_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearch.Location = new System.Drawing.Point(350, 177);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(290, 65);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "Найти мой заказ";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCalculate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCalculate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCalculate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCalculate.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnCalculate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCalculate.Location = new System.Drawing.Point(350, 341);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(290, 65);
            this.btnCalculate.TabIndex = 20;
            this.btnCalculate.Text = "Посчитать сумму заказа";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCreate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCreate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCreate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCreate.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnCreate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCreate.Location = new System.Drawing.Point(350, 83);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(290, 65);
            this.btnCreate.TabIndex = 19;
            this.btnCreate.Text = "Сделать Заказ";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Cyan;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(253, 16);
            this.label1.MaximumSize = new System.Drawing.Size(1500, 0);
            this.label1.MinimumSize = new System.Drawing.Size(500, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(500, 34);
            this.label1.TabIndex = 18;
            this.label1.Text = "Меню:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(809, 420);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(149, 45);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Выход";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelAdminTop
            // 
            this.panelAdminTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelAdminTop.BackgroundImage")));
            this.panelAdminTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelAdminTop.Controls.Add(this.label5);
            this.panelAdminTop.Controls.Add(this.label2);
            this.panelAdminTop.Location = new System.Drawing.Point(0, 0);
            this.panelAdminTop.Name = "panelAdminTop";
            this.panelAdminTop.Size = new System.Drawing.Size(971, 90);
            this.panelAdminTop.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(328, 9);
            this.label5.MaximumSize = new System.Drawing.Size(400, 0);
            this.label5.MinimumSize = new System.Drawing.Size(290, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(366, 44);
            this.label5.TabIndex = 13;
            this.label5.Text = "АИС Издательства";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(199, 53);
            this.label2.MaximumSize = new System.Drawing.Size(1500, 0);
            this.label2.MinimumSize = new System.Drawing.Size(500, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(612, 34);
            this.label2.TabIndex = 17;
            this.label2.Text = "Добро пожаловать в наше приложение!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 567);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelAdminTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Издательство";
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelAdminTop.ResumeLayout(false);
            this.panelAdminTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelAdminTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnSearchPub;
    }
}