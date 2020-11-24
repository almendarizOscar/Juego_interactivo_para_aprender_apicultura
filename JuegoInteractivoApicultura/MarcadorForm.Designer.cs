namespace JuegoInteractivoApicultura
{
    partial class MarcadorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarcadorForm));
            this.lb_puntaje = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_perdidas = new System.Windows.Forms.Label();
            this.lb_dinero = new System.Windows.Forms.Label();
            this.lb_años = new System.Windows.Forms.Label();
            this.lb_colmenas = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_puntaje
            // 
            this.lb_puntaje.AutoSize = true;
            this.lb_puntaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_puntaje.Location = new System.Drawing.Point(41, 197);
            this.lb_puntaje.Name = "lb_puntaje";
            this.lb_puntaje.Size = new System.Drawing.Size(100, 18);
            this.lb_puntaje.TabIndex = 20;
            this.lb_puntaje.Text = "Puntaje final";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(290, 463);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lb_perdidas
            // 
            this.lb_perdidas.AutoSize = true;
            this.lb_perdidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_perdidas.Location = new System.Drawing.Point(21, 162);
            this.lb_perdidas.Name = "lb_perdidas";
            this.lb_perdidas.Size = new System.Drawing.Size(127, 18);
            this.lb_perdidas.TabIndex = 14;
            this.lb_perdidas.Text = "Colonias perdidas";
            // 
            // lb_dinero
            // 
            this.lb_dinero.AutoSize = true;
            this.lb_dinero.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dinero.Location = new System.Drawing.Point(22, 123);
            this.lb_dinero.Name = "lb_dinero";
            this.lb_dinero.Size = new System.Drawing.Size(129, 18);
            this.lb_dinero.TabIndex = 13;
            this.lb_dinero.Text = "Dinero acumulado";
            // 
            // lb_años
            // 
            this.lb_años.AutoSize = true;
            this.lb_años.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_años.Location = new System.Drawing.Point(22, 82);
            this.lb_años.Name = "lb_años";
            this.lb_años.Size = new System.Drawing.Size(123, 18);
            this.lb_años.TabIndex = 12;
            this.lb_años.Text = "Años Alcanzados";
            // 
            // lb_colmenas
            // 
            this.lb_colmenas.AutoSize = true;
            this.lb_colmenas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_colmenas.Location = new System.Drawing.Point(22, 46);
            this.lb_colmenas.Name = "lb_colmenas";
            this.lb_colmenas.Size = new System.Drawing.Size(130, 18);
            this.lb_colmenas.TabIndex = 11;
            this.lb_colmenas.Text = "Total de colmenas";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(39, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(149, 25);
            this.label11.TabIndex = 81;
            this.label11.Text = "Marcador final";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(157, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(105, 20);
            this.textBox1.TabIndex = 82;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(157, 83);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(105, 20);
            this.textBox2.TabIndex = 83;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(157, 124);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(105, 20);
            this.textBox3.TabIndex = 84;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(157, 163);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(105, 20);
            this.textBox4.TabIndex = 85;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(157, 198);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(105, 20);
            this.textBox5.TabIndex = 86;
            // 
            // Marcador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(290, 463);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lb_puntaje);
            this.Controls.Add(this.lb_perdidas);
            this.Controls.Add(this.lb_dinero);
            this.Controls.Add(this.lb_años);
            this.Controls.Add(this.lb_colmenas);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Marcador";
            this.Text = "Marcador";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Marcador_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_puntaje;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_perdidas;
        private System.Windows.Forms.Label lb_dinero;
        private System.Windows.Forms.Label lb_años;
        private System.Windows.Forms.Label lb_colmenas;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
    }
}