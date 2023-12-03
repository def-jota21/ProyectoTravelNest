using Entidades;
using Negocios;
using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class sesionyseguridad : System.Web.UI.Page
    {
        Negocios.Neg_Usuarios negocio = new Negocios.Neg_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack & eUsuarios != null)
            {
                
                DataTable dt = negocio.ObtenerContraseñaUsuario(eUsuarios.IdUsuario);

                if (dt.Rows.Count > 0)
                {
                    txtcontraseña.Text = dt.Rows[0]["Contrasena"].ToString();
                    
                }
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener el valor del TextBox de contraseña
            string nuevaContrasena = txtcontraseña.Text;

            // Asegúrate de obtener el IdUsuario del usuario actual
            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;
            if (eUsuarios == null)
            {
                // Manejar la situación donde no hay un usuario en sesión
                return;
            }

            // Verificar si la nueva contraseña es diferente de la contraseña actual
            if (eUsuarios.Contrasena == nuevaContrasena)
            {
                // Mostrar una notificación de que no se realizó ningún cambio
                string noChangeScript = "Swal.fire('Atención', 'La nueva contraseña es igual a la contraseña actual. No se realizó ningún cambio.', 'warning');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlertaNoCambio", noChangeScript, true);
                return;
            }

            // Crear objeto de usuario con los nuevos datos
            Usuarios usuario = new Usuarios();
            usuario.IdUsuario = eUsuarios.IdUsuario; // Asegúrate de que esto está asignado
            usuario.Contrasena = nuevaContrasena;

            // Llamar capa de negocio para actualizar
            Neg_Usuarios negocio = new Neg_Usuarios();
            negocio.ActualizarContrasenaUsuario(usuario);

            // Mostrar una notificación de éxito
            string successScript = "Swal.fire('¡Éxito!', 'Modificación de la contraseña exitosa', 'success');";
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", successScript, true);
        }


        protected void btnConfirmarDesactivacion_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el IdUsuario de la sesión
                Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;
                string idUsuario = eUsuarios.IdUsuario;

                // Llamar al método para desactivar la cuenta
                Neg_Usuarios negocio = new Neg_Usuarios();
                negocio.DesactivarCuenta(idUsuario);
                HttpContext.Current.Session.Abandon();

                // Redirigir a una página de confirmación o realizar otras acciones necesarias
                Response.Redirect("../pages/login.aspx");
            }
            catch (Exception ex)
            {
               
            }
        }

    }
}


