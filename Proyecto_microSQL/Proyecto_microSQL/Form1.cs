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
        List<string> tiposDeDato = new List<string>(); //lista de los tipos de datos reservados.
        Utilities U = new Utilities();
        DataGridViewManagement D = new DataGridViewManagement();
        Errors system = new Errors();

        string path = @"C:\Users\bryan\Desktop\microSQL\"; //direccion principal de los archivos

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
            tiposDeDato = U.CargarTiposDefault();
        }

        private void Continuar_Click(object sender, EventArgs e)
        {
            gbOn();
            U.CrearDefault();
            comandolst = U.CargarComando();
            tiposDeDato = U.CargarTiposDefault();
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
            int i = 0;
            int position = richTextBox1.SelectionStart;
            richTextBox1.Text = richTextBox1.Text.ToUpper();

            for (i = 0; i < comandolst.Count(); i++)
            {
                CheckKeywordColor(comandolst[i], Color.Blue);
            }

            for(i = 0; i < tiposDeDato.Count(); i++)
            {
                CheckKeywordColor(tiposDeDato[i], Color.Blue);
            }

            CheckVarcharColor();

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

        private void CheckVarcharColor()
        {
            int index = -1;
            int start = 0;
            int finish = 0;
            int selectStart = richTextBox1.SelectionStart;

            while((index = richTextBox1.Text.IndexOf("'", index + 1)) != -1 && (finish = richTextBox1.Text.IndexOf("'", index + 1)) != -1 )
            {
                start = index;
                index = finish;               
                richTextBox1.Select(start, finish - start + 1);
                richTextBox1.SelectionColor = Color.DarkOrange;
                richTextBox1.Select(selectStart, 0);
                richTextBox1.SelectionColor = Color.Black;
            }         
        }

        string[] charsToRemove = new string[] { "@", ",", ".", ";" };

        private void Enter_Click_1(object sender, EventArgs e)
        {
            int numeroError = 0;
            bool flag;
            int i = 0;
            string texto = string.Empty;
            string comando = string.Empty;
            List<string> linea;
            List<string> funcion;
            List<string> comandosRemplazos = U.ObtenerReemplazo();
            List<string> acciones = new List<string>();
            Queue<string> nombres = new Queue<string>();

            //Une todo el texto en un solo string.
            texto = string.Join(" ", richTextBox1.Lines);

            //Reemplaza los comandos separados por los comandos en una sola palabra..
            for(i = 0; i < comandolst.Count; i++)
            {
                texto = texto.Replace(comandolst[i], comandosRemplazos[i]);
            }
            
            //Cambia el INT PRIMARY KEY por INTPRIMARYKEY
            texto = texto.Replace(tiposDeDato[0], string.Join("", tiposDeDato[0].Split(' ')));

            //Convierte todo a una lista..
            linea = texto.Split(' ').ToList();
            linea = U.LimiarArray(linea.ToArray(), charsToRemove).ToList();

            //Remueve los elementos que esten vacios.
            linea.RemoveAll((y) => y == "");

            //No se puede procesar porque no hay mas datos.
            if (linea.Count <= 1)
            {
                numeroError = 7;
            }

            //Algoritmo de verificación de errores
            i = 0;
            while (i < linea.Count && numeroError == 0)
            {
                funcion = new List<string>();

                flag = true;
                for (int j = 0; j < comandosRemplazos.Count; j++)
                {
                    if (linea[i] == comandosRemplazos[j])
                    {
                        flag = false;
                        comando = comandolst[j];
                        i++;
                        break;
                    }
                }

                //No se encontro ningun comando que inicie alguna función.
                if (flag == true)
                {
                    numeroError = 5;
                    //MessageBox.Show(system.Errores(5), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                else
                {
                    //Analiza si el comando es VALUES/FROM/WHERE/GO
                    if (comando == comandolst[1] || comando == comandolst[3] || comando == comandolst[7] || comando == comandolst[8])
                    {
                        numeroError = 6;
                    }

                    //Buscar el GO correspondiente a la funcion
                    while (numeroError == 0 && i < linea.Count && linea[i] != comandosRemplazos[comandosRemplazos.Count - 1])
                    {
                        if (linea[i] != comandosRemplazos[0] && linea[i] != comandosRemplazos[2] && linea[i] != comandosRemplazos[4] && linea[i] != comandosRemplazos[5] && linea[i] != comandosRemplazos[6])
                        {
                            //Va insertando la informacion de la funcion encontrada
                            funcion.Add(linea[i]);
                            i++;
                        }
                        else
                        {
                            // Esto sucede cuando no encuentra el GO correspondiente a la función
                            // y encuentra otra funcion.
                            numeroError = 2;
                            break;
                        }
                    }
                    i++;

                    //Cuando llego al final del codigo y no encontro ningun G0
                    if (i > linea.Count)
                    {
                        numeroError = 2;
                    }

                    //Numero de Error = 0 indica que no hay errores hasta el momento
                    if (numeroError == 0)
                    {
                        numeroError = AnalizarCodigo(comando, funcion);

                        if(numeroError == 0)
                        {
                            acciones.Add(comando);
                            
                            //Cuando tenga que crear una tabla, almacena el nombre de la tabla
                            if(comando == comandolst[4])
                            {
                                nombres.Enqueue(funcion[0].Trim());
                            }                        
                        }
                    }
                }
            }

            if (numeroError != 0)
            {
                MessageBox.Show(system.Errores(numeroError), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Si no hay errores realiza todos las acciones almacenadas.

                for(i = 0; i < acciones.Count; i++)
                {
                    EjecutarAcciones(acciones[i]);

                    if (acciones[i] == comandolst[4])
                    {
                        dataGridView1.DataSource = D.NewDataTable(nombres.Dequeue());
                    }
                }

                MessageBox.Show("Se han ejecutado las acciones correctamente.", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                richTextBox1.Clear();
            }



            /*
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
                        string tem = "Por favor revise la sintaxis. Los siguientes campos son inexistentes:";
                        for (int j = 0; j < U.Missing.Count(); j++)
                        {
                            tem = tem + " " + U.Missing[j]; 
                        }
                        MessageBox.Show(tem);
                        break;
                    }
                    richTextBox1.Clear();
                    dataGridView1.DataSource = D.ToDataTable(U.listDataTable);
                    fg = true;
                    break;
                }
                //DELETE FROM 
                if(Lines[i].Contains(comandolst[2]))
                {
                    if(!U.Delete())
                    {
                        MessageBox.Show("Por favor revise la sintaxis");
                        break;
                    }
                    richTextBox1.Clear();
                   // dataGridView1.DataSource = D.NewDataTable(Lines[i + 1].Trim());
                    fg = true;
                    break;
                }
                else
                {
                    MessageBox.Show("Por favor revise la sintaxis");
                }
            }

            */
        }

        private void EjecutarAcciones(string comando)
        {
            //SELECT
            if (comando == comandolst[0])
            {
               
            }

            //DELETE
            if (comando == comandolst[2])
            {
                
            }

            //CREATE TABLE
            if (comando == comandolst[4])
            {
                U.crearTabla(U.TablasPorCrear.Dequeue());
            }

            //DROP TABLE
            if (comando == comandolst[5])
            {
                
            }

            //INSERT TO
            if (comando == comandolst[6])
            {
                
            }
        }

        private int AnalizarCodigo(string comando, List<string> datos)
        {
            /*  Si llega a generar un error retornaran el numero de error correspondiente
             *  en caso no ocurra ningun error retorna 0   */

            //SELECT
            if (comando == comandolst[0])
            {
                return U.VerificiarSintaxisSelect();
            }

            //DELETE
            if (comando == comandolst[2])
            {
                return U.VerificiarSintaxisDelete();
            }

            //CREATE TABLE
            if (comando == comandolst[4])
            {
                return U.VerificarSintaxisCrearTabla(datos);
            }

            //DROP TABLE
            if (comando == comandolst[5])
            {
                return U.VerificarSintaxisDropTable();
            }

            //INSERT TO
            if (comando == comandolst[6])
            {
                return U.VerificarSintaxisInsertTo();
            }

            //En caso que no cumpla ningun comando anterior, retorna el numero del error correspondiente
            return 6;
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
