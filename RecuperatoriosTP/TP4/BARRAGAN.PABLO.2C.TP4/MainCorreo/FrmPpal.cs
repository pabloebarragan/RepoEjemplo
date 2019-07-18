using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            
            try
            {
                correo += paquete;
                paquete.InformaEstado += paq_InformaEstado;
                paquete.InformaSQLException += paq_InformaSQLException;
                ActualizarEstados();
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message, "Paquete Repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        /// <summary>
        /// Inicializa correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_Load(object sender, EventArgs e)
        {
            correo = new Correo();
        }

        /// <summary>
        /// Actualiza los listBox con los paquetes que vayan en cada lista
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();
            foreach (Paquete paquete in correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(paquete);
                        break;
                }
            }
        }

        /// <summary>
        /// Informa del estado de los paquetes del correo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        /// <summary>
        /// Muestra el error si se produjo un fallo con la base de datos.
        /// </summary>
        /// <param name="e"></param>
        private void paq_InformaSQLException(Exception e)
        {
            MessageBox.Show(e.Message, "Guardado no realizado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// evaluará que el atributo elemento no sea nulo y:
        /// a.Mostrará los datos de elemento en el rtbMostrar.
        /// b.Utilizará el método de extensión para guardar los datos en un archivo llamado salida.txt.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento">Elemento que contiene la informacion a mostrar</param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                string datos = elemento.MostrarDatos(elemento); ;

                rtbMostrar.Text = datos;
                try
                {
                    datos.Guardar(@"salida.txt");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Guardado no realizado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// cierra todos los hilos abiertos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }



    }
}
