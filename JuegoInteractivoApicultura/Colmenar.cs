using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoInteractivoApicultura
{
    //Son las acciones que estan en la barra de herramientas y que
    //puede realizar el apicultor
    enum Actividad { 
        SELECION, VER_COLMENA, PONER_CAMARA, PONER_ALZA, 
        PONER_REDUCTOR, ELIMINAR, ALIMENTAR, PONER_REINA,
        COSECHAR, DIVIDIR, PONER_NUCLEO
    }
    enum Estacion
    {
        PRIMAVERA, VERANO, OTONO, INVIERNO
    }
    public partial class Colmenar : Form
    {
        private int colmenas_Muertas;

        private Apicultor apicultor;
        private TiendaForm tienda;
        private AlmacenForm almacen;
        private Foco foco;
        private Clima clima;

        //private CurvaDeFloracion curva;
        private Actividad actividadActual; //Es la actividad que está relizando el apicultor
        private TipoAlimento tipo_Alimento;
        private int anio;
       
        public Colmenar()
        {
            InitializeComponent();
            inicializarColmenar();
        }


        private void inicializarColmenar() {
            barra.BackColor = Color.Transparent;
            actividadActual = Actividad.SELECION;
            tienda = new TiendaForm();
            almacen = new AlmacenForm();           
            foco = new Foco();            
            clima = new Clima(Estacion.INVIERNO, 0, 5);
            apicultor = new Apicultor(almacen, clima);
            colmenas_Muertas = 0;
            quitar_colmenas();
            
            timer1.Stop();
            barra.Location = new Point(231, 58);//Regresar al inicio
            toolStripTextBox1.Text = toolStripTextBox2.Text = toolStripTextBox3.Text = toolStripTextBox4.Text = "";
            Inicio(true);
        }
        private void quitar_colmenas() {
            celda0.Image = celda1.Image = celda2.Image = celda3.Image = celda4.Image =
            celda5.Image = celda6.Image = celda7.Image = celda8.Image = celda9.Image =
            celda10.Image = celda11.Image = celda12.Image = celda13.Image = celda14.Image =
            celda15.Image = celda16.Image = celda17.Image = celda18.Image = celda19.Image =
            celda20.Image = celda21.Image = celda22.Image = celda23.Image = celda24.Image =
            celda25.Image = celda26.Image = celda27.Image = celda28.Image = celda29.Image =
            celda30.Image = celda31.Image = System.Drawing.Image.FromFile("celda.png");
        }

        private void Inicio(bool visibilidad) {
            celda0.Visible = celda1.Visible = celda2.Visible = celda3.Visible = celda4.Visible =
            celda5.Visible = celda6.Visible = celda7.Visible = celda8.Visible = celda9.Visible =
            celda10.Visible = celda11.Visible = celda12.Visible = celda13.Visible = celda14.Visible =
            celda15.Visible = celda16.Visible = celda17.Visible = celda18.Visible = celda19.Visible =
            celda20.Visible = celda21.Visible = celda22.Visible = celda23.Visible = celda24.Visible =
            celda25.Visible = celda26.Visible = celda27.Visible = celda28.Visible = celda29.Visible =
            celda30.Visible = celda31.Visible = !visibilidad;
            barra.Visible = label2.Visible= !visibilidad;
            pictureBox3.Visible = !visibilidad; //Foco
            toolStrip1.Visible = !visibilidad;
            toolStrip2.Visible = !visibilidad;                       
            pictureBox2.Visible = visibilidad; //Fondo del inicio 
            pictureBox1.Visible = !visibilidad; //Fondo del apiario
            //Botones del menu
            almacenMenu.Enabled = tiendaMenu.Enabled = vistaGeneralDelApiarioMenu.Enabled = !visibilidad;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Ir al Almacén
        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form almacen = new AlmacenForm();
            almacen.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        //Actividad: Colocar camara de cría
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            actividadActual = Actividad.PONER_CAMARA;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void alimentoDeSosttenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
                  
        }
       

        //Menú "Salir"
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            Inicio(true);
        }
        //Menú "Terminar"
        private void terminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        //Celda 1
        private void celda1_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //PLAY
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        //PAUSA
        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        //DISMINUIR
        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            if (timer1.Interval <= 2000)               
                timer1.Interval += 20;
        }
        //AUMENTAR
        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            if (timer1.Interval >= 25) //Miestras sea mayor que 10 milisegundos
                timer1.Interval -= 20;
        }

        private void actulizar_estacion() {

            if (barra.Location.X >= 965) //Incremento del año
            {
                anio = anio + 1;
                barra.Location = new Point(231, 58);//Regresar al inicio
                clima.Estacion_del_año = Estacion.INVIERNO;              
            }else if (barra.Location.X >= 231 && barra.Location.X < 318)
            {
                clima.Estacion_del_año = Estacion.INVIERNO;
            }
            else if (barra.Location.X >= 318 && barra.Location.X < 502)
            {
                clima.Estacion_del_año = Estacion.PRIMAVERA;
              
            }
            else if (barra.Location.X >= 502 && barra.Location.X < 688 && clima.Estacion_del_año != Estacion.VERANO)
                clima.Estacion_del_año = Estacion.VERANO;
            else if (barra.Location.X >= 688 && barra.Location.X < 876 && clima.Estacion_del_año != Estacion.OTONO)
                clima.Estacion_del_año = Estacion.OTONO;
            else if (barra.Location.X >= 876 && clima.Estacion_del_año != Estacion.INVIERNO)
                clima.Estacion_del_año = Estacion.INVIERNO;

        }
        private void actulizar_nivel_de_nectar() {
            //Invierno 
            if (clima.Estacion_del_año == Estacion.INVIERNO)
            {
                if (barra.Location.X >= 231 && barra.Location.X < 266)
                    clima.Nivel_de_netar = 5;
                else if (barra.Location.X >= 266 && barra.Location.X < 290)
                    clima.Nivel_de_netar = 10;
                else if (barra.Location.X >= 290 && barra.Location.X < 305)
                    clima.Nivel_de_netar =15;
                else if (barra.Location.X >= 305 && barra.Location.X < 319)
                    clima.Nivel_de_netar = 20;
                else if (barra.Location.X >= 877 && barra.Location.X < 975)
                    clima.Nivel_de_netar =1;
            }
            else if (clima.Estacion_del_año == Estacion.PRIMAVERA)
            {
                //Primavera
                if (barra.Location.X >= 319 && barra.Location.X < 327)
                    clima.Nivel_de_netar = 25;
                else if (barra.Location.X >= 327 && barra.Location.X < 339)
                    clima.Nivel_de_netar =35;
                else if (barra.Location.X >= 339 && barra.Location.X < 352)
                    clima.Nivel_de_netar = 50;
                else if (barra.Location.X >= 353 && barra.Location.X < 366)
                    clima.Nivel_de_netar = 65;
                else if (barra.Location.X >= 366 && barra.Location.X < 382)
                    clima.Nivel_de_netar = 80;
                else if (barra.Location.X >= 382 && barra.Location.X < 438)
                    clima.Nivel_de_netar = 100;
                else if (barra.Location.X >= 438 && barra.Location.X < 458)
                    clima.Nivel_de_netar = 80;
                else if (barra.Location.X >= 458 && barra.Location.X < 476)
                    clima.Nivel_de_netar = 65;
                else if (barra.Location.X >= 476 && barra.Location.X < 492)
                    clima.Nivel_de_netar = 50;
                else if (barra.Location.X >= 492 && barra.Location.X < 503)
                    clima.Nivel_de_netar = 30;
            }
            else if (clima.Estacion_del_año == Estacion.VERANO)
            {
                //Verano
                if (barra.Location.X >= 503 && barra.Location.X < 524)
                    clima.Nivel_de_netar = 20;
                else if (barra.Location.X >= 524 && barra.Location.X < 555)
                    clima.Nivel_de_netar = 17;
                else if (barra.Location.X >= 555 && barra.Location.X < 607)
                    clima.Nivel_de_netar = 15;
                else if (barra.Location.X >= 607 && barra.Location.X < 689)
                    clima.Nivel_de_netar = 10;
            }
            else if (clima.Estacion_del_año == Estacion.OTONO)
            {
                if (barra.Location.X >= 689 && barra.Location.X < 712)
                    clima.Nivel_de_netar = 20;
                else if (barra.Location.X >= 712 && barra.Location.X < 732)
                    clima.Nivel_de_netar = 35;
                else if (barra.Location.X >= 732 && barra.Location.X < 787)
                    clima.Nivel_de_netar = 50;
                else if (barra.Location.X >= 787 && barra.Location.X < 815)
                    clima.Nivel_de_netar = 35;
                if (barra.Location.X >= 815 && barra.Location.X < 849)
                    clima.Nivel_de_netar = 20;
                else if (barra.Location.X >= 849 && barra.Location.X < 877)
                    clima.Nivel_de_netar = 5;
            }
        }
        private void actualizar_temperatura() {
            if (barra.Location.X >= 231 && barra.Location.X < 274)
                clima.Temperatura = 5;
            else if (barra.Location.X >= 274 && barra.Location.X < 300)
                clima.Temperatura = 15;
            else if (barra.Location.X >= 300 && barra.Location.X < 325)
                clima.Temperatura = 25;
            else if (barra.Location.X >= 325 && barra.Location.X < 689)
                clima.Temperatura = 35;
            else if (barra.Location.X >= 689 && barra.Location.X < 815)
                clima.Temperatura = 25;
            else if (barra.Location.X >= 815 && barra.Location.X < 847)
                clima.Temperatura = 20;
            else if (barra.Location.X >= 847 && barra.Location.X < 882)
                clima.Temperatura = 10;
            else
                clima.Temperatura = 1;
        }

        //Lo que se va a ejecutar cuando el intervalo del reloj se cumpla
        private void timer1_Tick(object sender, EventArgs e)
        {
            barra.Location = new Point(barra.Location.X + 2, 58); //Mover la barra                    
            //Cambio del clima  
            actulizar_estacion();
            actulizar_nivel_de_nectar();
            actualizar_temperatura();
            afectar_colmenas_con_clima();
            //Las colmenas actuan
            foreach (Colmena colonia in apicultor.GetColmenas())
            {                
                //Si la colonia tiene reina, pone huevos 
                if (colonia.hayAbejaReina().Equals("Si")) 
                    colonia.getReina().pon_huevos();                 
                colonia.actualiza_vida();
                colonia.recolecta_miel();
            }            
            //Actualización de las salidas en los textbox
            toolStripTextBox1.Text = "%" + clima.Nivel_de_netar.ToString();
            toolStripTextBox2.Text = anio.ToString();
            toolStripTextBox4.Text = clima.Temperatura.ToString() + "°";
        }

        private void afectar_colmenas_con_clima() {
            //Matar colmenas por el fri            
            if (clima.Temperatura == 1)
            { 
                foreach (Colmena mi_colmena in apicultor.GetColmenas()) {                   
                    if (!mi_colmena.Reductor_de_piquera || mi_colmena.total_de_miel() > 0)
                    {
                        mi_colmena.getCelda().Image = System.Drawing.Image.FromFile("celda.png");
                        colmenas_Muertas += 1;
                    }
                }

            }
            

        }

        //Actividad: Selección
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            actividadActual = Actividad.SELECION;
        }
        //Actividad: Poner alza 
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            actividadActual = Actividad.PONER_ALZA;
        }
        //Actividad: Ver colmena
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            actividadActual = Actividad.VER_COLMENA;

        }
        //Actividad: Reductor de piquera
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            actividadActual = Actividad.PONER_REDUCTOR;
        }
        //Actividad: Eliminar camara
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            actividadActual = Actividad.ELIMINAR;
        }
        //Actividad: Poner reina
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            actividadActual = Actividad.PONER_REINA;
        }

        //Celda 0
        private void celda0_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 2
        private void celda2_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 3
        private void celda3_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 4
        private void celda4_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 5
        private void celda5_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 6
        private void celda6_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 7
        private void celda7_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);

        }
        //Celda 8
        private void celda8_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 9
        private void celda9_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 10
        private void celda10_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);

        }
        //Celda 11
        private void celda11_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 12
        private void celda12_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 13
        private void celda13_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 14
        private void celda14_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 15
        private void celda15_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 16
        private void celda16_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 17
        private void celda17_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 18
        private void celda18_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 19
        private void celda19_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 20
        private void celda20_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 21
        private void celda21_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 22
        private void celda22_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 23
        private void celda23_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda
        private void celda24_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 25
        private void celda25_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 26
        private void celda26_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 27
        private void celda27_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 28
        private void celda28_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 29
        private void celda29_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);

        }
        //Celda 30
        private void celda30_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);
        }
        //Celda 31
        private void celda31_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender, clima.Estacion_del_año);

        }
        //Actividad: Poner Nucleo de abejas
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            actividadActual = Actividad.PONER_NUCLEO;

        }
        //Actividad: Dividir colmena
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            actividadActual = Actividad.DIVIDIR;            
        }
        //Actividad: Cosechar
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            actividadActual = Actividad.COSECHAR;
        }
        //VISTA GENERAL DEL APIARIO
        private void vistaGeneralDelApiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form vistaGeneral = new VistaGeneral(apicultor.GetColmenas());
            vistaGeneral.Show();
        }
           
        //Ir a la tienda
        private void tiendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form tiena = new TiendaForm();
            tiena.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }
        //Terminar partida
        private void terminarPartidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        //Nuevo apiario
        private void nuevoApiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {               
            inicializarColmenar();
            Inicio(false);            
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
