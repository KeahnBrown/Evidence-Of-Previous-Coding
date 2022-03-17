using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Calculator
{
    public partial class GraphFunction : Form
    {
        public GraphFunction()
        {
            InitializeComponent();
            //initialises chart features
            InitialiseChart();
            //creates chart and finds function positions
            LoadFunctionChart();
            //adds graph to chart on form
            chtGraph.Controls.Add(FunctionChart);
        }
        public static Chart FunctionChart;

        private void InitialiseChart()
        {
            //Getting function from Graph selection form
            Graph GraphWPF = new Graph();
            string formula = GraphWPF.formula;
            //defining chart area
            ChartArea chartArea = new ChartArea();
            //defining colours for legend of function
            Legend legend = new Legend() { BackColor = Color.AliceBlue, ForeColor = Color.Black };
            //initializing new function chart
            FunctionChart = new Chart();
            //initializing apsects of FunctionChart
            chartArea.Name = "FormulaArea";
            FunctionChart.ChartAreas.Add(chartArea);
            FunctionChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend.Name = formula;
            FunctionChart.Legends.Add(legend);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        private static void LoadFunctionChart()
        {
            //grabing values from window2, values include range and domain and formula.
            Window2 Window2 = new Window2();
            string formula = Window2.formula;
            double[] limitArray = Window2.limitArray;
            
            //setting up function colour
            FunctionChart.Series.Clear();
            FunctionChart.BackColor = Color.White;
            FunctionChart.Palette = ChartColorPalette.Fire;
            FunctionChart.ChartAreas[0].BackColor = Color.Transparent;

            //setting up series for function
            Series series = new Series
            {
                Name = "function",
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Line
            };//adds series to function
            FunctionChart.Series.Add(series);
            //clears series points
            FunctionChart.Series[0].Points.Clear();
            //initialises datatable class
            DataTable dt = new DataTable();
            //Checks if function contains an x variable
            if (!formula.Contains("x"))
            {//if the function does not contain x, then it remains constant
                //calculates equation
                double Y = Convert.ToDouble(dt.Compute(formula, ""));
                //loop which starts at domain min and adds 0.01 until domain max
                for (double x = limitArray[2]; x <= limitArray[3]; x += 0.01)
                {
                    //adds calculated equation point to chart series
                    FunctionChart.Series[0].Points.AddXY(x, Y);
                }
            }
            else
            {//if the function contains an x character, it finds the positions of x and adds them to a list
                List<int> xPositions = Conversion_Checker.FindCharacterPositions('x', formula);
                //replaces characters like the multiplication sign and division sign to '*' and '/'
                formula = Conversion_Checker.BeforeConversionReplaceValues(formula);
                string changedFormula = formula;  
                //runs for every x in the equation
                for (int i = 0; i < xPositions.Count; i++)
                {
                    try
                    {//checks if the character before or after the x character is a number and if so adds a multiplication sign in between.
                        if (int.TryParse(Convert.ToString(formula[xPositions[i] - 1]), out _)) { changedFormula = formula.Insert(xPositions[i], "*"); }
                        if (int.TryParse(Convert.ToString(formula[xPositions[i] + 1]), out _)) { changedFormula = formula.Insert(xPositions[i]+1, "*"); }
                    }
                    catch { }
                }
                formula = changedFormula;
                //loop runs from min domain to max domain and adds 0.01 to x every loop
                for (double X = limitArray[2]; X <= limitArray[3]; X += 0.01)
                {
                    //substitues the x value of the array into the x positions in the equation
                    string substitutedformula = formula.Replace("x", (Math.Round(X,2)).ToString());
                    //calculated the substitued equation
                    double Y = Convert.ToDouble(dt.Compute(substitutedformula, ""));
                    //checks if calcuated y coordinate is outside of the range
                    if (Y < limitArray[0] || Y > limitArray[1]) { }
                    //if not then it adds the point (X, Y) to the series
                    else { FunctionChart.Series[0].Points.AddXY(Math.Round(X,2), Y); }
                }
            }
        }
    }
}
