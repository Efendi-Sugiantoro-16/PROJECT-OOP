using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_PBO1
{
    public static class KategoriObatGenerator
    {
        private static readonly Dictionary<string, string> kategoriMap = new()
        {
            { "paracetamol", "Analgesik (Pereda Nyeri), Antipiretik (Penurun Demam)" },
            { "ibuprofen", "Analgesik (Pereda Nyeri), Antipiretik (Penurun Demam)" },
            { "aspirin", "Analgesik (Pereda Nyeri), Obat Kardiovaskular" },
            { "amoksisilin", "Antibiotik (Anti Infeksi Bakteri)" },
            { "azitromisin", "Antibiotik (Anti Infeksi Bakteri)" },
            { "ciprofloxacin", "Antibiotik (Anti Infeksi Bakteri)" },
            { "oseltamivir", "Antiviral (Anti Virus)" },
            { "acyclovir", "Antiviral (Anti Virus)" },
            { "ketoconazole", "Antijamur" },
            { "fluconazole", "Antijamur" },
            { "amlodipin", "Antihipertensi (Penurun Tekanan Darah)" },
            { "losartan", "Antihipertensi (Penurun Tekanan Darah)" },
            { "metformin", "Antidiabetes" },
            { "insulin", "Antidiabetes" },
            { "salbutamol", "Antiasma" },
            { "budesonide", "Antiasma" },
            { "omeprazole", "Obat Saluran Cerna (Maag)" },
            { "loperamide", "Obat Saluran Cerna (Diare)" },
            { "digoxin", "Obat Kardiovaskular" },
            { "vitamin c", "Suplemen & Vitamin" },
            { "vitamin d", "Suplemen & Vitamin" },
            { "kalsium", "Suplemen & Vitamin" }
        };

        public static string TentukanKategori(string NamaObat)
        {
            if (string.IsNullOrWhiteSpace(NamaObat))
            {
                return "Nama obat tidak boleh kosong";
            }

            NamaObat = NamaObat.ToLower(); // Membuat pencarian tidak case-sensitive

            return kategoriMap.TryGetValue(NamaObat, out string kategori)
                ? kategori
                : "Kategori Tidak Diketahui";
        }
    }
}
