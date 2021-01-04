using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoInteractivoApicultura
{

    class AbejaReina
    {       
        private Vida vida;
        private Colmena colmena; //La coleman donde está ubicada        
        private int postura_por_dias;

        public int Postura_por_dias
        {
            get { return postura_por_dias; }
            set { postura_por_dias = value; }
        }
        public Vida Mi_vida {
            get { return vida; }
        }
        public AbejaReina(Colmena colmena)
        {           
            vida = new Vida();
            this.colmena = colmena;
        }

        /**Este metodo evalua las condiciones climaticas y determina cuantos hueos pone la reina por dias
         */
       
     
    }
}
