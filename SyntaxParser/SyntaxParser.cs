
using Lex;
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
        public bool IsParsed(IList<Lexema> lexems, out IList<Operation> opers)
        {
            opers = new List<Operation>();
            Stack <IState> workingStack = new Stack<IState>();
            workingStack.Push((_loader.LoadedNonTerminals[0] as NonTerminal).Clone());
            int caret = 0;
            for(int i = 0; i < lexems.Count; i++)
            {
                caret = i;
                if (workingStack.Peek() is Operation)
                {
                    opers.Add(workingStack.Peek() as Operation);
                    workingStack.Pop();
                    i = caret - 1;
                }
                else if (workingStack.Peek() is NonTerminal)
                {
                    Cell cell;
                    try
                    {
                        cell = _loader.RecognizeTable
                            .Single(x => x.NonTerminal.Name == workingStack.Peek().Name && x.Terminal == lexems[i]);
                    }
                    catch(InvalidOperationException e)
                    {
                        string[] expectedTerms = _loader.RecognizeTable
                            .Where(x => x.NonTerminal.Name == workingStack.Peek().Name && x.Terminal == lexems[i])
                            .Select(x => x.Terminal.Name + ",\n")
                            .ToArray();
                        string expected_terms_str = string.Empty;
                        foreach(string str in expectedTerms)
                            expected_terms_str += str;
                        if (expectedTerms.Length > 1)
                            throw new Exception("Error at line: " + lexems[i].line + " position: " + lexems[i].position + ";\n" +
                                " Unrecognize symbol;\n" + " Expected one of:\n " +
                                expected_terms_str);
                        else
                            throw new Exception("Error at line: " + lexems[i].line + " position: " + lexems[i].position + ";\n" +
                                " Unrecognize symbol;\n");
                    }
                    workingStack.Pop();
                    if (cell.Rule.RightPart[0].Name != "null")
                    {
                        var rightPart = cell.Rule.RightPart.Reverse();
                        foreach(var part in rightPart)
                        {
                            if (part is NonTerminal)
                                workingStack.Push((part as NonTerminal).Clone());
                            else if (part is Terminal)
                                workingStack.Push((part as Terminal).Clone());
                            else if (part is Operation)
                                workingStack.Push(part as Operation);

                        }
                    }
                    i = caret - 1;
                }
                else if (workingStack.Peek() is Terminal)
                {
                    if ((workingStack.Peek() as Terminal) == lexems[i])
                        workingStack.Pop();
                    else
                        throw new Exception("unexpected token; Errors at line: " + lexems[i].line + " position: " + lexems[i].position);
                }
            }
            while (workingStack.Any())
            {
                if (workingStack.Peek() is Operation)
                {
                    opers.Add(workingStack.Peek() as Operation);
                    workingStack.Pop();
                }
                else
                {
                    var cell = _loader.RecognizeTable.Single(x => x.NonTerminal.Name == workingStack.Peek().Name && x.Terminal.Name == "null");
                    workingStack.Pop();
                    if (cell.Rule.RightPart[0].Name != "null")
                    {
                        foreach (var item in cell.Rule.RightPart.Reverse())
                            if (item is NonTerminal)
                                workingStack.Push(item as NonTerminal);
                            else if (item is Terminal)
                                workingStack.Push(item as Terminal);
                    }
                }
                
            }
            return !workingStack.Any() && caret == lexems.Count - 1;
        }
    }
}
