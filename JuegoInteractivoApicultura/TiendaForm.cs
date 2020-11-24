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
    public partial class TiendaForm : Form
    {
        int camaras = 0;
        int alzas = 0;
        int nucleos = 0;
        int reinas = 0;
        int precioC = 0;
        int precioA = 0;
        int precioN = 0;
        int precioR = 0;
        int saldo;
        int total = 0;
        //int sobra=0;
        public TiendaForm()
        {
            InitializeComponent();
            saldo = 30000;
            tb_saldo.Text = saldo.ToString();


        }

        public TiendaForm(int sal_total)
        {
            InitializeComponent();
            saldo = sal_total;
            tb_saldo.Text = saldo.ToString();

        }

        public void calcularTotal()
        {
            total = precioC + precioA + precioN + precioR;
            tb_pago.Text = total.ToString();
            if (total < saldo)
            {
                saldo = saldo - total;
                tb_saldores.Text = saldo.ToString();
            }
            else
            {
                MessageBox.Show("Saldo insuficiente");
                bt_comprar.Enabled = false;
            }


        }

        private void cb_camara_SelectedIndexChanged(object sender, EventArgs e)
        {
            bt_comprar.Enabled = true;
            camaras = cb_camara.SelectedIndex + 1;
            precioC = camaras * 800;
            calcularTotal();
        }

        private void cb_alza_SelectedIndexChanged(object sender, EventArgs e)
        {
            bt_comprar.Enabled = true;
            alzas = cb_alza.SelectedIndex + 1;
            precioA = alzas * 300;
            calcularTotal();
        }

        private void cb_nucleo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bt_comprar.Enabled = true;
            nucleos = cb_nucleo.SelectedIndex + 1;
            precioN = nucleos * 2000;
            calcularTotal();
        }

        private void cb_abeja_SelectedIndexChanged(object sender, EventArgs e)
        {
            bt_comprar.Enabled = true;
            reinas = cb_abeja.SelectedIndex + 1;
            precioR = reinas * 1000;
            calcularTotal();
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_comprar_Click(object sender, EventArgs e)
        {
         

        }

        private void Tienda_Load(object sender, EventArgs e)
        {


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
