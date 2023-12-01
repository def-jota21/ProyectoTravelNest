using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class sesionyseguridad : System.Web.UI.Page
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

                Negocios.Neg_Usuarios negocio = new Negocios.Neg_Usuarios();
                DataTable dt = negocio.ObtenerContraseñaUsuario(eUsuarios.IdUsuario);

                if (dt.Rows.Count > 0)
                {
                    // Guardamos la contraseña en Session para usarla después
                    Session["Contrasena"] = dt.Rows[0]["Contrasena"].ToString();
                }
            }
        }

        protected void btnGuardarContrasena_Click(object sender, EventArgs e)
        {
            string contrasena = Session["Contrasena"] as string;

            String script = "document.getElementById('modalTxtContraseñaActual').value = '" + contrasena + "';";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "asignarValor", script, true);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "$('#modalContrasena').modal('show');", true);
        }
    }
} 