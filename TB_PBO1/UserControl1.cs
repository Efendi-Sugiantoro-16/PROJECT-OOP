using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TB_PBO1
{
    public partial class UserControl1 : UserControl
    {
        private DatabaseHelper dbHelper; // Objek untuk mengakses database
        private Random random = new Random(); // Objek untuk menghasilkan warna acak

        public UserControl1()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper(); // Inisialisasi helper database
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            LoadChartData(); // Memuat data awal ke dalam grafik
            LoadComboBoxData(); // Memuat data ke dalam ComboBox
        }

        // Method untuk memuat data ke dalam grafik
        private void LoadChartData(string selectedObat = null, SeriesChartType chartType = SeriesChartType.Column)
        {
            chart1.Series.Clear(); // Menghapus semua seri sebelum menggambar ulang
            chart1.ChartAreas.Clear(); // Menghapus area grafik

            // Konfigurasi area grafik
            ChartArea chartArea = new ChartArea
            {
                AxisX = { Title = "Nama Obat", Interval = 1, MajorGrid = { LineWidth = 0 } },
                AxisY = { Title = "Jumlah Stok", MajorGrid = { LineDashStyle = ChartDashStyle.Dash } }
            };
            chart1.ChartAreas.Add(chartArea);

            // Mengambil data obat dari database dan mengurutkannya berdasarkan nama
            List<Obat> obatList = dbHelper.GetAllObat().OrderBy(o => o.NamaObat).ToList();
            if (!string.IsNullOrEmpty(selectedObat)) // Jika ada filter berdasarkan nama obat
            {
                obatList = obatList.Where(o => o.NamaObat == selectedObat).ToList();
            }

            if (obatList.Count == 0) // Jika tidak ada data obat
            {
                MessageBox.Show("Data obat tidak tersedia.", "Peringatan");
                return;
            }

            // Membuat seri data untuk grafik
            Series series = new Series("Stok Obat")
            {
                ChartType = chartType,
                IsValueShownAsLabel = true, // Menampilkan label jumlah stok pada grafik
                BorderWidth = 2,
                IsXValueIndexed = true // Memastikan semua data tampil dengan benar
            };

            // Menambahkan setiap data obat ke dalam grafik
            foreach (var obat in obatList)
            {
                DataPoint point = new DataPoint();
                point.SetValueXY(obat.NamaObat, obat.Stok);
                point.Color = Color.FromArgb(random.Next(100, 255), random.Next(100, 255), random.Next(100, 255)); // Warna acak untuk setiap batang
                point.Label = obat.Stok.ToString(); // Menampilkan jumlah stok di atas batang
                series.Points.Add(point);
            }

            chart1.Series.Add(series); // Menambahkan seri ke dalam grafik
        }

        // Method untuk memuat data ke dalam ComboBox
        private void LoadComboBoxData()
        {
            List<Obat> obatList = dbHelper.GetAllObat().OrderBy(o => o.NamaObat).ToList();
            comboBoxNama.Items.Clear(); // Menghapus item sebelumnya
            comboBoxNama.Items.Add("Semua"); // Opsi untuk menampilkan semua data
            comboBoxNama.Items.AddRange(obatList.Select(o => o.NamaObat).ToArray()); // Menambahkan nama obat ke dalam ComboBox
            comboBoxNama.SelectedIndex = 0; // Pilihan default: semua data

            comboBoxChartType.Items.Clear(); // Menghapus opsi sebelumnya
            comboBoxChartType.Items.AddRange(new string[] { "Column", "Pie" }); // Hanya Column dan Pie
            comboBoxChartType.SelectedIndex = 0; // Pilihan default: Column
        }

        // Event handler untuk tombol refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (comboBoxNama.SelectedItem == null || comboBoxChartType.SelectedItem == null)
            {
                MessageBox.Show("Silakan pilih nama obat dan jenis grafik terlebih dahulu.", "Peringatan");
                return;
            }

            LoadChartData(
                comboBoxNama.SelectedItem.ToString() == "Semua" ? null : comboBoxNama.SelectedItem.ToString(),
                GetSelectedChartType()
            );
        }

        // Event handler untuk pemilihan nama obat di ComboBox
        private void comboBoxNama_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNama.SelectedItem == null || comboBoxChartType.SelectedItem == null)
                return;

            LoadChartData(
                comboBoxNama.SelectedItem.ToString() == "Semua" ? null : comboBoxNama.SelectedItem.ToString(),
                GetSelectedChartType()
            );
        }

        // Event handler untuk pemilihan jenis grafik di ComboBox
        private void comboBoxChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNama.SelectedItem == null || comboBoxChartType.SelectedItem == null)
                return;

            LoadChartData(
                comboBoxNama.SelectedItem.ToString() == "Semua" ? null : comboBoxNama.SelectedItem.ToString(),
                GetSelectedChartType()
            );
        }

        // Method untuk mendapatkan jenis grafik berdasarkan pilihan di ComboBox
        private SeriesChartType GetSelectedChartType()
        {
            if (comboBoxChartType.SelectedItem == null)
                return SeriesChartType.Column; // Default jika tidak ada yang dipilih

            return comboBoxChartType.SelectedItem.ToString() switch
            {
                "Column" => SeriesChartType.Column,
                "Pie" => SeriesChartType.Pie,
                _ => SeriesChartType.Column,
            };
        }
    }
}
