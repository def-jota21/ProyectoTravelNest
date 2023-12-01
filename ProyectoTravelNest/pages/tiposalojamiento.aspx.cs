using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class tiposalojamiento : System.Web.UI.Page
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
                Negocios.Negocio_Inmuebles neg = new Negocios.Negocio_Inmuebles();

                rptCategorias.DataSource = neg.ObtenerCategorias();
                rptCategorias.DataBind();
            }

        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                String Categoria = TextBox2.Text;

                Negocios.Negocio_Inmuebles neg = new Negocios.Negocio_Inmuebles();

                neg.agregarCategorias(Categoria);

                rptCategorias.DataSource = neg.ObtenerCategorias();
                rptCategorias.DataBind();

                TextBox2.Text = string.Empty;

                string script = "Swal.fire('¡Éxito!', 'Se agregó la nueva categoría.', 'success');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
            }
            catch (Exception)
            {

                string script = "Swal.fire('¡Error!', 'La categoria que intenta agregar ya existe.', 'error');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
            }

            

        }

    }

}