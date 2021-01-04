using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace JuegoInteractivoApicultura
{
    class Otto
    {
        public List<int>mensaje_activado;
       
        public Otto()
        {
            mensaje_activado = new List<int>();
        }
        public bool el_mensaje_esta_mostrandose(int id_mensaje) {
            if (mensaje_activado.Count != 0)
            {
                foreach (int id in mensaje_activado)
                {
                    if (id == id_mensaje)
                        return true;
                }
            }
            return false;
        }
        
        public void primer_mensaje(string mensaje, Color color) {
            Program.mensajes_de_Otto.SelectionColor =color;
            Program.mensajes_de_Otto.SelectedText = mensaje;
        }

        public void Mensaje(string mensaje, Color color)
        {
            Program.mensajes_de_Otto.SelectionColor = color;
            Program.mensajes_de_Otto.SelectedText = Environment.NewLine + mensaje;
        }

        public void mensaje_de_inicio(bool ya_presiono_start)
        {
            if (!ya_presiono_start)
            {
                Program.mensajes_de_Otto.Clear();//Limpiamos pantalla
                Program.mensajes_de_Otto.SelectionColor = Color.Blue;
                Program.mensajes_de_Otto.SelectedText = "Hola. Soy Otto \"El Apicultor\"";
                Program.mensajes_de_Otto.SelectedText = Environment.NewLine + "Te ayudaré a poner tu apiario.";
                Program.mensajes_de_Otto.SelectionColor = Color.Red;
                Program.mensajes_de_Otto.SelectedText = Environment.NewLine + "Antes de inciar. Observa que te encuentras en invierno. Una estación fría. Si la temperatura es " +
                "menor a 5° C tus colmenas pueden morir de frío. "+ "Si colocas una colmena, " +
                    "no olvides ponerle el reductor de piquera para mantenerlas calientes y sobrevivan el invierno.";
                Program.mensajes_de_Otto.SelectionColor = Color.Green;
                Program.mensajes_de_Otto.SelectedText = Environment.NewLine + "Habras ganado hasta que completes un total de 5 colmenas vivas.";

            }
        }

    }
}
