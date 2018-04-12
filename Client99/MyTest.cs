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

            var excelApp = new Excel.Application();
            excelApp.Visible = true;
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

            Excel.Workbook ex_sample = excelApp.Workbooks.Add(@"D:\users\repos\soft2check\dat\sample.xlsx");
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
               excelApp.Workbooks.Close();
               excelApp.Quit();
               report += "\nĐÃ KIỂM TRA EXCEL";
            ////////////////end test
           
            return report;
        }
    }
}
