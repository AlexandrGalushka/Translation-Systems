using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxParser
{
    public class Rule
    {
        public NonTerminal LeftPart { get; set; }
        public IList<IState> RightPart { get; set; } = new List<IState>();
    }
}
