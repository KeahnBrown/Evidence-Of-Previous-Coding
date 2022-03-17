using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynCharts_Objts_Lsts
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void setupCounterList()
        {
            Form1.CountersLst.Clear();
            for (int row = 0; row < Fields.DistrictList.Count; row++)
            {
                List<int> colLst = new List<int>();
                for (int col = 0; col < Fields.CatgryLst.Count; col++)
                {
                    colLst.Add(0);
                }
                Form1.CountersLst.Add(colLst);
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            setupCounterList();

            int districtPos = -1;
            foreach ( CrimeCls oneCrime in Fields.crimeList)
            {
                districtPos = Fields.DistrictList.IndexOf(oneCrime.District);
                if (districtPos > -1)
                {
                    for (int i = 0; i<Fields.CatgryLst.Count; i++)
                    {
                        if ( oneCrime.Description.Contains(Fields.CatgryLst[i].ToUpper()) )
                        {
                            Form1.CountersLst[districtPos][i]++;
                        }
                    }
                }
            }
            Form1.LoadBarChart(Fields.DistrictList,Fields.CatgryLst);
            pnlChart.Controls.Add(Form1.barChart);
        }
    }
}
