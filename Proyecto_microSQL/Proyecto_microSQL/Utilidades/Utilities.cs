using Btree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Proyecto_microSQL.Utilidades
{
    class Utilities
    {
        string path = @"C:\Users\sebas\Desktop\microSQL\";

        public void crearFolder()
        {
            Directory.CreateDirectory(path);
          
            Directory.CreateDirectory(path + "\\microSQL");
            Directory.CreateDirectory(path + "\\tablas");
        }
        //string path = @"Archivo\microSQL.ini";
       
        public bool CrearDefault()
        {
        //  path = Path.Combine(path, "microSQL\\microSQL.ini"); 
           try
            {
                FileStream fs = File.Create(path + "microSQL\\microSQL.ini");
                fs.Close();
                using (StreamWriter file = new StreamWriter(path + "microSQL\\microSQL.ini", true))
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
                string[] lines = File.ReadAllLines(path + "microSQL\\microSQL.ini");
                for (int i = 0; i < lines.Length; i ++)
                {
                    line = lines[i].Split(',');
                    comandolst.Add(line[0]);
                }
                comandolst.Add("INT PRIMARY KEY");
                comandolst.Add("VARCHAR(100)");
                comandolst.Add("DATETIME");
                comandolst.Add("INT");
                return comandolst;
            }
            catch
            {
                return null;
            }
        }

        public bool CrearTabla(string tableName)
        {
            try
            {
                FileStream fs = File.Create(path + "tablas\\" + tableName + ".tabla");
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CrearArbol(string treeName)
        {
            try
            {
                BTree<string, string> a = new BTree<string, string>(treeName, 5);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool VerificarColumnas(string line)
        {
            string[] temp = line.Split(new string[] { " " }, StringSplitOptions.None);
            if (temp[0] == "INT")
            {

                return true;
            }
            else if(temp[0] == "VARCHAR(100)")
            {

                return true;
            }
            else if(temp[0] == "DATETIME")
            {

                return true;
            }
            return false;
        }

        public bool SetID(string line)
        {
            string[] name = line.Split(new string[] { "INT" }, StringSplitOptions.None);
            if (name[1].Contains("PRIMARY KEY"))
            {
                CrearTabla(name[0]);
                return true;
            }
            return false;
        }
    }
}
