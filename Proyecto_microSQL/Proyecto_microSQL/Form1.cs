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
        TreeViewManagement T = new TreeViewManagement();
        Errors system = new Errors();
        int numeroError = 0;

        string path = string.Empty; //direccion principal de los archivos

        private void Form1_Load(object sender, EventArgs e)
        {
            path = selectPath(); //direccion principal de los archivos
            /*  Para pintar el número de linea que se esta utilizando   */
            /*  Intervalo = 10 para evitar que parpadee 
                Inicia el Timer */
            timer1.Interval = 10;
            timer1.Start();
            tabControl1.Enabled = false;
            tabControl1.Visible = false;
            U.setPath(path);
            D.setPath(path);
            T.setPath(path);
        }

        private void Enter_Click(object sender, EventArgs e)
        {

        }
        private void CargaComandos_form2_Click(object sender, EventArgs e)
        {
            gbOn();
            (frm2).Show();
            U.AlmacenarComandos(frm2.getcomando());
            comandolst = U.CargarComando();
            tiposDeDato = U.CargarTiposDefault();
        }

        private void Continuar_Click(object sender, EventArgs e)
        {
            gbOn();
            U.CrearDefault();
            comandolst = U.CargarComando();
            tiposDeDato = U.CargarTiposDefault();
            T.PopulateTree(treeView1);
        }

        public void gbOn()
        {
            U.crearFolder();
            groupBox1.Enabled = false;
            groupBox1.Visible = false;
            tabControl1.Enabled = true;
            tabControl1.Visible = true;

        }

        bool fg = true;
        string str;

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int position = richTextBox1.SelectionStart;
            richTextBox1.Text = richTextBox1.Text.ToUpper();

            for (int i = 0; i < comandolst.Count(); i++)
            {
                CheckKeyword(comandolst[i], Color.Blue, 0);
            }

            for (int i = 0; i < tiposDeDato.Count(); i++)
            {
                CheckKeyword(tiposDeDato[i], Color.Green, 0);
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

        private bool checkright(string str, string word)
        {
            int lindex = str.LastIndexOf(word);
            int index = str.IndexOf(word, 0);
            if (str.Length > index + word.Length)
            {
                if (str[index + word.Length] == ' ')
                    return true;
            }
            if (str.Trim() == word)
            {
                return true;
            }
            if (str.Length == index + word.Length)
            {
                if (str[index - 1] == ' ')
                    return true;
            }
            return false;
        }

        public int[] getindexs(string[] lines, int n, string word)
        {
            int[] temp = new int[n];
            int j = 0;
            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i].Contains(word))
                {
                    temp[j] = i;
                    j++;
                }
            }
            return temp;
        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            try
            {
                if (richTextBox1.Text.Contains(word))
                {
                    string[] lines = richTextBox1.Lines;
                    int index = -1;
                    int selectStart = richTextBox1.SelectionStart;
                    int wordcount = lines.Count(v => v.Contains(word));

                    
                    int[] indexs = getindexs(lines, wordcount, word);
                    if (wordcount > 1)
                    {
                        int k = 0;
                        for (int i = 0; i < richTextBox1.Text.Length; i++)
                        {
                            index = richTextBox1.Text.IndexOf(word, (index + 1));
                            if (checkright(lines[indexs[k]], word))
                            {
                                if (index == -1)
                                {
                                    break;
                                }
                                richTextBox1.Select((index + startIndex), word.Length);
                                richTextBox1.SelectionColor = color;
                                richTextBox1.Select(selectStart, 0);
                                richTextBox1.SelectionColor = Color.Black;
                            }
                            k++;
                            if (k > indexs.Count() - 1)
                                break;
                        }
                    }
                    else
                    {
                        if (checkright(lines[indexs[0]], word))
                        {
                            while ((index = richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                            {
                                richTextBox1.Select((index + startIndex), word.Length);
                                richTextBox1.SelectionColor = color;
                                richTextBox1.Select(selectStart, 0);
                                richTextBox1.SelectionColor = Color.Black;
                            }
                        }
                    }
                }
            }
            catch
            {
                int index = -1;
                int selectStart = richTextBox1.SelectionStart;
                while ((index = richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    richTextBox1.Select((index + startIndex), word.Length);
                    richTextBox1.SelectionColor = color;
                    richTextBox1.Select(selectStart, 0);
                    richTextBox1.SelectionColor = Color.Black;
                }
            }
        }

        private void CheckVarcharColor()
        {
            int index = -1;
            int start = 0;
            int finish = 0;
            int selectStart = richTextBox1.SelectionStart;

            while ((index = richTextBox1.Text.IndexOf("'", index + 1)) != -1 && (finish = richTextBox1.Text.IndexOf("'", index + 1)) != -1)
            {
                start = index;
                index = finish;
                richTextBox1.Select(start, finish - start + 1);
                richTextBox1.SelectionColor = Color.DarkOrange;
                richTextBox1.Select(selectStart, 0);
                richTextBox1.SelectionColor = Color.Black;
            }
        }

        string[] charsToRemove = new string[] { "@", ",", ";" };

        private void Enter_Click_1(object sender, EventArgs e)
        {
            numeroError = 0;
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
            for (i = 0; i < comandolst.Count; i++)
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
                    }

                    /* AHORA VERIFICA Y EJECUTA LA ACCION SIN IMPORTAR QUE HAY DESPUES*/
                    if (numeroError == 0)
                    {
                        EjecutarAcciones(comando);
                    }
                }
            }

            if (numeroError != 0)
            {
                MessageBox.Show(system.Errores(numeroError), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Se han ejecutado las acciones correctamente.", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                T.PopulateTree(treeView1);
                richTextBox1.Clear();
            }

        }

        private void EjecutarAcciones(string comando)
        {
            //SELECT
            if (comando == comandolst[0])
            {
                numeroError = U.Select(U.Seleccion);
                dataGridView1.DataSource = D.ToDataTable(U.listDataTable);
            }

            //DELETE
            if (comando == comandolst[2])
            {
                numeroError = U.DeleteFrom(U.DeleteTabla);
                dataGridView1.DataSource = D.ToDataTable(U.listDataTable);
            }

            //CREATE TABLE
            if (comando == comandolst[4])
            {
                U.crearTabla(U.Tabla);
                dataGridView1.DataSource = D.NewDataTable(U.Tabla.TableName);
            }

            //DROP TABLE
            if (comando == comandolst[5])
            {
                U.DropTable(U.NombreTablaEliminar);
                dataGridView1.DataSource = D.ToDataTable(U.listDataTable);
            }

            //INSERT INTO
            if (comando == comandolst[6])
            {
                numeroError = U.Insertar(U.Insertar1);

                if(numeroError == 0)
                {
                    U.MostrarContenidoArbol(U.Insertar1.TableName);
                    dataGridView1.DataSource = D.ToDataTable(U.listDataTable);
                }

            }
        }

        private int AnalizarCodigo(string comando, List<string> datos)
        {
            /*  Si llega a generar un error retornaran el numero de error correspondiente
             *  en caso no ocurra ningun error retorna 0   */

            //SELECT
            if (comando == comandolst[0])
            {
                return U.VerificiarSintaxisSelect(datos);
            }

            //DELETE
            if (comando == comandolst[2])
            {
                return U.VerificiarSintaxisDelete(datos);
            }

            //CREATE TABLE
            if (comando == comandolst[4])
            {
                return U.VerificarSintaxisCrearTabla(datos);
            }

            //DROP TABLE
            if (comando == comandolst[5])
            {
                return U.VerificarSintaxisDropTable(datos);
            }

            //INSERT TO
            if (comando == comandolst[6])
            {
                return U.VerificarSintaxisInsertTo(datos);
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //dataGridView1.DataSource = D.NewDataTable(e.Node.Text);
        }

        private string selectPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\microSQL\\";
        }

        private void btnCargarLenguaje_Click(object sender, EventArgs e)
        {
            (frm2).Show();
            U.AlmacenarComandos(frm2.getcomando());
            comandolst = U.CargarComando();
            tiposDeDato = U.CargarTiposDefault();
        }
    }
}
