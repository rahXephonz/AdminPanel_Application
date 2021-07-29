using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proj1
{
    public partial class Panel_data : Form
    {
        public Panel_data()
        {
            InitializeComponent();
        }

        private void Label_X_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            Label_user.Text = LoginForm.username;
        }

        private void Label_X_MouseEnter(object sender, EventArgs e)
        {
            Label_X.ForeColor = Color.Cyan;
        }


    }
}
