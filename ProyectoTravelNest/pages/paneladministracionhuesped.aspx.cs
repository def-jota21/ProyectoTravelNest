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
    public partial class paneladministracionhuesped : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { 
            Negocios.Neg_Usuarios neg_Usuarios = new Neg_Usuarios();
            Session["IdUsuario"] = "1-1111-1111  ";

            int cantidadNotificaciones = neg_Usuarios.ObtenerNotificaciones(Session["IdUsuario"].ToString());

            Session["CantidadNotificaciones"] = cantidadNotificaciones;

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
            Session["IdUsuario"] = Session["IdUsuario"].ToString();
            Response.Redirect("/pages/elegirinmueble.aspx");
        }
    }
}