using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace ProyectoTravelNest.pages
{
    public partial class ModificarCalendarioReserva : System.Web.UI.Page
    {
        Neg_AjustarReserva iReserva = new Neg_AjustarReserva();
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack & eUsuarios != null)
            {
                string IdInmueble = eUsuarios.IdUsuario.ToString();
                ObtenerDatos(IdInmueble);
            }

            
        }

        private void ObtenerDatos(string idInmueble)
        {
            try
            {
                PrecioporNoche.Text = iReserva.GetPrecioNoche(idInmueble);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string IdInmueble = Session["idInmueble"].ToString();
                

                decimal precioNoche = Convert.ToDecimal(PrecioporNoche.Text);

                // Llamar al método para insertar en la base de datos
                iReserva.AjustarDataPrecio(IdInmueble, precioNoche);

                // Mostrar el mensaje de éxito
                lblMessage.Text = "Modificación de reserva exitosa";
                lblMessage.CssClass = "success-message"; // Puedes definir una clase CSS para el estilo
                lblMessage.Visible = true;
            }
            catch (Exception ex)
            {
                // Mostrar el mensaje de fallo
                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "success-message"; // Puedes definir una clase CSS para el estilo
                lblMessage.Visible = true;
            }
        }

        protected void btn_saveTiempo_Click(object sender, EventArgs e)
        {
            try
            {
                string IdInmueble = Session["idInmueble"].ToString();
                

                string Tiempo_EstadiaMinima = estadiaMinima.Text;
                string Tiempo_EstadiaMaxima = estadiaMaxima.Text;
                string Tiempo_ReservaMinima = reservaMinima.SelectedValue; // Obtenemos el valor seleccionado del DropDownList
                string Tiempo_ReservaMaxima = reservaMaxima.SelectedValue; // Obtenemos el valor seleccionado del DropDownList

                // Llamar al método para insertar en la base de datos
                iReserva.AjustarTimeReserva(IdInmueble, Tiempo_EstadiaMinima, Tiempo_EstadiaMaxima, Tiempo_ReservaMinima, Tiempo_ReservaMaxima);

                // Mostrar el mensaje de éxito
                lblMessage.Text = "Modificación de tiempos de estadia exitosa";
                lblMessage.CssClass = "success-message"; // Puedes definir una clase CSS para el estilo
                lblMessage.Visible = true;
                Response.Write("Modificación de reserva exitosa");
            }
            catch (Exception ex)
            {
                // Mostrar el mensaje de fallo
                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "success-message"; // Puedes definir una clase CSS para el estilo
                lblMessage.Visible = true;
            }
        }

    }
}