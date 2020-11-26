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
        private int camaras;
        private int alzas;
        private int nucleos;
        private int reinas;
        private int precioC = 0;
        private int precioA = 0;
        private int precioN = 0;
        private int precioR = 0;
        private int saldo;
        private int total = 0;
        private int sal_ini;
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
            sal_ini = sal_total;
            tb_saldo.Text = saldo.ToString();

        }

        public void calcularTotal()
        {
            total = precioC + precioA + precioN + precioR;
            tb_pago.Text = total.ToString();
            if (total <= saldo)
            {
                saldo = saldo - total;
                tb_saldores.Text = saldo.ToString();
            }
            else
            {
                MessageBox.Show("Saldo insuficiente");
                bt_comprar.Enabled = false;
                total = 0;
                saldo = sal_ini;
                cb_camara.ResetText();
                cb_alza.ResetText();
                cb_nucleo.ResetText();
                cb_abeja.ResetText();
                tb_pago.Clear();
                tb_saldores.Clear();
            }


        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_comprar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("compra realizada con exito");
            this.Close();

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


        public int Camaras
        {
            set
            {
                camaras = value;
            }
            get
            {
                return camaras;
            }
        }

        public int Alzas
        {
            set
            {
                alzas = value;
            }
            get
            {
                return alzas;
            }
        }

        public int Nucleos
        {
            set
            {
                nucleos = value;
            }
            get
            {
                return nucleos;
            }
        }

        public int Reinas
        {
            set
            {
                reinas = value;
            }
            get
            {
                return reinas;
            }
        }

        public int Saldores
        {
            set
            {
                saldo = value;
            }
            get
            {
                return saldo;
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
    }
}
