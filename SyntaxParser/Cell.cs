using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxParser
{
    public class Cell
    {
        public Rule Rule;
        public NonTerminal NonTerminal;
        public Terminal Terminal;
        public Cell(Rule rule, NonTerminal nonTerminal, Terminal terminal)
        {
            Rule = rule;
            NonTerminal = nonTerminal;
            Terminal = terminal;
        }
    }
}
