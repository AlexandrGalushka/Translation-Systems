using Lex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxParser
{
    public class Terminal : IState
    {
        public string Name { get; set; }
        public Terminal(string name)
        {
            Name = name;
        }
        public static bool operator ==(Terminal term, Lexema lex)
        {
            switch (term.Name)
            {
                case "IDNAME": return lex.Class == "Identifier"; 
                case "DOUBLE": return lex.Class == "Literal" && lex.SubClass == "DoubleLiteral";
                case "INT": return lex.Class == "Literal" && lex.SubClass == "IntLiteral";
                case "UINT": return lex.Class == "Literal" && lex.SubClass == "IntLiteral";
                case "\"ANY_SYMBOLS\"": return lex.Class == "Literal" && lex.SubClass == "StringLiteral";
                case "(": return lex.Class == "Delimiter" && lex.Value == "(";
                case ")": return lex.Class == "Delimiter" && lex.Value == "(";   
                case "{": return lex.Class == "Delimiter" && lex.Value == "{";   
                case "}": return lex.Class == "Delimiter" && lex.Value == "}";    
                case ";": return lex.Class == "Delimiter" && lex.Value == ";";     
                case ".": return lex.Class == "Delimiter" && lex.Value == ".";
                case "[": return lex.Class == "Delimiter" && lex.Value == "[";
                case "]": return lex.Class == "Delimiter" && lex.Value == "]";
                case ",": return lex.Class == "Delimiter" && lex.Value == ",";
                case "<=": return lex.Class == "Operator" && lex.Value == "<=";   
                case ">=": return lex.Class == "Operator" && lex.Value == ">=";
                case ">": return lex.Class == "Operator" && lex.Value == ">";
                case "<": return lex.Class == "Operator" && lex.Value == "<";
                case "==": return lex.Class == "Operator" && lex.Value == "==";
                case "!=": return lex.Class == "Operator" && lex.Value == "!=";
                case "||": return lex.Class == "Operator" && lex.Value == "||";
                case "&&": return lex.Class == "Operator" && lex.Value == "&&";
                case "=": return lex.Class == "Operator" && lex.Value == "=";
                case "+": return lex.Class == "Operator" && lex.Value == "+";
                case "-": return lex.Class == "Operator" && lex.Value == "-";
                case "/": return lex.Class == "Operator" && lex.Value == "/";
                case "*": return lex.Class == "Operator" && lex.Value == "*";
                case "\"": return lex.Value == "\"";
                case "%": return lex.Class == "Operator" && lex.Value == ">=";
                case "true": return lex.Class == "Literal" && lex.SubClass == "BoolLiteral" && lex.Value == "true";
                case "false": return lex.Class == "Literal" && lex.SubClass == "BoolLiteral" && lex.Value == "false";
                default: return false;
            }
        }
        public static bool operator !=(Terminal term, Lexema lex)
        {
            return !(term == lex);
        }
    }
    
}
