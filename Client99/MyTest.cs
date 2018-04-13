using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using PowerPoin = Microsoft.Office.Interop.PowerPoint;
using GemBox.Document;
/*using System.Windows;
using Spire.Doc;
using Spire.Doc.Documents;*/
namespace Client99
{
    class MyTest
    {
        public MyTest() { }

        static string excel_file = "d:\\TTKMy_excel_test";
        static string excel_file_ext = excel_file + ".xlsx";

        public class Account
        {
            public int ID { get; set; }
            public double Balance
            {
                get; set;
            }
        }
                  

        public static string TestAndReport()
        {
            string report = "Chưa kiểm tra MS Office.";
            ////////////////start test

            //test here
            // kiem tra office 
            string filePath = @"C:/Program Files/Microsoft Office/Office14/EXCEL.exe";
            if (System.IO.File.Exists(filePath))
               report +="\nTồn tại  \"Excel.exe\".";
            else
               report+="\nKhông tồn tại \"Excel.exe\".";

            string filePath2 = @"C:/Program Files/Microsoft Office/Office14/POWERPNT.exe";
            if (System.IO.File.Exists(filePath2))
                report += "\nTồn tại  \"POWERPOINT.exe\".";
            else
                report += "\nKhông tồn tại \"POWERPOINT.exe\".";

            string filePath3 = @"C:/Program Files/Microsoft Office/Office14/WINWORD.exe";
            if (System.IO.File.Exists(filePath3))
                report += "\nTồn tại  \"WINWORD.exe\".";
            else
                report += "\nKhông tồn tại \"WINWORD.exe\".";


            // goi excel

            //if (System.IO.File.Exists(excel_file_ext))//xoa file kiem tra cu
            //    System.IO.File.Delete(excel_file_ext);

            //    var bankAccounts = new List<Account>
            //    {
            //        new Account
            //                {
            //                ID = 1,
            //                Balance = 8
            //                },
            //        new Account
            //                {
            //                ID = 2,
            //                Balance = 5
            //                }
            //     };

            //Random r = new Random();
            //for (int i = 3; i <= 20; ++i)
            //{
            //    Account acc = new Account();
            //    acc.ID = i;
            //    acc.Balance = r.NextDouble();
            //    bankAccounts.Add(acc);
            //}

            /*  var excelApp = new Excel.Application();
              excelApp.Visible = true;*/
            // Microsoft.Office.Interop.Excel.Workbook wbook = excelApp.Workbooks.Add();
            //      Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            //      workSheet.Cells[1, "A"] = "MASV";
            //      workSheet.Cells[1, "B"] = "DiemThi";
            //  var row = 1;
            //  foreach (var acct in  bankAccounts )
            //  {
            //      row++;
            //      workSheet.Cells[row, "A"] = acct.ID;
            //      workSheet.Cells[row, "B"] = acct.Balance;
            //  System.Threading.Thread.Sleep(100);
            //  }
            //      workSheet.Columns[1].AutoFit();
            //      workSheet.Columns[2].AutoFit();
            //      ((Excel.Range)workSheet.Columns[1]).AutoFit();
            //      ((Excel.Range)workSheet.Columns[2]).AutoFit();

            /* string path = @"D:\users\repos\soft2check\dat\sample.xlsx";
             Excel.Workbook workbook = excelApp.Workbooks.Open(path);
             workSheet = workbook.Worksheets.get_Item(1);
             workSheet.Range["A9:L9"].Copy(workSheet.Range["A10:L10"]);
             Excel.Range source = workSheet.Range["A9:L9"].Insert(Excel.XlInsertShiftDirection.xlShiftDown);
             Excel.Range dest = workSheet.Range["F10"];
             source.Copy(dest);*/



            // excelApp.WindowState = XlWindowState.xlMinimized;

            //excelApp.Visible = false;
            //Directory.SetCurrentDirectory("d:/");
            //wbook.SaveAs("kiemtra.xlsx", Excel.XlFileFormat.xlWorkbookDefault);
            //try
            //{
            //    wbook.SaveAs(excel_file, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
            //   false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
            //   Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //}
            //catch(COMException)
            //{

            //}

            /* Excel.Workbook ex_sample = excelApp.Workbooks.Add(@"D:\users\repos\soft2check\dat\sample.xlsx");
             Excel.Worksheet ws_samp = ex_sample.ActiveSheet;
             Excel.Workbook ex_m = excelApp.Workbooks.Add(excel_file_ext);
             Excel.Worksheet ws_m = ex_m.ActiveSheet;

             int i = 0;
             foreach(Excel.Range c in ws_samp.Columns)
             {
                 if (3 < ++i)
                     break;
                 c.Copy();
                 ws_m.Columns["A"].PasteSpecial();
             }
             */
            //ws.Select(true);
            //ws.Cells.Select();

            //for (int i = 2; i <= excelApp.Workbooks.Count; i++)
            //{
            //    int count = excelApp.Workbooks[i].Worksheets.Count;

            //    excelApp.Workbooks[i].Activate();
            //    for (int j = 1; j <= count; j++)
            //    {
            //        Excel._Worksheet ws = (Excel._Worksheet)excelApp.Workbooks[i].Worksheets[j];

            //        ws.Select(true);
            //        ws.Cells.Select();

            //        Excel.Range sel = (Excel.Range)excelApp.Selection;
            //        sel.Copy(Type.Missing);

            //        Excel._Worksheet sheet = (Excel._Worksheet)excelApp.Workbooks[1].Worksheets.Add(
            //            Type.Missing, Type.Missing, Type.Missing, Type.Missing
            //            );

            //        sheet.Paste(Type.Missing, Type.Missing);

            //        sheet.Name = excelApp.Workbooks[i].Worksheets[j].Name;
            //    }


            //}

            //excelApp.DisplayAlerts = false;
            //excelApp.Workbooks[3].Close();
            //excelApp.Workbooks[2].Close();
            //excelApp.DisplayAlerts = true;

            //wbook.Close();
            /*  excelApp.Workbooks.Close();
              excelApp.Quit();
              report += "\nĐÃ KIỂM TRA EXCEL";*/


            //kt wprd
            /*var wordApp = new Word.Application();
            wordApp.Visible = true;
            wordApp.Documents.Add();*/
            // wordApp.Selection.PasteSpecial(Link: true, DisplayAsIcon: true);

            /* Document doc = new Document();
             //Add Section
             Section section = doc.AddSection();
             //Add Paragraph
             Paragraph Para = section.AddParagraph();
             Para.AppendText("Hello! "
                 + "I was created by Spire.Doc for WPF, it's a professional .NET Word component "
                 + "which enables developers to perform a large range of tasks on Word document (such as create, open, write, edit, save and convert "
                 + "Word document) without installing Microsoft Office and any other third-party tools on system.");*/


            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);

