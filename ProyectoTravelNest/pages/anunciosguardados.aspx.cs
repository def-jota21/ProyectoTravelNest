using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class anunciosguardados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack & eUsuarios != null)
            {
                Negocios.Negocio_Inmuebles iInmueble = new Negocios.Negocio_Inmuebles();

                //aca tambien se debe de obtener la variable session al inciciar sesion
                rptAlojamientos.DataSource = iInmueble.ListarInmueblesInactivosAnfitrion(eUsuarios.IdUsuario);
                rptAlojamientos.DataBind();
            }

        }

        protected void btnVerInformacion_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "VerInformacion")
            {
                string[] args = e.CommandArgument.ToString().Split(',');

                if (args.Length == 2)
                {
                    string IdUsuario = args[0].Trim();
                    string IdInmueble = args[1].Trim();

                    // Redirige a la página de destino con los parámetros
                    Response.Redirect($"verinformacion.aspx?IdUsuario={IdUsuario}&IdInmueble={IdInmueble}");
                }
            }
        }

        protected void btnModificar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                string[] args = e.CommandArgument.ToString().Split(',');

                if (args.Length == 2)
                {
                    string IdUsuario = args[0].Trim();
                    string IdInmueble = args[1].Trim();

                    // Redirige a la página de destino con los parámetros
                    Response.Redirect($"editaranuncio.aspx?IdUsuario={IdUsuario}&IdInmueble={IdInmueble}");
                }
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect($"crearalojamiento.aspx");
        }
    }
}