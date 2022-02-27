using System.Text;
using System.IO;
namespace DataExtractor
{
    class Tablero
    {
        string Nombre;
        string Mediciones;
        string Nota;
        string Path;
        string ImagePath;

        public Tablero(string path, string dir){
            string[] t = dir.Split('\\');
            this.ImagePath = path + dir;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < t.Length-1; i++)
            {
                sb.Append(t[i]);
                sb.Append("\\");
            }
            this.Path = sb.ToString();

            try
            {
                this.Nombre = readTxtFile(path+this.Path + "\\Nombre.txt");
            }
            catch (FileNotFoundException fnfe)
            {
                //El archivo no se encontró
                this.Nombre = "";
            }

            try
            {
                this.Nota = readTxtFile(path + this.Path + "\\Nota.txt");
            }
            catch (FileNotFoundException fnfe)
            {
                //El archivo no se encontró
                this.Nota = "Sin observaciones";
            }

            try
            {
                this.Mediciones = "Med: " + readTxtFile(path + this.Path + "\\Medicion.txt");
            }
            catch (FileNotFoundException fnfe)
            {
                //El archivo no se encontró
                this.Mediciones = "";
            }
        }

        public string getFilePath()
        {
            return this.ImagePath;
        }

        private string readTxtFile(string p)
        {
            return File.OpenText(p).ReadToEnd();
        }

        public string getText()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(this.Path);
            if(!this.Nombre.Equals(""))
                sb.AppendLine(this.Nombre);
            if (!this.Mediciones.Equals(""))
                sb.AppendLine(this.Mediciones);
            sb.AppendLine(this.Nota);

            return sb.ToString();

        }
    }
    
}