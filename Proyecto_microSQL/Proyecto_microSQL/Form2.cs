using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_microSQL
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
           // FormClosed += new FormClosedEventHandler(Form2_FormClosed);
        }

        List<string> comandolst = new List<string>();
        bool flag = false;
        //private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    Application.Exit();
        //}
     
        public List<string> getcomando()
        {
            return comandolst;
        }

        private void Cargar_Click(object sender, EventArgs e)
        {
           try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (DialogResult.OK == ofd.ShowDialog())
                {
                    string[] line;
                    string path = ofd.FileName;
                    if (ofd.FileName.Trim() != "")
                    {
                        string data = File.ReadAllText(ofd.FileName).Replace("\r\n", ",");
                        string[] strcomandos = data.Split(',');
                        //<Palabra Reservada>, <Comando en otro idioma> 
                        for (int i = 0; i < strcomandos.Length; i ++)
                        {
                            line = strcomandos[i].Split(',');
                            comandolst.Add(strcomandos[i]);
                        }
                        Path.Text = path;
                    }
                }
                flag = true;
            }
            catch
            {
                Close();
                MessageBox.Show("Ocurrio un error, intente de nuevo");
                (new Form2()).Show(); 
            }
        }
        
        private void backForm1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                (Application.OpenForms["Form1"] as Form1).gbOn();
                Close();
            }
            else
                MessageBox.Show("Por favor cargue un archivo");
        }
    }
}
