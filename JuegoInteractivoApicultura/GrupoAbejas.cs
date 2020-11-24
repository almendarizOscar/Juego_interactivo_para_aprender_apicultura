using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoInteractivoApicultura
{
    enum EstadoDe
    {
        VIVAS, MUERTAS
    }
    class GrupoAbejas
    {
        private int numero_de_abejas;
        private Vida vida;
        private int dias_en_huevo;
        private bool estamos_vivas;

        public bool Estamos_vivas{
            get { return estamos_vivas; }
            set { estamos_vivas = value; }
        }
        public int Numero_de_abejas {
            get { return numero_de_abejas; }
            set { numero_de_abejas = value; }
        }
        public Vida getVida() { return vida; }
        public int Dias_en_el_huevo
        {
            get { return dias_en_huevo; }
            set { dias_en_huevo = value; }
        }

        public GrupoAbejas(int num_abejas)
        {
            estamos_vivas = true;
            numero_de_abejas = num_abejas;
            dias_en_huevo = 0;
        }

        public double recolecta_miel(Clima clima, Alimento alimento)
        {
            double miel_recolectada = 0;
            //Las abejas empiezan a estar activas arriba de 10
            //2500 Abejas producen 1Kg de miel
            if (clima.Temperatura > 10) {
                if (clima.Estacion_del_año == Estacion.PRIMAVERA) {
                    miel_recolectada = ((numero_de_abejas*0.0004)/2500)/21;
                }
                else if (clima.Estacion_del_año == Estacion.VERANO)
                    miel_recolectada = (((numero_de_abejas * 0.0004) / 2500) / 21)*0.4;
                else if (clima.Estacion_del_año == Estacion.OTONO)
                    miel_recolectada = (((numero_de_abejas * 0.0004) / 2500) / 21)*0.6;
            }
            else if (clima.Temperatura >= 5){
                //Si hay alimento
                if (alimento.Cantidad >0)
                    miel_recolectada = ((numero_de_abejas * 0.0004) / 2500) / 21;              
            }
            return miel_recolectada;
        }
    }
}
