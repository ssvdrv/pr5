using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormTest
{
    public partial class Form2 : Form
    {
        DataBase database = new DataBase();
        public Form2()
        {
            InitializeComponent();
        }

        private void museumBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.museumBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testingDataSet.test". При необходимости она может быть перемещена или удалена.
            this.testTableAdapter.Fill(this.testingDataSet.test);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Museum". При необходимости она может быть перемещена или удалена.
            this.museumTableAdapter.Fill(this.dataSet1.Museum);

        }

        private void testDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
            this.Show();
        }
    }
}
