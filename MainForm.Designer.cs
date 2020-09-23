namespace TradingAutoTerminal
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, "1,4,2,3");
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, "1,4,3,2");
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpgGraph = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnAddCRSI = new System.Windows.Forms.Button();
            this.btnAddMACD = new System.Windows.Forms.Button();
            this.btnAddCandles = new System.Windows.Forms.Button();
            this.lblCrsi = new System.Windows.Forms.Label();
            this.btnCRSI = new System.Windows.Forms.Button();
            this.lblMacd = new System.Windows.Forms.Label();
            this.btnMACD = new System.Windows.Forms.Button();
            this.lblLoad = new System.Windows.Forms.Label();
            this.btnLoadCandles = new System.Windows.Forms.Button();
            this.tpgSettings = new System.Windows.Forms.TabPage();
            this.txtbxCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkMACDHistogram = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpgGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tpgSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(760, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(760, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(760, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpgGraph);
            this.tabControl1.Controls.Add(this.tpgSettings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 379);
            this.tabControl1.TabIndex = 3;
            // 
            // tpgGraph
            // 
            this.tpgGraph.Controls.Add(this.chart1);
            this.tpgGraph.Controls.Add(this.groupBox1);
            this.tpgGraph.Location = new System.Drawing.Point(4, 22);
            this.tpgGraph.Name = "tpgGraph";
            this.tpgGraph.Padding = new System.Windows.Forms.Padding(3);
            this.tpgGraph.Size = new System.Drawing.Size(752, 353);
            this.tpgGraph.TabIndex = 0;
            this.tpgGraph.Text = "График";
            this.tpgGraph.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.LineWidth = 2;
            chartArea1.Name = "ChartArea1";
            chartArea2.Name = "ChartArea2";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series1.BackSecondaryColor = System.Drawing.Color.Red;
            series1.BorderColor = System.Drawing.Color.Black;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Color = System.Drawing.Color.Green;
            series1.Name = "Series1";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.ShadowOffset = 4;
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea2";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(546, 347);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chartTraiding";
            this.chart1.Click += new System.EventHandler(this.сhart1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkMACDHistogram);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.btnAddCRSI);
            this.groupBox1.Controls.Add(this.btnAddMACD);
            this.groupBox1.Controls.Add(this.btnAddCandles);
            this.groupBox1.Controls.Add(this.lblCrsi);
            this.groupBox1.Controls.Add(this.btnCRSI);
            this.groupBox1.Controls.Add(this.lblMacd);
            this.groupBox1.Controls.Add(this.btnMACD);
            this.groupBox1.Controls.Add(this.lblLoad);
            this.groupBox1.Controls.Add(this.btnLoadCandles);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(549, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 347);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры графика";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "2",
            "10",
            "50",
            "100",
            "150",
            "200",
            "250"});
            this.comboBox1.Location = new System.Drawing.Point(101, 133);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(73, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Text = "50";
            // 
            // btnAddCRSI
            // 
            this.btnAddCRSI.Location = new System.Drawing.Point(11, 206);
            this.btnAddCRSI.Name = "btnAddCRSI";
            this.btnAddCRSI.Size = new System.Drawing.Size(75, 34);
            this.btnAddCRSI.TabIndex = 7;
            this.btnAddCRSI.Text = "Построить CRSI";
            this.btnAddCRSI.UseVisualStyleBackColor = true;
            this.btnAddCRSI.Click += new System.EventHandler(this.btnAddCRSI_Click);
            // 
            // btnAddMACD
            // 
            this.btnAddMACD.Location = new System.Drawing.Point(11, 166);
            this.btnAddMACD.Name = "btnAddMACD";
            this.btnAddMACD.Size = new System.Drawing.Size(75, 34);
            this.btnAddMACD.TabIndex = 7;
            this.btnAddMACD.Text = "Построить MACD";
            this.btnAddMACD.UseVisualStyleBackColor = true;
            this.btnAddMACD.Click += new System.EventHandler(this.btnAddMACD_Click);
            // 
            // btnAddCandles
            // 
            this.btnAddCandles.Location = new System.Drawing.Point(11, 125);
            this.btnAddCandles.Name = "btnAddCandles";
            this.btnAddCandles.Size = new System.Drawing.Size(75, 34);
            this.btnAddCandles.TabIndex = 6;
            this.btnAddCandles.Text = "Построить свечи";
            this.btnAddCandles.UseVisualStyleBackColor = true;
            this.btnAddCandles.Click += new System.EventHandler(this.btnAddCandles_Click);
            // 
            // lblCrsi
            // 
            this.lblCrsi.AutoSize = true;
            this.lblCrsi.Location = new System.Drawing.Point(98, 100);
            this.lblCrsi.Name = "lblCrsi";
            this.lblCrsi.Size = new System.Drawing.Size(76, 13);
            this.lblCrsi.TabIndex = 5;
            this.lblCrsi.Text = "Не рассчитан";
            // 
            // btnCRSI
            // 
            this.btnCRSI.Location = new System.Drawing.Point(11, 95);
            this.btnCRSI.Name = "btnCRSI";
            this.btnCRSI.Size = new System.Drawing.Size(75, 23);
            this.btnCRSI.TabIndex = 4;
            this.btnCRSI.Text = "CRSI";
            this.btnCRSI.UseVisualStyleBackColor = true;
            this.btnCRSI.Click += new System.EventHandler(this.btnCRSI_Click);
            // 
            // lblMacd
            // 
            this.lblMacd.AutoSize = true;
            this.lblMacd.Location = new System.Drawing.Point(98, 70);
            this.lblMacd.Name = "lblMacd";
            this.lblMacd.Size = new System.Drawing.Size(76, 13);
            this.lblMacd.TabIndex = 3;
            this.lblMacd.Text = "Не рассчитан";
            // 
            // btnMACD
            // 
            this.btnMACD.Location = new System.Drawing.Point(11, 65);
            this.btnMACD.Name = "btnMACD";
            this.btnMACD.Size = new System.Drawing.Size(75, 23);
            this.btnMACD.TabIndex = 2;
            this.btnMACD.Text = "MACD";
            this.btnMACD.UseVisualStyleBackColor = true;
            this.btnMACD.Click += new System.EventHandler(this.btnMACD_Click);
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.Location = new System.Drawing.Point(96, 34);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(66, 13);
            this.lblLoad.TabIndex = 1;
            this.lblLoad.Text = "Нет данных";
            // 
            // btnLoadCandles
            // 
            this.btnLoadCandles.Location = new System.Drawing.Point(11, 24);
            this.btnLoadCandles.Name = "btnLoadCandles";
            this.btnLoadCandles.Size = new System.Drawing.Size(75, 34);
            this.btnLoadCandles.TabIndex = 0;
            this.btnLoadCandles.Text = "Загрузить свечи";
            this.btnLoadCandles.UseVisualStyleBackColor = true;
            this.btnLoadCandles.Click += new System.EventHandler(this.btnLoadCandles_Click);
            // 
            // tpgSettings
            // 
            this.tpgSettings.Controls.Add(this.txtbxCount);
            this.tpgSettings.Controls.Add(this.label1);
            this.tpgSettings.Location = new System.Drawing.Point(4, 22);
            this.tpgSettings.Name = "tpgSettings";
            this.tpgSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpgSettings.Size = new System.Drawing.Size(752, 353);
            this.tpgSettings.TabIndex = 1;
            this.tpgSettings.Text = "Настройки";
            this.tpgSettings.UseVisualStyleBackColor = true;
            // 
            // txtbxCount
            // 
            this.txtbxCount.Location = new System.Drawing.Point(197, 4);
            this.txtbxCount.Name = "txtbxCount";
            this.txtbxCount.Size = new System.Drawing.Size(44, 20);
            this.txtbxCount.TabIndex = 1;
            this.txtbxCount.Text = "50";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество отображаемых свечей";
            // 
            // checkMACDHistogram
            // 
            this.checkMACDHistogram.AutoSize = true;
            this.checkMACDHistogram.Location = new System.Drawing.Point(100, 174);
            this.checkMACDHistogram.Name = "checkMACDHistogram";
            this.checkMACDHistogram.Size = new System.Drawing.Size(94, 17);
            this.checkMACDHistogram.TabIndex = 9;
            this.checkMACDHistogram.Text = "Гистограмма";
            this.checkMACDHistogram.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Trading autoterminal v0.0.1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpgGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpgSettings.ResumeLayout(false);
            this.tpgSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpgGraph;
        private System.Windows.Forms.TabPage tpgSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLoad;
        private System.Windows.Forms.Button btnLoadCandles;
        private System.Windows.Forms.Button btnAddCRSI;
        private System.Windows.Forms.Button btnAddMACD;
        private System.Windows.Forms.Button btnAddCandles;
        private System.Windows.Forms.Label lblCrsi;
        private System.Windows.Forms.Button btnCRSI;
        private System.Windows.Forms.Label lblMacd;
        private System.Windows.Forms.Button btnMACD;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox txtbxCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkMACDHistogram;
    }
}

