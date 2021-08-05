using MySql.Data.MySqlClient;

namespace Proj1
{
    class DBConnect
    {
        private MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=panel_db");

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        // Fungsi Kelas Buka Koneksi
        public void OpenCon()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
               connection.Open();     
            }
        }

        // Tutup Koneksi
        public void CloseCon()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        
    }
}
