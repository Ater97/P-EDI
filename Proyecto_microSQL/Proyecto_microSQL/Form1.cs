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
    }
}
