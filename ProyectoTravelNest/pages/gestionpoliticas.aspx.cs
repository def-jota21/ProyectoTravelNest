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
            
                if (Request.QueryString["IdInmueble"] != null)
                {
                    // Lee los valores de los parámetros
                    IdInmueble = Request.QueryString["IdInmueble"];
                    Negocios.Negocio_Inmuebles iNeg = new Negocio_Inmuebles();
                    hfIDinmueble.Value = IdInmueble;
                    rptPoliticas.DataSource = iNeg.ListarPoliticaAsociada(IdInmueble);
                    rptPoliticas.DataBind();

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


            Response.Redirect("gestionpoliticas.aspx?idInmueble=" + IdInmueble);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {


            int PoliticaxInmueble = int.Parse(hiddenField1.Value);


            Negocios.Negocio_Inmuebles iNeg = new Negocio_Inmuebles();

            iNeg.EliminarPolitica(PoliticaxInmueble);

            Response.Redirect("gestionpoliticas.aspx?idInmueble=" + IdInmueble);

        }

        
        protected void btnAgregar_Click(object sender, EventArgs e)
        {


            string idPolitica = ddlPolitica.SelectedValue;
            string Comentario = TextBox2.Text;

            Negocios.Negocio_Inmuebles iNeg = new Negocio_Inmuebles();

            iNeg.AgregarPolitica(idPolitica, Comentario, IdInmueble);

            Response.Redirect("gestionpoliticas.aspx?idInmueble=" + IdInmueble);

        }
    }
}