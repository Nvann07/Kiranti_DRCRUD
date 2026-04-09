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

        // ===============================
        // BUTTON CONNECT
        // ===============================
        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectDatabase();
        }

        // ===============================
        // LOAD DATA MAHASISWA
        // ===============================
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                dataGridView1.Rows.Clear();

                if (dataGridView1.Columns.Count == 0)
                {
                    dataGridView1.Columns.Add("NIM", "NIM");
                    dataGridView1.Columns.Add("Nama", "Nama");
                    dataGridView1.Columns.Add("JenisKelamin", "Jenis Kelamin");
                    dataGridView1.Columns.Add("TanggalLahir", "Tanggal Lahir");
                    dataGridView1.Columns.Add("Alamat", "Alamat");
                    dataGridView1.Columns.Add("KodeProdi", "Kode Prodi");
                }

                string query = "SELECT * FROM Mahasiswa";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(
                        reader["NIM"].ToString(),
                        reader["Nama"].ToString(),
                        reader["JenisKelamin"].ToString(),
                        Convert.ToDateTime(reader["TanggalLahir"]).ToShortDateString(),
                        reader["Alamat"].ToString(),
                        reader["KodeProdi"].ToString()
                    );
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data : " + ex.Message);
            }
        }

      
