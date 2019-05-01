using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SyntaxParser
{
    public class GrammarLoader
    {
        public IList<Rule> LoadedRules {get; set;} = new List<Rule>();
        public IList<NonTerminal> LoadedNonTerminals { get; set; } = new List<NonTerminal>();
        public IList<Terminal> LoadedTerminals { get; set; } = new List<Terminal>();
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
                    foreach(var state in newRule.RightPart)
                    {
                        if(state is NonTerminal)
                        {
                            LoadedNonTerminals.Add(state as NonTerminal);
                        } else if (state is Terminal)
                        {
                            LoadedTerminals.Add(state as Terminal);
                        }
                    }
                    LoadedRules.Add(newRule);
                }
            }
            else
            {
                throw new Exception("Empty file");
            }
        }
        private Rule ParseString(string str, int idx)
        {
            Regex stateReg = new Regex(@"<[^<,>]*>");
            Regex stateTypeReg = new Regex(@"\$(n|t)\$");
            Regex nameReg = new Regex(@"\$[^\$]*>");
            Rule Rule = new Rule();
            var matches = stateReg.Matches(str);
            string str_match = matches[0].ToString();
            var type = stateTypeReg.Match(str_match).ToString();
            type = type.Substring(1, type.Length - 2);
            if (type == "n")
            {
                string name = nameReg.Match(str_match).ToString();
                name = name.Substring(1, name.Length - 2);
                var nonterm = new NonTerminal(name);
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
                        var nonterm = new NonTerminal(name);
                        LoadedNonTerminals.Add(nonterm);
                        Rule.RightPart.Add(nonterm);
                        break;
                    case "t":
                        var term = new Terminal(name);
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
