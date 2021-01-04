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
    public partial class Tienda : Form
    {
        private int camaras = 0;
        private int alzas = 0;
        private int nucleos = 0;
        private int reinas = 0;
        private int costo_Camaras = 0;
        private int costo_Alzas = 0;
        private int costo_Nucleos = 0;
        private int costo_Reinas = 0;
        private int costo_total = 0;
        private Apicultor apicultor;

      
        public Tienda(Object apicultor)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();           
            Program.reloj.Stop();
            this.apicultor = (Apicultor)apicultor;
            tb_saldo.Text = this.apicultor.Monedas.ToString();
            if (Program.clima.Estacion_del_año == Estacion.INVIERNO || Program.clima.Estacion_del_año == Estacion.OTONO)
            {
                cb_nucleo.Enabled = cb_abeja.Enabled = false;
                costo_Nucleos = costo_Reinas = 0;
            }
        }

        public void calcularTotal()
        {
            costo_total = costo_Camaras + costo_Alzas + costo_Nucleos + costo_Reinas;
            tb_pago.Text = costo_total.ToString();
            if (costo_total <= apicultor.Monedas)
            {
                Double saldo_restante = ((Apicultor)apicultor).Monedas - costo_total;
                tb_saldores.Text = Math.Round(saldo_restante, 2).ToString();
                bt_comprar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Saldo insuficiente");
                bt_comprar.Enabled = false;
                cb_camara.ResetText();
                cb_alza.ResetText();
                cb_nucleo.ResetText();
                cb_abeja.ResetText();
                tb_pago.Clear();
                tb_saldores.Clear();
            }
        }

        private void realiza_compra()
        {
            MessageBox.Show("Compra realizada con exito. Se han guardado tus compras en el almacen");
            //Guardar compras en el almacen
            apicultor.El_almacen.Alzas += alzas;
            apicultor.El_almacen.Camaras_de_cria += camaras;
            apicultor.El_almacen.Nucleos += nucleos;
            apicultor.El_almacen.Reinas += reinas;
            //Restar dinero del apicultor
            apicultor.Monedas -= costo_total;
        }
        //Comprar
        private void bt_comprar_Click(object sender, EventArgs e)
        {
            realiza_compra();
            this.Close(); //Salir de la tienda

        }
        //Cerrar
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //*************Combox para seleccionar la cantidad a comprar *******************************
        private void cb_camara_SelectedIndexChanged(object sender, EventArgs e)
        {
            camaras = cb_camara.SelectedIndex + 1;
            costo_Camaras = camaras * 800;
            calcularTotal();
        }

        private void cb_alza_SelectedIndexChanged(object sender, EventArgs e)
        {
            alzas = cb_alza.SelectedIndex + 1;
            costo_Alzas = alzas * 300;
            calcularTotal();
        }

        //Seleccionar nucleos de abejas
        private void cb_nucleo_SelectedIndexChanged(object sender, EventArgs e)
        {
            nucleos = cb_nucleo.SelectedIndex + 1;
            costo_Nucleos = nucleos * 2000;
            calcularTotal();
        }
        //Seleccionar abejas reinas
        private void cb_abeja_SelectedIndexChanged(object sender, EventArgs e)
        {
            reinas = cb_abeja.SelectedIndex + 1;
            costo_Reinas = reinas * 1000;
            calcularTotal();
        }

        private void Tienda_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void bt_comprar_Click_1(object sender, EventArgs e)
        {
            realiza_compra();
            this.Close(); //Salir de la tienda
        }
    }
}
