using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class politicasgestor : System.Web.UI.Page
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

                rptCategorias.DataSource = neg.ObtenerPoliticas();
                rptCategorias.DataBind();
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                String Categoria = txtPolitica.Text;

                Negocios.Negocio_Inmuebles neg = new Negocios.Negocio_Inmuebles();

                neg.agregarPoliticas(Categoria);

                rptCategorias.DataSource = neg.ObtenerPoliticas();
                rptCategorias.DataBind();

                txtPolitica.Text = string.Empty;

                string script = "Swal.fire('¡Éxito!', 'Se agregó la nueva política.', 'success');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
            }
            catch (Exception)
            {

                string script = "Swal.fire('¡Error!', 'La política que intenta agregar ya existe.', 'error');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
            }



        }
    }
}