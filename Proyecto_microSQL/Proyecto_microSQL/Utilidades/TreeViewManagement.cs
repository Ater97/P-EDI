using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_microSQL.Utilidades
{
    class TreeViewManagement
    {
        string path;
        public void setPath(string p)
        {
            path = p;
        }
        Utilities U = new Utilities();

        public void PopulateTree(TreeView tree)
        {
            try
            {
                tree.Nodes.Clear();
                List<TreeNode> roots = new List<TreeNode>();
               // roots.Add(tree.Nodes.Add("Tablas"));
                List<TreeNode> temp = new List<TreeNode>();
                temp.Add(tree.Nodes.Add("Tablas"));

                List<TreeItem> items = new List<TreeItem>(); //nombres para mostrar

                int filesCount = Directory.GetFiles(path + "tablas\\", "*", SearchOption.AllDirectories).Length; //cantidad de archivos
                string[] filesPaths = Directory.GetFiles(path + "tablas\\"); //direcciones de los archivos

                var Remove = new string[] { ".tabla", path + "tablas\\" };
                string[] fileNames = U.LimiarArray(Directory.GetFiles(path + "tablas\\"), Remove);//nombres de los archivos

                bool fg = false;
                for (int i = 0; i < filesCount; i++)
                {
                    try
                    {
                        string data = File.ReadAllText(filesPaths[i]).Replace("\r\n", "$"); //cargar tabla
                        string[] Table = data.Split('$');
                        string[] headers = Table[0].Split(','); //obtener nombre de columnas
                       // items.Add(new TreeItem(fileNames[i], 0, 0)); //agregar nombre de archivo
                        items.Add(new TreeItem("Columnas", 0, i));
                        for (int j = 0; j < headers.Count(); j++)
                        {

                            items.Add(new TreeItem(headers[j], 1, i));
                        }
                        roots.Add(tree.Nodes.Add(fileNames[i]));
                        foreach (TreeItem item in items)
                            {
                                if (item.Level == roots.Count)
                                {
                                    roots.Add(roots[roots.Count - 1].LastNode);
                                }
                                roots[item.Level].Nodes.Add(item.Name);
                            }
                       
                        fg = true;
                        items = new List<TreeItem>();
                        roots = new List<TreeNode>();

                    }
                    catch
                    {
                        items.Add(new TreeItem(fileNames[i], 0, i));
                        items.Add(new TreeItem("Carga fallida", 1, i));
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error, intente de nuevo");
            }
        }

        public List<TreeItem> fillTreeView()
        {
            try
            {
                List<TreeItem> items = new List<TreeItem>(); //nombres para mostrar

                int filesCount = Directory.GetFiles(path + "tablas\\", "*", SearchOption.AllDirectories).Length; //cantidad de archivos
                string[] filesPaths = Directory.GetFiles(path + "tablas\\"); //direcciones de los archivos

                var Remove = new string[] { ".tabla", path + "tablas\\" };
                string[] fileNames = U.LimiarArray(Directory.GetFiles(path + "tablas\\"), Remove);//nombres de los archivos

                for (int i = 0; i < filesCount; i++)
                {
                    try
                    {
                        string data = File.ReadAllText(filesPaths[i]).Replace("\r\n", "$"); //cargar tabla
                        string[] Table = data.Split('$');
                        string[] headers = Table[0].Split(','); //obtener nombre de columnas
                        items.Add(new TreeItem(fileNames[i], 0, 0)); //agregar nombre de archivo
                        items.Add(new TreeItem("Columnas", 1, i));
                        for (int j = 0; j < headers.Count(); j++)
                        {

                            items.Add(new TreeItem(headers[j], 2, i));
                        }

                    }
                    catch
                    {
                        items.Add(new TreeItem(fileNames[i], 0, i));
                        items.Add(new TreeItem("Carga fallida", 1, i));
                    }
                }
                return items;
            }
            catch
            {
                return null;
            }
        }
    }

    public class TreeItem
    {
        public string Name;
        public int Level;
        public int Father;
        public TreeItem(string name, int level, int father)
        {
            Name = name;
            Level = level;
            Father = father;
        }
    }
}
