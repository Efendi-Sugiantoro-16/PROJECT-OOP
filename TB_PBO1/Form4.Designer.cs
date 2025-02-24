using System;
using System.Drawing;
using System.Windows.Forms;

namespace TB_PBO1
{
    partial class Form4
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            dataGridViewObat = new DataGridView();
            txtKodeObat = new TextBox();
            txtNamaObat = new TextBox();
            txtKategori = new TextBox();
            txtDeskripsi = new TextBox();
            txtStok = new TextBox();
            txtCari = new TextBox();
            dtpTanggal = new DateTimePicker();
            lblKodeObat = new Label();
            lblNamaObat = new Label();
            lblJenisObat = new Label();
            lblKategoriObat = new Label();
            lblDeskripsi = new Label();
            lblTanggal = new Label();
            lblStok = new Label();
            lblCari = new Label();
            btnConfirm = new Button();
            btnBatal = new Button();
            btnDelete = new Button();
            btnExportPDF = new Button();
            panelSidebar = new Panel();
            BtnHome = new Button();
            BtnData = new Button();
            BtnView = new Button();
            BtnHistory = new Button();
            BtnLogout = new Button();
            cmbJenisObat = new ComboBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btnPilihObat = new Button();
            txtNamaMerek = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewObat).BeginInit();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewObat
            // 
            dataGridViewObat.BackgroundColor = Color.White;
            dataGridViewObat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewObat.Location = new Point(201, 50);
            dataGridViewObat.Name = "dataGridViewObat";
            dataGridViewObat.RowHeadersWidth = 51;
            dataGridViewObat.Size = new Size(769, 180);
            dataGridViewObat.TabIndex = 1;
            dataGridViewObat.CellContentClick += dataGridViewObat_CellContentClick;
            // 
            // txtKodeObat
            // 
            txtKodeObat.BackColor = Color.FromArgb(212, 225, 87);
            txtKodeObat.Location = new Point(420, 236);
            txtKodeObat.Name = "txtKodeObat";
            txtKodeObat.Size = new Size(300, 27);
            txtKodeObat.TabIndex = 2;
            // 
            // txtNamaObat
            // 
            txtNamaObat.BackColor = SystemColors.Window;
            txtNamaObat.Location = new Point(420, 274);
            txtNamaObat.Name = "txtNamaObat";
            txtNamaObat.Size = new Size(300, 27);
            txtNamaObat.TabIndex = 3;
            txtNamaObat.TextChanged += txtNamaObat_TextChanged;
            // 
            // txtKategori
            // 
            txtKategori.BackColor = Color.FromArgb(212, 225, 87);
            txtKategori.Location = new Point(420, 405);
            txtKategori.Name = "txtKategori";
            txtKategori.Size = new Size(300, 27);
            txtKategori.TabIndex = 4;
            // 
            // txtDeskripsi
            // 
            txtDeskripsi.Location = new Point(420, 445);
            txtDeskripsi.Name = "txtDeskripsi";
            txtDeskripsi.Size = new Size(300, 27);
            txtDeskripsi.TabIndex = 5;
            // 
            // txtStok
            // 
            txtStok.BackColor = Color.FromArgb(212, 225, 87);
            txtStok.Location = new Point(420, 485);
            txtStok.Name = "txtStok";
            txtStok.Size = new Size(300, 27);
            txtStok.TabIndex = 6;
            // 
            // txtCari
            // 
            txtCari.Location = new Point(420, 15);
            txtCari.Name = "txtCari";
            txtCari.Size = new Size(250, 27);
            txtCari.TabIndex = 7;
            txtCari.TextChanged += txtCari_TextChanged;
            // 
            // dtpTanggal
            // 
            dtpTanggal.Location = new Point(420, 525);
            dtpTanggal.Name = "dtpTanggal";
            dtpTanggal.Size = new Size(300, 27);
            dtpTanggal.TabIndex = 8;
            // 
            // lblKodeObat
            // 
            lblKodeObat.Location = new Point(320, 241);
            lblKodeObat.Name = "lblKodeObat";
            lblKodeObat.Size = new Size(100, 23);
            lblKodeObat.TabIndex = 10;
            lblKodeObat.Text = "Kode Obat:";
            // 
            // lblNamaObat
            // 
            lblNamaObat.Location = new Point(320, 278);
            lblNamaObat.Name = "lblNamaObat";
            lblNamaObat.Size = new Size(100, 23);
            lblNamaObat.TabIndex = 11;
            lblNamaObat.Text = "Nama Obat:";
            // 
            // lblJenisObat
            // 
            lblJenisObat.Location = new Point(320, 365);
            lblJenisObat.Name = "lblJenisObat";
            lblJenisObat.Size = new Size(100, 23);
            lblJenisObat.TabIndex = 12;
            lblJenisObat.Text = "Jenis Obat:";
            // 
            // lblKategoriObat
            // 
            lblKategoriObat.Location = new Point(320, 410);
            lblKategoriObat.Name = "lblKategoriObat";
            lblKategoriObat.Size = new Size(100, 23);
            lblKategoriObat.TabIndex = 13;
            lblKategoriObat.Text = "Kategori:";
            // 
            // lblDeskripsi
            // 
            lblDeskripsi.Location = new Point(320, 450);
            lblDeskripsi.Name = "lblDeskripsi";
            lblDeskripsi.Size = new Size(100, 23);
            lblDeskripsi.TabIndex = 14;
            lblDeskripsi.Text = "Deskripsi:";
            // 
            // lblTanggal
            // 
            lblTanggal.Location = new Point(320, 525);
            lblTanggal.Name = "lblTanggal";
            lblTanggal.Size = new Size(100, 23);
            lblTanggal.TabIndex = 15;
            lblTanggal.Text = "Tanggal:";
            // 
            // lblStok
            // 
            lblStok.Location = new Point(320, 490);
            lblStok.Name = "lblStok";
            lblStok.Size = new Size(100, 23);
            lblStok.TabIndex = 16;
            lblStok.Text = "Stok:";
            // 
            // lblCari
            // 
            lblCari.Location = new Point(362, 15);
            lblCari.Name = "lblCari";
            lblCari.Size = new Size(52, 23);
            lblCari.TabIndex = 17;
            lblCari.Text = "Cari:";
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.Lime;
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.Location = new Point(374, 558);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(100, 30);
            btnConfirm.TabIndex = 18;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.LightBlue;
            btnBatal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBatal.Location = new Point(489, 558);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(100, 30);
            btnBatal.TabIndex = 19;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(604, 558);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.TabIndex = 20;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnExportPDF
            // 
            btnExportPDF.BackColor = SystemColors.GradientActiveCaption;
            btnExportPDF.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportPDF.Location = new Point(800, 250);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(120, 30);
            btnExportPDF.TabIndex = 21;
            btnExportPDF.Text = "Export PDF";
            btnExportPDF.UseVisualStyleBackColor = false;
            btnExportPDF.Click += btnExportPDF_Click;
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(76, 175, 80);
            panelSidebar.Controls.Add(BtnHome);
            panelSidebar.Controls.Add(BtnData);
            panelSidebar.Controls.Add(BtnView);
            panelSidebar.Controls.Add(BtnHistory);
            panelSidebar.Controls.Add(BtnLogout);
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(200, 594);
            panelSidebar.TabIndex = 1;
            // 
            // BtnHome
            // 
            BtnHome.BackColor = Color.White;
            BtnHome.FlatStyle = FlatStyle.Flat;
            BtnHome.Font = new Font("Arial", 12F, FontStyle.Bold);
            BtnHome.Location = new Point(21, 20);
            BtnHome.Name = "BtnHome";
            BtnHome.Size = new Size(161, 74);
            BtnHome.TabIndex = 0;
            BtnHome.Text = "Home";
            BtnHome.UseVisualStyleBackColor = false;
            BtnHome.Click += BtnHome_Click;
            // 
            // BtnData
            // 
            BtnData.BackColor = Color.White;
            BtnData.FlatStyle = FlatStyle.Flat;
            BtnData.Font = new Font("Arial", 12F, FontStyle.Bold);
            BtnData.Location = new Point(21, 110);
            BtnData.Name = "BtnData";
            BtnData.Size = new Size(161, 74);
            BtnData.TabIndex = 1;
            BtnData.Text = "Data Input";
            BtnData.UseVisualStyleBackColor = false;
            BtnData.Click += BtnData_Click;
            // 
            // BtnView
            // 
            BtnView.BackColor = Color.White;
            BtnView.FlatStyle = FlatStyle.Flat;
            BtnView.Font = new Font("Arial", 12F, FontStyle.Bold);
            BtnView.Location = new Point(21, 200);
            BtnView.Name = "BtnView";
            BtnView.Size = new Size(161, 74);
            BtnView.TabIndex = 2;
            BtnView.Text = "View Graphics";
            BtnView.UseVisualStyleBackColor = false;
            BtnView.Click += BtnView_Click;
            // 
            // BtnHistory
            // 
            BtnHistory.BackColor = Color.White;
            BtnHistory.FlatStyle = FlatStyle.Flat;
            BtnHistory.Font = new Font("Arial", 12F, FontStyle.Bold);
            BtnHistory.Location = new Point(21, 290);
            BtnHistory.Name = "BtnHistory";
            BtnHistory.Size = new Size(161, 74);
            BtnHistory.TabIndex = 3;
            BtnHistory.Text = "History";
            BtnHistory.UseVisualStyleBackColor = false;
            BtnHistory.Click += BtnHistory_Click;
            // 
            // BtnLogout
            // 
            BtnLogout.BackColor = Color.Red;
            BtnLogout.FlatStyle = FlatStyle.Flat;
            BtnLogout.Font = new Font("Arial", 12F, FontStyle.Bold);
            BtnLogout.ForeColor = Color.White;
            BtnLogout.Location = new Point(21, 467);
            BtnLogout.Name = "BtnLogout";
            BtnLogout.Size = new Size(161, 74);
            BtnLogout.TabIndex = 4;
            BtnLogout.Text = "Logout";
            BtnLogout.UseVisualStyleBackColor = false;
            BtnLogout.Click += BtnLogout_Click;
            // 
            // cmbJenisObat
            // 
            cmbJenisObat.Items.AddRange(new object[] { "Tablet", "Kapsul", "Sirup", "Cair", "Salep", "Injeksi", "Drops", "Suppositoria" });
            cmbJenisObat.Location = new Point(420, 365);
            cmbJenisObat.Name = "cmbJenisObat";
            cmbJenisObat.Size = new Size(300, 28);
            cmbJenisObat.TabIndex = 9;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // btnPilihObat
            // 
            btnPilihObat.BackColor = SystemColors.HotTrack;
            btnPilihObat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPilihObat.Location = new Point(389, 405);
            btnPilihObat.Name = "btnPilihObat";
            btnPilihObat.Size = new Size(31, 29);
            btnPilihObat.TabIndex = 22;
            btnPilihObat.UseVisualStyleBackColor = false;
            btnPilihObat.Click += btnPilihObat_Click;
            // 
            // txtNamaMerek
            // 
            txtNamaMerek.BackColor = Color.FromArgb(212, 225, 87);
            txtNamaMerek.Location = new Point(420, 315);
            txtNamaMerek.Name = "txtNamaMerek";
            txtNamaMerek.Size = new Size(300, 27);
            txtNamaMerek.TabIndex = 23;
            txtNamaMerek.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.Location = new Point(320, 318);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 24;
            label1.Text = "Nama Merek:";
            // 
            // Form4
            // 
            BackColor = SystemColors.Info;
            ClientSize = new Size(982, 611);
            Controls.Add(label1);
            Controls.Add(txtNamaMerek);
            Controls.Add(btnPilihObat);
            Controls.Add(panelSidebar);
            Controls.Add(dataGridViewObat);
            Controls.Add(txtKodeObat);
            Controls.Add(txtNamaObat);
            Controls.Add(txtKategori);
            Controls.Add(txtDeskripsi);
            Controls.Add(txtStok);
            Controls.Add(txtCari);
            Controls.Add(dtpTanggal);
            Controls.Add(cmbJenisObat);
            Controls.Add(lblKodeObat);
            Controls.Add(lblNamaObat);
            Controls.Add(lblJenisObat);
            Controls.Add(lblKategoriObat);
            Controls.Add(lblDeskripsi);
            Controls.Add(lblTanggal);
            Controls.Add(lblStok);
            Controls.Add(lblCari);
            Controls.Add(btnConfirm);
            Controls.Add(btnBatal);
            Controls.Add(btnDelete);
            Controls.Add(btnExportPDF);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form4";
            Text = "TRASMEDIS";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewObat).EndInit();
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridViewObat;
        private TextBox txtCari;
        private Label lblCari;
        private Label lblKodeObat;
        private Label lblNamaObat;
        private TextBox txtNamaObat;
        private Label lblKategoriObat;
        private TextBox txtKategori;
        private ContextMenuStrip contextMenuStrip1;
        private Label lblDeskripsi;
        private TextBox txtDeskripsi;
        private Button btnConfirm;
        private Button btnBatal;
        private Button btnDelete;
        private DateTimePicker dtpTanggal;
        private Label lblTanggal;
        private Label lblJenisObat;
        private TextBox txtKodeObat;
        private Panel panelSidebar;
        private Button BtnLogout;
        private Button BtnHistory;
        private Button BtnView;
        private Button BtnData;
        private Button BtnHome;
        public ComboBox cmbJenisObat;
        private TextBox txtStok;
        private Label lblStok;
        private Button btnExportPDF;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btnPilihObat;
        private TextBox txtNamaMerek;
        private Label label1;
    }
}
