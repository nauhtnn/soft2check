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
            CleanDesktop();
            report += CleanDrive();
            return report;
        }
        
       public static string CleanDesktop()
        {
            //read file ../../../dat/desktop.txt
            string[] keep = System.IO.File.ReadAllLines("../../../dat/desktop.txt");

            //list files in Desktop of current user
            string[] all = System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory));

            //loop the files, if not contain strings in
            string report = "";
            foreach(string f in all)
            {
                bool toDel = true;
                foreach (string k in keep)
                    if (f.ToLower().Contains(k))
                    {
                        toDel = false;
                        break;
                    }
                    else if (toDel)
                        try
                        {

                            System.IO.File.Delete(f);
                            report += "_" + f + "_ đã bị xóa\n";
                        }
                        catch (UnauthorizedAccessException)
                        {
                            report += "!!!! bỏ qua tap tin _" + f + "_\n";
                        }
                    
            }
            return report;
        }

        public static string CleanDrive()
        {
            string report = "";
            if (System.IO.File.Exists("C:/Program Files/UniKey42/UniKeyNT.exe"))
                report += "Tim thay";
            else
                report += "Khong tim thay!";
            // xoa file
            report += "\n--------------\n";

            string[] folders = System.IO.Directory.GetDirectories("D:/");
            foreach (string p in folders)
            {
                if ((!p.ToLower().Contains("users")))
                {
                    try
                    {

                        System.IO.Directory.Delete(p, true);
                        report += "_" + p + "_ đã bị xóa\n";
                    }
                    catch (UnauthorizedAccessException)
                    {
                        report += "!!!! bỏ qua thư mục _" + p + "_\n";
                    }
                    catch (IOException)
                    {
                        report += "!!!! bỏ qua thư mục _" + p + "_\n";

                    }

                }
            }
            string[] filePaths1 = System.IO.Directory.GetFiles(@"D:/", "*.*");
            foreach (string p in filePaths1)
            {
                try
                {
                    System.IO.File.Delete(p);
                    report += "_" + p + "_đã bị xóa\n";
                }
                catch (UnauthorizedAccessException)
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
                    