using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class gestionusuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Negocios.Neg_Usuarios iNeUser = new Negocios.Neg_Usuarios();

            rptDatosUsuarios.DataSource = iNeUser.ListarUsuarios(3);
            rptDatosUsuarios.DataBind();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

            string Nombre = txtNombre.Text;
            string Apellidos = txtApellidos.Text;
            string Telefono = txtTelefono.Text;
            string CorreoElectronico = txtCorreoElectronico.Text;
            string Identificacion = txtIdentificacion.Text;
            string Estado = ddlEstado.SelectedValue.ToString();
            Entidades.Usuarios iUsuario = new Entidades.Usuarios();

            iUsuario.Nombre = Nombre;
            iUsuario.Apellidos = Apellidos;
            iUsuario.Telefono = int.Parse(Telefono);
            iUsuario.Correo = CorreoElectronico;
            iUsuario.IdUsuarioRegistro = Identificacion;
            iUsuario.Estado = Estado;

            Negocios.Neg_Usuarios iUsuariosNeg = new Neg_Usuarios();

            iUsuariosNeg.EditarUsuario(iUsuario, 2);

            Negocios.Neg_Usuarios iNeUser = new Negocios.Neg_Usuarios();

            rptDatosUsuarios.DataSource = iNeUser.ListarUsuarios(3);
            rptDatosUsuarios.DataBind();
        }

    }
}