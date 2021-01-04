using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace JuegoInteractivoApicultura
{
    static class Puntero
    {
        static public void cambia_puntero(Actividad actividad)
        {            
            switch (actividad)
            {
                case Actividad.PONER_ALZA:
                    if (Program.almacen.Alzas > 0)
                        Program.colmenar.Cursor = new Cursor("alza.ico");                                       
                    else
                        Program.colmenar.Cursor = Cursors.Default;
                    break;

                case Actividad.PONER_CAMARA:
                    if (Program.almacen.Camaras_de_cria > 0)
                        Program.colmenar.Cursor = new Cursor("camara.ico");
                    else
                        Program.colmenar.Cursor = Cursors.Default;
                    break;

                case Actividad.VER_COLMENA:
                    Program.colmenar.Cursor = new Cursor("lupa.ico");
                    break;

                case Actividad.PONER_REDUCTOR:
                    Program.colmenar.Cursor = new Cursor("reductor.ico");
                    break;

                case Actividad.ELIMINAR:
                    Program.colmenar.Cursor = new Cursor("tacha.ico");
                    break;

                case Actividad.ALIMENTAR:
                    Program.colmenar.Cursor = new Cursor("alimentador.ico");
                    break;
                case Actividad.COSECHAR:
                    Program.colmenar.Cursor = new Cursor("espatula.ico");
                    break;
                case Actividad.PONER_REINA:
                    if (Program.almacen.Reinas > 0)
                        Program.colmenar.Cursor = new Cursor("abeja.ico");
                    else
                        Program.colmenar.Cursor = Cursors.Default;
                    break;
                   
                case Actividad.DIVIDIR:
                    if (Program.almacen.Camaras_de_cria > 0)
                        Program.colmenar.Cursor = new Cursor("cuchillo.ico");
                    else
                        Program.colmenar.Cursor = Cursors.Default;
                    break;

                case Actividad.PONER_NUCLEO:
                    if (Program.almacen.Nucleos > 0)
                        Program.colmenar.Cursor = new Cursor("nucleo.ico");
                    else
                        Program.colmenar.Cursor = Cursors.Default;
                    break;
                   
                case Actividad.SELECION:
                    Program.colmenar.Cursor = Cursors.Default;
                    break;

            }
        }
    }
}
