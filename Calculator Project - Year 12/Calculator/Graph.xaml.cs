using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Maps;
using WpfMath;
using Analytics;
using System.Reflection;
using Exversion;
using Exversion.Analytics;
using Physics;
using Exversion.Physics;
using System.IO;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for Graph.xaml
    /// </summary>
    public partial class Graph : Window
    {
        public Graph()
        {
            InitializeComponent();
            InitializeAnalytics();
            
            function.Formula = "f(x)";
        }

        private Translator translator;
        private BaseConverter converter;

        private void InitializeAnalytics()
        {
            string[] exts = new string[] { "Analytics.Real" };
            LoadExtensions(exts);

            converter = new AnalyticsTeXConverter();
            translator = new Translator();
        }

        private void LoadExtensions(string[] exts)
        {
            int n = exts.Length;
            for (int i = 0; i < n; i++)
            {
                string sname = exts[i];
                try
                {
                    Assembly.Load(sname);
                }
                catch (Exception)
                {
                }
            }
        }


        public string formula;
        public int domainMax, domainMin, rangeMax, rangeMin;

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            tbxInput.Text = Conversion_Checker.ButtonClicked((sender as Button).Content.ToString(), tbxInput.Text);
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            function.Formula = tbxTest.Text;
        }

        private void Execute(object sender, RoutedEventArgs e)
        {
            //string formula = Conversion_Checker.ReplaceValues(tbxInput.Text);
            /*string formula = Conversion_Checker.ExecuteButton(tbxInput.Text);
            if (Conversion_Checker.resultantValue == "") { }
            else
            {
                if (!formula.Contains("="))
                {
                    formulaControl.Formula = formula + " = " + Conversion_Checker.resultantValue;
                }
                else { formulaControl.Formula = formula; }
            }*/
        }

        private void TbxInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxInput.Text.Length == 0) { function.Formula = ""; }
            else
            {
                function.Formula =  "{{f(x)=}" + Conversion_Checker.TextChange(tbxInput.Text) + "}";
            }
        }

        private void GraphFunction(string formula)
        {

        }
    }
}
