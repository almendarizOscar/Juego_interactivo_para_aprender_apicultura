using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoInteractivoApicultura
{

    class AbejaReina
    {
        private Clima clima;
        private Vida vida;      
        private Colmena colmena; //La coleman donde está ubicada        
        public int postura_por_dias;

        public int Postura_por_dias
        {
            get { return postura_por_dias; }
            set { postura_por_dias = value; }
        }
        public Vida getVida() { return vida; }                

        public AbejaReina(Colmena colmena, Clima clima) {
            this.clima = clima;
            vida = new Vida();
            this.colmena = colmena;           
        }

        public void evalua_condiciones()
        {
            //Si el clima es muy frio, la abeja reina no pone
            if (clima.Temperatura <= 10)
                postura_por_dias = 0;
            else
            {
                if (clima.Temperatura > 10 && clima.Temperatura <= 15)
                    postura_por_dias = 1500;
                else if (clima.Temperatura > 15)
                    postura_por_dias = 2000;
            }
                 
        }

        public void pon_huevos() {
            evalua_condiciones();
            if (postura_por_dias != 0)                                      
                colmena.Cria.Add(new GrupoAbejas(postura_por_dias));
            
        }
    }
}
