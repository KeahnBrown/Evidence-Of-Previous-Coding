using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMath;
using Analytics;
using System.Reflection;
using Exversion;
using Exversion.Analytics;
using Physics;
using Exversion.Physics;

namespace Calculator
{
    class ClsVariables
    {
        //values in order within csv file
        private char fCharacter;
        private string fValue;

        //constructor
        public ClsVariables(char cCharacter, string sValue)
        {
            fCharacter = cCharacter; fValue = sValue;
        }

        //modifiers
        public void SetValue(char cCharacter) { fCharacter = cCharacter; }
        public void SetValue(string sValue) { fValue = sValue; }

        //Accessors
        public char GetCharacter() { return fCharacter; }
        public string GetValue() { return fValue; }
    }
}
