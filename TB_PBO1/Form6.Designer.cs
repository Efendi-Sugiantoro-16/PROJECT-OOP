namespace TB_PBO1
{
    partial class Form6
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewKategori;
        private System.Windows.Forms.Button btnPilih;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Label lblJudul;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            dataGridViewKategori = new DataGridView();
            btnPilih = new Button();
            btnBatal = new Button();
            lblJudul = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKategori).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewKategori
            // 
            dataGridViewKategori.AllowUserToAddRows = false;
            dataGridViewKategori.AllowUserToDeleteRows = false;
            dataGridViewKategori.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewKategori.BackgroundColor = SystemColors.Window;
            dataGridViewKategori.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewKategori.Location = new Point(16, 40);
            dataGridViewKategori.Name = "dataGridViewKategori";
            dataGridViewKategori.ReadOnly = true;
            dataGridViewKategori.RowHeadersWidth = 51;
            dataGridViewKategori.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewKategori.Size = new Size(379, 247);
            dataGridViewKategori.TabIndex = 1;
            // 
            // btnPilih
            // 
            btnPilih.BackColor = Color.LawnGreen;
            btnPilih.Font = new Font("Calibri", 10.2F, FontStyle.Bold);
            btnPilih.Location = new Point(68, 318);
            btnPilih.Name = "btnPilih";
            btnPilih.Size = new Size(101, 46);
            btnPilih.TabIndex = 2;
            btnPilih.Text = "Pilih";
            btnPilih.UseVisualStyleBackColor = false;
            btnPilih.Click += btnPilih_Click;
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.Red;
            btnBatal.Font = new Font("Calibri", 10.2F, FontStyle.Bold);
            btnBatal.Location = new Point(237, 318);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(101, 46);
            btnBatal.TabIndex = 3;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblJudul.Location = new Point(68, 9);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(296, 28);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Pilih Nama dan Kategori Obat";
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(411, 406);
            Controls.Add(btnBatal);
            Controls.Add(btnPilih);
            Controls.Add(dataGridViewKategori);
            Controls.Add(lblJudul);
            Font = new Font("Microsoft Sans Serif", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form6";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Daftar Obat";
            Load += Form6_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewKategori).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
