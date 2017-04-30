using Proyecto_microSQL.Utilidades;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int caracter; //Se utiliza para la numeracion de lineas
        Form2 frm2 = new Form2(); //Form para la carga de palabras reservadas
        List<string> comandolst = new List<string>(); //lista de palabras reservadas
        Utilities U = new Utilities();
        DataGridViewManagement D = new DataGridViewManagement();
        string path = @"C:\Users\sebas\Desktop\microSQL\"; //direccion principal de los archivos

        private void Form1_Load(object sender, EventArgs e)
        {
            /*  Para pintar el número de linea que se esta utilizando   */
            /*  Intervalo = 10 para evitar que parpadee 
                Inicia el Timer */
            timer1.Interval = 10;
            timer1.Start();
            U.setPath(path);
            D.setPath(path);
        }

        private void Enter_Click(object sender, EventArgs e)
        {

        }
        private void CargaComandos_form2_Click(object sender, EventArgs e)
        {
            gbOn();
            (frm2).Show();
            comandolst = frm2.getcomando();
        }

        private void Continuar_Click(object sender, EventArgs e)
        {
            gbOn();
            U.CrearDefault();
            comandolst = U.CargarComando();
        }

        public void gbOn()
        {
            U.crearFolder();
            groupBox1.Enabled = false;
            groupBox1.Visible = false;
            groupBox2.Enabled = true;
            groupBox2.Visible = true;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        bool fg = true;
        string str;
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int position = richTextBox1.SelectionStart;
            richTextBox1.Text = richTextBox1.Text.ToUpper();

            for (int i = 0; i < comandolst.Count(); i++)
            {
                CheckKeywordColor(comandolst[i], Color.Blue);
            }

            #region bug
            if (fg)
            {
                str = richTextBox1.Text;
                richTextBox1.Text = " " + str;
                fg = false;
                position = 2;
            }

            richTextBox1.SelectionStart = position;
            richTextBox1.Focus();

            #endregion
        }

        private void CheckKeywordColor(string word, Color color)
        {
            if (richTextBox1.Text.Contains(word))
            {
                int index = -1;
                int selectStart = richTextBox1.SelectionStart;

                while ((index = richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    richTextBox1.Select(index, word.Length);
                    richTextBox1.SelectionColor = color;
                    richTextBox1.Select(selectStart, 0);
                    richTextBox1.SelectionColor = Color.Black;
                }
                //richTextBox1.Text += Environment.NewLine;
            }
        }
        string[] charsToRemove = new string[] { "@", ",", ".", ";" };
        private void Enter_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Text += Environment.NewLine;
            string[] Lines = richTextBox1.Lines;
            Lines = U.LimiarArray(Lines, charsToRemove); //eliminar espacios en blanco, enters y caracteres extra

            for (int i = 0; i < Lines.Count(); i++)
            {
                //CREATE TABLE
                if (Lines[i].Contains(comandolst[4]))
                { //crear archivo tabla y arbol
                    if (!U.crearTabla(U.splitArray(Lines, i + 4).Item1, Lines[i + 1], Lines[i + 3]) || !U.splitArray(Lines, i + 4).Item2)
                    {
                        MessageBox.Show("Por favor revise la sintaxis");
                        break;
                    }
                    richTextBox1.Clear();
                    dataGridView1.DataSource = D.NewDataTable(Lines[i + 1].Trim());
                    fg = true;
                    break;
                }
                //INSERT INTO
                if (Lines[i].Contains(comandolst[6]))
                {
                    int indexValues = U.getSplitIndex(Lines, i + 3, comandolst[7]);
                    if (!U.Insertar(Lines[i + 1], U.splitArray(Lines, i + 3).Item1, U.splitArray(Lines, indexValues).Item1)
                        || !U.splitArray(Lines, i + 3).Item2 || !U.splitArray(Lines, indexValues).Item2) //Insertar datos
                    {
                        MessageBox.Show("Por favor revise la sintaxis");
                        break;
                    }
                    richTextBox1.Clear();
                    dataGridView1.DataSource = D.NewDataTable(Lines[i + 1].Trim());
                    fg = true;
                    break;
                }
                //SELECT 
                if (Lines[i].Contains(comandolst[0]))
                {
                    int index = U.getSplitIndex(Lines, i + 1, comandolst[1]);
                    if (!U.Select(Lines, Lines[index - 1].Trim(), index))
                    {
                        MessageBox.Show("Por favor revise la sintaxis");
                        break;
                    }
                    richTextBox1.Clear();
                    dataGridView1.DataSource = D.ToDataTable(U.listDataTable);
                    fg = true;
                    break;
                }
                //DELETE FROM 

                else
                {
                    MessageBox.Show("Por favor revise la sintaxis");
                }
            }
        }

        #region Numero de Linea

        /// <summary>
        /// Timer dedicado a la actualizacion constante del picture box
        /// que pinta las lineas del editor de de texto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            /*  Cada tick, actualiza el picturebox  */
            pBLineas.Refresh();
        }

        /// <summary>
        /// Funcion del picture box encargada de pintar el numero de linea
        /// correspondiente a la que el usuario este trabajando en el editor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBLineas_Paint(object sender, PaintEventArgs e)
        {
            /*  Inicializa siempre en 0 por cada actualizacion que realice el picture box   */
            caracter = 0;
            /*  Inicializa en la altura en la primera posicion del editor   */
            int altura = richTextBox1.GetPositionFromCharIndex(0).Y;

            if (richTextBox1.Lines.Length > 0)
            {
                //No se encuentra en la primera linea del editor
                for (int i = 0; i <= richTextBox1.Lines.Length - 1; i++)
                {
                    /*  Encuentra y dibuja el número de linea que corresponde   */
                    e.Graphics.DrawString((i + 1).ToString(), richTextBox1.Font, Brushes.Blue, pBLineas.Width - (e.Graphics.MeasureString((i + 1).ToString(), richTextBox1.Font).Width + 10), altura);
                    /*  Se actualiza a la siguiente linea del editor    */
                    caracter += richTextBox1.Lines[i].Length + 1;
                    /*  Recalcula la altura donde deba pintar en el picture box */
                    altura = richTextBox1.GetPositionFromCharIndex(caracter).Y;
                }

            }
            else
            {
                /*  Se encuentra en la primera linea del editor.
                 *  Inicializa la primera linea siempre en '1'   */
                e.Graphics.DrawString("1", richTextBox1.Font, Brushes.Blue, pBLineas.Width - (e.Graphics.MeasureString("1", richTextBox1.Font).Width + 10), altura);
            }


        }

        #endregion

        private void exportcsv_Click(object sender, EventArgs e)
        {
            if (!D.Exporcsv(dataGridView1.Rows))
                MessageBox.Show("Ocurrio un error, intente de nuevo");
        }
    }
}
