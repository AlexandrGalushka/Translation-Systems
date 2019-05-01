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
    }
}
