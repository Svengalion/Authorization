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

namespace Forms
{
    public partial class log_in : Form
    {
        DataBase database = new DataBase();
        public log_in()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void sign_in_Load(object sender, EventArgs e)
        {

            text_password.PasswordChar = '*';
            text_password.MaxLength = 50;
            text_name.MaxLength = 50;
        }
        
        private void roundButton1_Click(object sender, EventArgs e)
        {
            var loginUser = text_name.Text;
            var passwordUser = text_password.Text;
            if (loginUser == "")
            {
                MessageBox.Show("Вы не ввели логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (passwordUser == "")
                {
                    MessageBox.Show("Вы не ввели пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    database.openConnection();

                    string querystring = $"select логин, пароль from пользователь where логин = '{loginUser}' and пароль = '{passwordUser}'";

                    SqlCommand command = new SqlCommand(querystring);
                    command.Connection = database.GetConnection();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        MessageBox.Show("Вы успешно вошли!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataBank.LoginOfUserGlobal = loginUser;
                        Successfully successfully = new Successfully();
                        successfully.Show();
                        this.Hide();
                        
                    }
                    else
                    {
                        MessageBox.Show("Такого аккаунта не существует", "Аккаунта не существует", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    database.closeConnection();
                }
            }
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            registration log_In = new registration();
            log_In.Show();
            this.Hide();
        }
    }
}
