using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;


namespace ProyectoTravelNest.pages
{

    public partial class DatosPersonales : System.Web.UI.Page
    {
        Negocios.Neg_Usuarios UsuariosBD = new Negocios.Neg_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica si hay un usuario en la sesión
            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                // Si no hay un usuario en la sesión, redirige a la página de inicio de sesión
                FormsAuthentication.RedirectToLoginPage();
            }

            // Verifica si la página se carga por primera vez y si hay un usuario en la sesión
            if (!IsPostBack && eUsuarios != null)
            {
                // Obtén los datos del usuario desde el método en la clase UsuariosBD
                DataTable dtUsuario = UsuariosBD.ObtenerDatosUsuario(eUsuarios.IdUsuario);

                // Verifica si se obtuvieron datos
                if (dtUsuario.Rows.Count > 0)
                {
                    // Llena los campos de la página con los datos del usuario
                    txtid.Text = dtUsuario.Rows[0]["IdUsuario"].ToString();
                    txtnombres.Text = dtUsuario.Rows[0]["Nombre"].ToString();
                    txtapellidos.Text = dtUsuario.Rows[0]["Apellidos"].ToString();
                    txtcorreo.Text = dtUsuario.Rows[0]["Correo"].ToString();
                    txtTelefono.Text = dtUsuario.Rows[0]["Telefono"].ToString();


                   
                }


            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener valores de los campos del formulario
                string idUsuario = txtid.Text;
                string nombre = txtnombres.Text;
                string apellidos = txtapellidos.Text;
                string correo = txtcorreo.Text;
                int telefono = int.Parse(txtTelefono.Text);

                // Crear objeto de usuario con los nuevos datos
                Usuarios usuario = new Usuarios();
                usuario.IdUsuario = idUsuario;
                usuario.Nombre = nombre;
                usuario.Apellidos = apellidos;
                usuario.Correo = correo;
                usuario.Telefono = telefono;

                // Llamar capa de negocio para actualizar
                Neg_Usuarios negocio = new Neg_Usuarios();
                negocio.ActualizarUsuario(usuario);

                string successScript = "Swal.fire('¡Éxito!', 'Modificación de datos personales', 'success');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", successScript, true);
            }
            catch (Exception ex)
            {
                // Manejar la excepción, ya sea mostrando un mensaje de error o registrándolo en algún lugar.
                string errorScript = $"Swal.fire('¡Error!', '{ex.Message}', 'error');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarError", errorScript, true);
            }
        }
    }
}
