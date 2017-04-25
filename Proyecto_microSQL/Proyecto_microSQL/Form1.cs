using Proyecto_microSQL.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        Form2 frm2 = new Form2();
        List<string> comandolst = new List<string>();
        Utilities U = new Utilities();

        private void Form1_Load(object sender, EventArgs e)
        {

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
        
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text.ToUpper();

            for (int i = 0; i < comandolst.Count(); i++)
            {
                CheckKeywordColor(comandolst[i], Color.Blue);
            }

            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.Focus();
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
            }
        }

        private void Enter_Click_1(object sender, EventArgs e)
        {
            //CREATE TABLE
            if (richTextBox1.Text == comandolst[4])
            {

            }
        }
    }
}
