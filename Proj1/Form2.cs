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
    public partial class SignupForm : Form
    {
        DBConnect connect = new DBConnect();
        public SignupForm()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuPanel1);
            bunifuFormDock1.SubscribeControlToDragEvents(UI_Vector2);
        }

        // Mengizinkan draggin pointer
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        // End

        // Aksi tombol klik create ke menu signup (Already have an account?)
        private void Label_signin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
        // End

        // Aksi tombol X (Silang)
        private void Label_X_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Label_X_MouseEnter(object sender, EventArgs e)
        {
            Label_X.ForeColor = Color.Cyan;
        }
        private void Label_X_MouseLeave(object sender, EventArgs e)
        {
            Label_X.ForeColor = Color.White;
        }
        // End

        // Aksi tombol klik create ke menu signin (Already have an account?)
        private void Label_signin_MouseEnter(object sender, EventArgs e)
        {
            Label_signin.ForeColor = Color.White;
        }
        private void Label_signin_MouseLeave(object sender, EventArgs e)
        {
            Label_signin.ForeColor = Color.Black;
        }

        // End

        private void Button_Signup_Click(object sender, EventArgs e)
        {
            if (Text_username.Text.Trim().Equals("") || Text_password.Text == "" || Text_email.Text == "")
            {
                // MessageBox.Show("Enter your username and password to login!", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bunifuSnackbar1.Show(this, "Enter your account information to Sign Up!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);

            }

            else if (Text_password.Text.Trim().Length < 7)
            {
                bunifuSnackbar1.Show(this, "Password too weak (Max 7 characters)", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
            }

            else 
            {
                string selectquery = "INSERT INTO `user`(`username`, `email`, `password`) VALUES (@usn, @mail, @pass)";
                MySqlCommand command = new MySqlCommand(selectquery, connect.GetConnection());

                command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = Text_username.Text;
                command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = Text_email.Text;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Text_password.Text;

                // Buka koneksi
                connect.OpenCon();

                // Jika nama user atau email sudah terdaftar di database == true maka show error
                if (Check_Username())
                {
                    bunifuSnackbar1.Show(this, "The Username Already Registered! Choose Different Username!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                }

                else if (Check_UserEmail())
                {
                    bunifuSnackbar1.Show(this, "The Email Already Registered! Choose Another One!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                }

                // Jika nama user tidak sama dengan didatabase maka user akan ditambahkan
                else
                {
                    //Eksekusi query menambahkan user akan melakukan Auto Increment
                    if (command.ExecuteNonQuery() == 1)
                    {
                        bunifuSnackbar1.Show(this, "User succesfully created!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                    }
                    else
                    {
                        bunifuSnackbar1.Show(this, "Error!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    }
                }

                // Tutup koneksi
                connect.CloseCon();
            }
        }
        // End

        // Cek jika user sudah terdaftar dan tersedia didatabase
        public Boolean Check_Username()
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string selectquery = ("SELECT * FROM `user` WHERE `username` = @usn");
            MySqlCommand command = new MySqlCommand(selectquery, connect.GetConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = Text_username.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            // Cek status jika ada username yang sudah terdaftar di database
            if (table.Rows.Count > 0) // hitung dari table 0
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public Boolean Check_UserEmail()
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string selectquery = "SELECT * FROM `user` WHERE `email` = @mail";
            MySqlCommand command = new MySqlCommand(selectquery, connect.GetConnection());
            command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = Text_email.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            // Cek status jika ada emaild yang sudah terdaftar di database
            if (table.Rows.Count > 0) // hitung dari table 0
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