            //Insert a paragraph at the beginning of the document.
            Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = "hello word ";
            oPara1.Range.Font.Bold = 1;
            oPara1.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
            oPara1.Range.InsertParagraphAfter();
            //Insert a paragraph at the end of the document.
            Word.Paragraph oPara2;
            object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara2.Range.Text = "troi oi xong roi";
            oPara2.Format.SpaceAfter = 6;
            oPara2.Range.InsertParagraphAfter();
            //Insert another paragraph.
            Word.Paragraph oPara3;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara3.Range.Text = "This is a sentence of normal text. Now here is a table:";
            oPara3.Range.Font.Bold = 0;
            oPara3.Format.SpaceAfter = 24;
            oPara3.Range.InsertParagraphAfter();

           

            //Insert a 3 x 5 table, fill it with data, and make the first row
            //bold and italic.
            Word.Table oTable;
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, 3, 5, ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = 6;
            int r, c;
            string strText;
            for (r = 1; r <= 3; r++)
                for (c = 1; c <= 5; c++)
                {
                    strText = "r" + r + "c" + c;
                    oTable.Cell(r, c).Range.Text = strText;
                }
            oTable.Rows[1].Range.Font.Bold = 1;
            oTable.Rows[1].Range.Font.Italic = 1;

            //Add some text after the table.
            Word.Paragraph oPara4;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara4 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara4.Range.InsertParagraphBefore();
            oPara4.Range.Text = "And here's another table:";
            oPara4.Format.SpaceAfter = 24;
            oPara4.Range.InsertParagraphAfter();

            //Insert a 5 x 2 table, fill it with data, and change the column widths.
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, 5, 2, ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = 6;
            for (r = 1; r <= 5; r++)
                for (c = 1; c <= 2; c++)
                {
                    strText = "r" + r + "c" + c;
                    oTable.Cell(r, c).Range.Text = strText;
                }
            oTable.Columns[1].Width = oWord.InchesToPoints(2); //Change width of columns 1 & 2
            oTable.Columns[2].Width = oWord.InchesToPoints(3);

            //Keep inserting text. When you get to 7 inches from top of the
            //document, insert a hard page break.
            object oPos;
            double dPos = oWord.InchesToPoints(7);
            oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range.InsertParagraphAfter();
            do
            {
                wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                wrdRng.ParagraphFormat.SpaceAfter = 6;
                wrdRng.InsertAfter("A line of text");
                wrdRng.InsertParagraphAfter();
                oPos = wrdRng.get_Information
                                       (Word.WdInformation.wdVerticalPositionRelativeToPage);
            }
            while (dPos >= Convert.ToDouble(oPos));
            object oCollapseEnd = Word.WdCollapseDirection.wdCollapseEnd;
            object oPageBreak = Word.WdBreakType.wdPageBreak;
            wrdRng.Collapse(ref oCollapseEnd);
            wrdRng.InsertBreak(ref oPageBreak);
            wrdRng.Collapse(ref oCollapseEnd);
            wrdRng.InsertAfter("We're now on page 2. Here's my chart:");
            wrdRng.InsertParagraphAfter();

            //Insert a chart.
            Word.InlineShape oShape;
            object oClassType = "MSGraph.Chart.8";
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oShape = wrdRng.InlineShapes.AddOLEObject(ref oClassType, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing);

            //Demonstrate use of late bound oChart and oChartApp objects to
            //manipulate the chart object with MSGraph.
            object oChart;
            object oChartApp;
            oChart = oShape.OLEFormat.Object;
            oChartApp = oChart.GetType().InvokeMember("Application",
            BindingFlags.GetProperty, null, oChart, null);

            //Change the chart type to Line.
            object[] Parameters = new Object[1];
            Parameters[0] = 4; //xlLine = 4
            oChart.GetType().InvokeMember("ChartType", BindingFlags.SetProperty,
            null, oChart, Parameters);

            //Update the chart image and quit MSGraph.
            oChartApp.GetType().InvokeMember("Update",
            BindingFlags.InvokeMethod, null, oChartApp, null);
            oChartApp.GetType().InvokeMember("Quit",
            BindingFlags.InvokeMethod, null, oChartApp, null);
            //... If desired, you can proceed from here using the Microsoft Graph 
            //Object model on the oChart and oChartApp objects to make additional
            //changes to the chart.

            //Set the width of the chart.
            oShape.Width = oWord.InchesToPoints(6.25f);
            oShape.Height = oWord.InchesToPoints(3.57f);

            //Add text after the chart.
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            wrdRng.InsertParagraphAfter();
            wrdRng.InsertAfter("THE END.");
            ////////////////end test
            return report;
        }
    }
}
