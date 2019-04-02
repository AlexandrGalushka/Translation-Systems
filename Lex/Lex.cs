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
        string Delimiter = "Delimiter";
        string Operator = "Operator";
        string Identifier = "Identifier";
        string StringLiteral = "StringLiteral";
        string IntLiteral = "IntLiteral";
        string DoubleLiteral = "DoubleLiteral";


        private string[] ReservedWords =
        {
            "for",//
            "while",//
            "do",//
            "if",//
            "else",//
            "write",//
            "read",//
            "fread",//
            "fwrite",//
            "cuts",//
            "int",//
            "double",
            "bool",//
            "signal",//
            "hz",//
            "convol",//
            "timeof",//
            "func",//
            "return",//
            "false",//
            "true"//
        };
        private string[] Operators = { "+", "-", "*", "/", "%", "<", ">", "=", "==", "!=", "<=", ">=", "&&", "||" };
        private string[] Delimiters = { "(", ")", "{", "}", ";", ",", "[", "]", " ", "\t" };
        private string[] OperatorSymbols = { "+", "-", "*", "/", "%", "<", ">", "=", "!", "&", "|" };

        private Regex IndentifierReg = new Regex(@"^[a-z|A-Z]+\w*$");
        private Regex DoubleConstReg = new Regex(@"^-?\d+\.\d+$");
        private Regex IntConstReg = new Regex(@"^-?\d+$");
        private Regex StringConstReg = new Regex("^\"" + @"[\S|\s]*" + "\"$");


        public ICollection<Lexema> Analys(string[] text)
        {
            List<Lexema> collection = new List<Lexema>();
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < text[i].Length; j++)
                {
                    string currSymb = text[i][j].ToString();
                    string nextSymb = j <= text[i].Length - 2 ? text[i][j + 1].ToString() : " ";
                    Regex space_reg = new Regex(@"\s+");
                    if (space_reg.IsMatch(currSymb) && space_reg.IsMatch(nextSymb))
                    {
                        continue;
                    }
                    if (currSymb.BelongTo(Delimiters))
                    {
                        if (currSymb != " " && currSymb != "\t")
                        {
                            collection.Add(new Lexema(i + 1, j + 1, Delimiter, currSymb));
                        }
                    }
                    else if (currSymb.BelongTo(OperatorSymbols))
                    {
                        string tmplex = currSymb;
                        if (nextSymb.BelongTo(OperatorSymbols))
                        {
                            tmplex += nextSymb;
                        }
                        if (tmplex.BelongTo(Operators))
                        {
                            collection.Add(new Lexema(i + 1, j + 1, Operator, tmplex));
                            j++;
                        }
                        else
                        {
                            throw new Exception("Error at " + (i + 1) + " line at " + (j + 1) + " position");
                        }
                    }
                    else
                    {
                        string tmplex = string.Empty;
                        if (!Regex.IsMatch(currSymb, @"\s+"))
                            tmplex = currSymb;
                        else
                            tmplex = string.Empty;
                        int pos = j + 1;
                        string type;
                        if (currSymb == "\"")
                        {
                            while(nextSymb != "\"")
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
                            while (!nextSymb.BelongTo(Delimiters) && !nextSymb.BelongTo(OperatorSymbols))
                            {
                                tmplex += nextSymb;
                                j++;
                                nextSymb = j + 1 < text[i].Length ? text[i][j + 1].ToString() : " ";
                            }
                        }
                        
                        if (tmplex.BelongTo(ReservedWords)) type = ReservedWord;
                        else if (IndentifierReg.IsMatch(tmplex)) type = Identifier;
                        else if (StringConstReg.IsMatch(tmplex)) type = StringLiteral;
                        else if (IntConstReg.IsMatch(tmplex)) type = IntLiteral;
                        else if (DoubleConstReg.IsMatch(tmplex)) type = DoubleLiteral;
                        else throw new Exception("Error at " + (i + 1) + " line at " + (j + 1) + " position");

                        collection.Add(new Lexema(i + 1, pos, type, tmplex));
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
        public string type { get; set; }
        public string name { get; set; }
        public Lexema(int line, int pos, string type, string name)
        {
            this.line = line;
            this.position = pos;
            this.type = type;
            this.name = name;
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
    public static bool BelongTo(this string name, string[] LexemClass)
    {
        foreach (var lex in LexemClass)
        {
            if (lex == name)
            {
                return true;
            }
        }
        return false;
    }
}
