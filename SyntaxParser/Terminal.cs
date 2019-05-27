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
                case "IDNAME": return lex.Class == "Identifier" && lex.SubClass == "UserVariable"; 
                case "F_IDNAME": return lex.Class == "Identifier" && (lex.SubClass == "UserFunction" || lex.SubClass == "SysFunction");
                case "DOUBLE": return lex.Class == "Literal" && lex.SubClass == "DoubleLiteral";
                case "INT": return lex.Class == "Literal" && lex.SubClass == "IntLiteral";
                case "UINT": return lex.Class == "Literal" && lex.SubClass == "IntLiteral";
                case "\"ANY_SYMBOLS\"": return lex.Class == "Literal" && lex.SubClass == "StringLiteral";
                case "INT_T": return lex.Class == "ReservedWord" && lex.SubClass == "Type" && lex.Value == "int";
                case "DOUBLE_T": return lex.Class == "ReservedWord" && lex.SubClass == "Type" && lex.Value == "double";
                case "SIGNAL_T": return lex.Class == "ReservedWord" && lex.SubClass == "Type" && lex.Value == "signal";
                case "BOOL_T": return lex.Class == "ReservedWord" && lex.SubClass == "Type" && lex.Value == "bool";
                case "UINT_T": return lex.Class == "ReservedWord" && lex.SubClass == "Type" && lex.Value == "uint";
                case "STRING_T": return lex.Class == "ReservedWord" && lex.SubClass == "Type" && lex.Value == "string";
                case "if": return lex.Class == "ReservedWord" && lex.SubClass == "Conditional" && lex.Value == "if";
                case "for": return lex.Class == "ReservedWord" && lex.SubClass == "Cycle" && lex.Value == "for";
                case "while": return lex.Class == "ReservedWord" && lex.SubClass == "Cycle" && lex.Value == "while";
                case "do": return lex.Class == "ReservedWord" && lex.SubClass == "Cycle" && lex.Value == "do";
                case "else": return lex.Class == "ReservedWord" && lex.SubClass == "Conditional" && lex.Value == "else";
                case "func": return lex.Class == "ReservedWord" && lex.Value == "func";
                case "return": return lex.Class == "ReservedWord" && lex.Value == "return";
                case "(": return lex.Class == "Delimiter" && lex.Value == "(";
                case ")": return lex.Class == "Delimiter" && lex.Value == ")";   
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
                case "%": return lex.Class == "Operator" && lex.Value == "%";
                case "true": return lex.Class == "Literal" && lex.SubClass == "BoolLiteral" && lex.Value == "true";
                case "false": return lex.Class == "Literal" && lex.SubClass == "BoolLiteral" && lex.Value == "false";
                case "array": return lex.Class == "ReservedWord" && lex.SubClass == "Type" && lex.Value == "array";
                
                default: return false;
            }
        }
        public static bool operator !=(Terminal term, Lexema lex)
        {
            return !(term == lex);
        }
    }
    
}
