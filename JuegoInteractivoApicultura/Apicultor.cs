using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoInteractivoApicultura
{
    class Apicultor
    {        
        private int monedas;
        private List<Colmena> colmena;
        private Almacen almacen;
       

        public Almacen El_almacen
        {
            get { return almacen; }
            set { almacen = value; }
        }
        public int Monedas
        {
            set
            {
                monedas = value;
            }
            get
            {
                return monedas;
            }
        }
        public List<Colmena> Mis_Colmenas
        {
            set
            {
                colmena = value;
            }
            get
            {
                return colmena;
            }
        }
        public List<Colmena> GetColmenas() { return colmena; }
        //Variables para la división de colmenas
        private Colmena colmena_seleccionada;
        private PictureBox celda_disponible; //Es la celda donde se pondrá la nueva colonia dividida       

        public Apicultor(Almacen almacen)
        {           
            monedas = 2500; //Dinero inicial con el que cuenta el apicultor
            colmena = new List<Colmena>();
            this.almacen = almacen;
            
        }
        private void desactivar_seleccion()
        {
            colmena_seleccionada = null;
            celda_disponible = null;
        }
        public void realizaActividad(Actividad actividad, Object celda)
        {

            
            if (actividad == Actividad.PONER_CAMARA)
            {
                desactivar_seleccion();                
                ponerColmena((PictureBox)celda);                
            }else if (actividad == Actividad.SELECION)
            {
                
                foreach (Colmena col in colmena)
                {
                    if (col.getCelda() == (PictureBox)celda)
                    {
                        colmena_seleccionada = col; //Colmena a divir
                    }
                }
                if (!((PictureBox)celda).Image.Equals("celda.png"))
                {
                    celda_disponible = ((PictureBox)celda);
                }

                if (celda_disponible != null && colmena_seleccionada != null) {  
                    celda_disponible = ((PictureBox)celda);
                    //Mover la colmena
                    //La anterior se elimina
                    colmena_seleccionada.getCelda().Image = System.Drawing.Image.FromFile("celda.png");
                    //y se le asigna la actual celda                   
                    if (colmena_seleccionada.getAlzas().Count == 0)
                    {
                        celda_disponible.Image = System.Drawing.Image.FromFile("colmena0.png");
                        colmena_seleccionada.setCelda(celda_disponible);
                    }
                }
            }
            else
            {
                //Desactivar las variables de selección
                desactivar_seleccion();
                //Recorrer todas las colmenas para buscar la seleccionada
                foreach (Colmena col in colmena)
                {
                    if (col.getCelda() == celda)
                    {
                        if (actividad == Actividad.PONER_ALZA)
                        {
                            if (almacen.Alzas > 0)
                                ponerAlza(col, (PictureBox)celda);  //Poner Alza 
                            else
                                sonido_de_pato();
                            break;
                        }
                        else if (actividad == Actividad.VER_COLMENA)
                        {
                            Program.play.Enabled = true;
                            Program.pause.Enabled = false;
                            verColmena(col);
                            break;
                        }
                        else if (actividad == Actividad.PONER_REDUCTOR)
                        {
                            ponerReductor(col);
                            break;
                        }
                        else if (actividad == Actividad.QUITAR_REDUCTOR)
                        {
                            quitarReductor(col);
                            break;
                        }
                        else if (actividad == Actividad.ELIMINAR)
                        {
                            eliminaColmena(col, (PictureBox)celda);
                            break;
                        }
                        else if (actividad == Actividad.PONER_REINA)
                        {
                            ponerReina(col);
                            break;
                        }
                        else if (actividad == Actividad.COSECHAR)
                        {
                            cosechar(col, (PictureBox)celda);
                            break;
                        }
                        else if (actividad == Actividad.PONER_NUCLEO)
                        {
                            ponerNucleo(col);
                            break;
                        }

                    }
                }

            }
        }

        //------------Actividades --------------------------------------------------
        //*Estos metodos deven de hacer las validaciones correspondientes
        private void ponerReductor(Colmena col)
        {
            col.Reductor_de_piquera = true;
        }
        private void quitarReductor(Colmena col)
        {
            col.Reductor_de_piquera = false;
        }

        /*  Un núcleo 
         *  - abejas
         *  - una abeja reina 
         *  - 12 kg de reservas de miel
         */
        private void ponerNucleo(Colmena col)
        {
            if (almacen.Nucleos > 0) {
                //Poner una reina 
                col.Reina = new AbejaReina(col);
                //Poner cuadros de cría
                col.Abejas_totales = 10000;
                col.Reserva_de_miel = 12;
                almacen.Nucleos -= 1;
            }
        }

        public void verColmena(Colmena colm)
        {
            //Solo se puede ver la colmena si hay abejas
            if (colm.Abejas_totales != 0) {
                Form vistaInterna = new VistaInterna(colm, this);
                vistaInterna.Show();
            }
            else
                sonido_de_pato();

        }
        //Solo se cosehcan las alzas que estén llenas
        //Al cosechar la miel las alzas se quitan y se guardan en el almacen
        public void cosechar(Colmena col, PictureBox celda)
        {
            if (col.getAlzas().Count != 0)
            {
                int alzas_llenas = 0;
                for (int i=0; i<col.getAlzas().Count; i++)
                {
                    if ((col.getAlzas())[i] >= 22) { 
                        alzas_llenas += 1;
                    (col.getAlzas())[i] = 0;
                    }
                }              
                //Calculamos la ganancia de monedas            
                monedas += alzas_llenas * 300;
                col.Gota_De_miel.Visible = false;
            }
        }


        public void ponerReina(Colmena col)
        {
            if (almacen.Reinas > 0)
            {
                col.Reina = new AbejaReina(col);
                almacen.Reinas -= 1;
            }
        }

        public void eliminaColmena(Colmena col, PictureBox celda)
        {
            //Guardamos el material en el almacen
            //Primero las alzas 
            almacen.Alzas += col.getAlzas().Count;
            //Al ultimo la camara de cría
            almacen.Camaras_de_cria += 1;

            //Eliminamos el id de la colmenas en la lista de ids ocupados
            Program.id_ya_asignado.Remove(col.ID);
            //Cambiar la imagen 
            celda.Image = System.Drawing.Image.FromFile("celda.png");
            //*Si se elimina la colmena con abejas dentro, cuanta como colmena muerta.
            //*El cajon y las alzas de la colmena regresan al almacen
            colmena.Remove(col); //Elimnar la colmena de la lista
            var sonido_pato = new System.Media.SoundPlayer("eliminada.wav");
            sonido_pato.Play();

           
        }

        public void ponerColmena(PictureBox celda)
        {
            //El primer paso es verificar que haya camaras de crias disponibles en el almacens
            if (almacen.Camaras_de_cria > 0) {

                bool yaEstaOcupado = false;
                //Verificar que la celda no está ocupada
                foreach (Colmena col in colmena)
                {
                    if (col.getCelda() == celda)
                        yaEstaOcupado = true;
                }
                if (!yaEstaOcupado) {

                    //Cambiar las imagenas de la celda           
                    celda.Image = System.Drawing.Image.FromFile("colmena0.png");
                    Colmena nueva_colmena = new Colmena(celda);
                    nueva_colmena.ID = asignar_id();
                    colmena.Add(nueva_colmena); //Se agrega una nueva colmena  

                    almacen.Camaras_de_cria -= 1;
                } else {
                    sonido_de_pato();
                }
            }  
        }

        //Una colmena solo puede tener, como máximo, 3 Alzas
        public void ponerAlza(Colmena colm, PictureBox celda)
        {
            if (almacen.Alzas > 0) {
                bool seAgregoAlza = colm.agregarAlza();
                if (seAgregoAlza)
                {
                    colm.mostrarAlzas();
                    almacen.Alzas -= 1;
                }
                else
                    sonido_de_pato();
            }
        }

        private void sonido_de_pato()
        {
            var sonido_pato = new System.Media.SoundPlayer("pato.wav");
            sonido_pato.Play();
        }

        //Devuelve un ID disponible para la colmena
        public int asignar_id()
        {
            //Los ID estan disponbles desde 1 hasta 32
            for (int i = 1; i <= 32; i++) {
                int id_asignado = i; //Es el id que se va a devolver
                bool id_ocupado = false;
                foreach (int id in Program.id_ya_asignado)
                {
                    if (id_asignado == id)
                    {
                        id_ocupado = true;
                        break;
                    }
                }
                if (!id_ocupado)
                {
                    Program.id_ya_asignado.Add(id_asignado);
                    return id_asignado;
                }
            }
            return -1; //Ya no hay disponibles 
        }

        public bool hay_al_menos_una_colmenas_con_el_reductor()
        {
            if (colmena.Count != 0)
            {
                foreach (Colmena col in colmena)
                {
                    if (col.Reductor_de_piquera)
                        return true;
                }
            }
            return false;
        }

        public int acompleto_estas_colmenas()
        {
            int numero_de_colmenas = 0;            
            if (monedas >= 1800)
            {
                numero_de_colmenas = monedas / 2500;
            }
            return numero_de_colmenas;
        }
    }   
}
