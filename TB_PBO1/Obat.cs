using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TB_PBO1
{
    public class Obat
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("KodeObat")]
        public string KodeObat { get; set; }

        [BsonElement("NamaObat")]
        public string NamaObat { get; set; }

        [BsonElement("NamaMerek")] // Tambahkan NamaMerek
        public string NamaMerek { get; set; }

        [BsonElement("JenisObat")]
        public string JenisObat { get; set; }

        [BsonElement("Kategori")]
        public string Kategori { get; set; }

        [BsonElement("Deskripsi")]
        public string Deskripsi { get; set; }

        [BsonElement("Stok")]
        public int Stok { get; set; }

        [BsonElement("Tanggal")]
        public DateTime Tanggal { get; set; }
    }
}
