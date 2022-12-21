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
    public partial class Halls : Form
    {
        
        MakeButtonsInHall MakeButtonsInHall;
        public Halls(int s)
        {
            StartPosition = FormStartPosition.CenterScreen;
            MakeButtonsInHall = new MakeButtonsInHall(s);
            InitializeComponent();
            this.Controls.Add(MakeButtonsInHall);
        }

        private void Halls_Load(object sender, EventArgs e)
        {
            
        }
    }
}
