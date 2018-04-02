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
namespace Client99
{
    class MyTest
    {
        public MyTest() { }

        public static string TestAndReport()
        {
            string report = "Chưa kiểm tra MS Office.";
            ////////////////start test

            //test here
            string filePath = @"C:/Program Files/Microsoft Office/Office14/EXCEL.exe";
            if (System.IO.File.Exists(filePath))
               report +="Tồn tại  \"Excel.exe\".";
            else
               report+="Không tồn tại \"Excel.exe\".";

            string filePath2 = @"C:/Program Files/Microsoft Office/Office14/POWERPNT.exe";
            if (System.IO.File.Exists(filePath2))
                report += "Tồn tại  \"POWERPOINT.exe\".";
            else
                report += "Không tồn tại \"POWERPOINT.exe\".";

            string filePath3 = @"C:/Program Files/Microsoft Office/Office14/WINWORD.exe";
            if (System.IO.File.Exists(filePath3))
                report += "Tồn tại  \"WINWORD.exe\".";
            else
                report += "Không tồn tại \"WINWORD.exe\".";
            ////////////////end test
            return report;
        }
    }
}
