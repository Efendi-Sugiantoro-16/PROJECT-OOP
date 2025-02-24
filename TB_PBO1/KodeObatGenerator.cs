using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_PBO1
{
    public static class KodeObatGenerator
    {
        public static string GenerateKodeObat(string namaObat, int counter)
        {
            // Format kode: NOB-YYYYMM-XXX (XXX adalah counter)
            string prefix = namaObat.Substring(0, 3).ToUpper(); // Ambil 3 huruf awal dari nama obat
            string datePart = DateTime.Now.ToString("yyyyMM"); // Tahun dan bulan
            string counterPart = counter.ToString("D3"); // Format 3 digit

            return $"{prefix}-{datePart}-{counterPart}";
        }
    }
}
