using System;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using BCrypt.Net;

namespace TB_PBO1
{
    public partial class Form2 : Form
    {
        private readonly IMongoCollection<BsonDocument> _userCollection;
        private readonly IMongoCollection<BsonDocument> _historyCollection;

        public Form2()
        {
            InitializeComponent();

            // Koneksi ke database MongoDB dan mendapatkan koleksi yang dibutuhkan
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("InventarisObat");

            _userCollection = database.GetCollection<BsonDocument>("user");
            _historyCollection = database.GetCollection<BsonDocument>("riwayat");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Validasi input agar tidak ada field yang kosong
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Semua kolom harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validasi format email sederhana
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Format email tidak valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validasi kesamaan password dan konfirmasi password
            if (password != confirmPassword)
            {
                MessageBox.Show("Password dan Konfirmasi Password tidak cocok!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cek apakah username sudah ada dalam database (case-insensitive)
            var existingUser = _userCollection.Find(Builders<BsonDocument>.Filter.Eq("username", username.ToLower())).FirstOrDefault();
            if (existingUser != null)
            {
                MessageBox.Show("Username sudah digunakan. Silakan pilih username lain.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hash password dengan BCrypt sebelum disimpan ke database
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // Membuat dokumen baru untuk pengguna
            var newUser = new BsonDocument
            {
                { "username", username.ToLower() },
                { "name", name },
                { "email", email },
                { "password", hashedPassword }
            };

            // Menyimpan data pengguna ke koleksi user di MongoDB
            _userCollection.InsertOne(newUser);

            // Simpan aktivitas ke koleksi Riwayat
            SaveHistory("Pendaftaran Pengguna", $"Pengguna '{username}' telah terdaftar.", username);

            MessageBox.Show("Pendaftaran berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Mengosongkan kembali input setelah registrasi berhasil
            txtUsername.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Navigasi kembali ke form login
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Hide();
        }

        // Fungsi untuk menyimpan riwayat aktivitas pengguna ke database
        private void SaveHistory(string action, string description, string username)
        {
            var historyEntry = new BsonDocument
            {
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "action", action },
                { "description", description },
                { "username", username }
            };

            _historyCollection.InsertOne(historyEntry);
        }
    }
}
