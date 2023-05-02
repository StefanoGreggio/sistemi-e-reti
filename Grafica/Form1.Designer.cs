namespace Grafica
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_cerchio = new System.Windows.Forms.Button();
            this.btn_linea = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_cerchio
            // 
            this.btn_cerchio.Location = new System.Drawing.Point(691, 459);
            this.btn_cerchio.Name = "btn_cerchio";
            this.btn_cerchio.Size = new System.Drawing.Size(75, 23);
            this.btn_cerchio.TabIndex = 0;
            this.btn_cerchio.Text = "Cerchio";
            this.btn_cerchio.UseVisualStyleBackColor = true;
            this.btn_cerchio.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_linea
            // 
            this.btn_linea.Location = new System.Drawing.Point(772, 459);
            this.btn_linea.Name = "btn_linea";
            this.btn_linea.Size = new System.Drawing.Size(82, 24);
            this.btn_linea.TabIndex = 1;
            this.btn_linea.Text = "Linea";
            this.btn_linea.UseVisualStyleBackColor = true;
            this.btn_linea.Click += new System.EventHandler(this.btn_linea_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 495);
            this.Controls.Add(this.btn_linea);
            this.Controls.Add(this.btn_cerchio);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_cerchio;
        private System.Windows.Forms.Button btn_linea;
    }
}

