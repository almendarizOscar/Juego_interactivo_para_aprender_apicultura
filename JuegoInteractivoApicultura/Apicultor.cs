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
       
        private int dinero;
        private List<Colmena> colmena;
        private AlmacenForm almacen;

        public int Dinero
        {
            set
            {
                dinero = value;
            }
            get
            {
                return dinero;
            }
        }

        public List<Colmena> col
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
        private Clima clima;

        public Apicultor(AlmacenForm almacen, Clima clima) {
            dinero = 2500; //Dinero inicial con el que cuenta el apicultor
            colmena = new List<Colmena>();
            this.almacen = almacen;
            this.clima = clima;
        }
        private void desactivar_seleccion() {
            colmena_seleccionada = null;
            celda_disponible = null;
        }
        public void realizaActividad(Actividad actividad, Object celda, Estacion estacion) {
            
             if (actividad == Actividad.DIVIDIR)
            {
                //Localizar la colmena a dividir
                foreach (Colmena col in colmena)
                {
                    if (col.getCelda() == celda)
                        colmena_seleccionada = col; //Colmena a divir
                }
                //Si la celda está desocupada, se toma como la ubicacion de la nueva colmena
                if (((PictureBox)celda).Image.Equals("celda.png"))
                    celda_disponible = ((PictureBox)celda);


                //Si hay una colmena que dividir y un lugar disponible
                if (celda != null && colmena_seleccionada != null)
                {
                    dividir_colmena();
                }
            }
            else if (actividad == Actividad.PONER_CAMARA)
            {
                desactivar_seleccion();
                bool yaEstaOcupado = false;
                //Verificar que la celda no está ocupada
                foreach (Colmena col in colmena)
                {
                    if (col.getCelda() == celda)
                        yaEstaOcupado = true;
                }
                if (!yaEstaOcupado)
                {
                    ponerColmena((PictureBox)celda);
                }
            } else {
                //Desactivar las variables de selección
                desactivar_seleccion();
                //Recorrer todas las colmenas para buscar la seleccionada
                foreach (Colmena col in colmena)
                {
                    if (col.getCelda() == celda) {
                        if (actividad == Actividad.PONER_ALZA)
                        {
                            ponerAlza(col, (PictureBox)celda);  //Poner Alza 
                            break;
                        }
                        else if (actividad == Actividad.VER_COLMENA)
                        {
                            verColmena(col, estacion);
                            break;
                        }
                        else if (actividad == Actividad.PONER_REDUCTOR)
                        {
                            col.ponerReductor();
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
                
        private void dividir_colmena() {

            //Distribuir las colonias de abejas a la mitad
            Colmena nueva_colmena = new Colmena(celda_disponible,
                                                colmena_seleccionada.getAbejas_Totales()/2,
                                                colmena_seleccionada.getClima());
            //colmena_seleccionada.reducri_colonia_a_la_mitad();

            //Distribuir la miel entre las dos colmenas
            switch (colmena_seleccionada.getAlzas().Count) {
                /*case 1:
                    nueva_colmena.agregarAlza((colmena_seleccionada.getAlzas())[0].getMiel()/2);
                    (colmena_seleccionada.getAlzas())[0].miel_a_la_mitad();
                    break;
                case 2:
                    nueva_colmena.agregarAlza(colmena_seleccionada.total_de_miel()/2); //%50 de miel
                    (colmena_seleccionada.getAlzas())[0].setMiel(colmena_seleccionada.total_de_miel() / 2);
                    colmena_seleccionada.quitar_Alza(); //Se quita una alza                   
                    break;
                case 3:
                    nueva_colmena.agregarAlza(100); //Una alza con %50 de miel
                    nueva_colmena.agregarAlza((colmena_seleccionada.total_de_miel()-100) / 2);

                    (colmena_seleccionada.getAlzas())[1].setMiel(nueva_colmena.getAlzas()[1].getMiel());
                    colmena_seleccionada.quitar_Alza(); //Se quita una alza   
                    break;*/
            }
            //Agregar a la  lista la nueva colmena
            colmena.Add(nueva_colmena);
            //Actualizar la imagen de las colmenas
            colmena_seleccionada.mostrarAlzas();
            nueva_colmena.mostrarAlzas();
        }
           
        private void ponerNucleo(Colmena col) {
            if (col.hayAbejaReina().Equals("No") || (col.Obreras))
            {
                //Poner una reina 
                col.Reina = new AbejaReina(col, clima);
                //Poner cuadros de cría
                for (int i = 0; i < 5; i++)
                    col.Cria.Add(new GrupoAbejas(300));
            }
        }

        public void verColmena(Colmena colm, Estacion estacion) {           
            Form vistaInterna = new VistaInterna(colm, estacion);
            vistaInterna.Show();
        }

        public void cosechar(Colmena col, PictureBox celda)
        {

        }
        public void ponerReina(Colmena col)
        {
            col.ponerReina(new AbejaReina(col, col.getClima()));
            col.matarHuevosDeReina();
        }
        public void eliminaColmena(Colmena col, PictureBox celda) {
            //Cambiar la imagen 
            celda.Image = System.Drawing.Image.FromFile("celda.png");           
            //*Si se elimina la colmena con abejas dentro, cuanta como colmena muerta.
            //*El cajon y las alzas de la colmena regresan al almacen
            colmena.Remove(col); //Elimnar la colmena de la lista
        }

        public void ponerColmena(PictureBox celda) {
            //Cambiar las imagenas de la celda
            if (celda.Image.Equals("celda.png"))
            { 
                celda.Image = System.Drawing.Image.FromFile("colmena0.png");
                Colmena nueva_colmena = new Colmena(celda, clima);
                colmena.Add(nueva_colmena); //Se agrega una nueva colmena
            }
        }
        
        //Una colmena solo puede tener, como máximo, 3 Alzas
        public void ponerAlza(Colmena colm, PictureBox celda) {
            bool seAgregoAlza = colm.agregarAlza();
            if (seAgregoAlza)            
                colm.mostrarAlzas();                        
        }
        
    }
}
