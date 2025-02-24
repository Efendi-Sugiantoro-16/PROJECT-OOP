namespace TB_PBO1
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            panelSidebar = new Panel();
            BtnHome = new Button();
            BtnData = new Button();
            BtnView = new Button();
            BtnHistory = new Button();
            BtnLogout = new Button();
            panelGraphics = new Panel();
            panelSidebar.SuspendLayout();
            SuspendLayout();
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
            panelSidebar.TabIndex = 23;
            // 
            // BtnHome
            // 
            BtnHome.BackColor = Color.White;
            BtnHome.FlatStyle = FlatStyle.Flat;
            BtnHome.Font = new Font("Arial", 12F, FontStyle.Bold);
            BtnHome.Location = new Point(22, 21);
            BtnHome.Name = "BtnHome";
            BtnHome.Size = new Size(161, 74);
            BtnHome.TabIndex = 0;
            BtnHome.Text = "Home";
            BtnHome.UseVisualStyleBackColor = false;
            BtnHome.Click += btnHome_Click;
            // 
            // BtnData
            // 
            BtnData.BackColor = Color.White;
            BtnData.FlatStyle = FlatStyle.Flat;
            BtnData.Font = new Font("Arial", 12F, FontStyle.Bold);
            BtnData.Location = new Point(22, 111);
            BtnData.Name = "BtnData";
            BtnData.Size = new Size(161, 74);
            BtnData.TabIndex = 1;
            BtnData.Text = "Data Input";
            BtnData.UseVisualStyleBackColor = false;
            BtnData.Click += btnData_Click;
            // 
            // BtnView
            // 
            BtnView.BackColor = Color.White;
            BtnView.FlatStyle = FlatStyle.Flat;
            BtnView.Font = new Font("Arial", 12F, FontStyle.Bold);
            BtnView.Location = new Point(22, 201);
            BtnView.Name = "BtnView";
            BtnView.Size = new Size(161, 74);
            BtnView.TabIndex = 2;
            BtnView.Text = "View Graphics";
            BtnView.UseVisualStyleBackColor = false;
            BtnView.Click += btnView_Click;
            // 
            // BtnHistory
            // 
            BtnHistory.BackColor = Color.White;
            BtnHistory.FlatStyle = FlatStyle.Flat;
            BtnHistory.Font = new Font("Arial", 12F, FontStyle.Bold);
            BtnHistory.Location = new Point(22, 291);
            BtnHistory.Name = "BtnHistory";
            BtnHistory.Size = new Size(161, 74);
            BtnHistory.TabIndex = 3;
            BtnHistory.Text = "History";
            BtnHistory.UseVisualStyleBackColor = false;
            BtnHistory.Click += btnHistory_Click;
            // 
            // BtnLogout
            // 
            BtnLogout.BackColor = Color.Red;
            BtnLogout.FlatStyle = FlatStyle.Flat;
            BtnLogout.Font = new Font("Arial", 12F, FontStyle.Bold);
            BtnLogout.ForeColor = Color.White;
            BtnLogout.Location = new Point(22, 467);
            BtnLogout.Name = "BtnLogout";
            BtnLogout.Size = new Size(161, 74);
            BtnLogout.TabIndex = 4;
            BtnLogout.Text = "Logout";
            BtnLogout.UseVisualStyleBackColor = false;
            BtnLogout.Click += BtnLogout_Click;
            // 
            // panelGraphics
            // 
            panelGraphics.Location = new Point(225, 11);
            panelGraphics.Name = "panelGraphics";
            panelGraphics.Size = new Size(735, 524);
            panelGraphics.TabIndex = 3;
            panelGraphics.Paint += panelGraphics_Paint;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(972, 547);
            Controls.Add(panelSidebar);
            Controls.Add(panelGraphics);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form5";
            Text = "TRASMEDIS";
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelSidebar;
        private Button BtnLogout;
        private Button BtnHistory;
        private Button BtnView;
        private Button BtnData;
        private Button BtnHome;
        private Panel panelGraphics;
    }
}