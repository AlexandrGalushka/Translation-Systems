using MoreLinq.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SyntaxParser
{
    public class GrammarLoader
    {
        public IList<Rule> LoadedRules { get; set; } = new List<Rule>();
        public IList<NonTerminal> LoadedNonTerminals { get; set; } = new List<NonTerminal>();
        public IList<Terminal> LoadedTerminals { get; set; } = new List<Terminal>();
        public IList<Cell> RecognizeTable { get; set; } = new List<Cell>();
        public void Load(string filepath)
        {
            IList<string> text = new List<string>();
            using (StreamReader sr = new StreamReader(filepath))
            {
                while (!sr.EndOfStream)
                {
                    text.Add(sr.ReadLine());
                }
            }
            if (text.Count > 0)
            {
                for (int i = 0; i < text.Count; i++)
                {
                    Rule newRule = ParseString(text[i], i);
                    LoadedNonTerminals.Add(newRule.LeftPart);
                    foreach (IState state in newRule.RightPart)
                    {
                        if (state is NonTerminal)
                        {
                            LoadedNonTerminals.Add(state as NonTerminal);
                        }
                        else if (state is Terminal)
                        {
                            LoadedTerminals.Add(state as Terminal);
                        }
                    }
                    LoadedRules.Add(newRule);
                }
                LoadedNonTerminals = LoadedNonTerminals.DistinctBy(x => x.Name).ToList();
                LoadedTerminals = LoadedTerminals.DistinctBy(x => x.Name).ToList();
                //CreateRecognizeTable();
            }
            else
            {
                throw new Exception("Empty file");
            }
        }
        public void CreateRecognizeTable()
        {
            foreach (NonTerminal nonterminal in LoadedNonTerminals)
            {
                foreach (Terminal terminal in LoadedTerminals)
                {
                    List<Rule> rules = LoadedRules.Where(x => x.LeftPart.Name == nonterminal.Name).ToList();
                    foreach (Rule rule in rules)
                    {
                        if (CanGoFromNonTerminalToTerminal(nonterminal, terminal, rule))
                        {
                            Cell cell = new Cell(rule, nonterminal, terminal);
                            RecognizeTable.Add(cell);
                        }
                    }
                }
            }
            
            IEnumerable<Cell> cells = RecognizeTable.Where(x => x.Rule.RightPart[0].Name == "null");
            List<Cell> removes = new List<Cell>();
            foreach (Cell cell in cells)
            {
                if (RecognizeTable.Any(x => x.NonTerminal.Name == cell.NonTerminal.Name && x.Terminal.Name == cell.Terminal.Name && x.Rule.RightPart[0].Name != "null"))
                {
                    removes.Add(cell);
                }
            }
            foreach (Cell cell in removes)
            {
                RecognizeTable.Remove(cell);
            }
        }
        public IList<string> TableToString()
        {
            IList<string> table = new List<string>();

            foreach (Cell cell in RecognizeTable)
            {

                string str_rule = cell.Rule.LeftPart.Name + "  ->  ";
                foreach (IState ri_part in cell.Rule.RightPart)
                {
                    str_rule += ri_part.Name + " ; ";
                }


                table.Add(cell.NonTerminal.Name + "    " + cell.Terminal.Name + "    " + str_rule);
            }
            return table;
        }
        private bool CanGoFromNonTerminalToTerminal(NonTerminal nonTerminal, Terminal terminal, Rule rule)
        {
            if (nonTerminal.Name == rule.LeftPart.Name)
            {
                if (rule.RightPart[0] is NonTerminal)
                {
                    List<Rule> rules = LoadedRules.Where(x => x.LeftPart.Name == rule.RightPart[0].Name).ToList();
                    foreach (Rule rule_it in rules)
                    {
                        if (CanGoFromNonTerminalToTerminal(rule.RightPart[0] as NonTerminal, terminal, rule_it))
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else if (rule.RightPart[0] is Terminal)
                {
                    return rule.RightPart[0].Name == terminal.Name || rule.RightPart[0].Name == "null" ? true : false;
                }
            }
            else
            {
                throw new Exception("This rule does not correct for this non terminals");
            }
            return false;
        }
        private Rule ParseString(string str, int idx)
        {
            Regex stateReg = new Regex(@"<\$[n,t]\$[^$]*>");
            Regex stateTypeReg = new Regex(@"\$(n|t)\$"); //need fix this
            Regex nameReg = new Regex(@"\$[^\$]*>");
            Rule Rule = new Rule();
            MatchCollection matches = stateReg.Matches(str);
            string str_match = matches[0].ToString();
            string type = stateTypeReg.Match(str_match).ToString();
            type = type.Substring(1, type.Length - 2);
            if (type == "n")
            {
                string name = nameReg.Match(str_match).ToString();
                name = name.Substring(1, name.Length - 4);
                NonTerminal nonterm = new NonTerminal(name);
                Rule.LeftPart = nonterm;
                LoadedNonTerminals.Add(nonterm);
            }
            else
            {
                throw new Exception("terminal cannot spawn rules");
            }
            for (int j = 1; j < matches.Count; j++)
            {
                type = stateTypeReg.Match(matches[j].ToString()).ToString();
                type = type.Substring(1, type.Length - 2);
                str_match = matches[j].ToString();
                string name = nameReg.Match(str_match).ToString();
                name = name.Substring(1, name.Length - 2);
                switch (type)
                {
                    case "n":
                        NonTerminal nonterm = new NonTerminal(name);
                        LoadedNonTerminals.Add(nonterm);
                        Rule.RightPart.Add(nonterm);
                        break;
                    case "t":
                        Terminal term = new Terminal(name);
                        LoadedTerminals.Add(term);
                        Rule.RightPart.Add(term);
                        break;
                    default:
                        throw new Exception(string.Format("In {0} line type of state is not valid", idx + 1));
                };
            }
            return Rule;
        }
    }
}
