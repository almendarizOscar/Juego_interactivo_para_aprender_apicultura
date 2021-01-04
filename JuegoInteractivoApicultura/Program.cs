using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JuegoInteractivoApicultura
{

    static class Program
    {
        static public Colmenar colmenar;
        static public Almacen almacen;
        static public Timer reloj;
        static public Clima clima;
        static public int colmenas_muertas;
        static public double miel_recolectada_total;
        static public List<int> id_ya_asignado; //Son los ID que ya se han asignado a las colmenas
        static public RichTextBox mensajes_de_Otto;
        static public Otto otto;
        static public ToolStripButton play;
        static public ToolStripButton pause;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>


        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            colmenar = new Colmenar();
            Application.Run(colmenar);
        }
    }
}
