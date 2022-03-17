using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collaboratibe_Project___new
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //sorts the LGA list before adding the LGA's to the items of both the combo boxes
            Categories.sortlist(Categories.LGAList);
            for (int i = 0; i < Categories.LGAList.Count(); i++)
            {
                cmbInput.Items.Add(Categories.LGAList[i]);
                cmbInput2.Items.Add(Categories.LGAList[i]);              
            }
            //removing unnessery information from the combo boxes
            cmbInput.Items.Remove("other");
            cmbInput2.Items.Remove("other");
        }

        //creating a list that stores the top ten offence lvl 3 occurcies in a LGA
        List<string> top10offenceLvl3 = new List<string>();

        //this function sorts through the offence types in an LGA and finds the top 10 types of offence types.
        private void areaSelected(string LGA, bool whichCmb)
        {
            //clearing lists and creating array
            List<int> colList = new List<int>();
            int[,] top10CrimesArray = new int[2, 10];
            Frm_Menu.Counter2DList.Clear();
            Frm_Menu.CounterList.Clear();
            
            //fill counter2DList with values for the number of offence lvl3 type crimes
            for (int i = 0; i < Categories.offencelvl3List.Count(); i++)
            {
                colList.Add(0);
            }
            Frm_Menu.Counter2DList.Add(colList);
            
            int seriesPos = -1;
            //runs through each row in csv
            foreach (clsCrime oneCrime in Categories.crimeList)
            {
                //checks if the LGA selected is equal to the rows LGA and if the offence lvl 3 exists in row
                if (Categories.offencelvl3List.IndexOf(oneCrime.getOffenceL3()) > -1 && LGA == oneCrime.getLGA())
                {
                    //finds position of offence count in row
                    seriesPos = Categories.offencelvl3List.IndexOf(oneCrime.getOffenceL3());
                    //adds value depending on what offence it was
                    Frm_Menu.Counter2DList[0][seriesPos]++;
                }
            }
            
            //finds the top 10 crimes in the LGA
            for (int i = 0; i < 10; i++)
            {
                top10CrimesArray[0, i] = 0;
                //goes through each offence lvl 3 crime type
                for (int j = 0; j < Categories.offencelvl3List.Count(); j++)
                {
                    //checks if number of crime offence is larger then any other crime offence value
                    if (Frm_Menu.Counter2DList[0][j] > top10CrimesArray[0, i])
                    {
                        //if so it adds the crime count value and crime type to array
                        top10CrimesArray[0, i] = Frm_Menu.Counter2DList[0][j];
                        top10CrimesArray[1, i] = j;
                    }
                }
                //makes remaining top value equal zero so it doesnt show again
                Frm_Menu.Counter2DList[0][top10CrimesArray[1, i]] = 0;
            }
            Frm_Menu.Counter2DList.Clear();
            
            colList.Clear();
            top10offenceLvl3.Clear();
            //adds the crime count values to counter list and crime types to top10offenceLVL3 list
            for (int i = 0; i < 10; i++)
            {
                Frm_Menu.CounterList.Add(top10CrimesArray[0, i]);
                top10offenceLvl3.Add(Categories.offencelvl3List[top10CrimesArray[1, i]]);
            }
            Frm_Menu.Counter2DList.Add(colList);
            //checks which combo box was changed and removes any chart from the panel
            if (whichCmb == true)
            {
                if (pnlOutput.Controls.Contains(Frm_Menu.barChart) == true) { pnlOutput.Controls.Remove(Frm_Menu.barChart); }
                else if (pnlOutput.Controls.Contains(Frm_Menu.pieChart) == true) { pnlOutput.Controls.Remove(Frm_Menu.pieChart); }
            }
            else
            {
                if (pnlOutput2.Controls.Contains(Frm_Menu.barChart2) == true) { pnlOutput2.Controls.Remove(Frm_Menu.barChart2); }
                else if (pnlOutput2.Controls.Contains(Frm_Menu.pieChart2) == true) { pnlOutput2.Controls.Remove(Frm_Menu.pieChart2); }
            }
            //calls the function that creates the chart
            chartTypeChanged(LGA, whichCmb);
        }

        private void chartTypeChanged(string LGA, bool whichCmb)
        {
            List<string> emptylist = new List<string>();
            emptylist.Add(LGA);
            //checks what combo box was changed
            if (whichCmb == true && LGA != "")
            {
                //checks what radio button is currently checked and displays chart to panel 1 depending on what is checked
                if (rbtBar.Checked == true)
                {
                    Frm_Menu.loadBarChart1(emptylist, top10offenceLvl3, true);
                    pnlOutput.Controls.Add(Frm_Menu.barChart);
                }
                if (rbtPie.Checked == true)
                {
                    Frm_Menu.LoadPieChart(emptylist, top10offenceLvl3, true);
                    pnlOutput.Controls.Add(Frm_Menu.pieChart);
                }
            }
            //checks if combo box 2 value was changed
            else if (whichCmb == false && LGA != "")
            {
                //checks if the radio button is currently checked for each display and displays the chart depending on what radio button is checked to panel 2
                if (rbtBar.Checked == true)
                {
                    Frm_Menu.loadBarChart2(emptylist, top10offenceLvl3, true);
                    pnlOutput2.Controls.Add(Frm_Menu.barChart2);
                }
                if (rbtPie.Checked == true)
                {
                    Frm_Menu.LoadPieChart2(emptylist, top10offenceLvl3, true);
                    pnlOutput2.Controls.Add(Frm_Menu.pieChart2);
                }
            }
            
        }
        //gets called when combo box 1 value is changed
        private void cmbInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            areaSelected(cmbInput.Text, true);
        }
        //gets called when chart type radio button is changed
        private void rbtBar_CheckedChanged(object sender, EventArgs e)
        {
            if (pnlOutput.Controls.Contains(Frm_Menu.barChart) == true) { pnlOutput.Controls.Remove(Frm_Menu.barChart); }
            if (pnlOutput2.Controls.Contains(Frm_Menu.barChart2) == true) { pnlOutput2.Controls.Remove(Frm_Menu.barChart2); }
            areaSelected(cmbInput.Text, true);
            areaSelected(cmbInput2.Text, false);
        }

        //gets called when pie chart type radio button is changed
        private void rbtPie_CheckedChanged(object sender, EventArgs e)
        {
            if (pnlOutput.Controls.Contains(Frm_Menu.pieChart) == true) { pnlOutput.Controls.Remove(Frm_Menu.pieChart); }
            if (pnlOutput2.Controls.Contains(Frm_Menu.pieChart2) == true) { pnlOutput2.Controls.Remove(Frm_Menu.pieChart2); }
            areaSelected(cmbInput.Text, true);
            areaSelected(cmbInput2.Text, false);
        }

        //gets called when combo box 2 value is changed
        private void cmbInput2_SelectedIndexChanged(object sender, EventArgs e)
        {
            areaSelected(cmbInput2.Text, false);
        }
        //closes form when close button is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
