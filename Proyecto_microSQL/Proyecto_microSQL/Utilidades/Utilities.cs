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
        // string path = "@C:\microSQL\microSQL.ini";
        //string path = @"Archivo\microSQL.ini";
        string path = @"C:\Users\sebas\Desktop\microSQL.txt";
        public bool CrearDefault()
        {
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
            List<string> comandolst = new List<string>();
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length - 1; i += 2)
            {
                comandolst.Add(lines[i] + "," + lines[i + 1]);
            }
            return comandolst;
        }
    }
}
