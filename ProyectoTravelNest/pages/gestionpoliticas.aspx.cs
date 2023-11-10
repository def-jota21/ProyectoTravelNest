using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            if (!IsPostBack)
            {
                if (Request.QueryString["IdInmueble"] != null)
                {
                    // Lee los valores de los parámetros
                    IdInmueble = Request.QueryString["IdInmueble"];
                    Negocios.Negocio_Inmuebles iNeg = new Negocio_Inmuebles();

                    rptPoliticas.DataSource = iNeg.ListarPoliticaAsociada(IdInmueble);
                    rptPoliticas.DataBind();

                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Negocios.Negocio_Inmuebles iNeg = new Negocio_Inmuebles();
            string Comentario = "";

            Comentario = txtComentario.Text;
            int PoliticaxInmueble = int.Parse(ddlPolitica.SelectedValue.ToString());

            iNeg.EditarPoliticaAsociada(PoliticaxInmueble,Comentario);

            rptPoliticas.DataSource = iNeg.ListarPoliticaAsociada(IdInmueble);
            rptPoliticas.DataBind();
        }
    }
}