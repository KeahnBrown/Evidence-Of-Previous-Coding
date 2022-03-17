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
using System.Windows.Forms.DataVisualization.Charting;


namespace DynCharts_Objts_Lsts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
                
        public static List<List<int>> CountersLst = new List<List<int>>();

        private void readDatafromFile()
        {
            string filename = @"Crime.csv";
            try
            {
                using (StreamReader sr = File.OpenText(filename))
                {
                    string line = "";
                    line = sr.ReadLine();

                    string[] data = new string[3];

                    while ((line = sr.ReadLine()) != null)
                    {
                        data = line.Split(',');
                        CrimeCls oneCrime = new CrimeCls(data[0], data[1], data[2]);
                        Fields.crimeList.Add(oneCrime);
                        Fields.populateList(Fields.DistrictList, oneCrime.District);                        
                    }
                }
            }
            catch
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("File not found", "Error!", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        public static Chart barChart;

        private void InitialiseChart()
        {
            ChartArea chartArea1 = new ChartArea();
            Legend legend = new Legend() { BackColor = Color.LightSkyBlue, ForeColor = Color.Black };
            barChart = new Chart();
            chartArea1 = new ChartArea();
            chartArea1.Name = "BarChartArea";
            barChart.ChartAreas.Add(chartArea1);
            barChart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            barChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend.Name = "Legend";
            barChart.Legends.Add(legend);
            
        }

        public static void LoadBarChart(List<string> pointsLst, List<string> seriesLst)
        {
            barChart.Series.Clear();            
            barChart.BackColor = Color.LightYellow;
            barChart.Palette = ChartColorPalette.Fire;
            barChart.ChartAreas[0].BackColor = Color.Transparent;
            int index = 0;
            foreach (string seriesItem in seriesLst)
            {
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

            int countPoints = 0;
            foreach (string point in pointsLst)
            {
                int countSeries = 0;
                foreach (string seriesItem in seriesLst)
                {
                    barChart.Series[seriesItem].Points.AddXY(point, CountersLst[countPoints][countSeries]);
                    countSeries++;
                }
                countPoints++;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            readDatafromFile();
            InitialiseChart();
        }

        private void btnDistrict_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }

       
    }
}
