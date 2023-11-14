using Negocios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class crearcuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            char tRol = 'a';
            String Nombre = txtNombre.Text;
            String Rol = ddlRol.SelectedValue.ToString();
            String Apellidos = txtApellidos.Text;
            String Telefono = txtTelefono.Text;
            String CorreoElectronico = txtCorreoElectronico.Text;
            String Identificacion = txtIdentificacion.Text;
            String Contrasena = txtcontrasenaCrear.Text;
            //int Tamanio = fileImagen.PostedFile.ContentLength;
            byte[] ImagenOriginal;
            ImagenOriginal = new byte[0];

            if (fileImagen.HasFile)
            {
                Stream fs = fileImagen.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                ImagenOriginal = br.ReadBytes((Int32)fs.Length);
            }

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
            iUsuario.ImagenPerfil = ImagenOriginal;

            Negocios.Neg_Usuarios iUsuariosNeg = new Neg_Usuarios();

            iUsuariosNeg.AgregarUsuario(iUsuario, 1);
        }

        
    }
}