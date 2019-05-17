﻿using SyntaxParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace lexanalys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
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
                try
                {
                    //List<string> res = new List<string>();
                    GrammarLoader grammarLoader = new GrammarLoader();
                    //List<string> l = new List<string>();
                    
                    grammarLoader.Load(@"D:\TranslationSystems\parsegrammar2.txt");
                    grammarLoader.CreateRecognizeTable();
                   // CodeBox.Lines = grammarLoader.TableToString().ToArray();
                    //SyntaxParser.SyntaxParser parser = new SyntaxParser.SyntaxParser(grammarLoader);
                    //if (parser.IsParsed("1+2-3*(4-2)/2*3-(4*6+(5-3)*(3-1*(8-2)))"))
                    //{
                    //    ErrorsBox.Text = "String is parsed succesfully by syntax parser!";
                    //}
                    var parser = new SyntaxParser.SyntaxParser(grammarLoader);
                    var lex = new Lex.Lex();
                    var lexs_bag = lex.Analys(CodeBox.Lines);
                    try
                    {
                        if (parser.IsParsed(lexs_bag.Lexems.ToList()))
                        {
                            ErrorsBox.Text += "Complete";
                        }
                        else
                        {
                            ErrorsBox.Text += "Failed";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorsBox.Text = ex.Message;
                    }
                }
                catch (Exception ex)
                {
                    ErrorsBox.Text = ex.Message;
                }
            };
            AnalysButton.MouseClick += (o, e) =>
            {
                if (CodeBox.Text != null)
                {
                    try
                    {
                        Lex.Lex lex = new Lex.Lex();
                        Lex.LexBag bag = lex.Analys(CodeBox.Lines);
                        List<Lex.Lexema> list = bag.Lexems.ToList();
                        List<Lex.Identifier> ids = bag.Ids.ToList();

                        ErrorsBox.Text = "Complete with StatusCode: 0;\n No lexical errors found;";
                        //Excel.Application application = new Excel.Application();
                        //Excel.Workbook workbook;
                        //Excel.Worksheet worksheet;
                        //workbook = application.Workbooks.Add();
                        //worksheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);
                        //// class, item, line, positionsvn

                        //worksheet.Cells[1, 1] = "Class";
                        //worksheet.Cells[1, 2] = "SubClass";
                        //worksheet.Cells[1, 3] = "Value";
                        //worksheet.Cells[1, 4] = "Line";
                        //worksheet.Cells[1, 5] = "Position";
                        //worksheet.Cells[1, 6] = "Position in Class";
                        //worksheet.Cells[1, 7] = "Position in Subclass";

                        //int i = 2;
                        //for (i = 2; i < list.Count + 2; ++i)
                        //{
                        //    worksheet.Cells[i, 1] = list[i - 2].Class;
                        //    worksheet.Cells[i, 2] = list[i - 2].SubClass;
                        //    worksheet.Cells[i, 3] = list[i - 2].Value;
                        //    worksheet.Cells[i, 4] = list[i - 2].line;
                        //    worksheet.Cells[i, 5] = list[i - 2].position;
                        //    worksheet.Cells[i, 6] = list[i - 2].pos_class;
                        //    worksheet.Cells[i, 7] = list[i - 2].pos_subclass;
                        //}
                        //i += 2;
                        //worksheet.Cells[i, 1] = "Line";
                        //worksheet.Cells[i, 2] = "Pos";
                        //worksheet.Cells[i, 3] = "Name";
                        //worksheet.Cells[i, 4] = "Type";
                        //worksheet.Cells[i, 5] = "Count";
                        //int it = 0;
                        //for(i += 1, it = 0; it < ids.Count; it++, i++)
                        //{
                        //    worksheet.Cells[i, 1] = ids[it].line;
                        //    worksheet.Cells[i, 2] = ids[it].pos;
                        //    worksheet.Cells[i, 3] = ids[it].name;
                        //    worksheet.Cells[i, 4] = ids[it].type;
                        //    worksheet.Cells[i, 5] = ids[it].count;
                        //}
                        //application.Visible = true;
                        //application.UserControl = true;

                    }
                    catch (Exception ex)
                    {
                        ErrorsBox.Text = ex.Message;
                    }

                }
                else
                {
                    MessageBox.Show("Сначала введите текст программы!");
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
