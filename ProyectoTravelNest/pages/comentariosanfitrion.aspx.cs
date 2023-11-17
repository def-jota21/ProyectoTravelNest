using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class comentariosanfitrion : System.Web.UI.Page
    {
        private static string IdAnfitrion = "";
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
                if (Request.QueryString["idAnfitrion"] != null && Request.QueryString["IdReservacion"] != null)
                {
                    // Lee los valores de los parámetros
                    IdAnfitrion = Request.QueryString["idAnfitrion"];
                    IdReservacion = Request.QueryString["IdReservacion"];

                }
            }

           
        }

        protected void EnviarComentarioAnfitrion_Click(object sender, EventArgs e)
        {
            string Comentario = "";
            int CalificacionInmueble = 0;
            int calificacion = 0;
            string ComentarioInmueble = "";

            ComentarioInmueble = txtComentarioInmueble.Text;
            Comentario = txtcomentarioPublico.Text;
            CalificacionInmueble = int.Parse(ddlComunicacion.SelectedValue.ToString());
            calificacion = int.Parse(ddlCalificacionAnfitrion.SelectedValue.ToString());
            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;
            //aca se debe de ontener el id huesped desde la variable session PENDIENTE
            Negocios.Negocio_Comentarios iNgcom = new Negocio_Comentarios();

            iNgcom.realizarComentarioaAnfitrion (IdAnfitrion, eUsuarios.IdUsuario, Comentario, ComentarioInmueble,CalificacionInmueble, calificacion, int.Parse(IdReservacion));

            string script = "Swal.fire('¡GRACIAS!', 'Su comentario se envió correctamente.', 'success');";
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);

            string redirectScript = "setTimeout(function(){window.location.href = 'comentariospendientesh.aspx';}, 5000);";
            ScriptManager.RegisterStartupScript(this, GetType(), "Redirigir", redirectScript, true);


        }
    }
}