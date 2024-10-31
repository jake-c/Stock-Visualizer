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



        //This is the class global list of stockData objects that we can filter from
        private List<StockData> fullStockData;


        /// <summary>
        /// On click of the button_loadData, we want to capture the input of the 4 user input fields. 
        /// From here, we will then contstruct the file location,
        ///  then call the cascading function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_loadData_Click(object sender, EventArgs e)
        {
            // Get user-selected values from the input fields
            string stockSymbol = comboBox_stockSymbol.SelectedItem?.ToString();
            string period = comboBox_period.SelectedItem?.ToString();
            DateTime startDate = dateTimePicker_startDate.Value;
            DateTime endDate = dateTimePicker_endDate.Value;

            // Check that the stock symbol and period are selected
            if (string.IsNullOrEmpty(stockSymbol) || string.IsNullOrEmpty(period))
            {
                MessageBox.Show("Please select both a stock symbol and a period.");
                return;
            }

            // Ensure that start date is less than end
            if (startDate > endDate)
            {
                MessageBox.Show("The start date must be earlier than the end date.", "Invalid Date Range");
                return;
            }

            //Based on user input, concatenate inputs to obtain the appropriate csv file path from the Stock Data folder
            string filePath = $"Stock Data/{stockSymbol}-{period}.csv";

            fullStockData = LoadCsvData(filePath);
            //Call the function to handle the csv
            FilterAndDisplayData(startDate, endDate);

        }



        /// <summary>
        /// Without having to parse the entire csv again, we can simply
        /// populate the graphs again with a filtered version of the current stockData list 
        /// when a user changes the time range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Update_Click(object sender, EventArgs e)
        {
            // Check if fullStockData is loaded and contains data. If not, propmt user to load stock first
            if (fullStockData == null || !fullStockData.Any())
            {
                MessageBox.Show("No stock data is currently loaded. Please load stock data first.");
                return;
            }
            //Capture the change in the timePicker controls
            DateTime startDate = dateTimePicker_startDate.Value;
            DateTime endDate = dateTimePicker_endDate.Value;

            // Filter and display data based on the selected date range
            FilterAndDisplayData(startDate, endDate);
        }


        /// <summary>
        /// Responsible for parsing the given csv file and turning each row of the csv
        /// into a stock object within a list.
        /// </summary>
        /// <param name="filePath">The user input of stockSymbol and period is concatenated to get us the file path of the current csv</param>
        /// <param name="startDate">user input startDate</param>
        /// <param name="endDate">user specified endDate</param>
        /// <returns>The list of stock objects, filtered by date range, and ready to be loaded into a graph</returns>
        private List<StockData> LoadCsvData(string filePath)
        {
            var stockDataList = File.ReadAllLines(filePath) // Parse the csv file
                .Skip(1) // Skip header line
                .Select(line => 
                {
                    //For each line in the csv, we are going to assign each property of the stock object to each entry in the corresponding columns
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

                // Convert the LINQ query into a usable list
                .ToList();

            return stockDataList;
        }



        /// <summary>
        /// Takes the list of stock objects and populates the two series
        /// within our chart_OHLC control. 
        /// </summary>
        /// <param name="stockDataList"> This is the list of stock objects that contain all of the data needed for each stock</param>
        private void PopulateCharts(List<StockData> stockDataList)
        {
            chart_OHLC.Series["Candlestick"].Points.Clear(); //Clear the points of both graphs so we can redraw the points from scratch
            chart_OHLC.Series["Volume"].Points.Clear();

            foreach (var data in stockDataList)
            {
                // The candlestick series method AddXY expects the date as x, and then the rest of the params take care of the y value, and are the candlesticks
                chart_OHLC.Series["Candlestick"].Points.AddXY(data.Date, data.High, data.Low, data.Open, data.Close);

                // We want to get the point that was just added above and color it accordingly based on if the stock price went up or down (Bullish vs Bearish)
                var dataPoint = chart_OHLC.Series["Candlestick"].Points.Last();
                dataPoint.Color = (data.Close >= data.Open) ? Color.Lime : Color.Red;

                // The volume plot is quite simple, we want to plot date vs volume for each stock entry in the list
                chart_OHLC.Series["Volume"].Points.AddXY(data.Date, data.Volume);
            }
        }


        /// <summary>
        /// FilterAndDisplayData essentially filters the data based on the start and end times, keeping
        /// only the elements that have a date within the two parameters
        /// </summary>
        /// <param name="startDate">Start date is the user inputted start date from the first combobox</param>
        /// <param name="endDate">End date is the user inputted start date from the second combobox</param>
        private void FilterAndDisplayData(DateTime startDate, DateTime endDate)
        {

            // Linq is used here to select the list elements based off the constraint and then return the list back to filteredData
            var filteredData = fullStockData
                .Where(data => data.Date >= startDate && data.Date <= endDate)
                .ToList();

            // Bind to DataGridView
            dataGridView_stockData.DataSource = filteredData;

            // Populate charts
            PopulateCharts(filteredData);
        }








        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

  


    }


    // Blueprint for the stockData object

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
