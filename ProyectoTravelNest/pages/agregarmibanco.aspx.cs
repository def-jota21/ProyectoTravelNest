using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class AgregarMiBanco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardarMiBanco_Click(object sender, EventArgs e)
        {
            string numeroCuenta = txtNumeroCuenta.Text.Trim();
            string cvv = txtCVV.Text.Trim();

            // Validación: Verificar que los campos no estén vacíos
            if (string.IsNullOrEmpty(numeroCuenta) || string.IsNullOrEmpty(cvv))
            {
                lblMensaje.Text = "Ambos campos son obligatorios.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                return; // Sale del evento si hay campos vacíos
            }

            // Validación: Verificar la longitud de número de cuenta y CVV
            if (numeroCuenta.Length != 13)
            {
                lblMensaje.Text = "El número de cuenta debe tener 13 dígitos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                return; // Sale del evento si la longitud no es 13
            }

            if (cvv.Length != 3)
            {
                lblMensaje.Text = "El CVV debe tener 3 dígitos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                return; // Sale del evento si la longitud no es 3
            }

            // Si se pasa por todas las validaciones, procede a realizar la inserción
            Negocios.Neg_MiBanco neg_MiBanco = new Neg_MiBanco();
            string mensaje = neg_MiBanco.InsertarCuentaMiBanco("2222222222", numeroCuenta, cvv);

            // Mostrar mensaje de éxito o error
            
            
            if (mensaje == "Exito")
            {
                string script = "Swal.fire('¡Éxito!', 'Los datos se almacenaron correctamente.', 'success');";
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