using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynCharts_Objts_Lsts
{
    class Fields
    {
        public static List<CrimeCls> crimeList = new List<CrimeCls>();
        public static List<string> DistrictList = new List<string>();
        public static List<string> CatgryLst = new List<string> { "Burglary", "Theft", "Assault" };        

        public static void populateList(List<string> thisList, string item)
        {
            if (!thisList.Contains(item))
            {
                thisList.Add(item);
            }
        }
    }
}
