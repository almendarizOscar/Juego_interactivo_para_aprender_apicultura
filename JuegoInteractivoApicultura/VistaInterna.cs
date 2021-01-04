using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoInteractivoApicultura
{
    public partial class VistaInterna : Form
    {
        private Colmena colmena; //Colmena que estamos revisando       
        private Apicultor apicultor;

        public VistaInterna(Object colmena, Object apicultor)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();            
            Program.reloj.Stop(); //Se detiene el juego
            this.colmena = (Colmena)colmena;
            label10.Text = this.colmena.ID.ToString();
            mostrarInformación();
            this.apicultor = (Apicultor)apicultor;
            pictureBox3.Visible = false;
        }

        //Muestra la imagen correspondiente a la colmena
        public void visualizacion_de_la_colmena()
        {
            if (colmena.getAlzas().Count == 0)
                pictureBox1.Image = System.Drawing.Image.FromFile("Colmena_B0.png");
            else if (colmena.getAlzas().Count == 1)
                pictureBox1.Image = System.Drawing.Image.FromFile("Colmena_B1.png");
            else if (colmena.getAlzas().Count == 2)
                pictureBox1.Image = System.Drawing.Image.FromFile("Colmena_B2.png");
            else
                pictureBox1.Image = System.Drawing.Image.FromFile("Colmena_B3.png");
            poner_reductor();
        }

        public void poner_reductor()
        {
            //Visualización del reductor de piquera            
            reductor_de_piquera.Visible = (colmena.Reductor_de_piquera == true) ? true : false;
            textBox9.Text = (colmena.Reductor_de_piquera == true) ? "Puesto" : "No Puesto";
            button3.Text = (colmena.Reductor_de_piquera == true) ? "Quitar" : "Colocar";
        }


        //Obtener informacion de la población
        private void Informacion_de_poblacion()
        {
            float peso;
            textBox2.Text = colmena.Pecoreadoras.ToString();
            peso = colmena.Abejas_totales / 10000; //Peso de la población            
            textBox13.Text = (peso * peso) + "Kg"; //Rendimiento de miel

        }
        public void mostrarInformación()
        {
            visualizacion_de_la_colmena();//Visualización de la colmena           
            panel1.Visible = true;
            textBox3.Text = Program.clima.Estacion_del_año.ToString(); //Estacion de año
            textBox5.Text = colmena.Temperatura.ToString(); //Temperatura interna de la colmena
            textBox4.Text = colmena.Abejas_totales.ToString(); //Población total de abejas        
           
            Informacion_de_poblacion();
            Informacion_abeja_reina();
            Informacion_enjambrazon();
            textBox11.Text = colmena.Mi_Alimento.ToString();
            textBox1.Text = colmena.Reserva_de_miel + " Kg"; //Reserva de miel
            Informacion_de_alzas_de_miel();



        }

        public void Informacion_de_alzas_de_miel()
        {
            if (colmena.getAlzas().Count != 0)
            {
                for (int i= colmena.getAlzas().Count-1; i>-1;i--)
                    this.dataGridView1.Rows.Add("Alza " + (i+1), (colmena.getAlzas())[i] + " Kg");
            }

        }

        public void Informacion_enjambrazon()
        {

            if (colmena.Estres <= 10)
            {
                textBox10.BackColor = Color.WhiteSmoke;
                textBox10.Text = "NULO";
                pictureBox3.Visible = false;
            }
            else if (colmena.Estres > 10 && colmena.Estres <= 20)
            {
                textBox10.BackColor = Color.Yellow;
                textBox10.Text = "BAJO";
                pictureBox3.Visible = true;                
            }
            else if (colmena.Estres > 20 && colmena.Estres <= 30)
            {
                textBox10.BackColor = Color.Orange;
                textBox10.Text = "MEDIO";
                pictureBox3.Visible = true;
                pictureBox3.Image = System.Drawing.Image.FromFile("enjambrazon_2.png");
            }
            else //ALTO
            {
                textBox10.BackColor = Color.Red;
                textBox10.Text = "ALTO";
                pictureBox3.Visible = true;
                pictureBox3.Image = System.Drawing.Image.FromFile("enjambrazon_3.png");

            }
        }


        public void Informacion_abeja_reina()
        {
            textBox6.Text = colmena.hayAbejaReina(); //Reina puesta
            if (colmena.hayAbejaReina().Equals("No"))
            {
                textBox7.BackColor = Color.Red;
                textBox7.Text = "";
                textBox8.Text = "";
            }
            else
            {
                if (colmena.Reina.Mi_vida.Anios <= 2)
                {
                    textBox7.BackColor = Color.Blue;
                    textBox7.ForeColor = Color.White;
                    textBox7.Text = "ALTO";
                }
                else if (colmena.Reina.Mi_vida.Anios >= 2 && colmena.Reina.Mi_vida.Anios < 3)
                {
                    textBox7.BackColor = Color.Yellow;
                    textBox7.ForeColor = Color.Black;
                    textBox7.Text = "MEDIO";
                }                
                else
                {
                    textBox7.BackColor = Color.Red;
                    textBox7.ForeColor = Color.White;
                    textBox7.Text = "BAJO";
                }
                textBox8.Text = colmena.Reina.Mi_vida.Anios.ToString(); //Años de la reina dentro de la colmena
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Cosechar reserva de miel
        private void button2_Click(object sender, EventArgs e)
        {
            int monedas_ganadas = Convert.ToInt32(colmena.Reserva_de_miel*300)/22;
            Program.miel_recolectada_total += colmena.Reserva_de_miel;
            textBox1.Text = "0 Kg";
            colmena.Reserva_de_miel = 0;
            apicultor.Monedas += monedas_ganadas;
        }
        //Quira reductor
        private void button3_Click(object sender, EventArgs e)
        {
            colmena.Reductor_de_piquera = !colmena.Reductor_de_piquera;           
            poner_reductor();
            if (!colmena.Reductor_de_piquera)
                colmena.Estres = 0;
            Informacion_enjambrazon();
        }
    }
}
