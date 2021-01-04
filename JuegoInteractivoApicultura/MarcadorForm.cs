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
    public partial class MarcadorForm : Form
    {
        private int colmenas;
        private int anios;
        private double miel_total;
        private int colperdidas;
        private int puntajefinal;
        public MarcadorForm()
        {
            InitializeComponent();

        }

        public MarcadorForm(Object apicultor, int años)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            colmenas = ((Apicultor)apicultor).Mis_Colmenas.Count * 80;
            anios = años * 70;
            miel_total = Program.miel_recolectada_total;
            colperdidas = Program.colmenas_muertas * 80;

            textBox1.Text = ((Apicultor)apicultor).Mis_Colmenas.Count.ToString();
            textBox2.Text = años.ToString();
            textBox3.Text = Program.miel_recolectada_total.ToString();
            textBox4.Text = Program.colmenas_muertas.ToString();

            puntajefinal = Convert.ToInt32( colmenas + Program.miel_recolectada_total - colperdidas - anios);

            puntajefinal = (puntajefinal < 0) ? 0 : puntajefinal;
            textBox5.Text = puntajefinal.ToString();
        }



    }
}

