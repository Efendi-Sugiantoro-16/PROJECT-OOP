//Form3 Dashboard
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TB_PBO1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
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
        // Event handler untuk tombol Home
        private void BtnHome_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Anda sudah berada di Home.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Event handler untuk tombol Data Input (Navigasi ke FormInputObat)
        private void BtnDataInput_Click(object sender, EventArgs e)
        {
            Form4 inputObatForm = new Form4();
            inputObatForm.Show();
            this.Hide();
        }

        // Event handler untuk tombol View Graphics (Navigasi ke FormGrafik)
        private void BtnViewGraphics_Click(object sender, EventArgs e)
        {
            Form5 grafikForm = new Form5();
            grafikForm.Show();
            this.Hide();
        }

        // Event handler untuk tombol History (Navigasi ke FormHistory)
        private void BtnHistory_Click(object sender, EventArgs e)
        {
            Form7 historyForm = new Form7();
            historyForm.Show();
            this.Hide();
        }

        // Event handler untuk tombol Logout
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


        // Event handler untuk Form Load
        private void Form3_Load(object sender, EventArgs e)
        {
            // Bisa digunakan untuk menginisialisasi data saat form dimuat
        }


    }
}