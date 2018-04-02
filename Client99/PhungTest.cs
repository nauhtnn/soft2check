using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Client99
{
    class PhungTest
    {
        public PhungTest() { }
       

        public static string TestAndReport()
        {
            string report = "Chưa kiểm tra File.";
            if (System.IO.File.Exists("C:/Program Files/UniKey42/UniKeyNT.exe"))
                report += "Tim thay";
            else
                report += "Khong tim thay!";
         
            return report;
        }
        
       

    }




    //test here

    ////////////////end test
}
                    