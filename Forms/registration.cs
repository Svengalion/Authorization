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
using System.Security.Cryptography.X509Certificates;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Forms
{
    public partial class registration : Form
    {
        DataBase database = new DataBase();
        public registration()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void log_in_Load(object sender, EventArgs e)
        {
            text_password.MaxLength = 50;
            text_login.MaxLength = 50;

        }
        private void roundButton1_Click(object sender, EventArgs e)
        {
            var loginUser = text_login.Text;
            var passwordUser = text_password.Text;
            var name = textBox_name.Text;
            var surname = textBox_surname.Text;
            var seconDname = textBox_secondname.Text;
            var birthDay = tB_DatofBirth.Text;
            var discount = 0;
            DateTime date = new DateTime();
            date = DateTime.Parse(birthDay);
            if (textBox_secondname.Text == "")
            {
                MessageBox.Show("Вы не указали Отчество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox_surname.Text == "")
                {
                    MessageBox.Show("Вы не указали фамилию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (textBox_name.Text == "")
                    {
                        MessageBox.Show("Вы не указали имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (text_password.Text == "")
                        {
                            MessageBox.Show("Вы не указали пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (text_login.Text == "")
                            {
                                MessageBox.Show("Вы не указали логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            if(CheckAccauntInDataBase(loginUser) == true)
                            {
                                MessageBox.Show("Такая почта уже зарегистрированна", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                if (date<DateTime.Now)
                                {
                                    database.openConnection();

                                    string querystring = $"insert into пользователь values('{surname}', '{name}', '{seconDname}', '{birthDay}', {discount}, '{loginUser}', '{passwordUser}');";

                                    SqlCommand command = new SqlCommand(querystring);
                                    command.Connection = database.GetConnection();
                                    if (command.ExecuteNonQuery() == 1)
                                    {
                                        MessageBox.Show("Вы создали аккаунт", "Аккаунта добавлен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        DataBank.LoginOfUserGlobal = loginUser;
                                        Successfully successfully = new Successfully();
                                        successfully.Show();
                                        this.Hide();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Что-то не так", "Аккаунт не создан", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Дата введена неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
            }
            database.closeConnection();
        }
        public Boolean CheckAccauntInDataBase(string CheckLoginUser)
        {
            string querystring = $"select логин from пользователь where логин = '{CheckLoginUser}'";

            SqlCommand command = new SqlCommand(querystring);
            command.Connection = database.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
