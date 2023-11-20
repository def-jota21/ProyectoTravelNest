using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class panelanfitrion : System.Web.UI.Page
    {
        Entidades.Usuarios eUsuarios = new Entidades.Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack & eUsuarios != null)
            {
                Negocios.Neg_Usuarios neg_Usuarios = new Neg_Usuarios();

                int cantidadNotificaciones = neg_Usuarios.ObtenerNotificaciones(Session["IdUsuario"].ToString());

                Session["CantidadNotificaciones"] = cantidadNotificaciones;

                Negocios.Neg_MiBanco neg_MiBanco = new Neg_MiBanco();
                bool usuarioMiBanco = neg_MiBanco.VerificarMiBanco(Session["IdUsuario"].ToString());

                Session["MiBancoUsuario"] = usuarioMiBanco;
            }
        }
        protected void lbtnReglas_Click(object sender, EventArgs e)
        {
            Session["pagina"] = "reglas";
            Session["IdUsuario"] = Session["IdUsuario"].ToString();
            Response.Redirect("/pages/elegirinmueble.aspx");
        }

        protected void lbtnPromociones_Click(object sender, EventArgs e)
        {
            Session["pagina"] = "promociones";
            Session["IdUsuario"] = Session["IdUsuario"].ToString();
            Response.Redirect("/pages/elegirinmueble.aspx");
        }

        protected void lbtnCalendario_Click(object sender, EventArgs e)
        {
            Session["pagina"] = "modificarcalendarioreserva";
            Session["IdUsuario"] = Session["IdUsuario"].ToString();
            Response.Redirect("/pages/elegirinmueble.aspx");
        }

        protected void lbtnDescuentos_Click(object sender, EventArgs e)
        {
            Session["pagina"] = "descuentos";
            //Session["IdUsuario"] = Session["IdUsuario"].ToString();
            Response.Redirect("/pages/elegirinmueble.aspx");
        }

        protected void lbtnVId_Click(object sender, EventArgs e)
        {
            Session["IdUsuario"] = Session["IdUsuario"].ToString();
            Response.Redirect("/pages/verificaridentidad.aspx");
        }
    }
}