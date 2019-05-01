using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxParser
{
    public class NonTerminal : IState
    {
        public string Name { get; set; }
        public NonTerminal(string name)
        {
            Name = name;
        }
    }
}
