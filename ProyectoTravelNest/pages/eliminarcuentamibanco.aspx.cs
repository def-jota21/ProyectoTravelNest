using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;
namespace ProyectoTravelNest.pages
{
    public partial class eliminarCuentaMiBanco : System.Web.UI.Page
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
               
            }
        }

        protected void btnEliminarMiBanco_Click(object sender, EventArgs e)
        {
            string numeroCuenta = txtNumeroCuenta.Text.Trim();

            if (numeroCuenta.Length != 16)
            {
                lblMensaje.Text = "El número de cuenta debe tener 16 dígitos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                return; // Sale del evento si la longitud no es 13
            }
            Negocios.Neg_MiBanco neg_MiBanco = new Neg_MiBanco();

            string mensaje = neg_MiBanco.EliminarCuentaMiBanco(eUsuarios.IdUsuario, numeroCuenta);

            if (mensaje == "Exito")
            {
                string mensaje2 = neg_MiBanco.EliminarCuentaMiBanco2(eUsuarios.IdUsuario, numeroCuenta);


                if (mensaje2 == "Exito")
                {
                    string script = "Swal.fire('¡Éxito!', 'Se elimino correctamente.', 'success');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
                    Response.Redirect("paneladministracionhuesped.aspx");
                }
                else
                {
                    lblMensaje.Text = "Error al eliminar la cuenta.";
                    lblMensaje.ForeColor = mensaje2.Contains("éxito") ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                    lblMensaje.Visible = true;
                }


                    
            }
            else
            {
                lblMensaje.Text = "La cuenta no es la enlazada.";
                lblMensaje.ForeColor = mensaje.Contains("éxito") ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                lblMensaje.Visible = true;
            }

        }
    }
}