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
        private int colonias_debiles;
        private int colonias_fuertes;
        private int colonias_enjambradas;
        private int reinas_viejas;
        private int colonias_sin_reina;

        public VistaGeneral(Object col)
        {
            InitializeComponent();
            colonias_debiles = 0;
            colonias_fuertes = 0;
            colonias_enjambradas = 0;
            reinas_viejas = 0;
            colonias_sin_reina = 0;
            colmena = (List<Colmena>)col;
            mostrarInformacion();
           
        }
    

        private void mostrarInformacion() {
            textBox1.Text = colmena.Count.ToString();
            if (colmena.Count != 0)
            {
                inspeccionarColmenas();
                textBox2.Text = colonias_debiles.ToString();
                textBox3.Text = colonias_fuertes.ToString();
                textBox4.Text = colonias_enjambradas.ToString();
                textBox5.Text = reinas_viejas.ToString();
                textBox6.Text = colonias_sin_reina.ToString();
            }
        }
        private void inspeccionarColmenas() {      
            foreach (Colmena col in colmena) {
                /*
                if (col.getCategoria() == Categoria.DEBIL)
                    colonias_debiles++;
                else if (col.getCategoria() == Categoria.FUERTE)
                    colonias_fuertes++;
                    */
                if (col.getNivel_de_enjambrazon() != Enjambrazon.NULO)
                    colonias_enjambradas++;
                if (col.hayAbejaReina() == "No")
                    colonias_sin_reina++;
                else if (col.getReina().getVida().Anios > 2)
                    reinas_viejas++;

            }            
        }
      


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
