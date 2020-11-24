using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoInteractivoApicultura
{
    enum TipoAlimento
    {
        INSENTIVO, SOSTEN
    }
    class Alimento
    {
        private TipoAlimento tipo;
        private float cantidad;
        public float Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public Alimento(float cantidad) {
            this.cantidad = cantidad;
        }
        
    }
}
