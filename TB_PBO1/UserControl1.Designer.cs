namespace TB_PBO1
{
    partial class UserControl1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox comboBoxChartType;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            btnRefresh = new Button();
            comboBoxChartType = new ComboBox();
            comboBoxNama = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(14, 14);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Stok Obat";
            chart1.Series.Add(series2);
            chart1.Size = new Size(708, 456);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(324, 476);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // comboBoxChartType
            // 
            comboBoxChartType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxChartType.FormattingEnabled = true;
            comboBoxChartType.Items.AddRange(new object[] { "Bagan (Column)", "Pie Chart" });
            comboBoxChartType.Location = new Point(453, 478);
            comboBoxChartType.Name = "comboBoxChartType";
            comboBoxChartType.Size = new Size(150, 28);
            comboBoxChartType.TabIndex = 3;
            comboBoxChartType.SelectedIndexChanged += comboBoxChartType_SelectedIndexChanged;
            // 
            // comboBoxNama
            // 
            comboBoxNama.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxNama.FormattingEnabled = true;
            comboBoxNama.Location = new Point(100, 478);
            comboBoxNama.Name = "comboBoxNama";
            comboBoxNama.Size = new Size(200, 28);
            comboBoxNama.TabIndex = 1;
            comboBoxNama.SelectedIndexChanged += comboBoxNama_SelectedIndexChanged;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(chart1);
            Controls.Add(comboBoxNama);
            Controls.Add(btnRefresh);
            Controls.Add(comboBoxChartType);
            Name = "UserControl1";
            Size = new Size(735, 524);
            Load += UserControl1_Load;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBoxNama;
    }
}
