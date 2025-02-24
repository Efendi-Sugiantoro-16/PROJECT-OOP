# PROJECT-OOP

## Deskripsi Proyek
**PROJECT-OOP** adalah aplikasi berbasis C# yang menggunakan konsep Pemrograman Berorientasi Objek (OOP) untuk mengelola data pengguna, obat, stok obat, dan riwayat perubahan stok dalam sistem manajemen inventaris obat. Aplikasi ini menggunakan MongoDB sebagai database NoSQL untuk menyimpan data secara permanen.

## Fitur Utama
- **Manajemen Pengguna:** Registrasi, login, dan peran pengguna seperti dokter, perawat, atau admin.
- **Manajemen Obat:** Tambah, ubah, hapus, dan lihat informasi obat.
- **Manajemen Stok Obat:** Pemantauan jumlah stok obat dan pembaruannya.
- **Riwayat Perubahan Stok:** Mencatat semua perubahan stok obat yang dilakukan oleh pengguna.
- **Antarmuka GUI:** Menggunakan Windows Forms untuk tampilan interaktif.

## Teknologi yang Digunakan
- **Bahasa Pemrograman:** C#
- **Framework:** .NET Windows Forms
- **Database:** MongoDB (dijalankan melalui Laragon atau MongoDB lokal)
- **Pustaka Pendukung:**
  - `MongoDB.Driver` untuk koneksi ke MongoDB
  - `BCrypt.Net` untuk enkripsi password
  - `System.Windows.Forms` untuk antarmuka pengguna

## Instalasi dan Konfigurasi
### 1. Prasyarat
- **Visual Studio** (disarankan versi terbaru dengan .NET Framework)
- **MongoDB** (terinstal dan berjalan di `localhost:27017`)
- **Laragon** (opsional, jika menggunakan MongoDB dari Laragon)

### 2. Clone Repository
```sh
 git clone https://github.com/username/PROJECT-OOP.git
 cd PROJECT-OOP
```

### 3. Instal Dependensi
Buka **Package Manager Console** di Visual Studio dan jalankan:
```sh
 Install-Package MongoDB.Driver
 Install-Package BCrypt.Net-Next
```

### 4. Jalankan Aplikasi
1. Buka `PROJECT-OOP.sln` di Visual Studio.
2. Pastikan MongoDB berjalan di latar belakang.
3. Tekan **F5** untuk menjalankan aplikasi.

## Struktur Proyek
```
PROJECT-OOP/
│-- TB_PBO1/
│   ├── Forms/
│   │   ├── Form1.cs  (Login Form)
│   │   ├── Form2.cs  (Register Form)
│   │   ├── Form3.cs  (Dashboard)
│   │   ├── FormStock.cs (Manajemen Stok)
│   │   ├── FormRiwayat.cs (Riwayat Perubahan Stok)
│   ├── Models/
│   │   ├── User.cs
│   │   ├── Medicine.cs
│   │   ├── Stock.cs
│   │   ├── Riwayat.cs
│   ├── Database/
│   │   ├── Connection.cs (Koneksi MongoDB)
│   ├── Program.cs (Main Program)
│   ├── App.config (Konfigurasi)
└── README.md
```

## Penggunaan
### 1. Login dan Registrasi
- Jalankan aplikasi dan daftar pengguna baru jika belum memiliki akun.
- Login dengan email dan password yang terdaftar.

### 2. Manajemen Obat
- Tambahkan obat baru beserta jenis, kategori, dan tanggal kedaluwarsa.
- Edit atau hapus obat jika diperlukan.

### 3. Manajemen Stok Obat
- Perbarui jumlah stok obat yang tersedia.
- Pantau stok yang hampir habis.

### 4. Riwayat Perubahan Stok
- Semua perubahan yang dilakukan oleh pengguna akan dicatat dalam riwayat.
- Riwayat dapat difilter berdasarkan tanggal atau pengguna.

## Kontribusi
1. **Fork** repository ini.
2. **Clone** repo ke lokal: `git clone https://github.com/username/PROJECT-OOP.git`
3. Buat **branch** baru untuk fitur yang akan ditambahkan: `git checkout -b feature-name`
4. **Commit** perubahan: `git commit -m 'Menambahkan fitur X'`
5. **Push** ke GitHub: `git push origin feature-name`
6. Buat **Pull Request**.

## Lisensi
Proyek ini dilisensikan di bawah **MIT License**.

