using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynCharts_Objts_Lsts
{
    class CrimeCls
    {
        private string date;
        private string district;
        private string description;
        public CrimeCls(string pDate, string pDistrict, string pDescription)
        {
            date = pDate;
            district = pDistrict;
            description = pDescription;
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string District
        {
            get { return district; }
            set { district = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }

}
