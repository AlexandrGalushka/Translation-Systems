using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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
                        List<Lex.Lexema> list = lex.Analys(CodeBox.Lines).ToList();
                        //string serializedCollection = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                        //File.WriteAllText(Environment.CurrentDirectory + "\\file.json", serializedCollection);
                        Excel.Application application = new Excel.Application();
                        Excel.Workbook workbook;
                        Excel.Worksheet worksheet;
                        workbook = application.Workbooks.Add();
                        worksheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);
                        // class, item, line, position
                        worksheet.Cells[1, 1] = "Class";
                        worksheet.Cells[1, 2] = "Item";
                        worksheet.Cells[1, 3] = "Line";
                        worksheet.Cells[1, 4] = "Position";

                        for (int i = 2; i < list.Count + 2; ++i)
                        {
                            worksheet.Cells[i, 1] = list[i - 2].type;
                            worksheet.Cells[i, 2] = list[i - 2].name;
                            worksheet.Cells[i, 3] = list[i - 2].line;
                            worksheet.Cells[i, 4] = list[i - 2].position;
                        }

                        application.Visible = true;
                        application.UserControl = true;

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
