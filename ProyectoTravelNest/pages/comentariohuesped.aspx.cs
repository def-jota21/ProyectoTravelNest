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
    public partial class comentariohuesped : System.Web.UI.Page
    {
        private static string IdHuesped = "";
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
                if (Request.QueryString["IdHuesped"] != null && Request.QueryString["IdReservacion"] != null)
                {
                    // Lee los valores de los parámetros
                    IdHuesped = Request.QueryString["IdHuesped"];
                    IdReservacion = Request.QueryString["IdReservacion"];

                }
            }
           
        }
        protected void EnviarComentarioHuesped_Click(object sender, EventArgs e)
        {
            string Comentario = "";
            int limpieza = 0;
            int calificacion = 0;

            Comentario = txtcomentarioPublico.Text;
            limpieza = int.Parse(ddlLimpieza.SelectedValue.ToString());
            calificacion = int.Parse(ddlCalificacion.SelectedValue.ToString());

            //aca se debe de ontener el id anfitrion desde la variable session PENDIENTE
            Negocios.Negocio_Comentarios iNgcom = new Negocio_Comentarios();

            iNgcom.realizarComentarioaHuesped("2222222222", IdHuesped, Comentario, limpieza, calificacion, int.Parse(IdReservacion));

            string script = "Swal.fire('¡GRACIAS!', 'Su comentario se envió correctamente.', 'success');";
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);


            string redirectScript = "setTimeout(function(){window.location.href = 'comentariopendientesa.aspx';}, 5000);";
            ScriptManager.RegisterStartupScript(this, GetType(), "Redirigir", redirectScript, true);

            
        }
    }
}