namespace Proyecto_microSQL
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Continuar = new System.Windows.Forms.Button();
            this.CargaComandos_form2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.exportcsv = new System.Windows.Forms.Button();
            this.pBLineas = new System.Windows.Forms.PictureBox();
            this.Enter = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBLineas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Continuar);
            this.groupBox1.Controls.Add(this.CargaComandos_form2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 101);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1.";
            // 
            // Continuar
            // 
            this.Continuar.Location = new System.Drawing.Point(131, 60);
            this.Continuar.Name = "Continuar";
            this.Continuar.Size = new System.Drawing.Size(75, 23);
            this.Continuar.TabIndex = 6;
            this.Continuar.Text = "No";
            this.Continuar.UseVisualStyleBackColor = true;
            this.Continuar.Click += new System.EventHandler(this.Continuar_Click);
            // 
            // CargaComandos_form2
            // 
            this.CargaComandos_form2.Location = new System.Drawing.Point(25, 60);
            this.CargaComandos_form2.Name = "CargaComandos_form2";
            this.CargaComandos_form2.Size = new System.Drawing.Size(75, 23);
            this.CargaComandos_form2.TabIndex = 5;
            this.CargaComandos_form2.Text = "Si";
            this.CargaComandos_form2.UseVisualStyleBackColor = true;
            this.CargaComandos_form2.Click += new System.EventHandler(this.CargaComandos_form2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Desea modificar palabras reservadas \r\npor comandos en otro idioma?\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.exportcsv);
            this.groupBox2.Controls.Add(this.pBLineas);
            this.groupBox2.Controls.Add(this.Enter);
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Controls.Add(this.treeView1);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(748, 430);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2.";
            this.groupBox2.Visible = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // exportcsv
            // 
            this.exportcsv.Location = new System.Drawing.Point(586, 239);
            this.exportcsv.Name = "exportcsv";
            this.exportcsv.Size = new System.Drawing.Size(75, 23);
            this.exportcsv.TabIndex = 7;
            this.exportcsv.Text = " Export";
            this.exportcsv.UseVisualStyleBackColor = true;
            this.exportcsv.Click += new System.EventHandler(this.exportcsv_Click);
            // 
            // pBLineas
            // 
            this.pBLineas.BackColor = System.Drawing.SystemColors.Info;
            this.pBLineas.Location = new System.Drawing.Point(241, 19);
            this.pBLineas.Name = "pBLineas";
            this.pBLineas.Size = new System.Drawing.Size(45, 214);
            this.pBLineas.TabIndex = 6;
            this.pBLineas.TabStop = false;
            this.pBLineas.Paint += new System.Windows.Forms.PaintEventHandler(this.pBLineas_Paint);
            // 
            // Enter
            // 
            this.Enter.Location = new System.Drawing.Point(667, 239);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(75, 23);
            this.Enter.TabIndex = 5;
            this.Enter.Text = "Enter";
            this.Enter.UseVisualStyleBackColor = true;
            this.Enter.Click += new System.EventHandler(this.Enter_Click_1);
            // 
            // richTextBox1
            // 
            this.richTextBox1.AutoWordSelection = true;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(285, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(457, 214);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(3, 16);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(232, 408);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(240, 265);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(502, 159);
            this.dataGridView1.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 442);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "s";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBLineas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CargaComandos_form2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Continuar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button Enter;
        private System.Windows.Forms.PictureBox pBLineas;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button exportcsv;
    }
}

