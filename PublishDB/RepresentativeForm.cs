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
    public partial class RepresentativeForm : Form
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; private set; }
        public string ContactDetails { get; set; }

        public RepresentativeForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FirstName = FirstNameTextBox.Text.Trim();
            LastName = LastNameTextBox.Text.Trim();
            MiddleName = MiddleNameTextBox.Text.Trim();
            ContactDetails = ContactDetailsTextBox.Text.Trim();

            // Проверяем заполненность полей
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(MiddleName) || string.IsNullOrWhiteSpace(ContactDetails))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
