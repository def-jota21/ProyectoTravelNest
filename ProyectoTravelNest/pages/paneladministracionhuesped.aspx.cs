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
        protected void Page_Load(object sender, EventArgs e)
            Negocios.Neg_Usuarios neg_Usuarios = new Neg_Usuarios();

            int cantidadNotificaciones = neg_Usuarios.ObtenerNotificaciones("2222222222");

            Session["CantidadNotificaciones"] = cantidadNotificaciones;


            }
        }

       

    }
}