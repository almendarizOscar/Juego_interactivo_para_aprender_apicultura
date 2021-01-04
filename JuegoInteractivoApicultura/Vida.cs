using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoInteractivoApicultura
{

    class Vida
    {
        private int dias;
        private int anios;
        public int Dias
        {
            get { return dias; }
            set { dias = value; }
        }
        public int Anios
        {
            get { return anios; }
            set { anios = value; }
        }

        public Vida()
        {
            this.dias = 0;
            this.anios = 0;
        }
     
    }
}
