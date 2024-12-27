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
    public partial class UserMainForm : Form
    {
        private int customerID;
        public UserMainForm(int customerid)
        {
            InitializeComponent();
            this.customerID = customerid;
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateOrderForm createOrderForm = new CreateOrderForm(customerID);
            createOrderForm.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ViewOrdersForm viewOrdersForm = new ViewOrdersForm(customerID);
            viewOrdersForm.Show();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateFrom calculateFrom = new CalculateFrom();
            calculateFrom.Show();
        }

        private void btnSearchPub_Click(object sender, EventArgs e)
        {
            ViewPubForm viewPubForm = new ViewPubForm();
            viewPubForm.Show();
        }
    }
}
