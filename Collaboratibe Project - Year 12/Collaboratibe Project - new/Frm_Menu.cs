using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace Collaboratibe_Project___new
{
    public partial class Frm_Menu : Form
    {
        public Frm_Menu()
        {
            InitializeComponent();
        }

        int count = 0;
        public static Chart barChart, pieChart, lineChart, barChart2, pieChart2;//seting variable names as charts
        List<clsCrime> listCrimeClass = new List<clsCrime>(); //Creating list that will store classes
        public static List<List<int>> Counter2DList = new List<List<int>>(); //Creating list which will count the number of times that the wanted value is found
        public static List<int> CounterList = new List<int>();

        private void InitialiseChart()//Creating a function which initialises the charts
        {
            ChartArea chartArea1 = new ChartArea();
            //setting the color of the legends for each chart
            Legend legend1 = new Legend() { BackColor = Color.Yellow, ForeColor = Color.Black };
            Legend legend2 = new Legend() { BackColor = Color.Yellow, ForeColor = Color.Black };
            Legend legend3 = new Legend() { BackColor = Color.Yellow, ForeColor = Color.Black };
            Legend legend4 = new Legend() { BackColor = Color.Yellow, ForeColor = Color.Black };
            Legend legend5 = new Legend() { BackColor = Color.Yellow, ForeColor = Color.Black };
            //declairing charts to variables
            barChart = new Chart();
            barChart2 = new Chart();
            pieChart = new Chart();
            pieChart2 = new Chart();
            lineChart = new Chart();

            //bar chart1
            chartArea1.Name = "BarChartArea";
            barChart.ChartAreas.Add(chartArea1);
            barChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            barChart.Legends.Add(legend1);

            chartArea1 = new ChartArea();
            chartArea1.Name = "BarChartArea";
            barChart2.ChartAreas.Add(chartArea1);
            barChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend4";
            barChart2.Legends.Add(legend4);

            //pie chart
            chartArea1 = new ChartArea();
            chartArea1.Name = "PieChartArea";
            pieChart.ChartAreas.Add(chartArea1);
            pieChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend2";
            pieChart.Legends.Add(legend2);
            pieChart.Location = new System.Drawing.Point(0, 50);

            chartArea1 = new ChartArea();
            chartArea1.Name = "PieChartArea";
            pieChart2.ChartAreas.Add(chartArea1);
            pieChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Name = "Legend5";
            pieChart2.Legends.Add(legend5);
            pieChart2.Location = new System.Drawing.Point(0, 50);

            //line chart
            chartArea1 = new ChartArea();
            chartArea1.Name = "LineChartArea";
            lineChart.ChartAreas.Add(chartArea1);
            lineChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend3";
            lineChart.Legends.Add(legend3);


            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        //function allows for the chart to be called and used with specific data sets
        public static void loadBarChart1(List<string> pointsList, List<string> seriesList, bool not2DList)
        {
            barChart.Series.Clear();
            barChart.BackColor = Color.SkyBlue;
            barChart.Palette = ChartColorPalette.Fire;
            barChart.ChartAreas[0].BackColor = Color.Transparent;
            int index = 0;
            foreach (string seriesItem in seriesList)
            {
                //adding the different series to the chart
                Series series = new Series
                {
                    Name = seriesItem,
                    IsVisibleInLegend = true,
                    ChartType = SeriesChartType.Column
                };
                barChart.Series.Add(series);
                barChart.Series[index].Points.Clear();
                index++;
            }
            //goes through data and displays number of values for each series
            int countPoints = 0;
            foreach (string point in pointsList)
            {
                int countSeries = 0;
                foreach (string seriesItem in seriesList)
                {
                    if (not2DList == true)
                    {
                        barChart.Series[seriesItem].Points.AddXY(point, CounterList[countSeries]);
                        countSeries++;
                    }
                    else
                    {
                        barChart.Series[seriesItem].Points.AddXY(point, Counter2DList[countPoints][countSeries]);
                        countSeries++;
                    }
                }
                countPoints++;
            }  
        }

        public static void loadBarChart2(List<string> pointsList, List<string> seriesList, bool not2DList)
        {
            barChart2.Series.Clear();
            barChart2.BackColor = Color.SkyBlue;
            barChart2.Palette = ChartColorPalette.Fire;
            barChart2.ChartAreas[0].BackColor = Color.Transparent;
            int index = 0;
            foreach (string seriesItem in seriesList)
            {
                //adding the different series to the chart
                Series series = new Series
                {
                    Name = seriesItem,
                    IsVisibleInLegend = true,
                    ChartType = SeriesChartType.Column
                };
                barChart2.Series.Add(series);
                barChart2.Series[index].Points.Clear();
                index++;
            }
            //goes through data and displays number of values for each series
            int countPoints = 0;
            foreach (string point in pointsList)
            {
                int countSeries = 0;
                foreach (string seriesItem in seriesList)
                {
                    if (not2DList == true)
                    {
                        barChart2.Series[seriesItem].Points.AddXY(point, CounterList[countSeries]);
                        countSeries++;
                    }
                    else
                    {
                        barChart2.Series[seriesItem].Points.AddXY(point, Counter2DList[countPoints][countSeries]);
                        countSeries++;
                    }
                }
                countPoints++;
            }
        }

        public static void LoadPieChart(List<string> pointsList, List<string> seriesList, bool not2DList)
        {
            pieChart.Series.Clear();
            pieChart.BackColor = Color.SkyBlue;
            pieChart.Palette = ChartColorPalette.Fire;
            pieChart.ChartAreas[0].BackColor = Color.Transparent;

            Series series = new Series
            {
                Name = pointsList[0],
                IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Pie
            };
            pieChart.Titles.Add(pointsList[0]);
            pieChart.Series.Add(series);
            pieChart.Series[pointsList[0]].Points.DataBindXY(seriesList, CounterList);
            pieChart.Series[pointsList[0]].Label = "#PERCENT";
            pieChart.Series[0].LegendText = "#VALX";
        }

        public static void LoadPieChart2(List<string> pointsList, List<string> seriesList, bool not2DList)
        {
            pieChart2.Series.Clear();
            pieChart2.BackColor = Color.SkyBlue;
            pieChart2.Palette = ChartColorPalette.Fire;
            pieChart2.ChartAreas[0].BackColor = Color.Transparent;
            Series series = new Series
            {
                Name = pointsList[0],
                IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Pie
            };
            pieChart2.Titles.Add(pointsList[0]);
            pieChart2.Series.Add(series);
            pieChart2.Series[pointsList[0]].Points.DataBindXY(seriesList, CounterList);
            pieChart2.Series[pointsList[0]].Label = "#PERCENT";
            pieChart2.Series[0].LegendText = "#VALX";
        }

        public static void LoadLineChart(List<string> pointsList, List<string> seriesList, bool not2DList)
        {
            lineChart.Series.Clear();
            lineChart.BackColor = Color.SkyBlue;
            lineChart.Palette = ChartColorPalette.Fire;
            lineChart.ChartAreas[0].BackColor = Color.Transparent;
            int index = 0;
            foreach (string seriesItem in seriesList)
            {
                Series series = new Series
                {
                    Name = seriesItem,
                    IsVisibleInLegend = true,
                    ChartType = SeriesChartType.Line
                };
                lineChart.Series.Add(series);
                lineChart.Series[index].Points.Clear();
                index++;
            }
            int countPoints = 0;
            foreach (string point in pointsList)
            {
                int countSeries = 0;
                foreach (string seriesItem in seriesList)
                {
                    if (not2DList == true)
                    {
                        lineChart.Series[seriesItem].Points.AddXY(point, CounterList[countSeries]);
                    }
                    else
                    {
                        lineChart.Series[seriesItem].Points.AddXY(point, Counter2DList[countPoints][countSeries]);
                        countSeries++;
                    }
                }
                countPoints++;
            }
        }
        //allows for another form to be loaded when the button is clicked on the menu form
        private void btnOpenFrm2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void btnOpenFrm3_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void btnOpenFrm4_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.ShowDialog();
        }

        private void btnOpenFrm5_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.ShowDialog();
        }

        private void btnOpenFrm1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.ShowDialog();
        }

        //stores values from csv file to class while adding different values to the catergories class
        private void Frm_Menu_Load(object sender, EventArgs e)
        {
            string fileName = @"CrimeData.csv";
            try
            {                
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string line = sr.ReadLine();
                    string[] arrData = new string[9];
                    while ((line = sr.ReadLine()) != null)
                    {
                        bool emptyValue = false;
                        arrData = line.Split(',');
                        for (int i = 0; i < 9; i++)
                        {
                            if (arrData[i] == "") { emptyValue = true; }
                        }
                        try
                        {
                            if (emptyValue == false)
                            {
                                clsCrime crimeDataRow = new clsCrime(arrData[0], arrData[1], arrData[2], arrData[3], arrData[4], arrData[5], Convert.ToInt32(arrData[6]), Convert.ToInt32(arrData[7]), arrData[8]);
                                Categories.crimeList.Add(crimeDataRow);
                                count++;
                                if (!Categories.suburbList.Contains(arrData[1])) { Categories.suburbList.Add(arrData[1]); }
                                if (!Categories.postcodeList.Contains(arrData[2])) { Categories.postcodeList.Add(arrData[2]); }
                                if (!Categories.offencelvl1List.Contains(arrData[3])) { Categories.offencelvl1List.Add(arrData[3]); }
                                if (!Categories.offencelvl2List.Contains(arrData[4])) { Categories.offencelvl2List.Add(arrData[4]); }
                                if (!Categories.offencelvl3List.Contains(arrData[5])) { Categories.offencelvl3List.Add(arrData[5]); }
                                if (!Categories.LGAList.Contains(arrData[8])) { Categories.LGAList.Add(arrData[8]); }
                            }
                        }
                        catch { }
                    }
                }
            }
            catch (Exception Exception) { }
            InitialiseChart();
        }
    }
}
