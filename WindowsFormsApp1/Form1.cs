using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUDMahasiswaADO
{
    public partial class Form1 : Form
    {

        // Koneksi Database
        private readonly SqlConnection conn;
        private readonly string connectionString =
        "Data Source=LAPTOP-NK6J0O8M\\SQLDEV;Initial Catalog=DBAkademikADO;Integrated Security=True";

        
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }
// ===============================
        // METHOD KONEKSI DATABASE
        // ===============================
        private void ConnectDatabase()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                MessageBox.Show("Koneksi berhasil");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal : " + ex.Message);
            }
        }

      
