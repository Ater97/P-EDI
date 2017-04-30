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
        string path;

        public void setPath(string p)
        {
            path = p;
        }

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
                var charsToRemove = new string[] { "@", ",", ".", ";" };
                temp = LimiarArray(temp, charsToRemove);
                if (temp[1].Contains("INT"))
                {
                    columnas.Add(temp[0].Trim() + " (" + temp[1].Trim() + ")");
                    type.Add(temp[1]);
                    count[0]++;
                }
                else if (temp[1].Contains("VARCHAR(100)"))
                {
                    columnas.Add(temp[0].Trim() + " (" + temp[1].Trim() + ")");
                    type.Add(temp[1]);
                    count[1]++;
                }
                else if (temp[1].Contains("DATETIME"))
                {
                    columnas.Add(temp[0].Trim() + " (" + temp[1].Trim() + ")");
                    type.Add(temp[1]);
                    count[2]++;
                }
                else
                {
                    return false;
                }
            }

            if (!CrearArchivoTabla(id, columnas, tableName.Trim()))
                return false;
            if (!CrearArbol(tableName.Trim(), id, type))
                return false;
            return true;
        }
        #endregion
        
        public Tuple< List<string>, bool> splitArray(string[] complete, int index)
        {
            bool fg = false;
            List<string> newLines = new List<string>();
            for (int i = index; i < complete.Count(); i++)
            {
                if (complete[i].Trim() == ")" || complete[i].Trim() == "}" || complete[i].Trim() == ">" || complete[i].Trim() == "]")
                {
                    fg = true;
                    break;
                }
                newLines.Add(complete[i]);
            }
            return Tuple.Create( newLines,fg);
        }
       
       public int getSplitIndex(string[] completelns, int startindex, string comando)
        {
            for (int i = startindex; i < completelns.Count(); i++)
            {
                if (completelns[i].Contains(comando))
                    return i + 2;
            }
            return 0;
        }

        public string[] LimiarArray(string[] Lines, string[] toRemove)
        {
            var charsToRemove = toRemove; //eliminar caracteres extra
            for (int i = 0; i < Lines.Length; i++)
            {
                foreach (var c in charsToRemove)
                {
                    Lines[i] = Lines[i].Replace(c, string.Empty);
                }
            }

            Lines = Lines.Where(x => !string.IsNullOrEmpty(x)).ToArray(); // eliminar espacios en blanco

            return Lines;
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

        public bool insertarArbol(string tableName, List<string> values, List<string> columns)
        {
            try
            {
                bool[,] c = new bool[3, 3];
                standardObject newobj = (new standardObject
                {
                    ID = int.Parse(values[0]),
                });

                var charsToRemove = new string[] {"'"};
                for (int i = 0; i < values.Count; i++)
                {
                    foreach (var ch in charsToRemove)
                    {
                        values[i] = values[i].Replace(ch, string.Empty);
                    }
                }

                string data = File.ReadLines(path + "tablas\\" + tableName + ".tabla").First();
                string[] strDataType = data.Split(',');

                for (int i = 0; i < columns.Count(); i++)
                {
                    if (strDataType[i].Contains("(INT)"))
                    {
                        if (!c[0, 0])
                        {
                            newobj.MyProperty_int1 = int.Parse(values[i]);
                            c[0, 0] = true;
                        }
                        else if (!c[0, 1])
                        {
                            newobj.MyProperty_int2 = int.Parse(values[i]);
                            c[0, 1] = true;
                        }
                        else if (!c[0, 2])
                        {
                            newobj.MyProperty_int3 = int.Parse(values[i]);
                            c[0, 2] = true;
                        }
                        else
                            return false;
                    }
                    else if (strDataType[i].Contains("(VARCHAR(100))"))
                    {
                        if (!c[1, 0])
                        {
                            newobj.MyProperty_vchar1 = values[i];
                            c[1, 0] = true;
                        }
                        else if (!c[1, 1])
                        {
                            newobj.MyProperty_vchar2 = values[i];
                            c[1, 1] = true;
                        }
                        else if (!c[1, 2])
                        {
                            newobj.MyProperty_vchar3 = values[i];
                            c[1, 2] = true;
                        }
                        else
                            return false;
                    }
                    else if (strDataType[i].Contains("(DATETIME)"))
                    {
                        if (!c[2, 0])
                        {
                            newobj.MyProperty_dt1 = DateTime.Parse(values[i]);
                            c[2, 0] = true;
                        }
                        else if (!c[2, 1])
                        {
                            newobj.MyProperty_dt2 = DateTime.Parse(values[i]);
                            c[2, 1] = true;
                        }
                        else if (!c[2, 2])
                        {
                            newobj.MyProperty_dt3 = DateTime.Parse(values[i]);
                            c[2, 2] = true;
                        }
                        else
                            return false;
                    }
                }

                BTree<int, standardObject> tree = new BTree<int, standardObject>(tableName,5);
                tree.Insertar(int.Parse(values[0]), newobj);
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
            if (!insertarArbol(tableName.Trim(), values, columns))
                return false;
            if (!insertarArchivoTabla(tableName.Trim(), values))
                return false;
            return true;
        }
        #endregion

        #region SELECT
        public List<string> listDataTable = new List<string>();
        public List<string> Missing = new List<string>();
        public bool Select(string[] columns, string tableName, int index)
        {
            try
            {
                string data = File.ReadAllText(path + "tablas\\" + tableName + ".tabla").Replace("\r\n", "$"); //cargar tabla
              //  BTree<int, standardObject> tree = new BTree<int, standardObject>(tableName, 5); // cargar arbol
                string[] Table = data.Split('$'); //tabla completa
                List<string> showlst = new List<string>(); //tabla para mostrar
                string[] strCol = Table[0].Split(','); //etiquetas columnas
                bool[] flags = new bool[9]; //banderas por columnas
                int[] orden = new int[9]; //Orden deseado de columnas
                string temp = "";

                #region preparations
                var Remove = new string[] { "(INT)", "(VARCHAR(100))", "(DATETIME)" };
                strCol = LimiarArray(strCol, Remove);
                for (int i = 1; i < strCol.Count(); i++)
                {
                    for (int j = 0; j < strCol.Count(); j++)
                    {   
                        if (columns[i].Trim() == strCol[j].Trim())
                        {
                            flags[i - 1] = true;
                            temp = temp + columns[i] + ",";
                            orden[j] = i;
                            break;
                        }
                    }
                }

                temp = temp.TrimEnd(',');
                showlst.Add(temp);
                List<int> missing = new List<int>();
                Missing = new List<string>();

                if (!check(flags, columns).Item1)  //verificar la existencia de las columnas solicitadas
                {
                    missing = check(flags, columns).Item2;
                    for (int i = 0; i < missing.Count(); i++)
                    {
                        Missing.Add(columns[missing[i] + 1]);
                    }
                    return false;
                }
               
                #endregion

                for (int i = 1; i < Table.Count() - 1; i++)
                {
                    temp = "";
                    string[] row = Table[i].Split(',');

                    for (int j = 0; j < orden.Count(); j++)
                    {
                        int ix = orden[j] - 1;
                        if (ix >= 0)
                            temp = temp + row[ix] + ",";
                    }
                    temp = temp.TrimEnd(',');
                    showlst.Add(temp);
                }
                listDataTable = showlst;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Tuple<bool, List<int>> check(bool[] flags, string[] lines)
        {
            int index = 0;
            List<int> missing = new List<int>();
            bool fg = true;
            for (int i = 1; i < lines.Count(); i++)
            {
                if (!fg)
                    break;
                if ("FROM" == lines[i].Trim())
                {
                    fg = false;
                }
                index++;

            }
            fg = true;
            for (int i = 0; i < index - 2; i++)
            {
                if (!flags[i])
                {
                    missing.Add(i);
                    fg = false;
                }
            }

            return Tuple.Create(fg, missing);
        }

        #endregion

        #region DELETE
        public bool Delete()
        {
            try
            {

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}

