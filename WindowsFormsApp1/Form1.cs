using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;



namespace WindowsFormsApp1
{





    public partial class Form1_mainForm : Form
    {
        public Form1_mainForm()
        {
            InitializeComponent();
        }



        /// COMMENT FURTHER. ADDED THIS
        private void button_loadData_Click(object sender, EventArgs e)
        {
            /// Get user-selected values
            string stockSymbol = comboBox_stockSymbol.SelectedItem?.ToString();
            string period = comboBox_period.SelectedItem?.ToString();
            DateTime startDate = dateTimePicker_startDate.Value;
            DateTime endDate = dateTimePicker_endDate.Value;

            /// Check that the stock symbol and period are selected
            if (string.IsNullOrEmpty(stockSymbol) || string.IsNullOrEmpty(period))
            {
                MessageBox.Show("Please select both a stock symbol and a period.");
                return;
            }

            
            ///Based on user input, select the appropriate csv file from the Stock Data folder
            string filePath = $"Stock Data/{stockSymbol}-{period}.csv";




            DisplayData(filePath, startDate, endDate);



        }





        private List<StockData> LoadCsvData(string filePath, DateTime startDate, DateTime endDate)
        {
            var stockDataList = File.ReadAllLines(filePath)
                .Skip(1) // Skip header line
                .Select(line =>
                {
                    var values = line.Split(',');
                    return new StockData
                    {
                        Date = DateTime.Parse(values[0]),
                        Open = double.Parse(values[1]),
                        High = double.Parse(values[2]),
                        Low = double.Parse(values[3]),
                        Close = double.Parse(values[4]),
                        Volume = double.Parse(values[5])
                    };
                })
                .Where(data => data.Date >= startDate && data.Date <= endDate) // Filter by date
                .ToList();

            return stockDataList;
        }




        private void DisplayData(string filePath, DateTime startDate, DateTime endDate)
        {
            var stockDataList = LoadCsvData(filePath, startDate, endDate);

            // Bind to DataGridView
            dataGridView_stockData.DataSource = stockDataList;

            // Populate charts
            PopulateCharts(stockDataList);
        }

        private void PopulateCharts(List<StockData> stockDataList)
        {
            chart_OHLC.Series["Candlestick"].Points.Clear();
            chart_OHLC.Series["Volume"].Points.Clear();

            foreach (var data in stockDataList)
            {
                // Candlestick series points
                chart_OHLC.Series["Candlestick"].Points.AddXY(data.Date, data.High, data.Low, data.Open, data.Close);

                // Set color based on open-close relationship
                var dataPoint = chart_OHLC.Series["Candlestick"].Points.Last();
                dataPoint.Color = (data.Close >= data.Open) ? Color.Lime : Color.Red;

                // Volume series points
                chart_OHLC.Series["Volume"].Points.AddXY(data.Date, data.Volume);
            }
        }











        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void chart_OHLC_Click(object sender, EventArgs e)
        {

        }
    }


    public class StockData
    {
        public DateTime Date { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
    }
}
