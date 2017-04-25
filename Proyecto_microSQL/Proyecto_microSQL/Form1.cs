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
            (frm2).Show(); 
            groupBox1.Enabled = false;
            groupBox1.Visible = false;
            comandolst = frm2.getcomando();
        }
        
        private void Continuar_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox1.Visible = false;
            U.CrearDefault();
            gbOn();
            comandolst = U.CargarComando();
        }

        public void gbOn()
        {
            groupBox2.Enabled = true;
            groupBox2.Visible = true;
        }
 
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < comandolst.Count(); i++)
            {
                CheckKeyword(comandolst[i], Color.Blue);
            }

            if (comandolst[0] == richTextBox1.Text)
            {
                MessageBox.Show("sdfdsfs");
            }
            if (comandolst[1] == richTextBox1.Text)
            {
                MessageBox.Show("good");
            }
        }

        private void CheckKeyword(string word, Color color)
        {
            try
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
            catch
            {

            }
        }
    }
}
