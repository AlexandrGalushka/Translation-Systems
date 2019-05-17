﻿using Lex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxParser
{
    public class SyntaxParser
    {
        GrammarLoader _loader;
        public SyntaxParser(GrammarLoader loader)
        {
            _loader = loader;
        }
        public bool IsParsed(IList<Lexema> lexems)
        {
            Stack <IState> workingStack = new Stack<IState>();
            workingStack.Push(_loader.LoadedNonTerminals[0] as NonTerminal);
            int caret = 0;
            for(int i = 0; i < lexems.Count; i++)
            {
                if (i == 3)
                {
                    i = i;
                }
                caret = i;
                if (workingStack.Peek() is NonTerminal)
                {
                    var cell = _loader.RecognizeTable.Single(x => x.NonTerminal.Name == workingStack.Peek().Name && x.Terminal == lexems[i]);
                    workingStack.Pop();
                    if (cell.Rule.RightPart[0].Name != "null")
                    {
                        var rightPart = cell.Rule.RightPart.Reverse();
                        foreach(var part in rightPart)
                        {
                            if (part is NonTerminal)
                            {
                                workingStack.Push(part as NonTerminal);
                            }
                            else if (part is Terminal)
                            {
                                workingStack.Push(part as Terminal);
                            }
                        }
                    }
                    i = caret - 1;
                }
                else if (workingStack.Peek() is Terminal)
                {
                    if ((workingStack.Peek() as Terminal) == lexems[i])
                    {
                        workingStack.Pop();
                    }
                    else
                    {
                        throw new Exception("unexpected token");
                    }
                }
                else
                {
                    throw new Exception("uncaught type of term");
                }
            }
            while (workingStack.Any())
            {
                var cell = _loader.RecognizeTable.Single(x => x.NonTerminal.Name == workingStack.Peek().Name && x.Terminal.Name == "null");
                workingStack.Pop();
                if (cell.Rule.RightPart[0].Name != "null")
                {
                    foreach(var item in cell.Rule.RightPart.Reverse())
                    {
                        if (item is NonTerminal)
                        {
                            workingStack.Push(item as NonTerminal);
                        }
                        else if (item is Terminal)
                        {
                            workingStack.Push(item as Terminal);
                        }
                    }
                }
            }
            return !workingStack.Any() && caret == lexems.Count - 1 ? true : false;
        }
    }
}
