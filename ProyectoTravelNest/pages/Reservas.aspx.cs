using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class Reservas : System.Web.UI.Page
    {   // Crear una instancia de la clase de negocios
        Negocios.Neg_Reservaciones negocioReservaciones = new Negocios.Neg_Reservaciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idUsuario = "2222222222";
                // Asumiendo que tienes una forma de obtener el ID del usuario logueado
                //string idUsuario = Session["IdUsuario"] as string;


                var negocioReservaciones = new Negocios.Neg_Reservaciones();
                var reservaReciente = negocioReservaciones.ObtenerReservacionRecientePorUsuario(idUsuario);

                if (reservaReciente != null)
                {
                    // Establece los valores de los controles a partir de los datos de la reserva
                    // Asegúrate de que los nombres de los controles en el código C# coincidan con los ID de los controles en el markup de ASP.NET
                    NombreTextBox.Text = reservaReciente.NombreUsuario;
                    NombreInmuebleTextBox.Text = reservaReciente.NombreInmueble; // Asumiendo que la propiedad se llama NombreInmueble
                    FechaInicioTextBox.Text = reservaReciente.F_Inicio.ToString("yyyy-MM-dd");
                    FechaFinalizaTextBox.Text = reservaReciente.F_Fin.ToString("yyyy-MM-dd");
                    EstadoTextBox.Text = reservaReciente.Estado;
                    // ... establecer el resto de los campos
                }
            }
        }


        protected void btnVerHistorial_Click(object sender, EventArgs e)
        {

        }

        protected void VerHistorialButton_Click(object sender, EventArgs e)
        {

        }
    }
}