using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios eUsuario = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuario != null)
            {
                Login.Visible = false;
                CerrarSesion.Visible = true;
                Registrarse.Visible = false;

                if (eUsuario.T_Rol.Equals('A'))
                {
                    PrivadaAnfitrion1.Visible = true;
                    PrivadaAnfitrion2.Visible = true;
                    PrivadaAnfitrion3.Visible = true;
                    PrivadaAnfitrion4.Visible = true;
                    PrivadaAnfitrion5.Visible = true;
                    PrivadaAnfitrion6.Visible = true;
                    PrivadaAnfitrion7.Visible = true;

                    PrivadaHuesped1.Visible = false;
                    PrivadaHuesped2.Visible = false;
                    PrivadaHuesped3.Visible = false;
                    PrivadaHuesped4.Visible = false;

                    PrivadaGestor1.Visible = false;

                    Registrarse.Visible = false;
                }

                if (eUsuario.T_Rol.Equals('H'))
                {
                    PrivadaAnfitrion1.Visible = false;
                    PrivadaAnfitrion2.Visible = false;
                    PrivadaAnfitrion3.Visible = false;
                    PrivadaAnfitrion4.Visible = false;
                    PrivadaAnfitrion5.Visible = false;
                    PrivadaAnfitrion6.Visible = false;
                    PrivadaAnfitrion7.Visible = false;

                    PrivadaHuesped1.Visible = true;
                    PrivadaHuesped2.Visible = true;
                    PrivadaHuesped3.Visible = true;
                    PrivadaHuesped4.Visible = true;

                    PrivadaGestor1.Visible = false;

                    Registrarse.Visible = false;
                }

                if (eUsuario.T_Rol.Equals('G'))
                {
                    PrivadaAnfitrion1.Visible = false;
                    PrivadaAnfitrion2.Visible = false;
                    PrivadaAnfitrion3.Visible = false;
                    PrivadaAnfitrion4.Visible = false;
                    PrivadaAnfitrion5.Visible = false;
                    PrivadaAnfitrion6.Visible = false;
                    PrivadaAnfitrion7.Visible = false;

                    PrivadaHuesped1.Visible = false;
                    PrivadaHuesped2.Visible = false;
                    PrivadaHuesped3.Visible = false;
                    PrivadaHuesped4.Visible = false;

                    PrivadaGestor1.Visible = true;

                    Registrarse.Visible = false;
                }
                if (Session["MensajesNoLeidos"] != null && (bool)Session["MensajesNoLeidos"])
                {
                    // Mostrar la notificación de mensajes no leídos
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", "mostrarNotificacion();", true);

                    // Restablecer el estado de mensajes no leídos
                    Session["MensajesNoLeidos"] = false;
                }
            }
        }

        protected void CerrarSesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            Session["IdUsuario"] = null;
            Login.Visible = true;
            CerrarSesion.Visible = false;
            Registrarse.Visible = true;


            PrivadaAnfitrion1.Visible = false;
            PrivadaAnfitrion2.Visible = false;
            PrivadaAnfitrion3.Visible = false;
            PrivadaAnfitrion4.Visible = false;
            PrivadaAnfitrion5.Visible = false;
            PrivadaAnfitrion6.Visible = false;
            PrivadaAnfitrion7.Visible = false;

            PrivadaHuesped1.Visible = false;
            PrivadaHuesped2.Visible = false;
            PrivadaHuesped3.Visible = false;
            PrivadaHuesped4.Visible = false;


            PrivadaGestor1.Visible = false;
        }
    }
}