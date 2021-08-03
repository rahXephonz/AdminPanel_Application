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
    public partial class Admindb : Form
    {
        // Panggil Koneksi
        DBConnect connect = new DBConnect();

        public void ShowData_TableProd()
        {
            // Query Database
            Data_tableprod.DataSource = connect.ShowData("SELECT * FROM `produk`");

            // Mengubah nama kolom yang ada pada page Product
            Data_tableprod.Columns[0].HeaderText = "No.";
            Data_tableprod.Columns[1].HeaderText = "Image";
            Data_tableprod.Columns[2].HeaderText = "Title";
            Data_tableprod.Columns[3].HeaderText = "Category";
            Data_tableprod.Columns[4].HeaderText = "SubCategory";
            Data_tableprod.Columns[5].HeaderText = "SuperSubCat";
            Data_tableprod.Columns[6].HeaderText = "Code";
            Data_tableprod.Columns[7].HeaderText = "Price";
        }

        public void ShowData_TableCat()
        {
            // Query Database
            Data_tablecat.DataSource = connect.ShowData("SELECT `no`, `image`, `category`, `subcategory`, `supersubcat` FROM `produk`");

            // Mengubah nama kolom yang ada pada page Category
            Data_tablecat.Columns[0].HeaderText = "No.";
            Data_tablecat.Columns[1].HeaderText = "Image";
            Data_tablecat.Columns[2].HeaderText = "Title Category";
            Data_tablecat.Columns[3].HeaderText = "Title SubCategory";
            Data_tablecat.Columns[4].HeaderText = "Title SuperSubCategory";

        }

        public Admindb()
        {
            InitializeComponent();
        }
        

        private void Admindb_Load(object sender, EventArgs e)
        {
            DateTime timeOfDayGreeting = DateTime.Now;
            Bitmap afternoon = new Bitmap("E:\\VS Project\\Proj1\\resources\\images\\afternoon.png");
            Bitmap evening = new Bitmap("E:\\VS Project\\Proj1\\resources\\images\\evening.png");
            Bitmap night = new Bitmap("E:\\VS Project\\Proj1\\resources\\images\\night.png");
            Bitmap morning = new Bitmap("E:\\VS Project\\Proj1\\resources\\images\\morning.png");

            if (timeOfDayGreeting.Hour >= 5 && timeOfDayGreeting.Hour < 10)
            {
                Image_greetings.Image = morning;
                Label_username.Text = "Good Morning! " + LoginForm.username + ".";
            }
            else if (timeOfDayGreeting.Hour >= 10 && timeOfDayGreeting.Hour < 15)
            {
                Image_greetings.Image = afternoon;
                Label_username.Text = "Good Afternoon! " + LoginForm.username + ".";
            }
            else if (timeOfDayGreeting.Hour >= 15 && timeOfDayGreeting.Hour < 18)
            {
                Image_greetings.Image = evening;
                Label_username.Text = "Good Evening! " + LoginForm.username + ".";
            }
            else
            {
                Image_greetings.Image = night;
                Label_username.Text = "Good Night! " + LoginForm.username + ".";
            }

            ShowData_TableProd();
            ShowData_TableCat();
        }

        private void Button_hide_Click(object sender, EventArgs e)
        {
            Image_greetings.Location = new System.Drawing.Point(60, 9);
            Label_username.Location = new System.Drawing.Point(102, 9);

            Button_createcat.Location = new System.Drawing.Point(889, 11);
            Button_deletecat.Location = new System.Drawing.Point(994, 11);
            Button_editcat.Location = new System.Drawing.Point(784, 11);
            Button_searchcat.Location = new System.Drawing.Point(679, 11);

            Button_createprod.Location = new System.Drawing.Point(889, 11);
            Button_deleteprod.Location = new System.Drawing.Point(994, 11);
            Button_editprod.Location = new System.Drawing.Point(784, 11);
            Button_searchprod.Location = new System.Drawing.Point(679, 11);

            Data_tableprod.Size = new Size(1089, 519);
            Data_tablecat.Size = new Size(1089, 519);
            Form_searchprod.Size = new Size(1089, 36);
            Form_searchcat.Size = new Size(1089, 36);
            Button_show.Visible = true;
            Button_hide.Visible = false;
            Logo_resize.Visible = true;
            guna2Panel1.Visible = false;
            Separator.Visible = false;
            guna2Panel1.Width = 52;
            bunifuPages1.Visible = false;
            bunifuPages1.Location = new System.Drawing.Point(52, 51);
            guna2Transition1.ShowSync(guna2Panel1);
            guna2Transition2.ShowSync(bunifuPages1);
        }

        private void Button_show_Click(object sender, EventArgs e)
        {
            Form_searchprod.Size = new Size(862, 36);
            Form_searchcat.Size = new Size(862, 36);

            Button_searchcat.Location = new System.Drawing.Point(452, 11);
            Button_createcat.Location = new System.Drawing.Point(662, 11);
            Button_deletecat.Location = new System.Drawing.Point(767, 11);
            Button_editcat.Location = new System.Drawing.Point(556, 11);

            Button_searchprod.Location = new System.Drawing.Point(452, 11);
            Button_createprod.Location = new System.Drawing.Point(662, 11);
            Button_deleteprod.Location = new System.Drawing.Point(767, 11);
            Button_editprod.Location = new System.Drawing.Point(556, 11);

            Data_tableprod.Size = new Size(860, 519);
            Data_tablecat.Size = new Size(860, 519);
            Image_greetings.Location = new System.Drawing.Point(291, 9);
            Label_username.Location = new System.Drawing.Point(335, 9);
            Logo_resize.Visible = false;
            Button_show.Visible = false;
            Button_hide.Visible = true;
            Separator.Visible = true;
            guna2Panel1.Visible = false;
            guna2Panel1.Width = 281;
            bunifuPages1.Visible = false;
            bunifuPages1.Location = new System.Drawing.Point(281, 51);
            guna2Transition1.ShowSync(guna2Panel1);
            guna2Transition2.ShowSync(bunifuPages1);
        }

        private void Button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_dashboard_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(Dashboard);
        }

        private void Button_produk_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(Product);
        }

        private void Button_kategori_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(Category);
        }

        private void Button_user_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(Users);
        }

        private void Button_settings_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(Settings);
        }

        private void Button_createprod_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(Create_Editprod);
        }

        private void Button_createcat_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(Create_Editprod);
        }
    }
}
