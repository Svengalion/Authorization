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
using System.Runtime.CompilerServices;
using System.Drawing.Drawing2D;

namespace Forms
{
    public partial class Form1 : Form
    {
        DataBase database = new DataBase();
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void roundButton1_Click(object sender, EventArgs e)
        {
            log_in sign = new log_in();
            sign.Show();
            this.Hide();
        }
        private void roundButton2_Click(object sender, EventArgs e)
        {
            registration log = new registration();
            log.Show();
            this.Hide();
        }
    }
}
