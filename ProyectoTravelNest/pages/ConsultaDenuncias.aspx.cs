using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace ProyectoTravelNest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Neg_Denuncias gestorDenuncias = new Neg_Denuncias();
        Email gestorEmail = new Email();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Entidades.Usuarios eUsuarios = Session["idUsuario"] as Entidades.Usuarios;
                string rol = eUsuarios.T_Rol.ToString();

                if (rol == "G")
                {
                    ObtenerDenuncias();
                }

                if (rol == "A" || rol == "H")
                {
                    ObtenerDenunciasPorID();
                }
            }
        }

        public void ObtenerDenuncias()
        {
            try
            {
                gestorDenuncias.Instruccion = "Read";
                rptDenuncias.DataSource = gestorDenuncias.ObtenerDenunciasGestor();
                rptDenuncias.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('{ex.Message}');", true);
            }
        }

        public void ObtenerDenunciasPorID()
        {
            try
            {
                Entidades.Usuarios eUsuarios = Session["idUsuario"] as Entidades.Usuarios;
                gestorDenuncias.Instruccion = "ReadById";
                gestorDenuncias.IdDenunciante = eUsuarios.IdUsuario;
                rptDenuncias.DataSource = gestorDenuncias.ObtenerDenunciasPorId();
                rptDenuncias.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('{ex.Message}');", true);
            }
        }

        protected void btnGuardarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                string asunto = "Resolución de tu denuncia";
                gestorDenuncias.Instruccion = "Update";
                gestorDenuncias.IdDenuncia = txtIdDenuncia.Text;
                gestorDenuncias.Estado = ddlNuevoEstado.SelectedValue;

                gestorDenuncias.CRUDDenuncias();
                gestorEmail.EnviarEmailDenuncia(txtIdDenuncia.Text, asunto);
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionExito", $"mostrarNotificacionExito('Estado de la denuncia actualizada con éxito!');", true);
                ObtenerDenuncias();
                divformCambiarEstado.Visible = false;
                updPanel_ConsultaDenuncias.Update();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('{ex.Message}');", true);
            }
        }

        protected void rptDenuncias_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Entidades.Usuarios eUsuarios = Session["idUsuario"] as Entidades.Usuarios;
                    Button btnCambiarEstado = (Button)e.Item.FindControl("btnCambiarEstado");

                    if (btnCambiarEstado != null && eUsuarios.T_Rol.ToString() == "G")
                    {
                        btnCambiarEstado.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('{ex.Message}');", true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            divformCambiarEstado.Visible = false;
            txtIdDenuncia.Text = "";
            updPanel_ConsultaDenuncias.Update();
        }

        protected void BtnCambiarEstado_Click(object sender, EventArgs e)
        {
            Button btnIdDenuncia = (Button)sender;
            string id = btnIdDenuncia.CommandArgument;
            txtIdDenuncia.Text = id;
            divformCambiarEstado.Visible = true;
            updPanel_ConsultaDenuncias.Update();
        }
    }
}