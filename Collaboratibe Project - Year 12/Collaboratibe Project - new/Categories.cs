using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collaboratibe_Project___new
{
    class Categories
    {
        public static List<clsCrime> crimeList = new List<clsCrime>();
        public static List<string> suburbList = new List<string>();
        public static List<string> postcodeList = new List<string>();
        public static List<string> offencelvl1List = new List<string>();
        public static List<string> offencelvl2List = new List<string>();
        public static List<string> offencelvl3List = new List<string>();
        public static List<string> LGAList = new List<string>();
        public static List<string> socioeconomicList = new List<string>();

        public static void sortlist(List<string> genList)
        {
            string temp;
            for (int i = 0; i < (genList.Count) - 1; i++)
            {
                for (int j = i + 1; j < (genList.Count); j++)
                {
                    if (string.Compare(genList[i], genList[j]) == 1)
                    {
                        temp = genList[i];
                        genList[i] = genList[j];
                        genList[j] = temp;
                    }
                }
            }
        }
    }
}
