using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Collections;


namespace DataExtractor
{
    class Program
    {
        static ArrayList atab = new ArrayList();

        static void Main(string[] args)
        {
            String execPath = AppDomain.CurrentDomain.BaseDirectory;


            Console.WriteLine(execPath);

            string[] allfiles = Directory.GetFiles(execPath, "*", SearchOption.AllDirectories);
            foreach (var file in allfiles)
            {
                FileInfo info = new FileInfo(file);
                // Do something with the Folder or just add them to a list via nameoflist.add();
                String pa;
                
                pa = info.FullName.ToString();
                
                pa=pa.Replace(execPath,"");
                if(pa.EndsWith(".jpg")){
                    //Console.WriteLine(execPath);
                    atab.Add(new Tablero(execPath,pa));
                    Console.WriteLine(pa);
                }
            }
            int i = 0;

            JpegMetaAdapter jma;

            foreach (Tablero item in atab)
            {
                Console.WriteLine(item.getText());
                jma = new JpegMetadataAdapter(item.getFilePath());
                //jma = new JpegMetaInsert(item.getFilePath());
                jma.SetComment(item.getText());
                jma.Save();
                i++;
                //if(i>10)
                //break;
            }
            
            /* for (int i = 0; i < args.Length; i++)
            {
                AgregarNota(execPath + args[i], "Esta es una nota");

                GetBinData(execPath, args[i]);
            } */

            Console.WriteLine("Operación completa");
            Console.ReadKey();
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
