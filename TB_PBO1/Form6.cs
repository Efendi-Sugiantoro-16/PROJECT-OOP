using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace TB_PBO1
{
    public partial class Form6 : Form
    {
        public string SelectedCategory { get; private set; } // Menyimpan kategori obat yang dipilih
        public string SelectedNamaObat { get; private set; } // Menyimpan nama obat yang dipilih

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // Objek untuk mengubah huruf awal setiap kata menjadi kapital
            TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;

            // Data kategori obat dari Dictionary (mengambil kategori unik)
            Dictionary<string, string> kategoriMap = new()
            {
                // 🔹 ANALGESIK & ANTIPIRETIK
                { "Paracetamol", "Analgesik (Pereda Nyeri), Antipiretik (Penurun Demam)" },
                { "Ibuprofen", "Analgesik (Pereda Nyeri), Antipiretik (Penurun Demam)" },
                { "Aspirin", "Analgesik (Pereda Nyeri), Obat Kardiovaskular" },
                { "Naproxen", "Analgesik (Pereda Nyeri), Antiinflamasi" },
                { "Diklofenak", "Analgesik (Pereda Nyeri), Antiinflamasi" },

                // 🔹 ANTIBIOTIK
                { "Amoksisilin", "Antibiotik (Anti Infeksi Bakteri)" },
                { "Azitromisin", "Antibiotik (Anti Infeksi Bakteri)" },
                { "Ciprofloxacin", "Antibiotik (Anti Infeksi Bakteri)" },
                { "Doksisiklin", "Antibiotik (Anti Infeksi Bakteri)" },
                { "Klindamisin", "Antibiotik (Anti Infeksi Bakteri)" },

                // 🔹 ANTIVIRAL
                { "Oseltamivir", "Antiviral (Anti Virus)" },
                { "Acyclovir", "Antiviral (Anti Virus)" },
                { "Lamivudine", "Antiviral (Anti Virus)" },

                // 🔹 ANTIJAMUR
                { "Ketoconazole", "Antijamur" },
                { "Fluconazole", "Antijamur" },
                { "Mikonazol", "Antijamur" },

                // 🔹 ANTIHIPERTENSI
                { "Amlodipin", "Antihipertensi (Penurun Tekanan Darah)" },
                { "Losartan", "Antihipertensi (Penurun Tekanan Darah)" },
                { "Captopril", "Antihipertensi (Penurun Tekanan Darah)" },

                // 🔹 ANTIDIABETES
                { "Metformin", "Antidiabetes" },
                { "Insulin", "Antidiabetes" },
                { "Glibenclamide", "Antidiabetes" },

                // 🔹 ANTIASMA
                { "Salbutamol", "Antiasma" },
                { "Budesonide", "Antiasma" },
                { "Teofilin", "Antiasma" },

                // 🔹 OBAT SALURAN CERNA
                { "Omeprazole", "Obat Saluran Cerna (Maag)" },
                { "Ranitidin", "Obat Saluran Cerna (Maag)" },
                { "Loperamide", "Obat Saluran Cerna (Diare)" },
                { "Domperidone", "Obat Saluran Cerna (Mual & Muntah)" },
                { "Magnesium Hydroxide", "Obat Saluran Cerna (Antasida)" },

                // 🔹 OBAT KARDIOVASKULAR
                { "Digoxin", "Obat Kardiovaskular" },
                { "Warfarin", "Obat Kardiovaskular" },
                { "Atorvastatin", "Obat Kardiovaskular" },

                // 🔹 SUPLEMEN & VITAMIN
                { "Vitamin A", "Suplemen & Vitamin" },
                { "Vitamin B", "Suplemen & Vitamin" },
                { "Vitamin C", "Suplemen & Vitamin" },
                { "Vitamin D", "Suplemen & Vitamin" },
                { "Vitamin E", "Suplemen & Vitamin" },
                { "Multivitamin", "Suplemen & Vitamin" },
                { "Kalsium", "Suplemen & Vitamin" },
                { "Zink", "Suplemen & Vitamin" },
                { "Asam Folat", "Suplemen & Vitamin" },

                // 🔹 OBAT LUAR (SALAP, KRIM, SPRAY)
                { "Betadine", "Obat Luar (Antiseptik Luka)" },
                { "Nebacetin", "Obat Luar (Antibiotik Luka)" },
                { "Methyl Salicylate", "Obat Luar (Pereda Nyeri Otot)" },
                { "Permethrin", "Obat Luar (Antiscabies)" },
                { "Hydrocortisone", "Obat Luar (Anti Alergi Kulit)" },

                // 🔹 OBAT MATA & TELINGA
                { "Tetes Mata Cendo", "Obat Mata" },
                { "Gentamicin Tetes", "Obat Mata (Antibiotik Mata)" },
                { "Tetes Telinga Otopain", "Obat Telinga" },

                // 🔹 OBAT PERNAPASAN
                { "Mukolitik", "Obat Pernapasan (Pengencer Dahak)" },
                { "Antitusif", "Obat Pernapasan (Pereda Batuk Kering)" },

                // 🔹 OBAT HORMON
                { "Levothyroxine", "Obat Hormon (Tiroid)" },
                { "Testosteron", "Obat Hormon (Androgen)" },
                { "Estrogen", "Obat Hormon (Wanita)" }
            };

            // Buat DataTable untuk DataGridView
            DataTable dt = new DataTable();
            dt.Columns.Add("Nama Obat", typeof(string));
            dt.Columns.Add("Kategori Obat", typeof(string));

            foreach (var item in kategoriMap)
            {
                dt.Rows.Add(item.Key, item.Value);
            }

            // Tambahkan data ke DataGridView
            dataGridViewKategori.DataSource = dt;
            dataGridViewKategori.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewKategori.AllowUserToAddRows = false;
            dataGridViewKategori.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewKategori.ReadOnly = true;
        }

        private void btnPilih_Click(object sender, EventArgs e)
        {
            if (dataGridViewKategori.SelectedRows.Count > 0)
            {
                SelectedNamaObat = dataGridViewKategori.SelectedRows[0].Cells[0].Value.ToString();
                SelectedCategory = dataGridViewKategori.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Silakan pilih obat!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
