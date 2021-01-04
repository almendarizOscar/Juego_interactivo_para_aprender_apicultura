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
    public partial class VistaGeneral : Form
    {
        private List<Colmena> colmena;
        private int numero_de_colmenas_vivas = 0;
        private int colonias_debiles = 0;
        private int colonias_fuertes = 0;
        private int colonias_enjambradas = 0;
        private int reinas_mayores_a_2 = 0;
        private int colonias_sin_reina = 0;

        public VistaGeneral(Object col)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            colmena = (List<Colmena>)col;
            mostrarInformacion();
            Program.reloj.Stop();
        }
        private void inspeccionarColmenas()
        {
            foreach (Colmena col in colmena)
            {
                if (col.Abejas_totales != 0)
                    numero_de_colmenas_vivas++;

                if (col.Abejas_totales <= 30000)
                    colonias_debiles++;
                else 
                    colonias_fuertes++;
                  
                if (col.Estres > 10)
                    colonias_enjambradas++;

                if (col.hayAbejaReina() == "No")
                    colonias_sin_reina++;
                else if (col.Reina.Mi_vida.Anios < 2)
                    reinas_mayores_a_2++;

            }
        }

        private void mostrarInformacion()
        {
           
            textBox2.Text = Program.colmenas_muertas.ToString(); //Colemnas muertas
            
            if (colmena.Count != 0)
            {
                inspeccionarColmenas();
                textBox1.Text = numero_de_colmenas_vivas.ToString(); //Numero de colmenas
                textBox3.Text = colonias_debiles.ToString(); //Colonias fuertes
                textBox4.Text = colonias_fuertes.ToString(); //Colonias débiles
                textBox5.Text = colonias_enjambradas.ToString(); //Colonias enjambradas
                textBox6.Text = reinas_mayores_a_2.ToString(); //Abejas reinas mayores a 2 años:
                textBox7.Text = colonias_sin_reina.ToString(); //Colonias sin reina
            }
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VistaGeneral_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
