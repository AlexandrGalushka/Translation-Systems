using System;
using System.Collections.Generic;
using System.IO;
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
            AnalysButton.MouseClick += (o, e) =>
            {
                if (CodeBox.Text != null)
                {
                    try
                    {
                        Lex.Lex lex = new Lex.Lex();
                        ICollection<Lex.Lexema> list = lex.Analys(CodeBox.Lines);
                        string serializedCollection = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                        File.WriteAllText(Environment.CurrentDirectory + "\\file.json", serializedCollection);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Сначала введите текст программы!");
                }
            };

        }
    }
}
