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
using Word = Microsoft.Office.Interop.Word;
using Powerpoint = Microsoft.Office.Interop.PowerPoint;
using Excel = Microsoft.Office.Interop.Excel;
namespace Client99
{
    class MyTest
    {
        public MyTest() { }

        static string excel_file = "d:\\TTKMy_excel_test";

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

            /*  if (System.IO.File.Exists(excel_file))//xoa file kiem tra cu
                  System.IO.File.Delete(excel_file);

               var bankAccounts = new List<Account>
               {
                   new Account
                           {
                           ID = 01,
                           Balance = 8
                           },
                   new Account
                           {
                           ID = 02,
                           Balance = 5

                           }
                };

               var excelApp = new Excel.Application();
                   excelApp.Visible = true;
              Microsoft.Office.Interop.Excel.Workbook wbook = excelApp.Workbooks.Add();
                   Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

                   workSheet.Cells[1, "A"] = "MASV";
                   workSheet.Cells[1, "B"] = "DiemThi";
               var row = 1;
               foreach (var acct in  bankAccounts )
               {
                   row++;
                   workSheet.Cells[row, "A"] = acct.ID;
                   workSheet.Cells[row, "B"] = acct.Balance;
               }
                   workSheet.Columns[1].AutoFit();
                   workSheet.Columns[2].AutoFit();
                   ((Excel.Range)workSheet.Columns[1]).AutoFit();
                   ((Excel.Range)workSheet.Columns[2]).AutoFit();

              //excelApp.Visible = false;
              //Directory.SetCurrentDirectory("d:/");
              //wbook.SaveAs("kiemtra.xlsx", Excel.XlFileFormat.xlWorkbookDefault);
              wbook.SaveAs(excel_file, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
              false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
              Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
              wbook.Close();
              excelApp.Workbooks.Close();
              excelApp.Quit();
              report += "\nĐÃ KIỂM TRA EXCEL";*/
            
            
            // kiem tra word.

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc";

            //Start Word and create a new document.

            Word.Application oWord;
            Word.Document oDoc;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
       
            ////////////////end test
            return report;
        }
    }
}
