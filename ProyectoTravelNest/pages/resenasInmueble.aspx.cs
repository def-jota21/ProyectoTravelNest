using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class resenasInmueble : System.Web.UI.Page
    {
        static string IdUsuario = "";
        static string idInmueble = "";
        Negocios.Negocio_Inmuebles iInmueble = new Negocio_Inmuebles();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IdUsuario = Request.QueryString["IdUsuario"];
                idInmueble = Request.QueryString["IdInmueble"];

                rptDatosInmueble.DataSource = iInmueble.ListarInformacionInmueble(idInmueble, IdUsuario);
                rptDatosInmueble.DataBind();

                RepeaterImagen.DataSource = iInmueble.ListarInformacionInmuebleImagenes(idInmueble, IdUsuario);
                RepeaterImagen.DataBind();

                RepeaterDatosSecundarios.DataSource = iInmueble.ListarInformacionInmueble(idInmueble, IdUsuario);
                RepeaterDatosSecundarios.DataBind();

                RepeaterComentarios.DataSource = iInmueble.comentariosInmueble(idInmueble);
                RepeaterComentarios.DataBind();
            }
        }

        protected string generarCalificacion(int calificacion)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < calificacion; i++)
            {
                sb.Append("<label id='colorStar'>★</label>");
            }
            for (int i = 0; i < 5 - calificacion; i++)
            {
                sb.Append("<label>★</label>");
            }
            return sb.ToString();
        }
    }
}