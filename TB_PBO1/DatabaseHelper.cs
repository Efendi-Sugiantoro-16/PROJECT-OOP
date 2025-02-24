using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TB_PBO1
{
    public class DatabaseHelper
    {
        private readonly IMongoCollection<Obat> _obatCollection;

        public DatabaseHelper()
        {
            // Koneksi ke MongoDB
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("InventarisObat");
            _obatCollection = database.GetCollection<Obat>("obat");
        }

        // Ambil semua data obat
        public List<Obat> GetAllObat()
        {
            return _obatCollection.Find(obat => true).ToList();
        }

        // Ambil data obat berdasarkan kategori
        public List<Obat> GetObatByKategori(string kategori)
        {
            return _obatCollection.Find(obat => obat.Kategori == kategori).ToList();
        }

        // Ambil semua kategori obat unik
        public List<string> GetAllKategori()
        {
            return _obatCollection.AsQueryable().Select(obat => obat.Kategori).Distinct().ToList();
        }

        // Tambahkan metode untuk mendapatkan total stok berdasarkan kategori
        public Dictionary<string, int> GetTotalStokByKategori()
        {
            var obatList = GetAllObat();
            return obatList
                .GroupBy(o => o.Kategori)
                .ToDictionary(g => g.Key, g => g.Sum(o => o.Stok));
        }
    }
}
