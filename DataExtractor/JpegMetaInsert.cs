using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace DataExtractor
{
    class JpegMetaInsert:JpegMetaAdapter
    {
        private readonly string path;
        private string comment;
        private Process process;



        //exiftool -XPComment="new comment2" test2.jpg   

        public JpegMetaInsert(string path)
        {
            this.path = path;

            try
            {
                File.Copy(path, path+"_original", false);
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }  
        }

        #region Miembros de JpegMetaAdapter


        public void Save()
        {
            SaveAs(this.path);
        }

        public void SaveAs(string path)
        {
         
            Console.WriteLine(path);
            process = new Process();
            process.StartInfo.FileName = "exiftool.exe";
            process.StartInfo.Arguments = "-XPComment=\"" + this.comment + "\" \"" + path + "\"";
            //Console.Write(process.StandardOutput);
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit();
            
        
        }

        public void SetComment(string comment)
        {
            this.comment = comment;
        }
        #endregion

    }
}
