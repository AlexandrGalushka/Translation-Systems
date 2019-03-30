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
            "timeof",
            "func",
            "return"
        };
        private string[] Operators = { "+", "-", "*", "/", "%", "<", ">", "=", "==", "!=", "<=", ">=" };
        private string[] Delimiters = { "(", ")", "\"", "{", "}", ";", ",", "[", "]", " " };
        private string[] OperatorSymbols = { "+", "-", "*", "/", "%", "<", ">", "=", "!" };

        private Regex IndentifierReg = new Regex(@"^[a-z|A-Z]+\w*$");
        private Regex DoubleConstReg = new Regex(@"^-?\d+\.\d+$");
        private Regex IntConstReg = new Regex(@"^-?\d+$");
        private Regex StringConstReg = new Regex("^\"\\S*\"$");




        public ICollection<Lexema> Analys(string[] text)
        {
            List<Lexema> collection = new List<Lexema>();
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < text[i].Length; j++)
                {
                    string currSymb = text[i][j].ToString();
                    string nextSymb = j <= text[i].Length - 2 ? text[i][j + 1].ToString() : " ";
                    if (currSymb.BelongTo(Delimiters))
                    {
                        if (currSymb != " ")
                        {
                            collection.Add(new Lexema(i + 1, j + 1, LexType.Delimiter, currSymb));
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
                            collection.Add(new Lexema(i + 1, j + 1, LexType.OperationMark, tmplex));
                        }
                        else
                        {
                            throw new Exception("Error at " + i + 1 + " line at " + j + 1 + "position");
                        }
                    }
                    else
                    {
                        string tmplex = currSymb;
                        int pos = j + 1;
                        LexType type;
                        while (!nextSymb.BelongTo(Delimiters) && !nextSymb.BelongTo(OperatorSymbols))
                        {
                            tmplex += nextSymb;
                            j++;
                            nextSymb = text[i][j+1].ToString();
                        }
                        if (tmplex.BelongTo(ReservedWords)) type = LexType.ReservedWord;
                        else if (IndentifierReg.IsMatch(tmplex)) type = LexType.Indentifier;
                        else if (StringConstReg.IsMatch(tmplex)) type = LexType.StringConst;
                        else if (IntConstReg.IsMatch(tmplex)) type = LexType.IntConst;
                        else if (DoubleConstReg.IsMatch(tmplex)) type = LexType.DoubleConst;
                        else throw new Exception("Error at " + i + 1 + " line at " + j + 1 + "position");
                    
                        collection.Add(new Lexema(i+1, pos, type, tmplex));
                    }
                }
            }
            return collection;

        }

    }

    //бежим посимвольно
        //если символ это разделитель
            //пхаем его в лексемы как разделитель
        //иначе если символ входит в множество знаков операций 
            //если следующий символ тоже входит во множество знаков операций
                //склеиваем эти 2 символа
            //если полученная строка является лексемой 
                //добавляем в список лексем
            //иначе ексепшн
        //иначе наращиваем слово
            //пока следующий символ не является разделителем и не входит во множество знаков операций
                //наращиваем лексему
            //*после цикла*
            //если полученное слово является лексемой класа "зарезервированные слова"
                //пхаем в список лексем как зарезервированное слово
            //иначе если это слово подходит как идентификатор
                //пхаем как идентификатор
            //иначе если это слово подходит как стрингконст
                //пхаем как стринг конст
            //иначе если подходит как инт
                //пхаем как инт
            //иначе если подходит как дабл
                //пхаем как дабл



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
