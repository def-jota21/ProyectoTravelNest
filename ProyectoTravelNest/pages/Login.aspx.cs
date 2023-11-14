using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string contrasena = txtcontrasena.Text;

            // Instancia de la clase de negocios para verificar las credenciales
            var negocioUsuarios = new Neg_Usuarios();
            var usuario = negocioUsuarios.VerificarCredenciales(correo, contrasena);

            if (usuario != null)
            {
                // Si el rol es A o H, inicia sesión
                if (usuario.T_Rol == 'A' || usuario.T_Rol == 'H')
                {
                    Session["IdUsuario"] = usuario;
                    Response.Redirect("../Default.aspx"); // Redirige a la página de inicio
                }
                else
                {
                    // Manejar roles no autorizados o mostrar mensaje
                }

            }
        }
    }
}