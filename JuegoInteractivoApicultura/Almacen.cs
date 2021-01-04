using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoInteractivoApicultura
{    
    class Almacen
    {
        private int alzas, camaras_de_cria, nucleos, reinas;

        public int Alzas
        {           
            get
            {
                return alzas;
            }
            set
            {
                alzas = value;
            }
        }
        public int Camaras_de_cria
        {
            get { return camaras_de_cria; }
            set { camaras_de_cria = value; }

        }
        public int Nucleos
        {
            get { return nucleos; }
            set { nucleos = value;
 }
        }
        public int Reinas
        {
            get { return reinas;  }
            set { reinas = value; }
        }

        public Almacen()
        {
            alzas = 6;
            camaras_de_cria = 2;
            nucleos = 2;
            reinas = 0;
        }
       
    }
}
