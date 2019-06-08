using SyntaxParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Lex;
using Label = SyntaxParser.Label;

namespace lexanalys
{
    
    public partial class Form1 : Form
    {
        GrammarLoader grammarLoader = new GrammarLoader();
        Lex.Lex lexer = new Lex.Lex();
        SyntaxParser.SyntaxParser parser;
        public Form1()
        {
            grammarLoader.Load(@"D:\TranslationSystems\parsegrammar2.txt");
            grammarLoader.CreateRecognizeTable();
            parser = new SyntaxParser.SyntaxParser(grammarLoader);
            lexer = new Lex.Lex();
            InitializeComponent();
            ReadCode.MouseClick += (o, e) =>
            {
                using (StreamReader sr = new StreamReader(@"D:\code.txt"))
                {
                    CodeBox.Text = sr.ReadToEnd();
                }
            };
            GrammarLoad.Click += (o, e) =>
            {
                //try
                //{
                    
                //    if (parser.IsParsed(lexs_bag.Lexems.ToList()))
                //    {
                //        ErrorsBox.Text += "Complete";
                //    }
                //    else
                //    {
                //        ErrorsBox.Text += "Failed";
                //    }
                //}
                //catch (Exception ex)
                //{
                //    ErrorsBox.Text = ex.Message;
                //}
        };
            AnalysButton.MouseClick += (o, e) =>
            {
                try
                {
                    IList<SyntaxParser.Operation> opers;
                    
                    var lexs_bag = lexer.Analys(CodeBox.Lines);
                    if (parser.IsParsed(lexs_bag.Lexems.ToList(), out opers))
                    {
                        var codegen = new CodeGenerator();
                        ErrorsBox.Lines = codegen.generate(opers).Split('\n');
            
                        //ErrorsBox.Text = "Complete";
                        //ErrorsBox.Text = tree.ToString();
                        //CodeBox.Lines = tree.toStringArr().ToArray();
                    }
                    else
                    {
                        ErrorsBox.Text = "Failed";
                    }
                }
                catch (Exception ex)
                {
                    ErrorsBox.Text = ex.Message;
                }
                //var generator = new CodeGenerator();
                //ErrorsBox.Text = generator.Execute(generator.CreateOutputArray(CodeBox.Lines[0])).ToString();

            };
            CodeBox.TextChanged += (o, e) =>
            {
                string[] nums = new string[CodeBox.Lines.Length];
                for (int i = 1; i <= CodeBox.Lines.Length; i++)
                {
                    nums[i - 1] = i.ToString();
                }
                numericCode.Lines = nums;
            };
            CodeBox.VScroll += (o, e) =>
            {
                numericCode.Select(numericCode.Text.Length - 1, 0);
                numericCode.ScrollToCaret();
            };

        }

    }
    public class CodeGenerator
    {
        private int iterator = 0;
        private IList<Label> labels = new List<Label>();
        public string generate(IList<Operation> actions)
        {
            string res = string.Empty;
            foreach (var action in actions)
            {
                res += action.toString(ref iterator, labels);
            }
            return res;
        }
    }
}
