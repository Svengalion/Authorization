using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Forms
{
    public partial class Successfully : Form
    {
        DataBase BD;

        public Successfully()
        {
            BD = new DataBase();
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Successfully_Load(object sender, EventArgs e)
        {
            lbHello.Text = $"Привет {DataBank.LoginOfUserGlobal}";
            lbHello.TextAlign = ContentAlignment.MiddleCenter;
            lbHello.AutoSize = false;
            LoadComboboc();
        }

        private void LoadComboboc()
        {
            string sql = "SELECT сеанс.Код, сеанс.НомерЗала, сеанс.дата, " +
                "сеанс.Время, фильм.Название FROM сеанс " +
                "JOIN фильм ON сеанс.Фильм = фильм.Код";
            using (SqlCommand cmd = new SqlCommand(sql, BD.sqlConnection))
            {
                cmd.CommandType = CommandType.Text;
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                comboBox1.DisplayMember = "Код";
                comboBox1.ValueMember = "Код";
                comboBox1.DataSource = table;
                dataGridView1.DataSource = table;
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            log_in sign = new log_in();
            sign.Show();
            this.Hide(); 
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            Halls halls = new Halls(Convert.ToInt32(comboBox1.SelectedValue));
            this.Hide();
            halls.Show();
        }
    }
}
