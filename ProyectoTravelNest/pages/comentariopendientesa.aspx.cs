using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class comentariopendientesa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Negocios.Negocio_Comentarios iNegComentario = new Negocios.Negocio_Comentarios();

                //aca debe de optener el valor de la variable session de inicio de sesion para poder hacer la consulta PENDIENTE
                rptComentariosPendientes.DataSource = iNegComentario.ListarComentarioPendientesAnfitrion("2222222222");
                rptComentariosPendientes.DataBind();
            }
        }


        protected void btnRealizarComentario_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "RealizarComentario")
            {
                string[] args = e.CommandArgument.ToString().Split(',');

                if (args.Length == 2)
                {
                    string IdHuesped = args[0].Trim();
                    string IdReservacion = args[1].Trim();

                    // Redirige a la página de destino con los parámetros
                    Response.Redirect($"comentariohuesped.aspx?IdHuesped={IdHuesped}&IdReservacion={IdReservacion}");
                }
            }
        }
    }
}