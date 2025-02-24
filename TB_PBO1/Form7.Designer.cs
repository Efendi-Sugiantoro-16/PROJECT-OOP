namespace TB_PBO1
{
    partial class Form7
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            dataGridViewHistory = new DataGridView();
            btnRefresh = new Button();
            lblTitle = new Label();
            panelSidebar = new Panel();
            BtnHome = new Button();
            BtnData = new Button();
            BtnView = new Button();
            BtnHistory = new Button();
            BtnLogout = new Button();
            txtCariHistory = new TextBox();
            lblCari = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).BeginInit();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewHistory
            // 
            dataGridViewHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHistory.Location = new Point(203, 62);
            dataGridViewHistory.Name = "dataGridViewHistory";
            dataGridViewHistory.RowHeadersWidth = 51;
            dataGridViewHistory.Size = new Size(854, 415);
            dataGridViewHistory.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom;
            btnRefresh.Location = new Point(570, 497);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(543, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(121, 37);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Riwayat";
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(76, 175, 80);
            panelSidebar.Controls.Add(BtnHome);
            panelSidebar.Controls.Add(BtnData);
            panelSidebar.Controls.Add(BtnView);
            panelSidebar.Controls.Add(BtnHistory);
            panelSidebar.Controls.Add(BtnLogout);
            panelSidebar.Location = new Point(-3, -4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(200, 545);
            panelSidebar.TabIndex = 4;
            // 
            // BtnHome
            // 
            BtnHome.BackColor = Color.White;
            BtnHome.FlatStyle = FlatStyle.Flat;
            BtnHome.Font = new Font("Arial", 12F, FontStyle.Bold);
            BtnHome.Location = new Point(15, 15);
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
            BtnData.Location = new Point(15, 105);
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
            BtnView.Location = new Point(15, 195);
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
            BtnHistory.Location = new Point(15, 285);
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
            BtnLogout.Location = new Point(15, 456);
            BtnLogout.Name = "BtnLogout";
            BtnLogout.Size = new Size(161, 74);
            BtnLogout.TabIndex = 4;
            BtnLogout.Text = "Logout";
            BtnLogout.UseVisualStyleBackColor = false;
            BtnLogout.Click += BtnLogout_Click;
            // 
            // txtCariHistory
            // 
            txtCariHistory.Location = new Point(795, 19);
            txtCariHistory.Name = "txtCariHistory";
            txtCariHistory.Size = new Size(262, 27);
            txtCariHistory.TabIndex = 5;
            txtCariHistory.TextChanged += txtCariHistory_TextChanged;
            // 
            // lblCari
            // 
            lblCari.AutoSize = true;
            lblCari.Location = new Point(754, 26);
            lblCari.Name = "lblCari";
            lblCari.Size = new Size(42, 20);
            lblCari.TabIndex = 6;
            lblCari.Text = "Cari :";
            // 
            // Form7
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(1069, 538);
            Controls.Add(lblCari);
            Controls.Add(txtCariHistory);
            Controls.Add(panelSidebar);
            Controls.Add(lblTitle);
            Controls.Add(btnRefresh);
            Controls.Add(dataGridViewHistory);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form7";
            Text = "History";
            Load += Form7_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).EndInit();
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTitle;
        private Panel panelSidebar;
        private Button BtnHome;
        private Button BtnData;
        private Button BtnView;
        private Button BtnHistory;
        private Button BtnLogout;
        private TextBox txtCariHistory;
        private Label lblCari;
    }
}
