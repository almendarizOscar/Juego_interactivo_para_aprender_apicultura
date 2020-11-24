using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoInteractivoApicultura
{
    class Alza
    {
        private double miel; //Kilogramos de miel      
        public double Miel
        {
            get { return miel; }
            set { miel = value; }
        }
      
        public Alza() {
            miel = 0;
        }
        public Alza(int miel)
        {
            this.miel = miel;
        }
        public void miel_a_la_mitad() {
            miel /= 2;
        }
       

    }
}
