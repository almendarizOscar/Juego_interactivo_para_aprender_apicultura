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
    enum Actividad
    {
        SELECION, VER_COLMENA, PONER_CAMARA, PONER_ALZA,
        PONER_REDUCTOR, QUITAR_REDUCTOR, ELIMINAR, ALIMENTAR, PONER_REINA,
        COSECHAR, DIVIDIR, PONER_NUCLEO
    }
    enum Estacion
    {
        PRIMAVERA, VERANO, OTONO, INVIERNO
    }
    public partial class Colmenar : Form
    {

        private Apicultor apicultor;
        private Actividad actividadActual; //Es la actividad que está relizando el apicultor        
        private int anio;
        private bool ya_presiono_start;
        public Colmenar()
        {
            InitializeComponent();
            inicializarColmenar();
            Program.colmenar = this; //Es el cursosr del programa                       
            Program.mensajes_de_Otto = richTextBox1;
            bloquear_herramientas();
        }


        private void inicializarColmenar()
        {
            
            this.StartPosition = FormStartPosition.CenterScreen;
            Program.id_ya_asignado = new List<int>();
            Program.play = toolStripButton12;
            Program.pause = toolStripButton13;
            barra.BackColor = Color.Transparent;
            actividadActual = Actividad.SELECION;
            Almacen al = new Almacen();
            Program.almacen = al;
            Program.clima = new Clima(Estacion.INVIERNO, 0, 5);
            apicultor = new Apicultor(al);
            Program.colmenas_muertas = 0;
            quitar_colmenas();
            timer2.Start();
            barra.Location = new Point(231, 58);//Regresar al inicio
            toolStripTextBox1.Text = "5%";
            toolStripTextBox2.Text = "0";
            toolStripTextBox3.Text = "5 °C";
            toolStripTextBox4.Text = "2500";
            Program.miel_recolectada_total = 0;
            Inicio(true);
            timer1.Stop();
            Program.reloj = timer1;
        }
        private void quitar_colmenas()
        {
            celda0.Image = celda1.Image = celda2.Image = celda3.Image = celda4.Image =
            celda5.Image = celda6.Image = celda7.Image = celda8.Image = celda9.Image =
            celda10.Image = celda11.Image = celda12.Image = celda13.Image = celda14.Image =
            celda15.Image = celda16.Image = celda17.Image = celda18.Image = celda19.Image =
            celda20.Image = celda21.Image = celda22.Image = celda23.Image = celda24.Image =
            celda25.Image = celda26.Image = celda27.Image = celda28.Image = celda29.Image =
            celda30.Image = celda31.Image = System.Drawing.Image.FromFile("celda.png");
        }

        private void Inicio(bool visibilidad)
        {

            celda0.Visible = celda1.Visible = celda2.Visible = celda3.Visible = celda4.Visible =
            celda5.Visible = celda6.Visible = celda7.Visible = celda8.Visible = celda9.Visible =
            celda10.Visible = celda11.Visible = celda12.Visible = celda13.Visible = celda14.Visible =
            celda15.Visible = celda16.Visible = celda17.Visible = celda18.Visible = celda19.Visible =
            celda20.Visible = celda21.Visible = celda22.Visible = celda23.Visible = celda24.Visible =
            celda25.Visible = celda26.Visible = celda27.Visible = celda28.Visible = celda29.Visible =
            celda30.Visible = celda31.Visible = !visibilidad;
            barra.Visible = label2.Visible = !visibilidad;
            toolStrip1.Visible = !visibilidad;
            toolStrip2.Visible = !visibilidad;
            pictureBox2.Visible = visibilidad; //Fondo del inicio 
            pictureBox1.Visible = !visibilidad; //Fondo del apiario
            //Botones del menu
            almacenMenu.Visible = tiendaMenu.Visible = !visibilidad;
            terminarPartidaToolStripMenuItem.Visible = !visibilidad;
            salirToolStripMenuItem.Visible = !visibilidad;
            v_generalToolStripMenuItem1.Visible = !visibilidad;
            ayudaToolStripMenuItem.Visible = !visibilidad;
            if (visibilidad) //Si es true, esta en el inicion del juego
            {
                //Se bloquea la ayudade Otto
                this.StartPosition = FormStartPosition.CenterScreen;
                panel1.Visible = false;
                this.Size = new Size(995, 575); //La pantalla se hace                
            }
            else
            {
                Program.otto = new Otto();
                this.Location = new Point(15, 15);
                toolStripButton13.Enabled = false; //Pausa
                toolStripButton12.Enabled = true; //Play
                panel1.Visible = true;
                this.Size = new Size(995, 693); //La pantalla se hace chica
                verToolStripMenuItem.Enabled = false;
                cerrarToolStripMenuItem.Enabled = true;
                ya_presiono_start = false;
                Program.otto.mensaje_de_inicio(ya_presiono_start);
            }
        }



        //Ir al Almacén
        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Pausar el timer   
            toolStripButton12.Enabled = true; //Play 
            toolStripButton13.Enabled = false; //Pausa
            Form almacen = new AlmacenForm(apicultor.Monedas);
            almacen.Show();
        }

        //Actividad: Colocar camara de cría
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            actividadActual = Actividad.PONER_CAMARA;
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
            apicultor.realizaActividad(actividadActual, sender);
        }
        //PLAY
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            if (!ya_presiono_start)
            {
                Program.mensajes_de_Otto.Clear();
                ya_presiono_start = true;
            }
            timer1.Enabled = true;
            toolStripButton13.Enabled = true; //Pausa
            toolStripButton12.Enabled = false; //Play
        }
        //PAUSA
        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            toolStripButton13.Enabled = false; //Pausa
            toolStripButton12.Enabled = true; //Play
        }
        //DISMINUIR
        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            if (Program.reloj.Interval <= 1000)
                Program.reloj.Interval += 100;
        }
        //AUMENTAR
        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            if (Program.reloj.Interval > 2) //Miestras sea mayor que 10 milisegundos
                Program.reloj.Interval -= 100;
        }

        private void actulizar_estacion()
        {

            if (barra.Location.X >= 965) //Incremento del año
            {
                anio = anio + 1;
                barra.Location = new Point(231, 58);//Regresar al inicio
                Program.clima.Estacion_del_año = Estacion.INVIERNO;
            }
            else if (barra.Location.X >= 231 && barra.Location.X < 318)
            {
                Program.clima.Estacion_del_año = Estacion.INVIERNO;
            }
            else if (barra.Location.X >= 318 && barra.Location.X < 502)
            {
                Program.clima.Estacion_del_año = Estacion.PRIMAVERA;

            }
            else if (barra.Location.X >= 502 && barra.Location.X < 688 && Program.clima.Estacion_del_año != Estacion.VERANO)
                Program.clima.Estacion_del_año = Estacion.VERANO;
            else if (barra.Location.X >= 688 && barra.Location.X < 876 && Program.clima.Estacion_del_año != Estacion.OTONO)
                Program.clima.Estacion_del_año = Estacion.OTONO;
            else if (barra.Location.X >= 876 && Program.clima.Estacion_del_año != Estacion.INVIERNO)
                Program.clima.Estacion_del_año = Estacion.INVIERNO;

        }
        private void actulizar_nivel_de_nectar()
        {
            //Invierno 
            if (Program.clima.Estacion_del_año == Estacion.INVIERNO)
            {
                if (barra.Location.X >= 231 && barra.Location.X < 266)
                    Program.clima.Nivel_de_netar = 5;
                else if (barra.Location.X >= 266 && barra.Location.X < 290)
                    Program.clima.Nivel_de_netar = 10;
                else if (barra.Location.X >= 290 && barra.Location.X < 305)
                    Program.clima.Nivel_de_netar = 15;
                else if (barra.Location.X >= 305 && barra.Location.X < 319)
                    Program.clima.Nivel_de_netar = 20;
                else if (barra.Location.X >= 877 && barra.Location.X < 975)
                    Program.clima.Nivel_de_netar = 1;
            }
            else if (Program.clima.Estacion_del_año == Estacion.PRIMAVERA)
            {
                //Primavera
                if (barra.Location.X >= 319 && barra.Location.X < 327)
                    Program.clima.Nivel_de_netar = 25;
                else if (barra.Location.X >= 327 && barra.Location.X < 339)
                    Program.clima.Nivel_de_netar = 35;
                else if (barra.Location.X >= 339 && barra.Location.X < 352)
                    Program.clima.Nivel_de_netar = 50;
                else if (barra.Location.X >= 353 && barra.Location.X < 366)
                    Program.clima.Nivel_de_netar = 65;
                else if (barra.Location.X >= 366 && barra.Location.X < 382)
                    Program.clima.Nivel_de_netar = 80;
                else if (barra.Location.X >= 382 && barra.Location.X < 438)
                    Program.clima.Nivel_de_netar = 100;
                else if (barra.Location.X >= 438 && barra.Location.X < 458)
                    Program.clima.Nivel_de_netar = 80;
                else if (barra.Location.X >= 458 && barra.Location.X < 476)
                    Program.clima.Nivel_de_netar = 65;
                else if (barra.Location.X >= 476 && barra.Location.X < 492)
                    Program.clima.Nivel_de_netar = 50;
                else if (barra.Location.X >= 492 && barra.Location.X < 503)
                    Program.clima.Nivel_de_netar = 30;
            }
            else if (Program.clima.Estacion_del_año == Estacion.VERANO)
            {
                //Verano
                if (barra.Location.X >= 503 && barra.Location.X < 524)
                    Program.clima.Nivel_de_netar = 20;
                else if (barra.Location.X >= 524 && barra.Location.X < 555)
                    Program.clima.Nivel_de_netar = 17;
                else if (barra.Location.X >= 555 && barra.Location.X < 607)
                    Program.clima.Nivel_de_netar = 15;
                else if (barra.Location.X >= 607 && barra.Location.X < 689)
                    Program.clima.Nivel_de_netar = 10;
            }
            else if (Program.clima.Estacion_del_año == Estacion.OTONO)
            {
                if (barra.Location.X >= 689 && barra.Location.X < 712)
                    Program.clima.Nivel_de_netar = 20;
                else if (barra.Location.X >= 712 && barra.Location.X < 732)
                    Program.clima.Nivel_de_netar = 35;
                else if (barra.Location.X >= 732 && barra.Location.X < 787)
                    Program.clima.Nivel_de_netar = 50;
                else if (barra.Location.X >= 787 && barra.Location.X < 815)
                    Program.clima.Nivel_de_netar = 35;
                if (barra.Location.X >= 815 && barra.Location.X < 849)
                    Program.clima.Nivel_de_netar = 20;
                else if (barra.Location.X >= 849 && barra.Location.X < 877)
                    Program.clima.Nivel_de_netar = 5;
            }
        }
        private void actualizar_temperatura()
        {
            if (barra.Location.X >= 231 && barra.Location.X < 274)                           
                Program.clima.Temperatura = 5;            
            else if (barra.Location.X >= 274 && barra.Location.X < 300)            
                Program.clima.Temperatura = 15;            
            else if (barra.Location.X >= 300 && barra.Location.X < 325)
                Program.clima.Temperatura = 25;
            else if (barra.Location.X >= 325 && barra.Location.X < 689)
                Program.clima.Temperatura = 35;
            else if (barra.Location.X >= 689 && barra.Location.X < 815)
                Program.clima.Temperatura = 25;
            else if (barra.Location.X >= 815 && barra.Location.X < 847)
                Program.clima.Temperatura = 20;
            else if (barra.Location.X >= 847 && barra.Location.X < 882)
                Program.clima.Temperatura = 10;
            else
                Program.clima.Temperatura = 1;
        }


        //Este evento hace que el juego sea autónomo
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Mover la barra 
            barra.Location = new Point(barra.Location.X + 2, 58);
            //Cambio del clima  
            actulizar_estacion();
            actulizar_nivel_de_nectar();
            actualizar_temperatura();
            //Las colmenas actuan
            foreach (Colmena colonia in apicultor.GetColmenas())
            {
                colonia.actualiza_colmena();
                if (colonia.Pecoreadoras > 0)
                    colonia.recolectar_miel();
            }
            //Actualización de las salidas en los textbox
            toolStripTextBox1.Text = "%" + Program.clima.Nivel_de_netar.ToString();
            toolStripTextBox2.Text = anio.ToString();
            toolStripTextBox3.Text = Program.clima.Temperatura.ToString() + "°C";
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
            apicultor.realizaActividad(actividadActual, sender);

        }
        //Celda 2
        private void celda2_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 3
        private void celda3_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 4
        private void celda4_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 5
        private void celda5_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 6
        private void celda6_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 7
        private void celda7_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);

        }
        //Celda 8
        private void celda8_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 9
        private void celda9_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 10
        private void celda10_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);

        }
        //Celda 11
        private void celda11_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 12
        private void celda12_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 13
        private void celda13_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 14
        private void celda14_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 15
        private void celda15_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 16
        private void celda16_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 17
        private void celda17_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 18
        private void celda18_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 19
        private void celda19_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 20
        private void celda20_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 21
        private void celda21_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 22
        private void celda22_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 23
        private void celda23_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda
        private void celda24_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 25
        private void celda25_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 26
        private void celda26_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 27
        private void celda27_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 28
        private void celda28_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 29
        private void celda29_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);

        }
        //Celda 30
        private void celda30_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);
        }
        //Celda 31
        private void celda31_Click(object sender, EventArgs e)
        {
            apicultor.realizaActividad(actividadActual, sender);

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

        }

        //Ir a la tienda
        private void tiendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton12.Enabled = true; //Play 
            toolStripButton13.Enabled = false; //Pausa
            Tienda tienda = new Tienda(apicultor);
            tienda.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }
        //Terminar partida
        private void terminarPartidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            MessageBox.Show("Juego terminado");
            MarcadorForm marcador = new MarcadorForm(apicultor, anio);
            marcador.Show();
            Inicio(true);


        }
        //Nuevo apiario
        private void nuevoApiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inicializarColmenar();
            Inicio(false);
        }

        private void alimentoDeSosttenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actividadActual = Actividad.PONER_REDUCTOR;
        }

        private void alimentoParaInsentivarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actividadActual = Actividad.QUITAR_REDUCTOR;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            actividadActual = Actividad.ALIMENTAR;

        }

        private void toolStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void toolStrip2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void celda0_MouseMove(object sender, MouseEventArgs e)
        {
            Puntero.cambia_puntero(actividadActual);
            no_hay_recursos((PictureBox)sender);

        }

        private void celda8_MouseMove(object sender, MouseEventArgs e)
        {
            Puntero.cambia_puntero(actividadActual);
        }

        private void celda16_MouseMove(object sender, MouseEventArgs e)
        {
            Puntero.cambia_puntero(actividadActual);
        }

        private void celda24_MouseMove(object sender, MouseEventArgs e)
        {
            Puntero.cambia_puntero(actividadActual);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Puntero.cambia_puntero(actividadActual);
        }
        //Metodo encargado de bloquear herramientas cuando no hya recursos en el almacen
        private void bloquear_herramientas()
        {
            toolStripButton7.Enabled = (Program.almacen.Alzas > 0) ? true : false; //ALZAS
            toolStripButton5.Enabled = (Program.almacen.Camaras_de_cria > 0) ? true : false; //CAMARAS
            toolStripButton8.Enabled = (Program.almacen.Reinas > 0) ? true : false; //REINAS
            toolStripButton11.Enabled = (Program.almacen.Nucleos > 0) ? true : false; //NUCLEOS
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            verificar_Si_ya_gano();
            verificar_si_ya_perdio();
            bloquear_herramientas();
            toolStripTextBox4.Text = apicultor.Monedas.ToString();
            if (ya_presiono_start)
                ayuda_de_Otto();
        }

        private void ayuda_de_Otto()
        {
            //Borrar el cuadro de mensajes
            //Program.mensajes_de_Otto.Clear();
           
            if (barra.Location.X >= 231 && barra.Location.X < 274)
            {
                //Mensaje 1
                //Program.clima.Temperatura = 5; 
                if (!Program.otto.el_mensaje_esta_mostrandose(1))
                {
                    Program.mensajes_de_Otto.Clear();//Limpiamos pantalla
                    Program.otto.mensaje_activado.Clear();//Eliminamos los demas mensajes
                    Program.otto.mensaje_activado.Add(1); //Agregamos el mensaje 

                    Program.otto.primer_mensaje("Las abejas no recolectan miel a temperaturas menores de 15°C", Color.Blue);
                    Program.otto.Mensaje("Si vas a poner colmenas en esta estación, será mejor que les pongas el reductor de piquera. " +
                    "De lo contrario, moriran de frio.", Color.Red);                                
                }
            }
            else if (barra.Location.X >= 274 && barra.Location.X < 300)
            {
                if (Program.clima.Temperatura >= 15 && Program.clima.Temperatura <= 20)
                {
                    //Program.clima.Temperatura = 15;
                    //Mensaje 2
                    if (!Program.otto.el_mensaje_esta_mostrandose(2))
                    {                      
                        Program.mensajes_de_Otto.Clear();//Limpiamos pantalla
                        Program.otto.mensaje_activado.Clear();//Eliminamos los demas mensajes
                        Program.otto.mensaje_activado.Add(2); //Agregamos el mensaje 

                        Program.otto.primer_mensaje("A esta temperatura las abejas empiezan a salir de su receso invernal.", Color.Blue);
                        Program.otto.Mensaje("Si tienes colmenas insataladas en el apiario, este es el mejor momento para colocar las alzas melarias.", Color.Blue);
                        
                    }
                    
                }
            }
            else if (barra.Location.X >= 300 && barra.Location.X < 815)
            {
                //Mensaje 3
                //La piquera está puesta en tiempo de calor
                if (apicultor.hay_al_menos_una_colmenas_con_el_reductor())
                {
                    if (!Program.otto.el_mensaje_esta_mostrandose(3))
                    {

                        Program.mensajes_de_Otto.Clear();//Limpiamos pantalla
                        Program.otto.mensaje_activado.Clear();//Eliminamos los demas mensajes
                        Program.otto.mensaje_activado.Add(3); //Agregamos el mensaje 

                        Program.otto.primer_mensaje("!!Uff. Ya hace más calor!!", Color.Red);
                        Program.otto.Mensaje("He notado que no has quitado el reductor de piquera a tus colmenas. Esto puede causar " +
                        "problemas a tus abejas.", Color.Red);
                    }
                } else {                    
                    if (Program.clima.Estacion_del_año == Estacion.PRIMAVERA)
                    {
                        //Mensaje 4
                        if (!Program.otto.el_mensaje_esta_mostrandose(4))
                        {
                            Program.mensajes_de_Otto.Clear();//Limpiamos pantalla
                            Program.otto.mensaje_activado.Clear();//Eliminamos los demas mensajes
                            Program.otto.mensaje_activado.Add(4); //Agregamos el mensaje 

                            Program.otto.primer_mensaje("Este es el mejor momento para poner colmenas. Usa las cámaras de crías y los nucleos de " +
                                   "abejas para formar una colmena. Y no olvides ponerle alzas para que recolecten miel.", Color.Blue);
                        }

                        //Mensaje 5 
                        if (apicultor.El_almacen.Nucleos >= 1 && apicultor.El_almacen.Camaras_de_cria >= 1)
                        {
                            if (!Program.otto.el_mensaje_esta_mostrandose(5))
                            {
                                Program.otto.mensaje_activado.Add(5); //Agregamos el mensaje 
                                Program.otto.Mensaje("Eh notado que, en tu almacen tienes suficientes núcleos y cámaras de cría para poner más colemenas. No desperdicies ese potencial y pon más colemas en tu apiario.", Color.Blue);
                            }
                        }
                        else
                        {
                            if (Program.otto.el_mensaje_esta_mostrandose(5)) {
                                Program.otto.mensaje_activado.Clear();//Eliminamos los demas mensajes
                            }
                        }
                        //Mensaje 6
                        if (apicultor.acompleto_estas_colmenas() != 0) {
                            if (!Program.otto.el_mensaje_esta_mostrandose(6)){
                                Program.otto.mensaje_activado.Add(6); //Agregamos el mensaje 
                                Program.otto.Mensaje("Puedes invertir tu dinero en comprar más núcleos y cámaras de cria. Esto te generara más ganancias por " +
                                "la cosecha de miel. Con las monedas que tienes, te alcanza para poner " + apicultor.acompleto_estas_colmenas() + " colmenas.", Color.Green);
                            }

                        }
                        else
                        {
                            if (Program.otto.el_mensaje_esta_mostrandose(6))                            
                                Program.otto.mensaje_activado.Clear();//Eliminamos los demas mensajes
                            
                        }

                    }
                    //Mensaje 7
                    else if (Program.clima.Estacion_del_año == Estacion.VERANO)
                    {
                        if (apicultor.Mis_Colmenas.Count != 0)
                        {
                            if (!Program.otto.el_mensaje_esta_mostrandose(7))
                            {
                                Program.mensajes_de_Otto.Clear();//Limpiamos pantalla
                                Program.otto.mensaje_activado.Clear();//Eliminamos los demas mensajes
                                Program.otto.mensaje_activado.Add(7); //Agregamos el mensaje 
                                Program.otto.primer_mensaje("Si alguna de tus colmenas tienen una abeja reina vieja. Mayor de 2 años. Esta es la mejor temporada" +
                                 " del año para remplazarla. Una abejas reina mayor de 2 años en la colmena disminuye su postura de huevos. Por lo tanto disminuye la " +
                                 "poblacion de abejas pecoreadores. Y estas colmenas no recolectan mucha miel durante la primavera", Color.Red);
                            }
                          
                        }

                    }
                }
                //Temperatura  25;
            }       
            //Mensaje 8
            else if (barra.Location.X >= 709 && barra.Location.X < 847)
            {
                if (!Program.otto.el_mensaje_esta_mostrandose(8)) { 
                Program.mensajes_de_Otto.Clear();//Limpiamos pantalla
                Program.otto.mensaje_activado.Clear();//Eliminamos los demas mensajes
                Program.otto.mensaje_activado.Add(8); //Agregamos el mensaje 
                Program.otto.primer_mensaje("Este es el momento para preparar tus colmenas para la invernada. Coloca el reductor de piquera a cada una de las colmenas " +
                    "que tengas en tu apiario.", Color.Red);
                    Program.otto.Mensaje("Además, para que sobrevivan el invierno debes de dejar reservas de miel o alimento artificial.", Color.Blue);
                    //Temperatura 20;
                }

            }
            else {
                //Menaje 9
                if (!Program.otto.el_mensaje_esta_mostrandose(9))
                {
                    Program.mensajes_de_Otto.Clear();//Limpiamos pantalla
                    Program.otto.mensaje_activado.Clear();//Eliminamos los demas mensajes
                    Program.otto.mensaje_activado.Add(9); //Agregamos el mensaje 
                    Program.otto.primer_mensaje("En esta epoca del año. No molestes a tus abejas. Dejas las descansar", Color.Blue);
                    Program.otto.Mensaje("Solo verifica que las reservas de miel no se terminen. Porque corren el riesgo de morir de hambre.", Color.Blue);
                }

            }
           

        }


        private bool Al_menos_una_colmena_con_abejas()
        {
            if (apicultor.Mis_Colmenas.Count != 0)
            {
                foreach (Colmena col in apicultor.Mis_Colmenas)
                {
                    if (col.Abejas_totales != 0)
                        return true;
                }
            }
            return false;
        }

        private void verificar_si_ya_perdio()
        {
            //checa que el apicultor tenga dinero y colmenas

            if (apicultor.Monedas == 0 && (apicultor.Mis_Colmenas.Count == 0 || !Al_menos_una_colmena_con_abejas())
                && apicultor.El_almacen.Camaras_de_cria == 0 && apicultor.El_almacen.Nucleos == 0)
            {
                timer2.Stop();
                MessageBox.Show("Has perdido la partida");
                MarcadorForm marcador = new MarcadorForm(apicultor, anio);
                marcador.Show();
                Inicio(true);

            }
        }
        private bool hay_colmenas_vivas(int numero_de_colemans)
        {
            if (apicultor.Mis_Colmenas.Count >= numero_de_colemans)
            {
                int contador = 0;
                for (int i = 0; i < apicultor.Mis_Colmenas.Count; i++)
                {
                    if (apicultor.Mis_Colmenas[i].Abejas_totales != 0)
                        contador++;
                    if (contador == numero_de_colemans)
                        return true;
                }
            }
            return false;
        }

        private void verificar_Si_ya_gano()
        {
            if (hay_colmenas_vivas(5))
            {
                timer2.Stop();
                MessageBox.Show("¡Ganaste!. Completaste 10 colmenas de abejas");
                MarcadorForm marcador = new MarcadorForm(apicultor, anio);
                marcador.Show();
                Inicio(true);

            }
        }
        private bool aun_hay_colmenas_en_el_apiario()
        {
            if (apicultor.Mis_Colmenas.Count > 0)
            {
                foreach (Colmena col in apicultor.Mis_Colmenas)
                {
                    if (col.Abejas_totales != 0)
                        return true;
                }
            }
            return false;

        }

        //Vista General
        private void ayudaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripButton12.Enabled = true; //Play 
            toolStripButton13.Enabled = false; //Pausa
            Form vistaGeneral = new VistaGeneral(apicultor.GetColmenas());
            vistaGeneral.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            actividadActual = Actividad.PONER_REDUCTOR;

        }

        private void no_hay_recursos(PictureBox celda)
        {
            if (actividadActual == Actividad.PONER_CAMARA)
            {
                bool la_celda_esta_desocupada = true;
                foreach (Colmena colmena in apicultor.Mis_Colmenas)
                {
                    if (colmena.getCelda() == celda)
                        la_celda_esta_desocupada = false;
                }
                if (!la_celda_esta_desocupada)
                    Program.colmenar.Cursor = Cursors.Default;
            }
            else
            {
                foreach (Colmena colmena in apicultor.Mis_Colmenas)
                {
                    if (colmena.getCelda() == celda)
                    {
                        switch (actividadActual)
                        {
                            case Actividad.PONER_ALZA:
                                if (colmena.getAlzas().Count == 3)
                                    Program.colmenar.Cursor = Cursors.Default;
                                break;

                            case Actividad.PONER_REDUCTOR:
                                if (colmena.Reductor_de_piquera)
                                    Program.colmenar.Cursor = Cursors.Default;
                                break;

                            case Actividad.ELIMINAR:
                                Program.colmenar.Cursor = new Cursor("tacha.ico");
                                break;
                            case Actividad.PONER_REINA:
                                if (colmena.Reina != null)
                                    Program.colmenar.Cursor = Cursors.Default;
                                break;
                            case Actividad.PONER_NUCLEO:
                                if (colmena.Abejas_totales != 0)
                                    Program.colmenar.Cursor = Cursors.Default;
                                break;
                            case Actividad.COSECHAR:
                                if (!colmena.hay_alguna_alza_llena())
                                    Program.colmenar.Cursor = Cursors.Default;
                                break;

                        }
                    }
                }
            }
        }

        private void celda1_MouseMove(object sender, MouseEventArgs e)
        {
            no_hay_recursos((PictureBox)sender);
        }

        private void celda2_MouseMove(object sender, MouseEventArgs e)
        {
            no_hay_recursos((PictureBox)sender);
        }

        private void celda3_MouseMove(object sender, MouseEventArgs e)
        {
            no_hay_recursos((PictureBox)sender);
        }

        private void celda4_MouseMove(object sender, MouseEventArgs e)
        {
            no_hay_recursos((PictureBox)sender);
        }

        private void celda5_MouseMove(object sender, MouseEventArgs e)
        {
            no_hay_recursos((PictureBox)sender);
        }

        private void celda6_MouseMove(object sender, MouseEventArgs e)
        {
            no_hay_recursos((PictureBox)sender);
        }

        private void celda7_MouseMove(object sender, MouseEventArgs e)
        {
            no_hay_recursos((PictureBox)sender);
        }

        private void celda10_MouseMove(object sender, MouseEventArgs e)
        {
            no_hay_recursos((PictureBox)sender);
        }

        private void celda24_MouseMove_1(object sender, MouseEventArgs e)
        {
            no_hay_recursos((PictureBox)sender);
        }
        //Ver la ayuda de Otto el apicultor
        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verToolStripMenuItem.Enabled = false;
            cerrarToolStripMenuItem.Enabled = true;
            this.Size = new Size(995, 693);
            panel1.Visible = true;
        }
        //Cerrar la ayuda de Otto el apicultor
        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verToolStripMenuItem.Enabled = true;
            cerrarToolStripMenuItem.Enabled = false;
            this.Size = new Size(995, 575);
            panel1.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer_mensajes_Tick(object sender, EventArgs e)
        {          
        }

        private void informaciónDelJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton12.Enabled = true; //Play 
            toolStripButton13.Enabled = false; //Pausa
            Form ayuda = new Ayuda();
            ayuda.Show();
        }

        private void ayudaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
    }
}