using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class gestionpoliticas : System.Web.UI.Page
    {
        private static string IdInmueble = "";
        private static string IdReservacion = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack & eUsuarios != null)
            {
                if (Request.QueryString["IdInmueble"] != null)
                {
                    // Lee los valores de los parámetros
                    IdInmueble = Request.QueryString["IdInmueble"];
                    Negocios.Negocio_Inmuebles iNeg = new Negocio_Inmuebles();
                    hfIDinmueble.Value = IdInmueble;
                    rptPoliticas.DataSource = iNeg.ListarPoliticaAsociada(IdInmueble);
                    rptPoliticas.DataBind();

                }

                Negocios.Negocio_Inmuebles iNeUser = new Negocios.Negocio_Inmuebles();

                DataTable datosUsuario = iNeUser.ListarPoliticaNoAsociada(IdInmueble);

                ddlPolitica.DataSource = datosUsuario;
                ddlPolitica.DataTextField = "Nombre";
                ddlPolitica.DataValueField = "Nombre";
                ddlPolitica.DataBind();
            }

            
            
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            Negocios.Negocio_Inmuebles iNeg = new Negocio_Inmuebles();
            string Comentario = "";

            Comentario = txtComentario.Text;
            int PoliticaxInmueble = int.Parse(hiddenField1.Value);

            iNeg.EditarPoliticaAsociada(PoliticaxInmueble,Comentario);

            txtComentario.Text = string.Empty;
            txtNombre.Text = string.Empty;

            
            hfIDinmueble.Value = IdInmueble;
            rptPoliticas.DataSource = iNeg.ListarPoliticaAsociada(IdInmueble);
            rptPoliticas.DataBind();

            txtComentario.Text = string.Empty;
            txtNombre.Text= string.Empty;

            string script = "Swal.fire('¡Éxito!', 'Los cambios se almacenaron correctamente.', 'success');";
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
            // Response.Redirect("gestionpoliticas.aspx?idInmueble=" + IdInmueble);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {


            int PoliticaxInmueble = int.Parse(hiddenField1.Value);


            Negocios.Negocio_Inmuebles iNeg = new Negocio_Inmuebles();

            iNeg.EliminarPolitica(PoliticaxInmueble);

        
            hfIDinmueble.Value = IdInmueble;
            rptPoliticas.DataSource = iNeg.ListarPoliticaAsociada(IdInmueble);
            rptPoliticas.DataBind();
            // Response.Redirect("gestionpoliticas.aspx?idInmueble=" + IdInmueble);
            Negocios.Negocio_Inmuebles iNeUser = new Negocios.Negocio_Inmuebles();

            DataTable datosUsuario = iNeUser.ListarPoliticaNoAsociada(IdInmueble);

            ddlPolitica.DataSource = datosUsuario;
            ddlPolitica.DataTextField = "Nombre";
            ddlPolitica.DataValueField = "Nombre";
            ddlPolitica.DataBind();

            string script = "Swal.fire('¡Éxito!', 'La política se eliminó correctamente.', 'success');";
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
        }

        
        protected void btnAgregar_Click(object sender, EventArgs e)
        {


            string idPolitica = ddlPolitica.SelectedValue;
            string Comentario = TextBox2.Text;

            Negocios.Negocio_Inmuebles iNeg = new Negocio_Inmuebles();

            iNeg.AgregarPolitica(idPolitica, Comentario, IdInmueble);

            
            hfIDinmueble.Value = IdInmueble;
            rptPoliticas.DataSource = iNeg.ListarPoliticaAsociada(IdInmueble);
            rptPoliticas.DataBind();
            Negocios.Negocio_Inmuebles iNeUser = new Negocios.Negocio_Inmuebles();

            DataTable datosUsuario = iNeUser.ListarPoliticaNoAsociada(IdInmueble);

            ddlPolitica.DataSource = datosUsuario;
            ddlPolitica.DataTextField = "Nombre";
            ddlPolitica.DataValueField = "Nombre";
            ddlPolitica.DataBind();

            TextBox2.Text = string.Empty;

            string script = "Swal.fire('¡Éxito!', 'La ´política se almacenó correctamente.', 'success');";
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
            // Response.Redirect("gestionpoliticas.aspx?idInmueble=" + IdInmueble);

        }
    }
}