using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proj1
{
    public partial class LoginForm : Form
    {
        DBConnect connect = new DBConnect();
        public static string username;
        public LoginForm()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuPanel1);
            bunifuFormDock1.SubscribeControlToDragEvents(UI_Vector1);
        }

        // Mengizinkan draggin pointer
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CAPTION = 0x2;
        // End

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Pass
        }

        // Aksi dari tombol login (Next)
        private void Button_Signin_Click(object sender, EventArgs e)
        {

            // Jika ada username yang kosong dan password kosong maka menampilkan warning
            if (Text_username.Text.Trim().Equals("") || Text_password.Text == "")
            {
                // MessageBox.Show("Enter your username and password to login!", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bunifuSnackbar1.Show(this, "Enter your username and password to login!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
            }

            // Jika ada username dan password tetapi tidak matching dengan database maka menampilkan error
            else
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                string selectquery = "SELECT * FROM `user` WHERE `username` = @usn AND `password` = @pass";
                MySqlCommand command = new MySqlCommand(selectquery, connect.GetConnection());
                command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = Text_username.Text;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Text_password.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);

                // Cek status jika ada user dan password yang terdaftar jika terdaftar maka diarahkan ke panel utama
                if (table.Rows.Count > 0)
                {
                    this.Hide();
                    username = Text_username.Text;
                    Admindb adminForm = new Admindb();
                    adminForm.Show();

                }
                else
                {
                    // MessageBox.Show("Username and Password not registered yet!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bunifuSnackbar1.Show(this, "Username and Password not registered yet!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                }
            }
        }
        // End

        // Aksi tombol klik create ke menu signup (Didnt have an account?)
        private void Label_create_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignupForm signupForm = new SignupForm();
            signupForm.Show();
        }
        private void Label_create_MouseEnter(object sender, EventArgs e)
        {
            Label_create.ForeColor = Color.Cyan;
        }
        private void Label_create_MouseLeave(object sender, EventArgs e)
        {
            Label_create.ForeColor = Color.White;
        }
        // End

        // Aksi tombol X (Silang)
        private void Label_X_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Label_X_MouseEnter(object sender, EventArgs e)
        {
            Label_X.ForeColor = Color.White;
        }
        private void Label_X_MouseLeave(object sender, EventArgs e)
        {
            Label_X.ForeColor = Color.Black;
        }

        // End

        // Event Handler Tampilkan Password 
        private void Show_pass_CheckedChanged(object sender, EventArgs e)
        {
            if (Show_pass.Checked)
            {
                Text_password.PasswordChar = default;
            }
            else
            {
                Text_password.PasswordChar = '●';
            }
        }

        // End
    }
}
