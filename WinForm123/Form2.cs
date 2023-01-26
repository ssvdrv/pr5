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

namespace WinForm123
{
    public partial class Form2 : Form
    {
        DataBase database = new DataBase();
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox_password1.PasswordChar = '*';
            textBox_login1.MaxLength = 50;
            textBox_password1.MaxLength = 50;
        }
        private void enter_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_login1.Text;
            var passUser = textBox_password1.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";
            SqlCommand command = new SqlCommand(querystring, database.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Успешный вход", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 f1 = new Form1();
                this.Hide();
                f1.ShowDialog();
                this.Show();
            }
            else MessageBox.Show("Такого аккаунта нет", "Аккаунта нет", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void clear_Click(object sender, EventArgs e)
        {
            textBox_login1.Clear();
            textBox_password1.Clear();
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
