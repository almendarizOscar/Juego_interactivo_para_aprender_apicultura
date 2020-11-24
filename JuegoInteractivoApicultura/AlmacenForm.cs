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
    public partial class AlmacenForm : Form
    {

        int camaras = 0;
        int alzas = 0;
        int nucleos = 0;
        int reinas = 0;
        int saldo;
        public AlmacenForm()
        {
            InitializeComponent();
        }

        public AlmacenForm(int sal, int cam, int alz, int nucle, int rei)
        {
            InitializeComponent();
            saldo = sal;
            camaras = cam;
            alzas = alz;
            nucleos = nucle;
            reinas = rei;

            tb_capital.Text = saldo.ToString();
            tb_camara.Text = camaras.ToString();
            tb_alza.Text = alzas.ToString();
            tb_nucleo.Text = nucleos.ToString();
            tb_abeja.Text = reinas.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Almacen_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
