using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lex
{
    public class Lex
    {
        string ReservedWord = "ReservedWord";
            string Type = "Type";
            string Cycle = "Cycle";
            string Conditional = "Conditional";

        string Delimiter = "Delimiter";
        string Operator = "Operator";

        string Identifier = "Identifier";
            string SysFunction = "SysFunction";
            string UserFunction = "UserFunction";
        string UserVariable = "UserVariable";

        string Literal = "Literal";
            string StringLiteral = "StringLiteral";
            string IntLiteral = "IntLiteral";
            string DoubleLiteral = "DoubleLiteral";
            string BoolLiteral = "BoolLiteral";

        private string[] ReservedWords =
        {
           // "for",//
           // "while",//
           // "do",//

           // "if",//
           // "else",//

           // "int",//
           /// "double",
            //"bool",//
           // "signal",//
            //"hz",//

            "func",//
            "return"//
        };
        private string[] Types = { "int", "double", "bool", "hz", "signal" };
        private string[] Cycles = { "for", "while", "do" };
        private string[] Conditionals = { "if", "else" };

        private string[] Functions =
        {
            "write",//
            "read",//
            "fread",//
            "fwrite",//
            "cuts",//
            "convol",//
            "timeof"//
        };
        private string[] Operators = { "+", "-", "*", "/", "%", "<", ">", "=", "==", "!=", "<=", ">=", "&&", "||" };
        private string[] OperatorSymbols = { "+", "-", "*", "/", "%", "<", ">", "=", "!", "&", "|" };

        private string[] Delimiters = { "(", ")", "{", "}", ";", ",", "[", "]", " ", "\t" };    

        private string[] BoolLiterals = { "true", "false" };

        private Regex IndentifierReg = new Regex(@"^[a-z|A-Z]+\w*$");
        private Regex DoubleConstReg = new Regex(@"^-?\d+\.\d+$");
        private Regex IntConstReg = new Regex(@"^-?\d+$");
        private Regex StringConstReg = new Regex("^\"" + @"[\S|\s]*" + "\"$");
        private Regex LiteralReg = new Regex(@"((^-?\d+\.\d+$)|(^-?\d+$)|" + "(^\"" + @"[\S|\s]*" + "\"$)|(true|false))");
        private Regex space_reg = new Regex(@"\s+");


        public List<Lexema> Analys(string[] text)
        {
            List<Lexema> collection = new List<Lexema>();
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < text[i].Length; j++)
                {
                    string Class = string.Empty;
                    string SubClass = string.Empty;

                    string currSymb = text[i][j].ToString();
                    string nextSymb = j <= text[i].Length - 2 ? text[i][j + 1].ToString() : " ";

                    if (!space_reg.IsMatch(currSymb))
                    {
                        if (currSymb.BelongTo(Delimiters) && !space_reg.IsMatch(currSymb))
                        {
                            Class = Delimiter;
                            collection.Add(new Lexema(i + 1, j + 1, currSymb, Class, SubClass, _pos_class: Delimiters.IndexOf(currSymb)));
                        }
                        else if (currSymb.BelongTo(OperatorSymbols))
                        {
                            string tmplex = currSymb;
                            tmplex += nextSymb.BelongTo(OperatorSymbols) ? nextSymb : string.Empty;
                            if (tmplex.BelongTo(Operators))
                            {
                                Class = Operator;
                                collection.Add(new Lexema(i + 1, j + 1, tmplex, Class, _pos_class: Operators.IndexOf(tmplex)));
                                j++;
                            }
                            else
                            {
                                throw new Exception("Error at " + (i + 1) + " line at " + (j + 1) + " position");
                            }
                        }
                        else
                        {
                            string tmplex = !space_reg.IsMatch(currSymb) ? currSymb : string.Empty;

                            int pos = j + 1;
                            if (currSymb == "\"")
                            {
                                while (nextSymb != "\"")
                                {
                                    tmplex += nextSymb;
                                    pos++;
                                    j++;
                                    nextSymb = text[i][pos].ToString();
                                }
                                tmplex += nextSymb;
                                j++;
                            }
                            else
                            {
                                while (!nextSymb.BelongTo(Delimiters, OperatorSymbols))
                                {
                                    tmplex += nextSymb;
                                    j++;
                                    nextSymb = j + 1 < text[i].Length ? text[i][j + 1].ToString() : " ";
                                }
                            }

                            if (tmplex.BelongTo(ReservedWords, Types, Cycles, Conditionals))
                            {
                                int? pos_class = null ;
                                int? pos_subclass = null;
                                Class = ReservedWord;
                                if (tmplex.BelongTo(Conditionals))
                                {
                                    SubClass = Conditional;
                                    pos_subclass = Conditionals.IndexOf(tmplex);
                                }
                                else if (tmplex.BelongTo(Types))
                                {
                                    SubClass = Type;
                                    pos_subclass = Types.IndexOf(tmplex);
                                }
                                else if (tmplex.BelongTo(Cycles))
                                {
                                    SubClass = Cycle;
                                    pos_subclass = Cycles.IndexOf(tmplex);
                                }
                                else
                                {
                                    SubClass = string.Empty;
                                }
                                collection.Add(new Lexema(i + 1, pos, tmplex, Class, SubClass, pos_class, pos_subclass));
                            }

                            else if (LiteralReg.IsMatch(tmplex))
                            {
                                Class = Literal;
                                if (StringConstReg.IsMatch(tmplex))
                                {
                                    SubClass = StringLiteral;
                                }
                                else if (IntConstReg.IsMatch(tmplex))
                                {
                                    SubClass = IntLiteral;
                                }
                                else if (DoubleConstReg.IsMatch(tmplex))
                                {
                                    SubClass = DoubleLiteral;
                                }
                                else if (tmplex.BelongTo(BoolLiterals))
                                {
                                    SubClass = BoolLiteral;
                                }
                                else throw new Exception("Error at " + (i + 1) + " line at " + (j + 1) + " position");
                                collection.Add(new Lexema(i + 1, pos, tmplex, Class, SubClass));
                            }
                            else if (IndentifierReg.IsMatch(tmplex))
                            {
                                Class = Identifier;
                                int? pos_subclass = null;
                                if (tmplex.BelongTo(Functions))
                                {
                                    SubClass = SysFunction;
                                    pos_subclass = Functions.IndexOf(tmplex);
                                }
                                else
                                {
                                    if (j + 1 < text[i].Length)
                                    {
                                        pos = j + 1;
                                        while (space_reg.IsMatch(text[i][pos].ToString()))
                                        {
                                            pos++;
                                        }
                                        if (text[i][pos].ToString() == "(")
                                        {
                                            SubClass = UserFunction;
                                        }
                                        else
                                        {
                                            SubClass = UserVariable;
                                        }
                                    }
                                }
                                collection.Add(new Lexema(i + 1, pos, tmplex, Class, SubClass, _pos_subclass: pos_subclass));
                            }
                            else throw new Exception("Error at " + (i + 1) + " line at " + (j + 1) + " position");
                        }
                    }
                }
            }
            return collection;

        }

    }




    public class Lexema
    {
        public int line { get; set; }
        public int position { get; set; }
        public int? pos_class { get; set; }
        public int? pos_subclass { get; set; }
        public string Class { get; set; }
        public string SubClass { get; set; }
        public string Value { get; set; }
        public Lexema(int _line, int pos, string value, string _class, string subclass = "", int? _pos_class = null, int? _pos_subclass = null)
        {
            line = _line;
            position = pos;
            Class = _class;
            SubClass = subclass;
            Value = value;
            pos_class = _pos_class;
            pos_subclass = _pos_subclass;
        }

        public override string ToString()
        {
            string jsonedObject = JsonConvert.SerializeObject(this);
            return jsonedObject;
        }
    }
}

public static class StringExstensions
{
    public static bool BelongTo(this string name, params string[][] LexemClasses)
    {
        foreach (var Class in LexemClasses)
        {
            foreach (var lex in Class)
            {
                if (lex == name)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public static int IndexOf(this string [] array, string value)
    {
        for(int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                return i;
            }
        }
        return -1;
    }
}
