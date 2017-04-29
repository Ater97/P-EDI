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

        #region CreateStuff
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

        public bool CrearArchivoTabla(string id, List<string> columns, string tablename)
        {
            try
            {
                string[] name = id.Split(new string[] { "INT" }, StringSplitOptions.None);
                if (name[1].Contains("PRIMARY KEY"))
                {
                    FileStream fs = File.Create(path + "tablas\\" + tablename + ".tabla");
                    fs.Close();
                    using (StreamWriter file = new StreamWriter(path + "tablas\\" + tablename + ".tabla", true))
                    {
                        file.WriteLine(name[0] + "," + string.Join(",", columns));
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CrearArbol(string treeName, string id ,List<string> types)
        {
            try
            {
                BTree<int, standardObject> a = new BTree<int, standardObject>(treeName, 5);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool crearTabla(List<string> lineas, string tableName, string id)
        {
            List<string> columnas = new List<string>();
            List<string> type = new List<string>();
            int[] count = new int[3]; //conteo tipo de dato
            for (int i = 0; i < lineas.Count(); i++) //verificar formato
            {
                if (count[0] > 3 || count[1] > 3 || count[2] > 3)
                {
                    return false;
                }

                string[] temp = lineas[i].Split(new string[] { " " }, StringSplitOptions.None);

                if (temp[1] == "INT")
                {
                    columnas.Add(temp[0] + " (" + temp[1] + ")");
                    type.Add(temp[1]);
                    count[0]++;
                }
                else if (temp[1] == "VARCHAR(100)")
                {
                    columnas.Add(temp[0] + " (" + temp[1] + ")");
                    type.Add(temp[1]);
                    count[1]++;
                }
                else if (temp[1] == "DATETIME")
                {
                    columnas.Add(temp[0] + " (" + temp[1] + ")");
                    type.Add(temp[1]);
                    count[2]++;
                }
                else
                {
                    return false;
                }
            }

            if (!CrearArchivoTabla(id, columnas, tableName))
                return false;
            if (!CrearArbol(tableName, id, type))
                return false;
            return true;
        }
        #endregion

        public List<string> splitArray(string[] complete, int index)
        {
            List<string> newLines = new List<string>();
            for (int i = index; i < complete.Count(); i++)
            {
                if (complete[i].Trim() == ")" || complete[i].Trim() == "}" || complete[i].Trim() == ">")
                {
                    break;
                }
                newLines.Add(complete[i]);
            }
            return newLines;
        }
       
       public int getSplitIndex(string[] completelns, int startindex, string comando)
        {
            for (int i = startindex; i < completelns.Count(); i++)
            {
                if (completelns.Contains(comando))
                    return i;
            }
            return 0;
        }

        #region Insert
        public bool insertarArchivoTabla(string tableName, List<string> values)
        {
           try
            {
                using (StreamWriter file = new StreamWriter(path + "tablas\\" + tableName + ".tabla", true))
                {
                    file.WriteLine(string.Join(",", values));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool insertarArbol(string tableName, List<string> values)
        {
            try
            {
                standardObject newobj = (new standardObject
                {
                    ID = int.Parse(values[0]),
                });
                //object instance;
                //for (int i = 0; i < types.Count(); i++)
                //{
                //    Type type = Type.GetType( , true);

                //    instance = Activator.CreateInstance(type);

                //    PropertyInfo prop = type.GetProperty(types[i])
                //}


                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Insertar(string tableName, List<string> columns, List<string> values)
        {
            for (int i = 0; i < columns.Count(); i++)//verificar formato
            {

            }
            for (int i = 0; i < values.Count(); i++)//verificar formato
            {

            }

            return true;
        }
        #endregion
    }
}

