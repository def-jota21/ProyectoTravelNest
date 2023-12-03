using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class configuracioncorreos : System.Web.UI.Page
    {
        Negocios.Email email = new Negocios.Email();
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios eUsuarios = Session["idUsuario"] as Entidades.Usuarios;
            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            if (!IsPostBack)
            {
                if (eUsuarios.T_Rol.ToString() == "G")
                {
                    getMensajes();
                }
                else
                {
                    Response.Redirect("/Default.aspx");
                }
            }
        }

        protected void btnGuardarEdicion_Click(object sender, EventArgs e)
        {
            if (lblTitulo.Text.Equals("Al reservar un alojamiento (correo para huésped)"))
            {
                email.setReservaHuesped(txtContenido.Text);
            }
            else if (lblTitulo.Text.Equals("Al reservar un alojamiento (correo para anfitrión)"))
            {
                email.setReservaAnfitrion(txtContenido.Text);
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void btnEditarHuespedReserva_Click(object sender, EventArgs e)
        {
            divFormulario.Visible = true;
            divTarjetas.Visible = false;
            txtContenido.Text = lblHuespedReserva.Text;
            txtContenido.Text = txtContenido.Text.Replace("<strong style=\"color: #1fc441\">{", "{").
                                                  Replace("}</strong>", "}").
                                                  Replace("<br/>", "\n");
            lblTitulo.Text = lblHuespedReservaTitulo.Text;
            updPanel_Editar.Update();
            updPanel_Correos.Update();
        }

        protected void btnEditarAnfitrionReserva_Click(object sender, EventArgs e)
        {
            divFormulario.Visible = true;
            divTarjetas.Visible = false;
            txtContenido.Text = lblAnfitrionReserva.Text;
            txtContenido.Text = txtContenido.Text.Replace("<strong style=\"color: #1fc441\">{", "{").
                                                  Replace("}</strong>", "}").
                                                  Replace("<br/>", "\n");
            lblTitulo.Text = lblAnfitrionReservaTitulo.Text;
            updPanel_Editar.Update();
            updPanel_Correos.Update();
        }

        protected void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            divFormulario.Visible = false;
            divTarjetas.Visible = true;
            updPanel_Editar.Update();
            updPanel_Correos.Update();
        }
        private void getMensajes()
        {
            lblHuespedReserva.Text = email.getReservaHuesped();
            lblHuespedReserva.Text = lblHuespedReserva.Text.Replace("{HuespedNombre}", "<strong style=\"color: #1fc441\">{HuespedNombre}</strong>")
                                                           .Replace("{HuespedApellidos}", "<strong style=\"color: #1fc441\">{HuespedApellidos}</strong>")
                                                           .Replace("{HuespedCorreo}", "<strong style=\"color: #1fc441\">{HuespedCorreo}</strong>")
                                                           .Replace("{HuespedTelefono}", "<strong style=\"color: #1fc441\">{HuespedTelefono}</strong>")
                                                           .Replace("{AnfitrionNombre}", "<strong style=\"color: #1fc441\">{AnfitrionNombre}</strong>")
                                                           .Replace("{AnfitrionApellidos}", "<strong style=\"color: #1fc441\">{AnfitrionApellidos}</strong>")
                                                           .Replace("{AnfitrionTelefono}", "<strong style=\"color: #1fc441\">{AnfitrionTelefono}</strong>")
                                                           .Replace("{AnfitrionCorreo}", "<strong style=\"color: #1fc441\">{AnfitrionCorreo}</strong>")
                                                           .Replace("{NombreReservacion}", "<strong style=\"color: #1fc441\">{NombreReservacion}</strong>")
                                                           .Replace("{ReservaPrecioTotal}", "<strong style=\"color: #1fc441\">{ReservaPrecioTotal}</strong>")
                                                           .Replace("{ReservaInicio}", "<strong style=\"color: #1fc441\">{ReservaInicio}</strong>")
                                                           .Replace("{ReservaFin}", "<strong style=\"color: #1fc441\">{ReservaFin}</strong>")
                                                           .Replace("\n", "<br/>");
            lblAnfitrionReserva.Text = email.getReservaAnfitrion();
            lblAnfitrionReserva.Text = lblAnfitrionReserva.Text.Replace("{HuespedNombre}", "<strong style=\"color: #1fc441\">{HuespedNombre}</strong>")
                                                               .Replace("{HuespedApellidos}", "<strong style=\"color: #1fc441\">{HuespedApellidos}</strong>")
                                                               .Replace("{HuespedCorreo}", "<strong style=\"color: #1fc441\">{HuespedCorreo}</strong>")
                                                               .Replace("{HuespedTelefono}", "<strong style=\"color: #1fc441\">{HuespedTelefono}</strong>")
                                                               .Replace("{AnfitrionNombre}", "<strong style=\"color: #1fc441\">{AnfitrionNombre}</strong>")
                                                               .Replace("{AnfitrionApellidos}", "<strong style=\"color: #1fc441\">{AnfitrionApellidos}</strong>")
                                                               .Replace("{AnfitrionTelefono}", "<strong style=\"color: #1fc441\">{AnfitrionTelefono}</strong>")
                                                               .Replace("{AnfitrionCorreo}", "<strong style=\"color: #1fc441\">{AnfitrionCorreo}</strong>")
                                                               .Replace("{NombreReservacion}", "<strong style=\"color: #1fc441\">{NombreReservacion}</strong>")
                                                               .Replace("{ReservaPrecioTotal}", "<strong style=\"color: #1fc441\">{ReservaPrecioTotal}</strong>")
                                                               .Replace("{ReservaInicio}", "<strong style=\"color: #1fc441\">{ReservaInicio}</strong>")
                                                               .Replace("{ReservaFin}", "<strong style=\"color: #1fc441\">{ReservaFin}</strong>")
                                                               .Replace("\n", "<br/>");
        }
    }
}