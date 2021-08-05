using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Proj1
{
    public partial class Admindb : Form
    {

        // Panggil Koneksi
        DBConnect connect = new DBConnect();
        
        public Admindb()
        {
            InitializeComponent();
        }

        private void ShowData_Product()
        {
            string query = "SELECT * FROM `produk`";
            MySqlCommand command = new MySqlCommand(query, connect.GetConnection());
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = command;
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataTable.Columns.Add("Picture", Type.GetType("System.Byte[]"));

            foreach (DataRow row in dataTable.Rows)
            {
                row["Picture"] = File.ReadAllBytes(Application.StartupPath + @"\Image\" + Path.GetFileName(row["Image"].ToString()));
            }
            Data_tableprod.DataSource = dataTable;
        }

        private void ShowData_Category()
        {
            string query = "SELECT `No`, `Category`, `SubCategory`, `SuperSubCat`, `Image` FROM `produk`";
            MySqlCommand command = new MySqlCommand(query, connect.GetConnection());
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = command;
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataTable.Columns.Add("Picture", Type.GetType("System.Byte[]"));

            foreach (DataRow row in dataTable.Rows)
            {
                row["Picture"] = File.ReadAllBytes(Application.StartupPath + @"\Image\" + Path.GetFileName(row["Image"].ToString()));
            }
            Data_tablecat.DataSource = dataTable;
        }

        private void EmptyData()
        {
            Form_no.Text = "";
            Insert_image.Image = null;
            Form_tittle.Text = "";
            Form_category.Text = "";
            Form_subcategory.Text = "";
            Form_supersubcat.Text = "";
            Form_code.Text = "";
            Form_price.Text = "";
        }

        private void ShowTime()
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
        }

        private void Admindb_Load(object sender, EventArgs e)
        {
            ShowTime();
            ShowData_Product();
            ShowData_Category();
            timer1.Start();
        }

        private void Button_hide_Click(object sender, EventArgs e)
        {
            Image_greetings.Location = new System.Drawing.Point(60, 9);
            Label_username.Location = new System.Drawing.Point(102, 9);
            Button_createprod.Location = new System.Drawing.Point(994, 11);
            Button_editprod.Location = new System.Drawing.Point(889, 11);
            Separator_cat.Size = new Size(1080, 10);
            Data_tableprod.Size = new Size(1089, 519);
            Data_tablecat.Size = new Size(1089, 700);
            Form_searchprod.Size = new Size(1089, 36);
            Button_show.Visible = true;
            Button_hide.Visible = false;
            Logo_resize.Visible = true;
            guna2Panel1.Visible = false;
            bunifuPages1.Visible = false;
            Separator.Visible = false;
            guna2Panel1.Width = 52;
            bunifuPages1.Location = new System.Drawing.Point(52, 51);
            guna2Transition1.ShowSync(guna2Panel1);
            guna2Transition2.ShowSync(bunifuPages1);
        }

        private void Button_show_Click(object sender, EventArgs e)
        {
            Form_searchprod.Size = new Size(862, 36);
            Button_createprod.Location = new System.Drawing.Point(767, 11);
            Button_editprod.Location = new System.Drawing.Point(662, 11);
            Separator_cat.Size = new Size(850, 10);
            Data_tableprod.Size = new Size(860, 519);
            Data_tablecat.Size = new Size(860, 700);
            Image_greetings.Location = new System.Drawing.Point(291, 9);
            Label_username.Location = new System.Drawing.Point(335, 9);
            Logo_resize.Visible = false;
            Button_show.Visible = false;
            Button_hide.Visible = true;
            Separator.Visible = true;
            guna2Panel1.Visible = false;
            bunifuPages1.Visible = false;
            guna2Panel1.Width = 281;
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

        private void Button_editprod_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(Create_Editprod);
        }

        private void Button_editcat_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(Create_Editprod);
        }


        private void Button_save_Click(object sender, EventArgs e)
        {
            if(ImageText.Text == "" || Form_tittle.Text == "" || Form_category.Text == "" || Form_subcategory.Text == "" || Form_supersubcat.Text == "" || Form_code.Text == "" || Form_price.Text == "")
            {
                bunifuSnackbar1.Show(this, "Data cannot be empty! Please enter a valid data", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
            }

            else
            {
                // Eksekusi query insert
                string query = "INSERT INTO `produk`(`Title`, `Category`, `SubCategory`, `SuperSubCat`, `Code`, `Price`, `Image`) VALUES ('" + this.Form_tittle.Text + "', '" + this.Form_category.Text + "', '" + this.Form_subcategory.Text + "', '" + this.Form_supersubcat.Text + "', '" + this.Form_code.Text + "', '" + this.Form_price.Text + "', '" + Path.GetFileName(Insert_image.ImageLocation) + "')";
                MySqlCommand command = new MySqlCommand(query, connect.GetConnection());
                MySqlDataReader datareader;
                connect.OpenCon();
                datareader = command.ExecuteReader();
                bunifuSnackbar1.Show(this, "Data Succesfully Added!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                connect.CloseCon();
                File.Copy(ImageText.Text, Application.StartupPath + @"\Image\" + Path.GetFileName(Insert_image.ImageLocation));

                ShowData_Product();
                ShowData_Category();
                EmptyData();
                bunifuPages1.SetPage(Product);
            }
        }

        private void Button_update_Click(object sender, EventArgs e)
        {
            if (ImageText.Text == "" || Form_tittle.Text == "" || Form_category.Text == "" || Form_subcategory.Text == "" || Form_supersubcat.Text == "" || Form_code.Text == "" || Form_price.Text == "")
            {
                bunifuSnackbar1.Show(this, "Data cannot be empty! Please enter a valid data", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                // Eksekusi query update
                string query = "UPDATE `produk` SET `Title` = '" + this.Form_tittle.Text + "', `Category` = '" + this.Form_category.Text + "', `SubCategory` = '" + this.Form_subcategory.Text + "', `SuperSubCat` = '" + this.Form_supersubcat.Text + "', `Code` = '" + this.Form_code.Text + "', `Price` = '" + this.Form_price.Text + "' WHERE `No` = '" + this.Form_no.Text + "'";
                MySqlCommand command = new MySqlCommand(query, connect.GetConnection());
                MySqlDataReader datareader;
                connect.OpenCon();
                datareader = command.ExecuteReader();
                bunifuSnackbar1.Show(this, "Data Succesfully Updated!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                connect.CloseCon();

                EmptyData();
                ShowData_Product();
                ShowData_Category();
                bunifuPages1.SetPage(Product);
            } 
        }

        private void Button_delete_Click(object sender, EventArgs e)
        {
            // Eksekusi query update
            string query = "DELETE FROM `produk` WHERE `No` = '" + this.Form_no.Text + "'";
            MySqlCommand command = new MySqlCommand(query, connect.GetConnection());
            MySqlDataReader datareader;
            connect.OpenCon();
            datareader = command.ExecuteReader();
            bunifuSnackbar1.Show(this, "Data Succesfully Deleted!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
            connect.CloseCon();

            ShowData_Product();
            ShowData_Category();
        }

        private void Form_searchprod_TextChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter dataAdapter;
            DataTable dataTable;
            connect.OpenCon();
            dataAdapter = new MySqlDataAdapter("SELECT * FROM `produk` WHERE `Title` LIKE '%' '" + Form_searchprod.Text + "' '%' OR `Category` LIKE '%' '" + Form_searchprod.Text + "' '%' OR `SubCategory` LIKE '%' '" + Form_searchprod.Text + "' '%' ", connect.GetConnection()); 
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataTable.Columns.Add("Picture", Type.GetType("System.Byte[]"));

            foreach (DataRow row in dataTable.Rows)
            {
                row["Picture"] = File.ReadAllBytes(Application.StartupPath + @"\Image\" + Path.GetFileName(row["Image"].ToString()));
            }
            Data_tableprod.DataSource = dataTable;
            connect.CloseCon();
        }

        private void Insert_image_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();
            openfd.Filter = "Image Files(*.jpg;*.jpeg;*.png;) | *.jpg;*.jpeg;*.png;";
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                ImageText.Text = openfd.FileName;
                Insert_image.Image = new Bitmap(openfd.FileName);
                Insert_image.ImageLocation = openfd.FileName;
                Insert_image.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            count = Data_tableprod.RowCount;
            Label_count.Text = count.ToString();
        }
    }
}
