using SyntaxParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Lex;

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
                    var lexs_bag = lexer.Analys(CodeBox.Lines);
                    if (parser.IsParsed(lexs_bag.Lexems.ToList()))
                    {
                        ErrorsBox.Text = "Complete";
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
}
