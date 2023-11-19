using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
namespace ProyectoTravelNest.pages
{
    public partial class Pantalla_Politicas : System.Web.UI.Page
    {
        Politicas gestorPoliticas = new Politicas();
        bool tienePermisoModificar = false;
        bool tienePermisoBorrar = false;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios eUsuarios = Session["idUsuario"] as Entidades.Usuarios;

            try
            {
                if (!IsPostBack)
                {
                    ObtenerDatosPoliticas();

                    if (eUsuarios.T_Rol.ToString() == "G")
                    {
                        btnInsert.Visible = true;
                    }
                    else
                    {
                        btnInsert.Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('{ex.Message}');", true);
            }
        }

        protected void rptTarjetas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Entidades.Usuarios eUsuarios = Session["idUsuario"] as Entidades.Usuarios;

                    // Verificar los permisos del usuario y establecer la visibilidad de los botones
                    Button btnEditar = (Button)e.Item.FindControl("btnEditar");
                    Button btnBorrar = (Button)e.Item.FindControl("btnBorrar");

                    if (eUsuarios.T_Rol.ToString() == "G")
                    {
                        tienePermisoModificar = true;
                        tienePermisoBorrar = true;
                    }



                    // Establecer la visibilidad de los botones
                    btnEditar.Visible = tienePermisoModificar;
                    btnBorrar.Visible = tienePermisoBorrar;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('{ex.Message}');", true);
            }
        }

        protected void rptTarjetas_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Editar")
                {
                    int idPolitica = Convert.ToInt32(e.CommandArgument);

                    // Obtener la información específica de la política por ID utilizando el objeto DataSet
                    gestorPoliticas.IdPolitica = idPolitica;
                    DataSet dsPoliticaEspecifica = gestorPoliticas.ObtenerPoliticaPorID();

                    // Verificar si el DataSet contiene datos antes de intentar acceder a ellos
                    if (dsPoliticaEspecifica != null && dsPoliticaEspecifica.Tables.Count > 0 && dsPoliticaEspecifica.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = dsPoliticaEspecifica.Tables[0].Rows[0];

                        // Lógica para editar la información en el índice específico, recuperar la info y enviarla al form
                        string titulo = row["Titulo"].ToString();
                        string contenido = row["Contenido"].ToString();
                        string textoAdicional = row["TextoAdicional"].ToString();

                        txtid.Text = idPolitica.ToString();
                        txtTitulo.Text = titulo;
                        txtContenido.Text = contenido;
                        txtTextoAdicional.Text = textoAdicional;

                        divTarjetas.Visible = false;
                        divFormulario.Visible = true;

                        btnGuardar.Visible = false;
                        btnEditarInfo.Visible = true;
                        updPanel_Editar.Update();
                    }
                    else
                    {
                        // Notificacion de error de que no se recupero ninguna politica con ese ID
                        throw new Exception("No se recupero ninguna politica con ese ID");
                    }
                }
                else if (e.CommandName == "Borrar")
                {
                    int idPolitica = Convert.ToInt32(e.CommandArgument);

                    gestorPoliticas.IdPolitica = idPolitica;
                    gestorPoliticas.Instruccion = "Delete";

                    gestorPoliticas.CRUDPoliticas();

                    ObtenerDatosPoliticas();

                    updPanel_Politicas.Update();
                    updPanel_Editar.Update();
                    ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionExito", $"mostrarNotificacionExito('Información eliminada con éxito');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('{ex.Message}');", true);
            }
        }

        private void ObtenerDatosPoliticas()
        {
            rptTarjetas.DataSource = gestorPoliticas.ObtenerPoliticasDesdeBD();
            rptTarjetas.DataBind();
        }

        protected void btnEditarInfo_Click(object sender, EventArgs e)
        {
            try
            {
                gestorPoliticas.IdPolitica = Convert.ToInt32(txtid.Text);
                gestorPoliticas.Titulo = txtTitulo.Text;
                gestorPoliticas.Contenido = txtContenido.Text;
                gestorPoliticas.TextoAdicional = txtTextoAdicional.Text;
                gestorPoliticas.Instruccion = "Update";

                gestorPoliticas.ValidarEdicion();
                gestorPoliticas.CRUDPoliticas();

                ObtenerDatosPoliticas();

                divTarjetas.Visible = true;
                divFormulario.Visible = false;
                btnGuardar.Visible = false;
                btnEditarInfo.Visible = false;

                LimpiarTextBoxs();

                updPanel_Politicas.Update();
                updPanel_Editar.Update();
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionExito", $"mostrarNotificacionExito('Información modificada con éxito!');", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('{ex.Message}');", true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                gestorPoliticas.Titulo = txtTitulo.Text;
                gestorPoliticas.Contenido = txtContenido.Text;
                gestorPoliticas.TextoAdicional = txtTextoAdicional.Text;
                gestorPoliticas.Instruccion = "Create";

                gestorPoliticas.CRUDPoliticas();

                ObtenerDatosPoliticas();

                divTarjetas.Visible = true;
                divFormulario.Visible = false;
                btnGuardar.Visible = false;
                btnEditarInfo.Visible = false;

                LimpiarTextBoxs();

                updPanel_Politicas.Update();
                updPanel_Editar.Update();
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionExito", $"mostrarNotificacionExito('Información insertada con éxito!');", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('{ex.Message}');", true);
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            divTarjetas.Visible = false;
            divFormulario.Visible = true;
            btnGuardar.Visible = true;
            btnEditarInfo.Visible = false;

            LimpiarTextBoxs();

            updPanel_Politicas.Update();
            updPanel_Editar.Update();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            divTarjetas.Visible = true;
            divFormulario.Visible = false;
            btnGuardar.Visible = false;
            btnEditarInfo.Visible = false;

            LimpiarTextBoxs();

            updPanel_Politicas.Update();
            updPanel_Editar.Update();
        }

        private void LimpiarTextBoxs()
        {
            txtid.Text = string.Empty;
            txtTitulo.Text = string.Empty;
            txtContenido.Text = string.Empty;
            txtTextoAdicional.Text = string.Empty;
        }
    }
}