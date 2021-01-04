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
        public AlmacenForm(double dinero_de_apicultor)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Program.reloj.Stop();
            tb_capital.Text = Math.Round(dinero_de_apicultor, 2).ToString();
            tb_camara.Text = Program.almacen.Camaras_de_cria.ToString();
            tb_alza.Text = Program.almacen.Alzas.ToString();
            tb_nucleo.Text = Program.almacen.Nucleos.ToString();
            tb_abeja.Text = Program.almacen.Reinas.ToString();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
         
            this.Close();
        }

        private void AlmacenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
