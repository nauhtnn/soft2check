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
            DirectoryInfo dirStanford = new DirectoryInfo("D:\\Stanford");
            DirectoryInfo[] dirSub = dirStanford.GetDirectories();
            foreach (DirectoryInfo folder in dirSub)
            {
                report = "Cac file ton tai:";
                
            }

            return report;
        }
        


    }




    //test here

    ////////////////end test
}
                    