using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
namespace ProyectoTravelNest.pages
{
    public partial class eliminarCuentaMiBanco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEliminarMiBanco_Click(object sender, EventArgs e)
        {
            string numeroCuenta = txtNumeroCuenta.Text.Trim();

            if (numeroCuenta.Length != 13)
            {
                lblMensaje.Text = "El número de cuenta debe tener 13 dígitos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                return; // Sale del evento si la longitud no es 13
            }
            Negocios.Neg_MiBanco neg_MiBanco = new Neg_MiBanco();

            string mensaje = neg_MiBanco.EliminarCuentaMiBanco("2222222222");

            if (mensaje == "Exito")
            {
                string script = "Swal.fire('¡Éxito!', 'Se elimino correctamente.', 'success');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
                Response.Redirect("paneladministracionhuesped.aspx");
            }
            else
            {
                lblMensaje.Text = mensaje;
                lblMensaje.ForeColor = mensaje.Contains("éxito") ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                lblMensaje.Visible = true;
            }

        }
    }
}