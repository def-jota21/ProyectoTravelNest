using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class elegirinmueble : System.Web.UI.Page
    {
        Negocios.Negocio_Inmuebles nInmueble = new Negocios.Negocio_Inmuebles();
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack & eUsuarios != null)
            {
                if (Session["pagina"].Equals("reglas"))
                {
                    h1_titulo.InnerText = "Agregar, modificar o eliminar una regla";
                }
                else if (Session["pagina"].Equals("promociones"))
                {
                    h1_titulo.InnerText = "Agregar, modificar o eliminar una promoción";
                }
                else if (Session["pagina"].Equals("descuentos"))
                {
                    h1_titulo.InnerText = "Agregar, modificar o eliminar un descuento";
                }
                else if (Session["pagina"].Equals("modificarcalendarioreserva"))
                {
                    h1_titulo.InnerText = "Seleccione el alojamiento que desee cambiar fecha disponible";
                }
                else
                {
                    h1_titulo.InnerText = " - Error -";
                    return;
                }
                ContentPlaceHolder mainContent = (ContentPlaceHolder)this.Master.FindControl("MainContent");
                Control div_row = mainContent.FindControl("row");

                rptAlojamientos.DataSource = nInmueble.ListaInmueblesPagina(1, eUsuarios.IdUsuario, null);
                rptAlojamientos.DataBind();
            }
        }
    }
}