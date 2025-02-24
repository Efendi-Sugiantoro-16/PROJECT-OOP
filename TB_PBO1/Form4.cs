using System; // Library dasar .NET
using System.Linq; // Library untuk query LINQ (Language Integrated Query)
using System.Windows.Forms; // Library untuk membuat antarmuka Windows Forms
using MongoDB.Driver; // Library MongoDB driver untuk .NET
using MongoDB.Bson; // Library untuk penggunaan BSON (Binary JSON) pada MongoDB
using System.IO; // Library untuk operasi input/output (I/O), seperti file handling
using iText.Kernel.Pdf; // Library iText untuk pembuatan dokumen PDF
using iText.Layout; // Library iText untuk pengaturan layout dokumen PDF
using iText.Layout.Element; // Library iText untuk elemen-elemen layout seperti Paragraph, Table, dll.
using iText.IO.Font.Constants; // Library untuk konstanta font standar iText
using iText.Kernel.Font; // Library untuk pembuatan dan penggunaan font di dokumen PDF
using System.Collections.Generic; // Library untuk koleksi generik (seperti List, Dictionary, dll.)
using iText.Kernel.Geom; // Library untuk pengaturan ukuran dan orientasi halaman PDF
using iText.Layout.Properties; // Library untuk properti layout dokumen PDF
using iText.Kernel.Colors; // Library untuk pengaturan warna pada dokumen PDF
using iText.Layout.Borders; // Library untuk pengaturan border pada dokumen PDF

namespace TB_PBO1
{
    // Kelas Form4 merupakan turunan dari Form yang menampilkan antarmuka pengguna untuk manajemen data obat
    public partial class Form4 : Form
    {
        // Deklarasi koleksi MongoDB untuk menyimpan data obat
        private readonly IMongoCollection<BsonDocument> _obatCollection;

        // Constructor Form4, dijalankan saat form diinisialisasi
        public Form4()
        {
            // Inisialisasi komponen pada form
            InitializeComponent();

            // Membuat koneksi ke MongoDB pada localhost dengan port default 27017
            var client = new MongoClient("mongodb://localhost:27017");

            // Mengambil database "InventarisObat"
            var database = client.GetDatabase("InventarisObat");

            // Mengambil koleksi "obat" dari database untuk operasi CRUD
            _obatCollection = database.GetCollection<BsonDocument>("obat");

            // Memuat data dari koleksi ke DataGridView
            LoadData();
        }

