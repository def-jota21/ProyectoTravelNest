using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;
namespace ProyectoTravelNest.pages
{
    public partial class RecepcionMensajes : System.Web.UI.Page
    {
        Mensajeria FunctionsMensajeria = new Mensajeria();
        Email FunctionsEmail = new Email();

        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack & eUsuarios != null)
            {
                try
                {
                        string instruccion = "";
                        string rol = eUsuarios.T_Rol.ToString();
                        string idUsuario = eUsuarios.IdUsuario.ToString();

                        if (rol == "H")
                        {
                            instruccion = "H";
                        }

                        if (rol == "A")
                        {
                            instruccion = "A";
                        }

                        rptAnfitriones.DataSource = FunctionsMensajeria.GetDataReservasActivas(idUsuario, instruccion);
                        rptAnfitriones.DataBind();

                    
                }
                catch (Exception ex)
                {
                    //Editar para mostrarle el mensaje de error al usuario
                    ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('{ex.Message}');", true);
                }
            }


        }

        private void GetMessagesFromBD(string idRecuperado, string idUsuario)
        {
            try
            {
                rpt_Mensajes.DataSource = FunctionsMensajeria.GetMessagesFromBD(idRecuperado, idUsuario);
                rpt_Mensajes.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "scrollScript", "scrollToChatBottom();", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('{ex.Message}');", true);
            }
        }


        public void EnviarMensaje(string mensaje)
        {
            try
            {
                Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

                string idEmisor = eUsuarios.IdUsuario.ToString();
                string idReceptor = Session["idReceptor"].ToString();

                string asunto = "Nuevo mensaje recibido en tu bandeja de entrada";

                FunctionsMensajeria.InsertMessage(idEmisor, idReceptor, mensaje);
                GetMessagesFromBD(idEmisor, idReceptor);
                UpdPanel_Page.Update();

                FunctionsEmail.EnviarEmail(idReceptor, asunto);//envia mensaje 

                ScriptManager.RegisterStartupScript(this, this.GetType(), "scrollScript", "scrollToChatBottom();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionExito", $"mostrarNotificacionExito('Mensaje enviado con éxito');", true);

                // Modificar la sesión para indicar que hay mensajes no leídos es para notificacion
                //Session["MensajesNoLeidos"] = true;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('{ex.Message}');", true);
            }
        }

        protected void btnAnfitrion_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

                // Obtener el IdAnfitrion del botón seleccionado
                Button button = (Button)sender;
                string idReceptor = button.CommandArgument;
                string idEmisor = eUsuarios.IdUsuario.ToString();

                Session["idReceptor"] = idReceptor;
                ScriptManager.RegisterStartupScript(this, GetType(), "check", $"console.log('Session[\"idReceptor\"] creada');", true);

                GetMessagesFromBD(idReceptor, idEmisor);
                UpdPanel_Page.Update();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('{ex.Message}');", true);
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = Request.Form["message_input"];
                EnviarMensaje(mensaje);
                UpdPanel_Page.Update();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "scrollScript", "scrollToChatBottom();", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('{ex.Message}');", true);
            }
        }
    }
}