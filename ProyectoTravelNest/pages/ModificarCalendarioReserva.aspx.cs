using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace ProyectoTravelNest.pages
{
    public partial class ModificarCalendarioReserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Negocios.Neg_AjustarReserva reserva = new Negocios.Neg_AjustarReserva();
            // Mostrar el mensaje de éxito
            lblMessage.Text = "Modificación de reserva exitosa";
            lblMessage.CssClass = "success-message"; // Puedes definir una clase CSS para el estilo
            lblMessage.Visible = true;

            int IdInmueble = 1; 
            string Tiempo_EstadiaMinima = estadiaMinima.Text;
            string Tiempo_EstadiaMaxima = estadiaMaxima.Text;
            string Tiempo_ReservaMinima = reservaMinima.SelectedValue; // Obtenemos el valor seleccionado del DropDownList
            string Tiempo_ReservaMaxima = reservaMaxima.SelectedValue; // Obtenemos el valor seleccionado del DropDownList

            // Llamar al método para insertar en la base de datos
            Negocios.Neg_AjustarReserva.InsertarAjustarReserva(IdInmueble, Tiempo_EstadiaMinima, Tiempo_EstadiaMaxima, Tiempo_ReservaMinima, Tiempo_ReservaMaxima);

        }

        protected void estadiaMinima_TextChanged(object sender, EventArgs e)
        {

        }

        protected void reservaMinima_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void PrecioporNoche_TextChanged(object sender, EventArgs e)
        {
            // Aquí coloca la lógica que deseas ejecutar cuando el texto del TextBox cambie.
        }
        protected void Descuento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aquí coloca la lógica que deseas ejecutar cuando se selecciona un elemento en el DropDownList.
        }

    }
}