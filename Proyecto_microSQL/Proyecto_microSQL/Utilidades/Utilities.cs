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
        string path = @"Archivo\";
        //string path = @"C:\Users\sebas\Desktop\microSQL.ini";
        public bool CrearDefault()
        {
            try
            {
                FileStream fs = File.Create(path);

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
            int counter = 0;
            List<string> comandolst = new List<string>();
            StreamReader file = new StreamReader(path);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                comandolst.Add(line);
                counter++;
            }
            file.Close();
            return comandolst;
        }
    }
}
