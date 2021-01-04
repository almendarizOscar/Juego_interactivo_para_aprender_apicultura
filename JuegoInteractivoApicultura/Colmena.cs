using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JuegoInteractivoApicultura
{
    enum Enjambrazon
    {
        NULO, BAJO, MEDIO, ALTO
    }

    class Colmena
    {
        private int id; //Identificador de la colmena
        private PictureBox gota_de_miel;
        private int nivel_de_estres; //Va de 0 hasta 40
        private PictureBox celda;
        private float temperatura;

        private double reserva_de_miel;
        private bool reductor; //Reductor de piquera
        private double alimento; //Alimento de la colmena
        private List<double> alza; //Máximo tres alzas por colmena
        private AbejaReina reina;
        private int abejas_totales; //Crias de la abeja reina 
        private int pecoreadoras;
        
        public void setCelda(PictureBox celda)
        {
            this.celda = celda;
        }        
        public PictureBox Gota_De_miel {
            get { return gota_de_miel; }           
            set { gota_de_miel = value; }
        }
        public int Estres
        {
            get { return nivel_de_estres; }
            set { nivel_de_estres = value; }
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public double Mi_Alimento
        {
            get { return alimento; }
            set { alimento = value; }
        }
        public AbejaReina Reina
        {
            get { return reina; }
            set { reina = value; }
        }
        public int Abejas_totales
        {
            get { return abejas_totales; }
            set { abejas_totales = value; }
        }
        public int Pecoreadoras
        {
            get { return pecoreadoras; }
            set { pecoreadoras = value; }
        }
        public bool Reductor_de_piquera
        {
            get { return reductor; }
            set { reductor = value; }
        }
        public PictureBox getCelda() { return celda; }
        public float Temperatura { get { return temperatura; } }
        public double Reserva_de_miel
        {
            get { return reserva_de_miel; }
            set { reserva_de_miel  = value; }
        }
        public List<double> getAlzas() { return alza; }            
        public string hayAbejaReina()
        {
            if (reina == null) return "No";
            else return "Si";
        }
        

        public Colmena(PictureBox celda)
        {
            this.celda = celda;
            reserva_de_miel = 0;
            inicializar();
        }

        //Constructor para un colmena dividida
        public Colmena(PictureBox celda, int cuadros_de_cria, double reserva_de_miel)
        {
            this.celda = celda;       
            inicializar();
            this.reserva_de_miel = reserva_de_miel;
        }

        private void inicializar_temperatura() {
            if (reductor)
            {
                //Si la colmena tiene un reductor de piquera
                switch (Program.clima.Estacion_del_año)
                {
                    case Estacion.INVIERNO:
                        temperatura = 35;
                        break;
                    default:
                        temperatura = 40;
                        break;
                }
            }else
            {
                if (Program.clima.Estacion_del_año != Estacion.INVIERNO)                                   
                        temperatura = 32;                                        
            }
        }

        private void inicializar()
        {          
            reductor = false;
            alimento = 0;
            reina = null;                
            alza = new List<double>();
            abejas_totales = 0;
            pecoreadoras = 0;
            nivel_de_estres = 0;
            temperatura = 0;
            gota_de_miel = new PictureBox();
            gota_de_miel.Image = System.Drawing.Image.FromFile("gota.png");
        }
          
        //Total de miel(Kg) recolectada  
        public double total_de_miel()
        {                               
            return (alza.Count==0)?0: alza[0] + alza[1] + alza[2];
        }
        //Agregar alza con miel
        public bool agregarAlza(float Kg_de_miel)
        {
            if (alza.Count < 3)
            {
                alza.Add(Kg_de_miel);
                return true;
            }
            return false;
        }
        //Agregar alza con miel
        public bool agregarAlza()
        {
            if (alza.Count < 3)
            {
                alza.Add(0);
                return true;
            }
            return false;
        }
        public void mostrarAlzas()
        {
            switch (alza.Count)
            {
                case 1:
                    celda.Image = System.Drawing.Image.FromFile("colmena1.png");
                    break;
                case 2:
                    celda.Image = System.Drawing.Image.FromFile("colmena2.png");
                    break;
                case 3:
                    celda.Image = System.Drawing.Image.FromFile("colmena3.png");
                    break;
            }
        }
        /* Determina la temperatura de la colmenan y ademas, si hace mucha temperatura las abejas se mueren
         * y las cuenta como muertas       
         * Aumenta el nievel de estres por piquera en temporada de calor
         */
        public void determinar_temperatura() {
            
            if (reductor)
            {
                //Si la colmena tiene un reductor de piquera
                switch (Program.clima.Estacion_del_año)
                {
                    case Estacion.INVIERNO:
                        temperatura = 35;
                        break;
                    default:
                        temperatura = 40;
                        nivel_de_estres += 1;
                        break;
                }                
            }else
            {
                //Si la colmena no tiene un reductor de piquera
                switch (Program.clima.Estacion_del_año)
                {
                    case Estacion.INVIERNO:
                        if (Program.clima.Temperatura <= 5)
                        {
                            //Las abejas se mueren porque hace mucho frio y no estan cubiertas
                            if (reina != null)
                                reina = null;
                            if (abejas_totales != 0) {
                                pecoreadoras = abejas_totales = 0;
                                Program.colmenas_muertas += 1; //Se cuenta como muerta
                            }
                        }
                        temperatura = Program.clima.Temperatura;
                        break;
                    default:
                        temperatura = 32;
                        break;
                }
            }
        }
        /*  Se encarga de aumentar un dia de vida a:
         *   - La reina 
         *   - Las obreras 
         *   - Las crias
         *   - Pecoreadoras
         *  Elimina a la reina si ya está vieja
         *  Aumenta el nievel de enjambrazon si es necesario 
         *  Determina la temperatura interna de la colmena
         *  Se come el alimento 
         */
        public void actualiza_colmena()
        {
            determinar_temperatura();
            if (abejas_totales != 0)
            {
                //Establecer
                if (Program.clima.Estacion_del_año == Estacion.INVIERNO)
                {
                    if (Program.clima.Temperatura <= 5)
                    {
                        if (alimento >= 0 || reserva_de_miel >= 0)
                            abejas_totales = 10000;
                        pecoreadoras = Convert.ToInt32(abejas_totales * 0.2);
                    }
                    else
                    {
                        if (alimento >= 0)
                        {
                            abejas_totales = 40000;
                            pecoreadoras = Convert.ToInt32(abejas_totales * 0.5);
                        }
                        else
                        {
                            abejas_totales = 20000;
                            pecoreadoras = Convert.ToInt32(abejas_totales * 0.25);
                        }
                    }
                }
                else if (Program.clima.Estacion_del_año == Estacion.PRIMAVERA)
                {
                    abejas_totales = 80000;
                    pecoreadoras = Convert.ToInt32(abejas_totales * 0.7);
                    if (reductor)
                        nivel_de_estres += 1;

                }
                else if (Program.clima.Estacion_del_año == Estacion.VERANO)
                {
                    abejas_totales = 30000;
                    pecoreadoras = Convert.ToInt32(abejas_totales * 0.3);
                    if (reductor)
                        nivel_de_estres += 1;
                }
                else
                { //Otoño
                    if (alimento >= 0)
                    {
                        abejas_totales = 50000;
                        pecoreadoras = Convert.ToInt32(abejas_totales * 6.0);
                    }
                }

            }                

                //Eliminar a la reina si ya es vieja
                if (reina != null)
                {
                    if (reina.Mi_vida.Anios >= 5)
                        reina = null;
                }
                //Comer alimento
                if (alimento > 0)
                    alimento -= 0.33;

            
        }
        public void recolectar_miel() {
            if (Program.clima.Temperatura > 5) {
                if (reserva_de_miel < 12)
                {
                    reserva_de_miel += ((pecoreadoras * 0.004) / 10) / 2;
                    if (reserva_de_miel > 12)
                        reserva_de_miel = 12;
                }
                else
                    poner_miel_en_alzas(((pecoreadoras * 0.004) / 10) / 2);
            }
            
        }

        public bool hay_alguna_alza_llena()
        {
            if (alza.Count > 0)
            {
                foreach(float miel in alza)
                {
                    if (miel >= 22)
                        return true;
                }
            }
            return false;
                
        }

        public void poner_miel_en_alzas(Double miel_recolectada)
        {
            double resto = 0;
            double miel_a_depositar = miel_recolectada;
            if (alza.Count != 0)
            {
                for (int i=0; i<alza.Count && miel_a_depositar != 0; i++)
                {
                    if (alza[i]< 22)
                    {
                        resto = (alza[i] + miel_recolectada) - 22;
                        if (resto < 0)
                        {
                            alza[i] = alza[i] + miel_a_depositar;
                            miel_a_depositar = 0;
                        }
                        else
                        {
                            int sig = i + 1;
                            if (sig < alza.Count)
                            {
                                alza[sig] += resto;
                            }
                            alza[i] = 22;
                            miel_a_depositar = 0;
                        }

                    }else
                    {
                        gota_de_miel.Visible = true;
                    }
                }
                

            }
           
        }


        
    }
}
