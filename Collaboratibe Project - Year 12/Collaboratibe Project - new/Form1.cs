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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //sorts the the LGA list and removes unnessecery data
            Categories.sortlist(Categories.LGAList);
            Categories.LGAList.Remove("other");
            //adds the LGA's to the combo box item list
            for (int i = 0; i < Categories.LGAList.Count(); i++)
            {
                cmbInput.Items.Add(Categories.LGAList[i]);
            }
        }
        //list which holds the number of suburbs in the selected LGA
        List<string> suburbsInLGA = new List<string>();

        //when the text in the combo box has been changed it calls this function
        private void areaChanged()
        {
            //clearing data from lists
            Frm_Menu.CounterList.Clear();
            suburbsInLGA.Clear();
            //goes through each row in the crime list
            foreach (clsCrime oneCrime in Categories.crimeList)
            {
                //checks if the LGA of the row is the same as the selected LGA
                if (cmbInput.Text == oneCrime.getLGA())
                {
                    //checks if the suburb has been added to the list of suburbs included in the selected LGA
                    if (suburbsInLGA.Contains(oneCrime.getSuburb()) == false)
                    {
                        //adds suburb to suburb in LGA list
                        suburbsInLGA.Add(oneCrime.getSuburb());
                        //adds an empty space of data in the counter list to store the number of crimes for the suburb
                        Frm_Menu.CounterList.Add(0);
                    }
                    //adds the number of offence count to the specific suburb's overall offence count
                    Frm_Menu.CounterList[suburbsInLGA.IndexOf(oneCrime.getSuburb())] += oneCrime.getOffenceCount();
                }
            }
            //calls a function which creates the charts with the provided data
            createChart();
        }

        //uses the data from the area changed function and creates a chart. gets called when chart type has changed or combo box has been changed
        private void createChart()
        {
            //new list which is used to store a single value which desribes the data on the chart
            List<string> emptylist = new List<string>();
            emptylist.Add("crime count for each suburb in the " + cmbInput.Text + " LGA");
            //adds and loads the chart depending on what chart is selected
            if (rbtBar.Checked == true) { Frm_Menu.loadBarChart1(emptylist, suburbsInLGA, true); pnlOutput.Controls.Add(Frm_Menu.barChart); }
            if (rbtPie.Checked == true) { Frm_Menu.LoadPieChart(emptylist, suburbsInLGA, true); pnlOutput.Controls.Add(Frm_Menu.pieChart); }
        }

        //closes form
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //calls create chart function when chart type is changed
        private void rbtBar_CheckedChanged(object sender, EventArgs e)
        {
            //if the radio button is checked it creates the chart otherwise it deletes the current chart
            if(rbtBar.Checked == true) { createChart(); }
            else { pnlOutput.Controls.Remove(Frm_Menu.barChart); }
        }
        //calls create chart function when chart type is changed
        private void rbtPie_CheckedChanged(object sender, EventArgs e)
        {
            //if the radio button is checked it creates the chart otherwise it deletes the current chart
            if (rbtPie.Checked == true) { createChart(); }
            else { pnlOutput.Controls.Remove(Frm_Menu.pieChart); }
        }
        //clears the chart then calls the area changed function
        private void cmbInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlOutput.Controls.Clear();
            areaChanged();
        }
    }
}
