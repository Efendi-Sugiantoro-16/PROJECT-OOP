//Form7 Riwayat 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TB_PBO1
{
    public partial class Form7 : Form
    {
        private readonly IMongoCollection<BsonDocument> _riwayatCollection;

        public Form7()
        {
            InitializeComponent();

            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("InventarisObat");
                _riwayatCollection = database.GetCollection<BsonDocument>("riwayat");
                LoadRiwayat();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal terhubung ke database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRiwayat(string searchQuery = "")
        {
            try
            {
                var filter = string.IsNullOrEmpty(searchQuery)
                    ? new BsonDocument()
                    : new BsonDocument("$or", new BsonArray
                    {
                        new BsonDocument("User", new BsonDocument("$regex", searchQuery).Add("$options", "i")),
                        new BsonDocument("Action", new BsonDocument("$regex", searchQuery).Add("$options", "i")),
                        new BsonDocument("Detail", new BsonDocument("$regex", searchQuery).Add("$options", "i")),
                        new BsonDocument("Timestamp", new BsonDocument("$regex", searchQuery).Add("$options", "i"))
                    });

                var riwayatList = _riwayatCollection.Find(filter).SortByDescending(d => d["Timestamp"]).ToList();

                dataGridViewHistory.DataSource = riwayatList.Select(d => new
                {
                    User = d.Contains("User") ? d["User"].AsString : "Unknown",
                    Action = d.Contains("Action") ? d["Action"].AsString : "Unknown",
                    Detail = d.Contains("Detail") ? d["Detail"].AsString : "Unknown",
                    Timestamp = d.Contains("Timestamp") ? d["Timestamp"].ToString() : "N/A"
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data riwayat: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Menympan Riwayat

        private void SimpanRiwayat(string user, string action, string detail)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("InventarisObat");
            var riwayatCollection = database.GetCollection<BsonDocument>("riwayat");

            var riwayatDoc = new BsonDocument
    {
        { "User", user },
        { "Action", action },
        { "Detail", detail },
        { "Timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }
    };

            riwayatCollection.InsertOne(riwayatDoc);
        }
        private void txtCariHistory_TextChanged(object sender, EventArgs e)
        {
            LoadRiwayat(txtCariHistory.Text);
        }

        // Tombol Refresh untuk memperbarui data
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRiwayat();
        }

        // Tombol Kembali ke Form Sebelumnya
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Navigasi ke Dashboard / Form Utama
        private void BtnHome_Click(object sender, EventArgs e)
        {
            Form3 home = new Form3();
            home.Show();
            this.Hide();
        }

        // Navigasi ke Form Input Data Obat
        private void BtnData_Click(object sender, EventArgs e)
        {
            Form4 inputData = new Form4();
            inputData.Show();
            this.Hide();
        }

        // Navigasi ke Form Grafik Stok Obat
        private void BtnView_Click(object sender, EventArgs e)
        {
            Form5 grafik = new Form5();
            grafik.Show();
            this.Hide();
        }

        // Tombol History tidak perlu navigasi karena sudah di Form7
        private void BtnHistory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Anda sudah berada di halaman Riwayat.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Tombol Logout - Kembali ke halaman Login
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "Apakah Anda yakin ingin logout?",
                "Konfirmasi Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialog == DialogResult.Yes)
            {
                SimpanRiwayat("Admin", "Logout", "User logout dari sistem.");

                // Tampilkan kembali Form Login (Form1)
                Form1 loginForm = new Form1();
                loginForm.Show();

                // Tutup form utama (agar tidak tetap berjalan di background)
                this.Close();
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // Tetapkan ukuran tetap untuk DataGridView
            dataGridViewHistory.Width = 854;
            dataGridViewHistory.Height = 415;

            // Atur agar kolom menyesuaikan ukuran DataGridView
            dataGridViewHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Pastikan tinggi header menyesuaikan dengan teks
            dataGridViewHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Panggil fungsi untuk memuat data
            LoadRiwayat();
        }

    }
}

