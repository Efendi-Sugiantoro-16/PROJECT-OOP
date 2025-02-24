//Form5 Grafik Data
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

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
    public partial class Form5 : Form
    {
        private UserControl1 userControl1;

        public Form5()
        {
            InitializeComponent();
            InitializeUserControl();
        }

        private void InitializeUserControl()
        {
            userControl1 = new UserControl1();
            userControl1.Dock = DockStyle.Fill;
            panelGraphics.Controls.Add(userControl1);
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
        private void btnHome_Click(object sender, EventArgs e)
        {
            // Navigasi ke Form Home
            Form3 home = new Form3();
            home.Show();
            this.Hide();
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            // Navigasi ke Form Data Input
            Form4 dataInput = new Form4();
            dataInput.Show();
            this.Hide();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            // Tetap di Form5 karena ini halaman View Graphics
            MessageBox.Show("Anda sudah berada di halaman grafik.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            // Navigasi ke Form History
            Form7 history = new Form7();
            history.Show();
            this.Hide();
        }

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


        private void panelGraphics_Paint(object sender, PaintEventArgs e)
        {
            // tak terimplemenatsi
        }
    }
}