        // Event Handler untuk memuat data ke DataGridView, dengan parameter pencarian opsional
        private void LoadData(string searchQuery = "")
        {
            try
            {
                // Membuat filter pencarian berdasarkan input searchQuery.
                // Jika searchQuery kosong, maka filter berupa dokumen kosong (mengambil semua data).
                // Jika tidak, filter menggunakan operator $or untuk mencari di beberapa kolom.
                var filter = string.IsNullOrEmpty(searchQuery)
                    ? new BsonDocument()
                    : new BsonDocument("$or", new BsonArray
                    {
                        new BsonDocument("KodeObat", new BsonDocument("$regex", searchQuery).Add("$options", "i")),
                        new BsonDocument("NamaObat", new BsonDocument("$regex", searchQuery).Add("$options", "i")),
                        new BsonDocument("NamaMerek", new BsonDocument("$regex", searchQuery).Add("$options", "i")), // Filter untuk NamaMerek
                        new BsonDocument("JenisObat", new BsonDocument("$regex", searchQuery).Add("$options", "i")),
                        new BsonDocument("Kategori", new BsonDocument("$regex", searchQuery).Add("$options", "i")),
                        new BsonDocument("Deskripsi", new BsonDocument("$regex", searchQuery).Add("$options", "i")),
                        new BsonDocument("Tanggal", new BsonDocument("$regex", searchQuery).Add("$options", "i")),
                        new BsonDocument("Stok", new BsonDocument("$regex", searchQuery).Add("$options", "i"))
                    });

                // Mengambil data obat dari MongoDB menggunakan filter yang telah dibuat
                var obatList = _obatCollection.Find(filter).ToList();

                // Memetakan data yang diambil ke DataGridView.
                // Hanya kolom-kolom tertentu yang dipilih dan dikonversi sesuai kebutuhan (misal, konversi ObjectId ke string)
                dataGridViewObat.DataSource = obatList.Select(d => new
                {
                    Id = d.Contains("_id") ? d["_id"].ToString() : "",
                    KodeObat = d.Contains("KodeObat") ? d["KodeObat"].AsString : "",
                    NamaObat = d.Contains("NamaObat") ? d["NamaObat"].AsString : "",
                    NamaMerek = d.Contains("NamaMerek") ? d["NamaMerek"].AsString : "", 
                    JenisObat = d.Contains("JenisObat") ? d["JenisObat"].AsString : "",
                    Kategori = d.Contains("Kategori") ? d["Kategori"].AsString : "",
                    Deskripsi = d.Contains("Deskripsi") ? d["Deskripsi"].AsString : "",
                    Tanggal = d.Contains("Tanggal") ? d["Tanggal"].ToString() : "",
                    Stok = d.Contains("Stok") ? d["Stok"].ToInt32() : 0
                }).ToList();
            }
            catch (Exception ex)
            {
                // Menampilkan pesan error jika terjadi kesalahan dalam memuat data
                MessageBox.Show($"Terjadi kesalahan saat memuat data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Metode untuk menyimpan riwayat aksi pengguna ke dalam koleksi "riwayat" di MongoDB
        private void SimpanRiwayat(string user, string action, string detail)
        {
            // Membuat koneksi ke database "InventarisObat" dan mengambil koleksi "riwayat"
            var database = new MongoClient("mongodb://localhost:27017").GetDatabase("InventarisObat");
            var riwayatCollection = database.GetCollection<BsonDocument>("riwayat");

            // Membuat dokumen riwayat yang berisi informasi user, aksi, detail, dan waktu kejadian
            var riwayatDoc = new BsonDocument
            {
                { "User", user },
                { "Action", action },
                { "Detail", detail },
                { "Timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }
            };

            // Menyisipkan dokumen riwayat ke koleksi "riwayat"
            riwayatCollection.InsertOne(riwayatDoc);
        }

        // Event Handler untuk tombol Confirm (simpan/update data obat)
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Validasi input: memastikan semua kolom yang diperlukan telah diisi (termasuk NamaMerek)
            if (string.IsNullOrWhiteSpace(txtNamaObat.Text) ||
                string.IsNullOrWhiteSpace(txtNamaMerek.Text) || // Validasi untuk NamaMerek
                string.IsNullOrWhiteSpace(txtDeskripsi.Text) ||
                cmbJenisObat.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtStok.Text) ||
                string.IsNullOrWhiteSpace(txtKategori.Text))
            {
                // Menampilkan pesan peringatan jika ada kolom yang belum diisi
                MessageBox.Show("Semua kolom yang diperlukan harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Jika txtKodeObat kosong, maka generate kode obat baru secara otomatis; jika tidak, gunakan nilai yang ada
            string kodeObat = string.IsNullOrWhiteSpace(txtKodeObat.Text) ? GenerateKodeObat() : txtKodeObat.Text;
            // Mengambil nilai kategori dari txtKategori
            string kategori = txtKategori.Text;

            // Mengecek apakah data obat dengan kode yang sama sudah ada di database
            var filter = Builders<BsonDocument>.Filter.Eq("KodeObat", kodeObat);
            var existingObat = _obatCollection.Find(filter).FirstOrDefault();

            if (existingObat == null)
            {
                // Jika data belum ada, lakukan INSERT DATA BARU ke dalam koleksi
                var document = new BsonDocument
                {
                    { "KodeObat", kodeObat },
                    { "NamaObat", txtNamaObat.Text },
                    { "NamaMerek", txtNamaMerek.Text }, // Menambahkan nilai NamaMerek
                    { "JenisObat", cmbJenisObat.SelectedItem.ToString() },
                    { "Kategori", kategori },
                    { "Deskripsi", txtDeskripsi.Text },
                    // Menggunakan tanggal dari DateTimePicker atau tanggal sekarang jika input kosong
                    { "Tanggal", string.IsNullOrWhiteSpace(dtpTanggal.Text) ? DateTime.Now.ToString("yyyy-MM-dd") : dtpTanggal.Value.ToString("yyyy-MM-dd") },
                    { "Stok", int.Parse(txtStok.Text) }
                };

                // Menyisipkan dokumen baru ke koleksi "obat"
                _obatCollection.InsertOne(document);
                // Menyimpan riwayat aksi penambahan data
                SimpanRiwayat("Admin", "Tambah Data", $"Menambahkan obat dengan kode {kodeObat}");

                // Menampilkan pesan bahwa data berhasil disimpan
                MessageBox.Show("Data berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Jika data sudah ada, lakukan UPDATE DATA YANG SUDAH ADA
                var update = Builders<BsonDocument>.Update
                    .Set("NamaObat", txtNamaObat.Text)
                    .Set("NamaMerek", txtNamaMerek.Text) // Memperbarui nilai NamaMerek
                    .Set("JenisObat", cmbJenisObat.SelectedItem.ToString())
                    .Set("Kategori", kategori)
                    .Set("Deskripsi", txtDeskripsi.Text)
                    // Mengatur tanggal menggunakan nilai dari DateTimePicker atau tanggal sekarang jika kosong
                    .Set("Tanggal", string.IsNullOrWhiteSpace(dtpTanggal.Text) ? DateTime.Now.ToString("yyyy-MM-dd") : dtpTanggal.Value.ToString("yyyy-MM-dd"))
                    .Set("Stok", int.Parse(txtStok.Text));

                // Melakukan update pada dokumen obat yang sesuai dengan filter
                _obatCollection.UpdateOne(filter, update);
                // Menyimpan riwayat aksi update data
                SimpanRiwayat("Admin", "Update Data", $"Memperbarui obat dengan kode {kodeObat}");

                // Menampilkan pesan bahwa data berhasil diperbarui
                MessageBox.Show("Data berhasil diperbarui!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Memuat ulang data dari database ke DataGridView
            LoadData();
            // Mengosongkan semua input form setelah operasi selesai
            ClearFields();
        }

        // Metode untuk menghasilkan kode obat secara otomatis dengan kombinasi prefix, karakter acak, dan angka acak
        private string GenerateKodeObat()
        {
            // Membuat objek Random untuk menghasilkan angka acak
            Random rand = new Random();
            // Array berisi prefix yang mungkin untuk kode obat
            string[] prefixes = {
                "OBT", "MED", "DRG", "PHR", "HCL", "RX", "ANT", "VIT", "SUP", "HERB",
                "GEN", "BRD", "INJ", "TAB", "CAP", "SYR", "SOL", "OTC", "PRES", "CURE"
            };

            // Memilih salah satu prefix secara acak dari array
            string prefix = prefixes[rand.Next(prefixes.Length)];
            // Menghasilkan bagian acak menggunakan GUID, ambil 4 karakter pertama dan konversi ke huruf kapital
            string randomPart = Guid.NewGuid().ToString("N").Substring(0, 4).ToUpper();
            // Menghasilkan angka acak 3 digit (antara 100 dan 999)
            int randomNumber = rand.Next(100, 999);

            // Mengembalikan kode obat dengan format "prefix-randomPartrandomNumber"
            return $"{prefix}-{randomPart}{randomNumber}";
        }

        // Event Handler untuk tombol Batal, yang akan mengosongkan form input dan menghapus seleksi DataGridView
        private void btnBatal_Click(object sender, EventArgs e)
        {
            ClearFields(); // Mengosongkan semua input
            dataGridViewObat.ClearSelection(); // Menghapus seleksi pada DataGridView
        }

        // Event Handler untuk tombol Delete, yang akan menghapus data obat yang dipilih
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Mengecek apakah ada baris yang dipilih di DataGridView
            if (dataGridViewObat.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang ingin dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mengambil ID dari baris yang dipilih
            var id = dataGridViewObat.SelectedRows[0].Cells["Id"].Value.ToString();
            // Mencari dokumen obat berdasarkan _id
            var obat = _obatCollection.Find(Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id))).FirstOrDefault();

            // Jika data obat tidak ditemukan, tampilkan pesan error
            if (obat == null)
            {
                MessageBox.Show("Data tidak ditemukan atau sudah dihapus.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mengambil nilai KodeObat atau memberikan nilai default "Tanpa Kode" jika tidak ditemukan
            string kodeObat = obat.Contains("KodeObat") ? obat["KodeObat"].AsString : "Tanpa Kode";
            // Menampilkan dialog konfirmasi penghapusan data
            var confirmResult = MessageBox.Show($"Apakah Anda yakin ingin menghapus obat dengan kode {kodeObat}?",
                                                "Konfirmasi Hapus",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Menghapus dokumen dari koleksi berdasarkan _id
                _obatCollection.DeleteOne(Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id)));
                // Menyimpan riwayat aksi penghapusan data
                SimpanRiwayat("Admin", "Hapus Data", $"Menghapus obat dengan kode {kodeObat}");
                // Memuat ulang data ke DataGridView
                LoadData();
                // Menampilkan pesan sukses penghapusan data
                MessageBox.Show("Data berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Event Handler untuk perubahan teks di TextBox pencarian
        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            // Memuat ulang data berdasarkan teks pencarian yang dimasukkan
            LoadData(txtCari.Text);
        }

        // Metode untuk mengosongkan semua input pada form
        private void ClearFields()
        {
            txtKodeObat.Clear();      // Mengosongkan TextBox KodeObat
            txtNamaObat.Clear();      // Mengosongkan TextBox NamaObat
            txtNamaMerek.Clear();     // Mengosongkan TextBox NamaMerek
            txtKategori.Clear();      // Mengosongkan TextBox Kategori
            txtDeskripsi.Clear();     // Mengosongkan TextBox Deskripsi
            txtStok.Clear();          // Mengosongkan TextBox Stok
            cmbJenisObat.SelectedIndex = -1; // Mengatur ComboBox JenisObat ke posisi tidak terpilih
            dtpTanggal.Value = DateTime.Now; // Mengatur DateTimePicker ke tanggal saat ini
        }

        // Event Handler untuk tombol Export PDF, yang akan mengekspor data dari DataGridView ke file PDF
        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            // Mengecek apakah DataGridView memiliki data yang dapat diekspor
            if (dataGridViewObat.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk diekspor!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Menggunakan SaveFileDialog untuk menentukan lokasi penyimpanan file PDF
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.FileName = "Data_Obat.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Mendapatkan path file dari dialog SaveFileDialog
                        string filePath = saveFileDialog.FileName;

                        // Membuat file PDF dan menulis isinya menggunakan iText7
                        using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                        using (PdfWriter writer = new PdfWriter(stream))
                        using (PdfDocument pdf = new PdfDocument(writer))
                        // Membuat dokumen PDF dengan orientasi lanskap (A4 Rotate)
                        using (Document document = new Document(pdf, PageSize.A4.Rotate()))
                        {
                            // Mengatur margin dokumen
                            document.SetMargins(20, 20, 20, 20);

                            // Membuat font untuk judul dan menambahkan judul laporan
                            PdfFont fontTitle = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                            document.Add(new Paragraph("Laporan Data Obat")
                                .SetFont(fontTitle)
                                .SetFontSize(18)
                                .SetTextAlignment(TextAlignment.CENTER));

                            // Menampilkan tanggal dan waktu ekspor di bagian atas dokumen
                            string exportDate = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
                            PdfFont fontDate = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                            document.Add(new Paragraph($"Tanggal Ekspor: {exportDate}")
                                .SetFont(fontDate)
                                .SetFontSize(10)
                                .SetTextAlignment(TextAlignment.RIGHT));

                            // Menambahkan spasi kosong antara judul dan tabel
                            document.Add(new Paragraph("\n"));

                            // Menentukan jumlah kolom pada DataGridView
                            int columnCount = dataGridViewObat.Columns.Count;
                            float[] columnWidths = new float[columnCount];

                            // Mengatur lebar kolom secara proporsional (semua kolom mendapat nilai 1)
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnWidths[i] = 1;
                            }

                            // Membuat objek Table dengan lebar kolom yang telah diatur
                            Table table = new Table(UnitValue.CreatePercentArray(columnWidths)).UseAllAvailableWidth();
                            PdfFont fontHeader = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                            PdfFont fontContent = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                            // Menambahkan header kolom ke dalam tabel PDF
                            foreach (DataGridViewColumn column in dataGridViewObat.Columns)
                            {
                                table.AddHeaderCell(new Cell()
                                    .Add(new Paragraph(column.HeaderText).SetFont(fontHeader))
                                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                                    .SetBorder(Border.NO_BORDER));
                            }

                            // Menambahkan setiap baris data dari DataGridView ke dalam tabel PDF
                            foreach (DataGridViewRow row in dataGridViewObat.Rows)
                            {
                                // Mengabaikan baris kosong (baris baru)
                                if (!row.IsNewRow)
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        // Menambahkan sel ke tabel, menggunakan tanda "-" jika nilai cell null
                                        table.AddCell(new Cell()
                                            .Add(new Paragraph(cell.Value?.ToString() ?? "-").SetFont(fontContent))
                                            .SetBorder(Border.NO_BORDER));
                                    }
                                }
                            }

                            // Menambahkan tabel ke dalam dokumen PDF
                            document.Add(table);
                            // Memastikan semua data telah ditulis ke dalam dokumen
                            document.Flush();
                            // Menutup dokumen dan writer
                            pdf.Close();
                            writer.Close();
                        }

                        // Menampilkan pesan sukses setelah ekspor PDF selesai
                        MessageBox.Show("Data berhasil diekspor ke PDF!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (IOException)
                    {
                        // Menampilkan pesan error jika file PDF sedang terbuka sehingga tidak dapat ditulis
                        MessageBox.Show("File PDF sedang terbuka, tutup terlebih dahulu sebelum mengekspor ulang.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        // Menampilkan pesan error jika terjadi kesalahan lain saat ekspor PDF
                        MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Event Handler untuk tombol Home, yang akan mengarahkan ke form Home (Form3)
        private void BtnHome_Click(object sender, EventArgs e)
        {
            // Membuat instance Form3 (Home)
            Form3 home = new Form3();
            home.Show(); // Menampilkan Form3
            this.Hide(); // Menyembunyikan Form4
        }

        // Event Handler untuk tombol Data Input yang tetap berada di Form4
        private void BtnData_Click(object sender, EventArgs e)
        {
            // Menampilkan pesan bahwa pengguna sudah berada di halaman Data Input
            MessageBox.Show("Anda sudah berada di halaman Data Input.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Event Handler untuk tombol View Graphics, yang mengarahkan ke Form5 (tampilan grafik)
        private void BtnView_Click(object sender, EventArgs e)
        {
            // Membuat instance Form5 untuk menampilkan grafik
            Form5 grafik = new Form5();
            grafik.Show(); // Menampilkan Form5
            this.Hide();   // Menyembunyikan Form4
        }

        // Event Handler untuk tombol History, yang mengarahkan ke Form7 (riwayat aktivitas)
        private void BtnHistory_Click(object sender, EventArgs e)
        {
            // Membuat instance Form7 untuk menampilkan riwayat
            Form7 history = new Form7();
            history.Show(); // Menampilkan Form7
            this.Hide();   // Menyembunyikan Form4
        }

        // Event Handler untuk tombol Logout
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            // Menampilkan dialog konfirmasi logout
            DialogResult dialog = MessageBox.Show(
                "Apakah Anda yakin ingin logout?",
                "Konfirmasi Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialog == DialogResult.Yes)
            {
                // Jika pengguna mengkonfirmasi logout, simpan riwayat aksi logout
                SimpanRiwayat("Admin", "Logout", "User logout dari sistem.");
                // Membuka form Login (Form1)
                Form1 loginForm = new Form1();
                loginForm.Show();
                // Menutup Form4 agar tidak berjalan di background
                this.Close();
            }
        }

        // Event Handler untuk perubahan teks di TextBox txtNamaObat (jika diperlukan)
        private void txtNamaObat_TextChanged(object sender, EventArgs e)
        {
            // Tempat untuk kode tambahan jika diperlukan saat teks diubah
        }

        // Event Handler untuk klik pada sel di DataGridView (memilih baris)
        private void dataGridViewObat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Mengecek apakah indeks baris valid
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewObat.Rows.Count)
            {
                // Mendapatkan baris yang diklik
                DataGridViewRow row = dataGridViewObat.Rows[e.RowIndex];

                // Mengecek jumlah sel pada baris untuk menghindari error
                if (row.Cells.Count >= 8)
                {
                    // Mengisi kontrol input dengan data dari baris yang dipilih
                    txtKodeObat.Text = row.Cells["KodeObat"].Value?.ToString() ?? "";
                    txtNamaObat.Text = row.Cells["NamaObat"].Value?.ToString() ?? "";
                    txtNamaMerek.Text = row.Cells["NamaMerek"].Value?.ToString() ?? ""; // Mengisi nilai NamaMerek
                    txtDeskripsi.Text = row.Cells["Deskripsi"].Value?.ToString() ?? "";
                    txtKategori.Text = row.Cells["Kategori"].Value?.ToString() ?? "";

                    // Mengatur nilai ComboBox JenisObat berdasarkan data dari baris
                    string jenisObat = row.Cells["JenisObat"].Value?.ToString();
                    if (!string.IsNullOrEmpty(jenisObat) && cmbJenisObat.Items.Contains(jenisObat))
                    {
                        cmbJenisObat.SelectedItem = jenisObat;
                    }
                    else
                    {
                        cmbJenisObat.SelectedIndex = -1;
                    }

                    // Mengatur nilai TextBox Stok berdasarkan data dari baris
                    if (int.TryParse(row.Cells["Stok"].Value?.ToString(), out int stok))
                    {
                        txtStok.Text = stok.ToString();
                    }
                    else
                    {
                        txtStok.Text = "0";
                    }

                    // Mengatur nilai DateTimePicker berdasarkan data tanggal dari baris
                    if (DateTime.TryParse(row.Cells["Tanggal"].Value?.ToString(), out DateTime tanggal))
                    {
                        dtpTanggal.Value = tanggal;
                    }
                    else
                    {
                        dtpTanggal.Value = DateTime.Now;
                    }
                }
            }
        }

        // Event Handler untuk tombol Pilih Obat, yang membuka Form6 untuk memilih data obat
        private void btnPilihObat_Click(object sender, EventArgs e)
        {
            // Membuat instance Form6
            Form6 form6 = new Form6();
            // Jika Form6 selesai dengan dialog OK, ambil nilai yang dipilih
            if (form6.ShowDialog() == DialogResult.OK)
            {
                txtNamaObat.Text = form6.SelectedNamaObat;   // Mengisi NamaObat dengan hasil pilihan
                txtKategori.Text = form6.SelectedCategory;   // Mengisi Kategori dengan hasil pilihan
            }
        }

        // Event Handler untuk klik pada isi sel di DataGridView (CellContentClick)
        private void dataGridViewObat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Mengecek apakah indeks baris valid
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewObat.Rows.Count)
            {
                // Mendapatkan baris yang diklik
                DataGridViewRow row = dataGridViewObat.Rows[e.RowIndex];

                // Mengecek jumlah sel untuk menghindari error
                if (row.Cells.Count >= 8)
                {
                    // Mengisi kontrol input dengan data dari baris yang diklik
                    txtKodeObat.Text = row.Cells["KodeObat"].Value?.ToString() ?? "";
                    txtNamaObat.Text = row.Cells["NamaObat"].Value?.ToString() ?? "";
                    txtNamaMerek.Text = row.Cells["NamaMerek"].Value?.ToString() ?? ""; 
                    txtDeskripsi.Text = row.Cells["Deskripsi"].Value?.ToString() ?? "";
                    txtKategori.Text = row.Cells["Kategori"].Value?.ToString() ?? "";

                    // Mengatur nilai ComboBox JenisObat berdasarkan data dari baris
                    string jenisObat = row.Cells["JenisObat"].Value?.ToString();
                    if (!string.IsNullOrEmpty(jenisObat) && cmbJenisObat.Items.Contains(jenisObat))
                    {
                        cmbJenisObat.SelectedItem = jenisObat;
                    }
                    else
                    {
                        cmbJenisObat.SelectedIndex = -1;
                    }

                    // Mengatur nilai TextBox Stok berdasarkan data dari baris
                    if (int.TryParse(row.Cells["Stok"].Value?.ToString(), out int stok))
                    {
                        txtStok.Text = stok.ToString();
                    }
                    else
                    {
                        txtStok.Text = "0";
                    }

                    // Mengatur nilai DateTimePicker berdasarkan data tanggal dari baris
                    if (DateTime.TryParse(row.Cells["Tanggal"].Value?.ToString(), out DateTime tanggal))
                    {
                        dtpTanggal.Value = tanggal;
                    }
                    else
                    {
                        dtpTanggal.Value = DateTime.Now;
                    }
                }
            }
        }

        // Event Handler untuk perubahan teks di TextBox txtNamaMerek (jika diperlukan)
        private void txtNamaMerek_TextChanged(object sender, EventArgs e)
        {
            // Tempat untuk kode tambahan jika diperlukan saat teks diubah di txtNamaMerek
        }

        // Event Handler untuk perubahan teks di TextBox tambahan (textBox1)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Tempat untuk kode tambahan jika diperlukan
        }

        // Event Handler yang dijalankan saat Form4 dimuat
        private void Form4_Load(object sender, EventArgs e)
        {
            // Tempat untuk kode tambahan yang dijalankan saat form pertama kali dimuat
        }
    }
}
