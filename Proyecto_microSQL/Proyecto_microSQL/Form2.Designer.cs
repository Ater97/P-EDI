namespace Proyecto_microSQL
{
    partial class Form2
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
            this.Path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Cargar = new System.Windows.Forms.Button();
            this.backForm1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(61, 41);
            this.Path.Name = "Path";
            this.Path.ReadOnly = true;
            this.Path.Size = new System.Drawing.Size(335, 20);
            this.Path.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Archivo:";
            // 
            // Cargar
            // 
            this.Cargar.Location = new System.Drawing.Point(12, 12);
            this.Cargar.Name = "Cargar";
            this.Cargar.Size = new System.Drawing.Size(101, 23);
            this.Cargar.TabIndex = 2;
            this.Cargar.Text = "Cargar Archivo";
            this.Cargar.UseVisualStyleBackColor = true;
            this.Cargar.Click += new System.EventHandler(this.Cargar_Click);
            // 
            // backForm1
            // 
            this.backForm1.Location = new System.Drawing.Point(340, 67);
            this.backForm1.Name = "backForm1";
            this.backForm1.Size = new System.Drawing.Size(75, 23);
            this.backForm1.TabIndex = 3;
            this.backForm1.Text = "Ok";
            this.backForm1.UseVisualStyleBackColor = true;
            this.backForm1.Click += new System.EventHandler(this.backForm1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 97);
            this.Controls.Add(this.backForm1);
            this.Controls.Add(this.Cargar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Path);
            this.Name = "Form2";
            this.Text = "Carga";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cargar;
        private System.Windows.Forms.Button backForm1;
    }
}