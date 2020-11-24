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
        private Colmena colmena;
        private Estacion estacion;
        public VistaInterna(Object colmena, Object estacion)
        {
            InitializeComponent();
            this.colmena = (Colmena)colmena;
            this.estacion = (Estacion)estacion;
            mostrarInformación();
        }
        public void visualizacion_de_la_colmena() {
            if (colmena.getAlzas().Count == 0)
                pictureBox1.Image = System.Drawing.Image.FromFile("Colmena_B0.png");
            else if (colmena.getAlzas().Count == 1)
                pictureBox1.Image = System.Drawing.Image.FromFile("Colmena_B1.png");
            else if (colmena.getAlzas().Count == 2)
                pictureBox1.Image = System.Drawing.Image.FromFile("Colmena_B2.png");
            else
                pictureBox1.Image = System.Drawing.Image.FromFile("Colmena_B3.png");
        }

        private void InformacionDePoblacion() {
            float peso;
            //Abejas pecoreadoras
            if (colmena.getAbejas_Totales()<= 10000) { 
                textBox2.Text = (colmena.getAbejas_Totales() * 0.2).ToString(); //Abejas pecoreadoras
                textBox11.Text = "%20"; //Porcentaje de pecoreadoras                               
            }
            else if (colmena.getAbejas_Totales() > 10000 && colmena.getAbejas_Totales()<=20000)
            {
                textBox2.Text = (colmena.getAbejas_Totales() * 0.25).ToString(); //Abejas pecoreadoras
                textBox11.Text = "%25"; //Porcentaje de pecoreadoras               
            }
            else if (colmena.getAbejas_Totales() > 20000 && colmena.getAbejas_Totales() <= 30000)
            {
                textBox2.Text = (colmena.getAbejas_Totales() * 0.30).ToString(); //Abejas pecoreadoras
                textBox11.Text = "%30"; //Porcentaje de pecoreadoras               
            }
            else if (colmena.getAbejas_Totales() > 30000 && colmena.getAbejas_Totales() <= 40000)
            {
                textBox2.Text = (colmena.getAbejas_Totales() * 0.50).ToString(); //Abejas pecoreadoras
                textBox11.Text = "%50"; //Porcentaje de pecoreadoras               
            }
            else if (colmena.getAbejas_Totales() > 40000 && colmena.getAbejas_Totales() <= 50000)
            {
                textBox2.Text = (colmena.getAbejas_Totales() * 0.60).ToString(); //Abejas pecoreadoras
                textBox11.Text = "%60"; //Porcentaje de pecoreadoras               
            }
            else if (colmena.getAbejas_Totales() > 50000 && colmena.getAbejas_Totales() <= 60000)
            {
                textBox2.Text = (colmena.getAbejas_Totales() * 0.65).ToString(); //Abejas pecoreadoras
                textBox11.Text = "%65"; //Porcentaje de pecoreadoras               
            }


            peso = colmena.getAbejas_Totales() / 10000; //Peso de la población
            textBox11.Text = peso + "Kg";
            textBox12.Text = (peso * peso) + "Kg"; //Rendimiento de miel

        }
        public void mostrarInformación() {
            //textBox1.Text = colmena.getEstado().ToString(); //Estado de la colonia
            visualizacion_de_la_colmena();//Visualización de la colmena           
            panel1.Visible = true;
            
            textBox3.Text = estacion.ToString(); //Estacion de año
            textBox4.Text = colmena.getAbejas_Totales().ToString(); //Población total            
            textBox5.Text = colmena.getTemperatura().ToString(); //Temperatura interna de la colmena
            InformacionDePoblacion();
            InformacionAbejaReina();
            InformacionEnjambrazon();
            InformacionAlzasDeMiel();            
        }
        public void InformacionAlzasDeMiel() {

        }
        public void InformacionEnjambrazon() {
            textBox10.Text = colmena.getNivel_de_enjambrazon().ToString();
            if (colmena.getNivel_de_enjambrazon() == Enjambrazon.NULO)
                textBox10.BackColor = Color.WhiteSmoke;
            else if (colmena.getNivel_de_enjambrazon() == Enjambrazon.BAJO)
                textBox10.BackColor = Color.Yellow;
            else if (colmena.getNivel_de_enjambrazon() == Enjambrazon.MEDIO)
                textBox10.BackColor = Color.Orange;
            else
                textBox10.BackColor = Color.Red;
        }


        public void InformacionAbejaReina() {
            textBox6.Text = colmena.hayAbejaReina();
            if (colmena.hayAbejaReina().Equals("No"))
            {
                textBox7.BackColor = Color.WhiteSmoke;
                textBox7.Text = "";
                textBox8.Text = "";
            }
            else {
                if (colmena.getReina().getVida().Anios == 5)
                    textBox7.BackColor = Color.Blue;
                else if (colmena.getReina().getVida().Anios == 4)
                    textBox7.BackColor = Color.Yellow;
                else if (colmena.getReina().getVida().Anios == 3)
                    textBox7.BackColor = Color.Orange;
                else
                    textBox7.BackColor = Color.Red;
                
                textBox8.Text = colmena.getReina().getVida().Anios.ToString();
            }
        }
        
        //Botón Salir
        private void button1_Click(object sender, EventArgs e)
        {           
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
