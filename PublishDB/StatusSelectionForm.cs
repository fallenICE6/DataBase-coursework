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
    public partial class StatusSelectionForm : Form
    {
        public string SelectedStatus { get; private set; }

        public StatusSelectionForm(List<string> availableStatuses, string currentStatus)
        {
            InitializeComponent();

            // Добавляем доступные статусы в ComboBox
            comboBoxStatuses.DataSource = availableStatuses;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Получаем выбранный статус
            SelectedStatus = comboBoxStatuses.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Если отмена, то просто закрываем форму
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
