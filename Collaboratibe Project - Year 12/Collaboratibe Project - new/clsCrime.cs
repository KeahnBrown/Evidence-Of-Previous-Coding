using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collaboratibe_Project___new
{
    class clsCrime
    {
        //In order of what appears in the CSV
        private string fDate;
        private string fSuburb;
        private string fPostcode;
        private string fOffenceL1;
        private string fOffenceL2;
        private string fOffenceL3;
        private int fOffenceCount;
        private int fSocioeconomic;
        private string fLGA;

        //Constructor
        public clsCrime(string sDate, string sSuburb, string sPostcode, string sOffenceL1, string sOffenceL2, string sOffenceL3, int iOffenceCount, int iSocioeconomic, string sLGA)
        {
            fDate = sDate; fSuburb = sSuburb; fPostcode = sPostcode; fOffenceL1 = sOffenceL1; fOffenceL2 = sOffenceL2; fOffenceL3 = sOffenceL3; fOffenceCount = iOffenceCount; fSocioeconomic = iSocioeconomic; fLGA = sLGA;
        }

        //Modifiers
        public void setDate(string sDate) { fDate = sDate; }
        public void setSuburb(string sSuburb) { fSuburb = sSuburb; }
        public void setPostcode(string sPostcode) { fPostcode = sPostcode; }
        public void setOffenceL1(string sOffenceL1) { fOffenceL1 = sOffenceL1; }
        public void setOffenceL2(string sOffenceL2) { fOffenceL2 = sOffenceL2; }
        public void setOffenceL3(string sOffenceL3) { fOffenceL3 = sOffenceL3; }
        public void setOffenceCount(int iOffenceCount) { fOffenceCount = iOffenceCount; }
        public void setSocioeconomic(int iSocioeconomic) { fSocioeconomic = iSocioeconomic; }
        public void setLGA(string sLGA) { fLGA = sLGA; }

        //Accessors
        public string getDate() { return fDate; }
        public string getSuburb() { return fSuburb; }
        public string getPostcode() { return fPostcode; }
        public string getOffenceL1() { return fOffenceL1; }
        public string getOffenceL2() { return fOffenceL2; }
        public string getOffenceL3() { return fOffenceL3; }
        public int getOffenceCount() { return fOffenceCount; }
        public int getSocioeconomic() { return fSocioeconomic; }
        public string getLGA() { return fLGA; } 
    }
}
