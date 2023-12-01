using Negocios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class crearcuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;
           
            if (eUsuarios != null)
            {
                Response.Redirect("Default.aspx");

            }
        }

        protected void btnCrearCuenta_Click(object sender, EventArgs e)
        {

            try
            {
                char tRol = 'a';
                String Nombre = txtNombre.Text;
                String Rol = ddlRol.SelectedValue.ToString();
                String Apellidos = txtApellidos.Text;
                String Telefono = txtTelefono.Text;
                String CorreoElectronico = txtCorreoElectronico.Text;
                String Identificacion = txtIdentificacion.Text;
                String Contrasena = txtcontrasenaCrear.Text;

                Entidades.Usuarios iUsuario = new Entidades.Usuarios();

                iUsuario.Nombre = Nombre;
                if (Rol.Equals("Anfitrión"))
                {
                    tRol = 'A';
                }
                if (Rol.Equals("Huésped"))
                {
                    tRol = 'H';
                }

                iUsuario.T_Rol = tRol;
                iUsuario.Apellidos = Apellidos;
                iUsuario.Telefono = int.Parse(Telefono);
                iUsuario.Correo = CorreoElectronico;
                iUsuario.IdUsuarioRegistro = Identificacion;
                iUsuario.Contrasena = Contrasena;
                //iUsuario.ImagenPerfil = ImagenOriginal;

                Negocios.Neg_Usuarios iUsuariosNeg = new Neg_Usuarios();

                iUsuariosNeg.AgregarUsuario(iUsuario, 1);

                string script = "Swal.fire('¡GRACIAS!', 'Su cuenta se creo de manera satisfactoria.', 'success');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);

                string redirectScript = "setTimeout(function(){window.location.href = 'login.aspx';}, 3000);";
                ScriptManager.RegisterStartupScript(this, GetType(), "Redirigir", redirectScript, true);
            }
            catch (Exception ex)
            {

                string mensajeError = ex.Message.Replace("'", "\\'");
                string script = $"Swal.fire('¡Error!', '{mensajeError}', 'error');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
            }
            
        }

       
    }
}