using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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





            LoadAndFilterCsvData(filePath, startDate, endDate);
            LoadChartData(filePath);

        }




        ///COMMENT LATER. ADDED THIS
        private void LoadAndFilterCsvData(string filePath, DateTime startDate, DateTime endDate)
        {
            var dt = new DataTable();

            // Check if the file exists before proceeding
            if (!File.Exists(filePath))
            {
                MessageBox.Show("CSV file not found.");
                return;
            }

            using (var reader = new StreamReader(filePath))
            {
                bool firstLine = true;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    /// Add columns to DataTable for the first line (headers)
                    if (firstLine)
                    {
                        foreach (var header in values)
                        {
                            dt.Columns.Add(header);
                        }
                        firstLine = false;
                    }
                    else
                    {
                        /// Parse date from the CSV row
                        DateTime rowDate = DateTime.Parse(values[0]); /// Assuming the Date is in the first column

                        /// Filter by start and end date
                        if (rowDate >= startDate && rowDate <= endDate)
                        {
                            dt.Rows.Add(values); /// Add row to DataTable if within range
                        }
                    }
                }
            }

            /// Bind the filtered DataTable to the DataGridView
            dataGridView_stockData.DataSource = dt;
        }





        private void LoadCandlestickData(string filePath)
        {
            /// Clear any previous data in the series
            chart_OHLC.Series.Clear();

            /// Set up the candlestick series
            Series candlestickSeries = new Series("CandlestickSeries")
            {
                ChartType = SeriesChartType.Candlestick,
                XValueType = ChartValueType.DateTime
            };

            /// Configure up and down colors for candlesticks
            candlestickSeries["PriceUpColor"] = "Lime"; // Green for up days
            candlestickSeries["PriceDownColor"] = "Red"; // Red for down days

            /// Add the series to the chart
            chart_OHLC.Series.Add(candlestickSeries);

            /// Load and parse data from the CSV file
            using (var reader = new StreamReader(filePath))
            {
                bool isFirstRow = true;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (isFirstRow)
                    {
                        isFirstRow = false; // Skip header row
                        continue;
                    }

                    /// Parse each column (assuming Date, Open, High, Low, Close)
                    DateTime date = DateTime.Parse(values[0]);
                    double open = double.Parse(values[1]);
                    double high = double.Parse(values[2]);
                    double low = double.Parse(values[3]);
                    double close = double.Parse(values[4]);

                    /// Add data point for candlestick series
                    int pointIndex = candlestickSeries.Points.AddXY(date, high);
                    candlestickSeries.Points[pointIndex].YValues[1] = low;
                    candlestickSeries.Points[pointIndex].YValues[2] = open;
                    candlestickSeries.Points[pointIndex].YValues[3] = close;
                }
            }

            /// Optional: Customize chart area for better visibility
            chart_OHLC.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";
            chart_OHLC.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            chart_OHLC.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chart_OHLC.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
        }


        /// WEIRD FORMATTING
        private void LoadChartData(string filePath)
        {
            chart_OHLC.Series["Candlestick"].Points.Clear();
            chart_OHLC.Series["Volume"].Points.Clear();

            // Set up color properties for the candlestick chart
            chart_OHLC.Series["Candlestick"].CustomProperties = "PriceUpColor=Lime, PriceDownColor=Red";

            using (var reader = new StreamReader(filePath))
            {
                bool isFirstRow = true;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (isFirstRow)
                    {
                        isFirstRow = false; // Skip the header row
                        continue;
                    }

                    DateTime date = DateTime.Parse(values[0]);
                    double open = double.Parse(values[1]);
                    double high = double.Parse(values[2]);
                    double low = double.Parse(values[3]);
                    double close = double.Parse(values[4]);
                    double volume = double.Parse(values[5]);

                    int pointIndex = chart_OHLC.Series["Candlestick"].Points.AddXY(date, high);
                    chart_OHLC.Series["Candlestick"].Points[pointIndex].YValues[1] = low;
                    chart_OHLC.Series["Candlestick"].Points[pointIndex].YValues[2] = open;
                    chart_OHLC.Series["Candlestick"].Points[pointIndex].YValues[3] = close;

                    chart_OHLC.Series["Volume"].Points.AddXY(date, volume);
                }
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
}
