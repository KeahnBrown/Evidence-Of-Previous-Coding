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
using System.Reflection;
using Exversion;
using Exversion.Analytics;
using Analytics;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            function.Formula = "f(x)=";
        }

        public static double[] limitArray = { -10, 10, -10, 10 };
        public static string formula;

        private Translator translator;
        private BaseConverter converter;

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

        private void InitializeAnalytics()
        {
            string[] exts = new string[] { "Analytics.Real" };
            LoadExtensions(exts);

            converter = new AnalyticsTeXConverter();
            translator = new Translator();
        }

        private void BtnEXE_Click(object sender, RoutedEventArgs e)
        {
            function.Formula = Conversion_Checker.ExecuteButton(tbxInput.Text);
            /*string f = tbxInput.Text;
            try
            {
                if (translator.CheckSyntax(f))
                {
                    object v = translator.Calculate(f);
                    string texf = converter.Convert(f);
                    string vs = Utilities.SafeToString(v);
                    formulaControl.Formula = texf + " = {" + vs + "}";
                }

            }
            catch (Exception ex)
            {
                formulaControl.Formula = ex.Message;
            }*/
        }


        private void covertingError()
        {

        }

        private void TbxInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxInput.Text.Length == 0) { function.Formula = ""; }
            else
            {
                function.Formula = "f(x)=" + Conversion_Checker.TextChange(tbxInput.Text);
            }
            formula = tbxInput.Text;
            /*string newFormula = "";
            formulaControl.Formula = "";
            int newFormulaLength = tbxInput.Text.Length;        
            try
            {
                newFormula = tbxInput.Text;
                //remove if (newFormula.Contains("+")) { newFormula += "c"; }
                newFormula = Conversion_Checker.BeforeConversionReplaceValues(newFormula);
                string text = converter.Convert(newFormula);
                text = Conversion_Checker.ReplaceValues(text);
                formulaControl.Formula = text;
            }
            catch(Exception ex)
            {
                formulaControl.Formula = ex.Message;
            }*/
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            tbxInput.Text = Conversion_Checker.ButtonClicked((sender as Button).Content.ToString(), tbxInput.Text);
        }

        private void CalculatorForm_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeAnalytics();
            translator.Add("{\\pi}", Math.PI);
            translator.Add("e", Math.E);
        }

        private void Execute(object sender, RoutedEventArgs e)
        {
            //string formula = Conversion_Checker.ReplaceValues(tbxInput.Text);
            GraphFunction FrmGraph = new GraphFunction();
            FrmGraph.ShowDialog();
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            function.Formula = tbxTest.Text;
        }
    }
}
