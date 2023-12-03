using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
namespace ProyectoTravelNest
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios eUsuario = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuario != null)
            {
                Neg_Usuarios neg_Usuarios = new Neg_Usuarios();
                DataTable dataTable = new DataTable();
                dataTable = neg_Usuarios.ListarUsuarioSeleccionado(4,eUsuario.IdUsuario);

                string rol = "";

                if(dataTable.Rows[0][5].ToString() == "A")
                {
                    rol = "Anfitrión";
                }else if (dataTable.Rows[0][5].ToString() == "H")
                {
                    rol = "Huesped";
                }
                else if (dataTable.Rows[0][5].ToString() == "G")
                {
                    rol = "Gestor";
                }

                lblNombreUsuario.Text = dataTable.Rows[0][1].ToString() + " " + dataTable.Rows[0][2].ToString() + " - " + rol;
                lblNombreUsuarioMobile.Text = dataTable.Rows[0][1].ToString() + " " + dataTable.Rows[0][2].ToString() + " - " + rol;
                lblNombreUsuario.Visible = true;
                lblNombreUsuarioMobile.Visible = true;
                Login.Visible = false;
                CerrarSesion.Visible = true;
                Registrarse.Visible = false;

                if (eUsuario.T_Rol.Equals('A'))
                {
                    PrivadaAnfitrion1.Visible = true;
                    

                    PrivadaHuesped1.Visible = false;
                    PrivadaHuesped2.Visible = false;
                    

                    PrivadaGestor1.Visible = false;
                    PrivadaGestor2.Visible = false;
                    PrivadaGestor3.Visible = false;

                    Registrarse.Visible = false;
                }

                if (eUsuario.T_Rol.Equals('H'))
                {
                    PrivadaAnfitrion1.Visible = false;
                   

                    PrivadaHuesped1.Visible = true;
                    PrivadaHuesped2.Visible = true;
                    

                    PrivadaGestor1.Visible = false;
                    PrivadaGestor2.Visible = false;
                    PrivadaGestor3.Visible = false;

                    Registrarse.Visible = false;
                }

                if (eUsuario.T_Rol.Equals('G'))
                {
                    PrivadaAnfitrion1.Visible = false;
                   

                    PrivadaHuesped1.Visible = false;
                    PrivadaHuesped2.Visible = false;
                    

                    PrivadaGestor1.Visible = true;
                    PrivadaGestor2.Visible = true;
                    PrivadaGestor3.Visible = true;

                    Registrarse.Visible = false;
                }
                if (Session["MensajesNoLeidos"] != null && (bool)Session["MensajesNoLeidos"])
                {
                    // Mostrar la notificación de mensajes no leídos
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showNotification", "mostrarNotificacion();", true);

                    // Restablecer el estado de mensajes no leídos
                    Session["MensajesNoLeidos"] = false;
                }
            }
        }

        protected void CerrarSesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            Session["IdUsuario"] = null;
            Login.Visible = true;
            CerrarSesion.Visible = false;
            Registrarse.Visible = true;
            lblNombreUsuario.Visible = false;

            PrivadaAnfitrion1.Visible = false;
           

            PrivadaHuesped1.Visible = false;
            PrivadaHuesped2.Visible = false;
           


            PrivadaGestor1.Visible = false;
            PrivadaGestor2.Visible = false;
            PrivadaGestor3.Visible = false;
        }
    }
}