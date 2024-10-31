namespace WindowsFormsApp1
{
    partial class Form1_mainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView_stockData = new System.Windows.Forms.DataGridView();
            this.button_loadData = new System.Windows.Forms.Button();
            this.comboBox_period = new System.Windows.Forms.ComboBox();
            this.comboBox_stockSymbol = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.chart_OHLC = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_stockData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OHLC)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_stockData
            // 
            this.dataGridView_stockData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_stockData.Location = new System.Drawing.Point(2, 12);
            this.dataGridView_stockData.Name = "dataGridView_stockData";
            this.dataGridView_stockData.Size = new System.Drawing.Size(685, 453);
            this.dataGridView_stockData.TabIndex = 0;
            // 
            // button_loadData
            // 
            this.button_loadData.Location = new System.Drawing.Point(612, 550);
            this.button_loadData.Name = "button_loadData";
            this.button_loadData.Size = new System.Drawing.Size(75, 23);
            this.button_loadData.TabIndex = 1;
            this.button_loadData.Text = "Load Stock";
            this.button_loadData.UseVisualStyleBackColor = true;
            this.button_loadData.Click += new System.EventHandler(this.button_loadData_Click);
            // 
            // comboBox_period
            // 
            this.comboBox_period.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_period.FormattingEnabled = true;
            this.comboBox_period.Items.AddRange(new object[] {
            "Day",
            "Week",
            "Month"});
            this.comboBox_period.Location = new System.Drawing.Point(335, 629);
            this.comboBox_period.Name = "comboBox_period";
            this.comboBox_period.Size = new System.Drawing.Size(121, 21);
            this.comboBox_period.TabIndex = 2;
            // 
            // comboBox_stockSymbol
            // 
            this.comboBox_stockSymbol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_stockSymbol.FormattingEnabled = true;
            this.comboBox_stockSymbol.Items.AddRange(new object[] {
            "AAPL",
            "DIS",
            "IBM",
            "INTC",
            "PAYX"});
            this.comboBox_stockSymbol.Location = new System.Drawing.Point(56, 629);
            this.comboBox_stockSymbol.Name = "comboBox_stockSymbol";
            this.comboBox_stockSymbol.Size = new System.Drawing.Size(121, 21);
            this.comboBox_stockSymbol.TabIndex = 3;
            this.comboBox_stockSymbol.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(539, 630);
            this.dateTimePicker_startDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_startDate.TabIndex = 4;
            this.dateTimePicker_startDate.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(775, 630);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_endDate.TabIndex = 5;
            // 
            // chart_OHLC
            // 
            chartArea1.Name = "chartArea_candlestick";
            chartArea2.Name = "chartArea_volume";
            this.chart_OHLC.ChartAreas.Add(chartArea1);
            this.chart_OHLC.ChartAreas.Add(chartArea2);
            legend1.Name = "Legend1";
            this.chart_OHLC.Legends.Add(legend1);
            this.chart_OHLC.Location = new System.Drawing.Point(693, 12);
            this.chart_OHLC.Name = "chart_OHLC";
            series1.ChartArea = "chartArea_candlestick";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceUpColor=Lime, PriceDownColor=Red";
            series1.Legend = "Legend1";
            series1.Name = "Candlestick";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "chartArea_volume";
            series2.Legend = "Legend1";
            series2.Name = "Volume";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chart_OHLC.Series.Add(series1);
            this.chart_OHLC.Series.Add(series2);
            this.chart_OHLC.Size = new System.Drawing.Size(660, 453);
            this.chart_OHLC.TabIndex = 6;
            this.chart_OHLC.Text = "chart1";
            this.chart_OHLC.Click += new System.EventHandler(this.chart_OHLC_Click);
            // 
            // Form1_mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 662);
            this.Controls.Add(this.chart_OHLC);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Controls.Add(this.comboBox_stockSymbol);
            this.Controls.Add(this.comboBox_period);
            this.Controls.Add(this.button_loadData);
            this.Controls.Add(this.dataGridView_stockData);
            this.Name = "Form1_mainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_stockData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OHLC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_stockData;
        private System.Windows.Forms.Button button_loadData;
        private System.Windows.Forms.ComboBox comboBox_period;
        private System.Windows.Forms.ComboBox comboBox_stockSymbol;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_OHLC;
    }
}

