using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxParser
{
    public static class ListExtensions
    {
        public static void Add(this IList<IState> list, IState NewState)
        {
            if (!list.Contains(NewState))
            {
                list.Add(NewState);
            }
        }
    }
    public class StateEqualityComparer : IEqualityComparer<IState>
    {
        public bool Equals(IState x, IState y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(IState obj)
        {
            return 0;
        }
    }
}
