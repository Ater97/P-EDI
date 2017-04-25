using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_microSQL.Utilidades
{
    class Utilities
    {
        string path = @"C:\Users\sebas\Desktop\microSQL\";

        public void crearFolder()
        {
            // direccion = @"C:\Users\bryan\Desktop\microSQL\";
            // direccion = @"Archivo\";
            Directory.CreateDirectory(path);
            Directory.CreateDirectory(Path.Combine(path, "tablas"));
        }

        // string path = "@C:\microSQL\microSQL.ini";
        //string path = @"Archivo\microSQL.ini";
       
        public bool CrearDefault()
        {
          path = Path.Combine(path, "microSQL.txt"); 
           try
            {
                FileStream fs = File.Create(path);
                fs.Close();
                using (StreamWriter file = new StreamWriter(path, true))
                {
                    file.WriteLine("SELECT,SELECT");
                    file.WriteLine("FROM,FROM");
                    file.WriteLine("DELETE,DELETE");
                    file.WriteLine("WHERE,WHERE");
                    file.WriteLine("CREATE TABLE,CREATE TABLE");
                    file.WriteLine("DROP TABLE,DROP TABLE");
                    file.WriteLine("INSERT INTO,INSERT INTO");
                    file.WriteLine("VALUES,VALUES");
                    file.WriteLine("GO,GO");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<string> CargarComando()
        {
            try
            {
                string[]line;
                List<string> comandolst = new List<string>();
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i ++)
                {
                    line = lines[i].Split(',');
                    comandolst.Add(line[0]);
                }
                return comandolst;
            }
            catch
            {
                return null;
            }
        }

     
    }
}
