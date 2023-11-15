using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
namespace ProyectoTravelNest.pages
{
    public partial class paneladministracionhuesped : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Negocios.Neg_Usuarios neg_Usuarios = new Neg_Usuarios();

            int cantidadNotificaciones = neg_Usuarios.ObtenerNotificaciones("2222222222");

            Session["CantidadNotificaciones"] = cantidadNotificaciones;

            Negocios.Neg_MiBanco neg_MiBanco = new Neg_MiBanco();
            bool UsuarioMiBanco = neg_MiBanco.VerificarMiBanco("2222222222");
            Session["MiBancoUsuario"] = UsuarioMiBanco;
        }

       

    }
}