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
        private int saldo;
        private int colperdidas;
        private int puntajefinal;
        public MarcadorForm()
        {
            InitializeComponent();

        }

        public MarcadorForm(int colm, int ani, int saldototal, int colperd)
        {
            InitializeComponent();
            colmenas = colm * 80;
            anios = ani * 70;
            saldo = saldototal;
            colperdidas = colperd * 80;

            textBox1.Text = colmenas.ToString();
            textBox2.Text = anios.ToString();
            textBox3.Text = saldo.ToString();
            textBox4.Text = colperdidas.ToString();
            marcador_total();
        }

        public void marcador_total()
        {
            puntajefinal = colmenas + saldo - colperdidas - anios;
            textBox5.Text = puntajefinal.ToString();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Marcador_FormClosed(object sender, FormClosedEventArgs e)
        {


        }
    }
}

