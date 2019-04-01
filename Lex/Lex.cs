using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lex
{
    public enum LexType
    {
        ReservedWord = 1,
        Delimiter,
        OperationMark,
        Indentifier,
        StringConst,
        IntConst,
        DoubleConst,
    }
    public class Lex
    {
        
        private string[] ReservedWords = 
        {
            "for",
            "while",
            "do",
            "if",
            "else",
            "write",
            "read",
            "fread",
            "fwrite",
            "cuts",
            "int",
            "double",
            "bool",
            "signal",
            "hz",
            "convol",
            "timeof"
        };
        private string[] OperationMarks = { "+", "-", "*", "/", "%", "<", ">", "=", "==", "!=", "<=", ">=" };
        private string[] Delimiters = { "(", ")", "\"", "{", "}", ";", ",", "[","]", " "};
        private string[] Identifiers = { };
        private string[] StringConsts = { };
        private string[] NumberIntConsts = { };
        private string[] NumberDoubleConsts = { };
        private Regex IndentifierReg = new Regex(@"^[a-z|A-Z]+\w*$");
        private Regex DoubleConstReg = new Regex(@"^-?\d+\.\d+$");
        private Regex IntConstReg = new Regex(@"^-?\d+$");
        private Regex StringConstReg = new Regex("^\"\\S*\"$");




        ICollection <Lexema> Analys(string[] text)
        {
            List<Lexema> collection = new List<Lexema>();
            for (int i = 0; i < text.Length - 1; i++)
            {
                for(int j = 0; j < text[i].Length; j++)
                {
                    string tmplex = string.Empty + text[j];
                    while (!text[i][j + 1].ToString().BelongTo(Delimiters) && !text[i][j + 1].ToString().BelongTo(OperationMarks))
                    {
                        tmplex += text[i][j + 1];
                        j++;
                    }
                    LexType type;
                    if (tmplex.BelongTo(ReservedWords)) type = LexType.ReservedWord;
                    else if (tmplex.BelongTo(Delimiters)) type = LexType.Delimiter;
                    else if (tmplex.BelongTo(OperationMarks)) type = LexType.OperationMark;
                    else if (IndentifierReg.IsMatch(tmplex)) type = LexType.Indentifier;
                    else if (IntConstReg.IsMatch(tmplex)) type = LexType.IntConst;
                    else if (DoubleConstReg.IsMatch(tmplex)) type = LexType.DoubleConst;
                    else if (StringConstReg.IsMatch(tmplex)) type = LexType.StringConst;
                    else throw new Exception("Error in " + i + 1 + " line at " + j + 1 + " position");

                    collection.Add(new Lexema(i + 1, j + 1, type, tmplex));

                }
            }
            return new List<Lexema>();
            
        }

    }
    

    public struct Lexema
    {
        int line;
        int position;
        LexType type;
        string name;
        public Lexema(int line, int pos, LexType type, string name)
        {
            this.line = line;
            this.position = pos;
            this.type = type;
            this.name = name;
        }
    }
}

public static class StringExstensions
{
    public static bool BelongTo(this string name, string[] LexemClass)
    {
        foreach(var lex in LexemClass)
        {
            if (lex == name)
            {
                return true;
            }
        }
        return false;
    }
}
