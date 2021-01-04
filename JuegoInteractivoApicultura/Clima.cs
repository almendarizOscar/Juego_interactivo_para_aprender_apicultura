using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoInteractivoApicultura
{
    class Clima
    {
        private Estacion estacion;
        private float nivelNectar;
        private float temperatura; //en grados centígrados        

        public Estacion Estacion_del_año
        {
            get { return estacion; }
            set { estacion = value; }
        }
        public float Nivel_de_netar
        {
            get { return nivelNectar; }
            set { nivelNectar = value; }
        }
        public float Temperatura
        {
            get { return temperatura; }
            set { temperatura = value; }
        }

        public Clima(Estacion s, float nivel, float temp)
        {
            estacion = s;
            nivelNectar = nivel;
            temperatura = temp;
        }
    }
}
