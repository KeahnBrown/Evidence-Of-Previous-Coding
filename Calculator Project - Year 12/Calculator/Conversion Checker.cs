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
    class Conversion_Checker
    {
        public static ClsVariables[] VariableArray = new ClsVariables[26];
        public static char[] SpecialCharacterArray = { '+', '-', '*', '/', '.', '^', '√' };
        public static string resultantValue;

        //Gets called when the formula translated has an issue and cant be turned into LaTeX wanted writing
        //Trys to find a possible solution to the problem in the formula using the obtain exception from the formula conversion error
        public static string FindSolution(string formula, string exception)
        {
            Assembly.Load("Analytics.Real");
            Translator translator = new Translator();
            AnalyticsTeXConverter converter = new AnalyticsTeXConverter();

            char problemCharacter = CharacterFind(exception);
            if (problemCharacter == ')' || problemCharacter == '(')
            {
                List<int> OpenBracketPositions = FindCharacterPositions('(', formula);
                List<int> CloseBracketPositions = FindCharacterPositions(')', formula);
                formula = BracketIssue(OpenBracketPositions, CloseBracketPositions, formula);
            }
            else
            {
                List<int> CharacterIndexs = FindCharacterPositions(problemCharacter, formula);
                formula = CharacterSolutionFinder(problemCharacter, formula, CharacterIndexs);
            }


            formula = FormulaUpdated(formula);
            return formula;


        }
        //Runs when the text inside the textbox changes, will then create formula for formula text box but if issues occur will try to fix them.
        public static string TextChange(string TextBox)
        {
            Translator translator = new Translator();
            AnalyticsTeXConverter converter = new AnalyticsTeXConverter();
            string formula = TextBox;
            try
            {
                TextBox = BeforeConversionReplaceValues(TextBox);
                translator.CheckSyntax(TextBox);
                formula = converter.Convert(TextBox);
                formula = ReplaceValues(formula);
                return formula;
            }
            catch (Exception ex)
            {
                string[] exceptionSplit = ex.Message.Split('\'');
                formula = FindSolution(formula, exceptionSplit[1]);
                return formula;
            }
        }

        private static string FormulaUpdated(string formula)
        {
            Translator translator = new Translator();
            AnalyticsTeXConverter converter = new AnalyticsTeXConverter();
            try
            {
                formula = BeforeConversionReplaceValues(formula);
                try
                {
                    object result = translator.Calculate(formula);
                    string convertedResult = Utilities.SafeToString(result);
                    resultantValue = convertedResult;
                }
                catch
                {
                    resultantValue = "";
                }
                string ConvertedFormula = converter.Convert(formula);
                ConvertedFormula = ReplaceValues(ConvertedFormula);
                return ConvertedFormula;
            }
            catch (Exception ex)
            {
                string[] exceptionSplit = ex.Message.Split('\'');
                formula = FindSolution(formula, exceptionSplit[1]);
                return formula;
            }
        }

        //searches through different characters to find a solution to the formula.
        //should make into array of characters to later on just use a for loop to run through possible characters like the Variable array.
        private static char CharacterFind(string exception)
        {
            if (exception.Contains("π")) { return 'π'; }
            else if (exception.Contains("/")) { return '/'; }
            else if (exception.Contains("+")) { return '+'; }
            else if (exception.Contains("-")) { return '-'; }
            else if (exception.Contains("*")) { return '*'; }
            else if (exception.Contains(".")) { return '.'; }
            else if (exception.Contains("e")) { return 'e'; }
            else if (exception.Contains("(")) { return ')'; }
            else if (exception.Contains(")")) { return '('; }
            else if (exception.Contains("à")) { return 'à'; }
            else if (exception.Contains(" ")) { return 'á'; }
            else if (exception.Contains("^")) { return '^'; }
            else if (exception.Contains("√")) { return '√'; }
            else
            {
                foreach (ClsVariables Variable in VariableArray)
                {
                    if (exception.Contains(Convert.ToChar(Variable.GetCharacter())))
                    {
                        return Variable.GetCharacter();
                    }
                }
                for (int i = 0; i <= 9; i++)
                {
                    if (exception.Contains((i).ToString()))
                    {
                        string Character = i.ToString();
                        return Character[0];
                    }
                }
            }
            return '?';
        }

        public static List<int> FindCharacterPositions(char Character, string formula)
        {
            List<int> indexList = new List<int>();
            int count = 0;
            string tempFormula = formula;
            while (tempFormula.Contains(Character))
            {
                indexList.Add(tempFormula.IndexOf(Character));
                tempFormula = tempFormula.Remove(indexList[count], 1);
                tempFormula = "m" + tempFormula;
                count++;
            }
            return indexList;
        }

        private static string CharacterSolutionFinder(char Character, string formula, List<int> indexList)
        {
            int initialLength = formula.Length;
            for (int i = 0; i < indexList.Count; i++)
            {
                if (indexList[i] == 0) { formula = CharPosStartEnd(Character, 0, formula); }
                else if (formula[indexList[i]] != ')' && formula[indexList[i]] != 'á' && formula[indexList[i]] - 1 != '(' && formula[indexList[i]] - 1 != 'à')
                {
                    formula = PositionChecker(indexList[i] - 1, indexList[i], formula, Character);
                }
                if (initialLength != formula.Length)
                {
                    for (int j = 0; j < indexList.Count; j++)
                    {
                        indexList[j]++;
                    }
                }
                if (indexList[i] == (formula.Length - 1)) { formula = CharPosStartEnd(Character, 1, formula); }
                else if (formula[indexList[i]] != '(' && formula[indexList[i]] != 'à' && formula[indexList[i]] + 1 != ')' && formula[indexList[i]] + 1 != 'á')
                {
                    formula = PositionChecker(indexList[i] + 1, indexList[i], formula, Character);
                }
            }
            return formula;
        }

        private static string CharPosStartEnd(char Character, int position, string formula)
        {
            switch (Character)
            {
                case '/' when position == 0:
                    return "â" + formula;
                case '/' when position == 1:
                    return formula + "â";
                case '*' when position == 0:
                    return "â" + formula;
                case '*' when position == 1:
                    return formula + "â";
                case '+' when position == 0:
                    return "â" + formula;
                case '+' when position == 1:
                    return formula + "â";
                case '-' when position == 0:
                    return "â" + formula;
                case '-' when position == 1:
                    return formula + "â";
                case '.' when position == 0:
                    return "â" + formula;
                case '.' when position == 1:
                    return formula + "â";
                case '^' when position == 0:
                    return "â" + formula;
                case '^' when position == 1:
                    return formula + "â";
                case '√' when position == 1:
                    return formula + "â";
                case '(' when position == 1:
                    return formula = formula.Substring(formula.Length) + "à";
                case ')' when position == 0:
                    return formula = "á" + formula.Substring(1);
            }
            return formula;
        }

        private static string RemoveCharacters(List<int> CharacterIndexs, string formula, char replacingCharacter)
        {
            StringBuilder newFormula = new StringBuilder(formula);
            for (int i = 0; i < CharacterIndexs.Count; i++)
            {
                newFormula[CharacterIndexs[i]] = replacingCharacter;
            }
            return newFormula.ToString();
        }

        private static string BracketIssue(List<int> OpenBracketPos, List<int> CloseBracketPos, string formula)
        {
            formula = RemoveCharacters(OpenBracketPos, formula, 'à');
            formula = RemoveCharacters(CloseBracketPos, formula, 'á');
            return formula;
        }

        //Adds a character to the formula allowing for correct formula formation.
        private static string CharacterAdd(int pos, int initialPos, string formula, string CharacterInsert)
        {
            if (pos == initialPos - 1) { formula = formula.Insert(initialPos, CharacterInsert); }
            else { formula = formula.Insert(pos, CharacterInsert); }
            return formula;
        }

        //Checks what the char is before or after a specific char in formula string.
        private static string PositionChecker(int pos, int initialPos, string formula, char Character)
        {
            bool isSpecialCharacter = false;
            bool isPosSpecialCharacter = false;
            for (int i = 0; i < SpecialCharacterArray.Length; i++)
            {
                if (Character == SpecialCharacterArray[i])
                {
                    isSpecialCharacter = true;
                }
                if(formula[pos] == SpecialCharacterArray[i])
                {
                    if (formula[pos] == Character)
                    {
                        formula = CharacterAdd(pos, initialPos, formula, "â");
                    }
                    isPosSpecialCharacter = true;
                }
            }
            if (isSpecialCharacter == false && isPosSpecialCharacter == false)
            {
                string tempFormula = formula;
                switch (formula[pos])
                {
                    case 'â':
                        formula = CharacterAdd(pos, initialPos, formula, "*");
                        break;
                    case 'à' when formula[pos] != 'à':
                        formula = CharacterAdd(pos, initialPos, formula, "*");
                        break;
                    case 'á' when formula[pos] != 'á':
                        formula = CharacterAdd(pos, initialPos, formula, "*");
                        break;
                    case ')' when formula[pos] != ')':
                        formula = CharacterAdd(pos, initialPos, formula, "*");
                        break;
                    case '(' when formula[pos] != '(':
                        formula = CharacterAdd(pos, initialPos, formula, "*");
                        break;
                    case 'e':
                        formula = CharacterAdd(pos, initialPos, formula, "*");
                        break;
                    case 'π':
                        formula = CharacterAdd(pos, initialPos, formula, "*");
                        break;
                }
                var isNumeric = int.TryParse(Convert.ToString(formula[pos]), out _);
                var isInitialNumeric = int.TryParse(Convert.ToString(formula[initialPos]), out _);

                if (formula != tempFormula) { }
                else if (isNumeric && !isInitialNumeric)
                {
                    formula = CharacterAdd(pos, initialPos, formula, "*");
                }
                else if (!isNumeric && isInitialNumeric)
                {
                    formula = CharacterAdd(pos, initialPos, formula, "*");
                }
                else
                {
                    try
                    {
                        foreach (ClsVariables Variable in VariableArray)
                        {
                            if (Variable.GetCharacter() == formula[pos])
                            {
                                formula = CharacterAdd(pos, initialPos, formula, "*");
                            }
                        }
                    }
                    catch { }
                }
            }
            return formula;
        }

        private static string BracketSolution(int pos, char character, int initialPos, string formula)
        {
            if (character == 'à' || character == 'á' || character == '(' || character == ')') { }
            else { formula = CharacterAdd(pos, initialPos, formula, "*"); }
            return formula;
        }

        //runs after the conversion of formula, replaces the pi symbol with string that allows the formula box to read it.
        public static string ReplaceValues(string formula)
        {
            formula = formula.Replace("\\sqrt{â}", "\\surd{}");
            formula = formula.Replace("π", "{\\pi}");
            formula = formula.Replace("â", string.Empty);
            formula = formula.Replace("á", ")");
            formula = formula.Replace("à", "(");
            return formula;
        }

        //runs before conversion of formula. just replaces values which are not accepted when converting to formula.
        public static string BeforeConversionReplaceValues(string formula)
        {
            formula = formula.Replace("÷", "/");
            formula = formula.Replace("×", "*");
            formula = formula.Replace(" ", string.Empty);
            return formula;
        }

        //gets called when exe button is clicked. Converts formula then calculates formula.
        public static string ExecuteButton(string textBox)
        {
            Translator translator = new Translator();
            BaseConverter converter = new AnalyticsTeXConverter();
            try
            {                
                if (translator.CheckSyntax(textBox))
                {
                    textBox = BeforeConversionReplaceValues(textBox);                   
                    string formula = converter.Convert(textBox);
                    object result = translator.Calculate(textBox);
                    formula = ReplaceValues(formula);
                    string convertedResult = Utilities.SafeToString(result);
                    resultantValue = convertedResult;
                    return formula + " = {" + convertedResult + "}";
                }
                return textBox;
            }
            catch (Exception ex)
            {
                try
                {
                    textBox = FindSolution(textBox, ex.Message);
                    return textBox;
                }
                catch
                {
                    return textBox;
                }                
            }
        }

        //Gets called when ever button is clicked. Runs specific commands based on specific buttons.
        public static string ButtonClicked(string buttonContext, string textBox)
        {
            if (buttonContext.Length > 1)
            {
                if (buttonContext == "DEL"&& textBox.Length > 0 == true) { textBox = textBox.Remove(textBox.Length - 1, 1); }
                else if (buttonContext == "CE") { textBox = ""; }
                return textBox;
            }
            else
            {
                return textBox += buttonContext;
            }
        }
    }
}
