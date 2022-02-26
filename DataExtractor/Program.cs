using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace DataExtractor
{
    class Program
    {
        private static Process process;

        //exiftool -XPComment="new comment2" test2.jpg   

        static void Main(string[] args)
        {
            String execPath = AppDomain.CurrentDomain.BaseDirectory;


            string[] allfiles = Directory.GetFiles(execPath, "*", SearchOption.AllDirectories);
            foreach (var file in allfiles)
            {
                FileInfo info = new FileInfo(file);
                // Do something with the Folder or just add them to a list via nameoflist.add();
                String pa;
                
                pa = info.FullName.ToString();
                
                pa=pa.Replace(execPath,"");
                //Console.WriteLine(execPath);
                Console.WriteLine(pa);
            }
            
            /* for (int i = 0; i < args.Length; i++)
            {
                AgregarNota(execPath + args[i], "Esta es una nota");

                GetBinData(execPath, args[i]);
            } */

            Console.WriteLine("Operación completa");
        }

        private static void AgregarNota(string v1, string v2)
        {
            Console.WriteLine(v1);
            process = new Process();
            process.StartInfo.FileName = "exiftool.exe";
            process.StartInfo.Arguments = "-XPComment=\"" + v2 + "\" \"" + v1 + "\"";

            process.Start();
            process.WaitForExit();
        }

        private static void GetBinData(string execPath, string p)
        {
            string binPath = execPath + p + ".bin";
            string orgPath = execPath + p;



            FileStream fileStream = new FileStream(orgPath, FileMode.Open, FileAccess.Read);

            BinaryReader binReader = new BinaryReader(fileStream, Encoding.UTF8);


            BinaryWriter binWriter =
            new BinaryWriter(File.Open(binPath, FileMode.Create));




            try
            {
                byte ac = 0, ant = 0;
                bool write = false, write2 = false;

                binWriter.Flush();

                for (int i = 0; i < fileStream.Length; i++)
                {
                    ac = binReader.ReadByte();

                    if (!write)
                        write = ant == 0xFF && ac == 0xD9;
                    else
                        if (!write2)
                        write2 = ant == 0x49 && ac == 0x52;
                    else
                    {
                        //Write stream
                        //binWriter.Write(fileBytes); // just feed it the contents verbatim
                        binWriter.Write(ac);
                    }


                    ant = ac;
                }

                binWriter.Close();

                binReader.Close();
                fileStream.Close();


            }
            catch (EndOfStreamException eose)
            {
                binReader.Close();
                fileStream.Close();

            }
            //binReader.ReadByte();
            //byte[] fileBytes = binReader.ReadBytes((int)fileStream.Length);
            //byte[] fileBytes = System.IO.File.ReadAllBytes(fileNameWithPath_); // this also works




        }
    }
}
