namespace TB_PBO1
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox4 = new PictureBox();
            BtnHome = new Button();
            BtnData = new Button();
            BtnView = new Button();
            BtnHistory = new Button();
            panelSidebar = new Panel();
            BtnLogout = new Button();
            pictureBox3 = new PictureBox();
            pictureBox5 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(744, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(230, 244);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(339, 122);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(417, 427);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(188, 1);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(240, 216);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 4;
            pictureBox4.TabStop = false;
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
            BtnData.Click += BtnDataInput_Click;
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
            BtnView.Click += BtnViewGraphics_Click;
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
            panelSidebar.Size = new Size(200, 550);
            panelSidebar.TabIndex = 0;
            // 
            // BtnLogout
            // 
            BtnLogout.BackColor = Color.Red;
            BtnLogout.FlatStyle = FlatStyle.Flat;
            BtnLogout.Font = new Font("Arial", 12F, FontStyle.Bold);
            BtnLogout.ForeColor = Color.White;
            BtnLogout.Location = new Point(21, 461);
            BtnLogout.Name = "BtnLogout";
            BtnLogout.Size = new Size(161, 74);
            BtnLogout.TabIndex = 4;
            BtnLogout.Text = "Logout";
            BtnLogout.UseVisualStyleBackColor = false;
            BtnLogout.Click += BtnLogout_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(765, 339);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(195, 196);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(206, 386);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(165, 163);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 6;
            pictureBox5.TabStop = false;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(972, 547);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(panelSidebar);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form3";
            Text = "TRASMEDIS";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox4;
        private Button BtnHome;
        private Button BtnData;
        private Button BtnView;
        private Button BtnHistory;
        private Panel panelSidebar;
        private Button BtnLogout;
        private PictureBox pictureBox3;
        private PictureBox pictureBox5;
    }
}