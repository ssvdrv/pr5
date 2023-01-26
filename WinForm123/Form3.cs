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
    public partial class Form3 : Form
    {
        DataBase database = new DataBase();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox_password2.PasswordChar = '*';
            textBox_login2.MaxLength = 50;
            textBox_password2.MaxLength = 50;
        }
        private void register_Click(object sender, EventArgs e)
        {
            var login = textBox_login2.Text;
            var password = textBox_password2.Text;
            string querystring = $"insert into register(login_user, password_user) values('{login}', '{password}')";
            SqlCommand command = new SqlCommand(querystring, database.GetConnection());
            database.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт создан успешно", "Успешно");
                Form2 f2 = new Form2();
                this.Hide();
                f2.ShowDialog();
                this.Show();
            } 
            else MessageBox.Show("Аккаунт не создан!");
            database.closeConnection();
        }
        private Boolean СheckUser()
        {
            var loginUser = textBox_login2.Text;
            var passUser = textBox_password2.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";
            SqlCommand command = new SqlCommand(querystring, database.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Этот пользователь уже зарегистрирован!");
                return true;
            }
            else return false;
        }
        private void clear_Click(object sender, EventArgs e)
        {
            textBox_login2.Clear();
            textBox_password2.Clear();
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
