using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JuegoInteractivoApicultura
{
    
    enum Enjambrazon {
        NULO, BAJO, MEDIO, ALTO
    }
   
    class Colmena
    {
        private PictureBox celda; 
        private float temperatura;
        private Enjambrazon nivelEnjambrazon;
        private int huevosDeReina;        
        private Clima clima;
    
        private bool reductor; //Reductor de piquera
        private Alimento alimento;
        private List<Alza> alza; //Máximo tres alzas por colmena
        private AbejaReina reina;
        private List<GrupoAbejas> cria; //Crias de la abeja reina 
        private List<GrupoAbejas> obrera; //Abejas obreras de la colonia
        private List<GrupoAbejas> pecoreadoras; //Son las abejas encargadas de recolectar la miel

        //Metodos get y set
        public List<GrupoAbejas> Cria
        {
            get { return cria; }            
        }
        public List<GrupoAbejas> Obreras
        {
            get { return obrera; }
        }
        public List<GrupoAbejas> Pecoreadoras
        {
            get { return pecoreadoras; }
        }
        public bool Reductor_de_piquera
        {
            get { return reductor; }
        }
        

        public PictureBox getCelda() { return celda; }
        public AbejaReina getReina() { return reina; }
        public void setReina (AbejaReina r) { reina = r; }  
        public void ponerReina (AbejaReina reina) { this.reina = reina; }
        
        public float getTemperatura() { return temperatura; }
        public Enjambrazon getNivel_de_enjambrazon() { return nivelEnjambrazon; }
        public int getHuevos_de_reina() { return huevosDeReina; }
        public void matarHuevosDeReina() { huevosDeReina = 0; }
        public List<Alza> getAlzas() { return alza; }
        public void quitar_Alza() {
            alza.RemoveAt(alza.Count-1);
        }
        public int numeroAlzas() { return alza.Count; }
        public Alimento getAlimento() { return alimento; }
        public Clima getClima() { return clima; }        
        public string hayAbejaReina() {
            if (reina == null) return "No";
            else return "Si";
        }
        public void ponerReductor() { reductor = true; }
        public void quitarReductor() { reductor = false; }

        //Regresa el número totales de abejas obreras    
        public int getAbejas_Totales() {
            int abejas_totales = 0;
            foreach (GrupoAbejas grupo_abejas_obreras in obrera) {
                abejas_totales += grupo_abejas_obreras.Numero_de_abejas;
            }
            return abejas_totales;
        }

        public Colmena(PictureBox celda, Clima cl) {
            this.celda = celda;                                                   
            clima = cl;
            inicializar();
        }
        //Constructor para un colmena dividida
        public Colmena(PictureBox celda, int cuadros_de_cria, Clima cl) {
            this.celda = celda;
            clima = cl;
            inicializar();                       
        }

        private void inicializar()
        {
            reductor = false;
            alimento = new Alimento(0);
            reina = null;
            temperatura = 0;
            nivelEnjambrazon = 0;
            huevosDeReina = 0;
            alza = new List<Alza>();
            obrera = new List<GrupoAbejas>();
            cria = new List<GrupoAbejas>();
        }

        public void reducri_colonia_a_la_mitad() {
            //abejasTotales /= 2; 
        }

        //Total de miel(Kg) recolectada  
        public double total_de_miel() {
            double total = 0;
            //Revisar cada una de las alzas
            foreach (Alza alz in alza)            
                total += alz.Miel;            
            return total;
        }
        //Agregar alza con miel
        public bool agregarAlza(int Kg_de_miel)
        {
            if (alza.Count < 3)
            {
                alza.Add(new Alza(Kg_de_miel));
                return true;
            }
            return false;
        }
        //Agregar alza con miel
        public bool agregarAlza()
        {
            if (alza.Count < 3) {
                alza.Add(new Alza());
                return true;
            }
            return false;
        }
        public void mostrarAlzas() {
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

        public void actualiza_vida() {
            aumenta_dias_de_las_crias();
            aumenta_vida_de_las_abejas_obreras();
            aumenta_vida_de_las_abejas_pecoreadoras();
        }

        public void aumenta_dias_de_las_crias() {
            //Aumentar los dias en el huevo, de las crias
            foreach (GrupoAbejas abejas in cria) {
                abejas.Dias_en_el_huevo = abejas.Dias_en_el_huevo+1;
                //Si las crias superan los 21 dias, las crias se convierten en obreras
                if (abejas.Dias_en_el_huevo >= 21)
                    obrera.Add(abejas);
            }
            //Eliminar a las crias que ya nacieron
            cria.RemoveAll(x=>x.Dias_en_el_huevo >= 21);            
        }
        //Este es el metodo que disminulle el numero de dias de vida de las crias, abejas obreras y de las reinas
        public void aumenta_vida_de_las_abejas_obreras() {
            //Aumentar vida de las abejas obreras
            foreach (GrupoAbejas abejas_obreras in obrera) {
                abejas_obreras.getVida().aumentar_día(); //Aumentar un día de vida de la obrera         
                if (abejas_obreras.getVida().Dias >= 24)
                    pecoreadoras.Add(abejas_obreras);
            }
            //Eliminar de la lista de obreras a las abejas que ya son pecoreadoras
            obrera.RemoveAll(x => x.getVida().Dias >= 24);

        }

        public void aumenta_vida_de_las_abejas_pecoreadoras() {

            foreach (GrupoAbejas abejas_pecoreadoras in pecoreadoras)
            {
                abejas_pecoreadoras.getVida().aumentar_día(); //Aumentar un día de vida de la obrera         
                if (abejas_pecoreadoras.getVida().Dias >= 45 && (clima.Estacion_del_año == Estacion.PRIMAVERA || clima.Estacion_del_año == Estacion.VERANO))
                    abejas_pecoreadoras.Estamos_vivas = false;
                else if (abejas_pecoreadoras.getVida().Dias >= 65)
                    abejas_pecoreadoras.Estamos_vivas = false;
            }
            //Eliminar a las abejas muertas 
            pecoreadoras.RemoveAll(x => x.Estamos_vivas == false);
        }

        public bool colmena_muerta() {
            return (obrera.Count == 0 && pecoreadoras.Count == 0 && cria.Count == 0) ? true : false;                       
        }

        public void recolecta_miel() {
            if (pecoreadoras.Count != 0) {
                //Primero verificar que haya alzas en la colmena
                if (alza.Count != 0) {
                    foreach (GrupoAbejas abejas_pecoreadoras in pecoreadoras) {
                        //Llenar las alzas con la miela                   
                        poner_miel_en_alzas(abejas_pecoreadoras.recolecta_miel(clima, alimento));
                    }
                }
            }
        }
        public bool hay_espacio_para_poner_miel() {
            if (alza.Count < 3)
                return true;
            else
            {
                if (alza[2].Miel < 22) return true;
            }
            return false;
        }
        public void poner_miel_en_alzas(Double miel_recolectada) {
            //Si hay espacion en las 
            if (hay_espacio_para_poner_miel())
            {

                for (int i = 0; i < alza.Count; i++) {
                    double total = alza[i].Miel + miel_recolectada;
                   // if (total<=22)
                 //       alza[i].Miel
                }
            }
        }
    }
}
