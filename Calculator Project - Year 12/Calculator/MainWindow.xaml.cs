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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using WpfMath;
using Analytics;
using Exversion;
using Exversion.Analytics;
using Physics;
using Exversion.Physics;
using System.IO;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Translator translator = new Translator();
        }

        private void BtnOpenCalculatorForm_Click(object sender, RoutedEventArgs e)
        {
            Window1 Frm1 = new Window1();
            Frm1.ShowDialog();
        }



        private void BtnOpenGraph_Click(object sender, RoutedEventArgs e)
        {
            Window2 Frm2 = new Window2();
            Frm2.ShowDialog();
        }

        private void getVariablesFromCSV()
        {
            string FileName = @"Variables.csv";
            try
            {
                using (StreamReader sr = File.OpenText(FileName))
                {
                    string[] arrData = new string[2];
                    for (int i = 0; i < 26; i++)
                    {
                        string line = sr.ReadLine();
                        arrData = line.Split(',');
                        ClsVariables Variables = new ClsVariables(Convert.ToChar(arrData[0]), arrData[1]);
                        Conversion_Checker.VariableArray[i] = Variables;
                    }
                }
            }
            catch { }
        }

        private void MenuForm_Loaded(object sender, RoutedEventArgs e)
        {
            getVariablesFromCSV();
        }
    }
}
