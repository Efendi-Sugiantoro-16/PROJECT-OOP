using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using BCrypt.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace TB_PBO1
{
    public partial class Form1 : Form
    {
        private IMongoDatabase database;
        private IMongoCollection<BsonDocument> userCollection;
        private IMongoCollection<BsonDocument> riwayatCollection;

        public Form1()
        {
            InitializeComponent();

            // Inisialisasi koneksi MongoDB
            var client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("InventarisObat");
            userCollection = database.GetCollection<BsonDocument>("user");
            riwayatCollection = database.GetCollection<BsonDocument>("riwayat"); // Koleksi untuk riwayat aktivitas
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Email dan Password harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cek apakah email ada di database
            var filter = Builders<BsonDocument>.Filter.Eq("email", email);
            var user = userCollection.Find(filter).FirstOrDefault();

            if (user != null)
            {
                string storedHashedPassword = user["password"].AsString;

                // Verifikasi password dengan BCrypt
                if (BCrypt.Net.BCrypt.Verify(password, storedHashedPassword))
                {
                    MessageBox.Show("Login berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Simpan aktivitas login ke riwayat
                    SimpanRiwayat(email, "Login", "User berhasil login ke sistem");

                    // Buka Form3 (Dashboard)
                    Form3 dashboard = new Form3();
                    dashboard.Show();
                    this.Hide(); // Sembunyikan Form1 setelah login berhasil
                }
                else
                {
                    MessageBox.Show("Email atau password salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Email atau password salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Metode untuk menyimpan aktivitas ke dalam koleksi 'riwayat'
        private void SimpanRiwayat(string user, string action, string detail)
        {
            var riwayatDoc = new BsonDocument
            {
                { "User", user },
                { "Action", action },
                { "Detail", detail },
                { "Timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }
            };

            riwayatCollection.InsertOne(riwayatDoc);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 registerForm = new Form2();
            registerForm.Show();
            this.Hide();
        }
    }
}
