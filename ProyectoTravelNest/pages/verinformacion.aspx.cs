using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class verinformacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string IdUsuario ="";
            string idInmueble ="";

            if (!IsPostBack)
            {
                if (Request.QueryString["IdUsuario"] != null && Request.QueryString["IdInmueble"] != null)
                {
                    // Lee los valores de los parámetros
                    IdUsuario = Request.QueryString["IdUsuario"];
                    idInmueble = Request.QueryString["IdInmueble"];

                }
                Negocios.Negocio_Inmuebles iInmueble = new Negocio_Inmuebles();
                rptDatosInmueble.DataSource = iInmueble.ListarInformacionInmueble(idInmueble, IdUsuario);
                rptDatosInmueble.DataBind();

                RepeaterImagen.DataSource = iInmueble.ListarInformacionInmuebleImagenes(idInmueble, IdUsuario);
                RepeaterImagen.DataBind();

                RepeaterDatosSecundarios.DataSource = iInmueble.ListarInformacionInmueble(idInmueble, IdUsuario);
                RepeaterDatosSecundarios.DataBind();

                rptInmuebles.DataSource = iInmueble.ListarInformacionInmueble(idInmueble, IdUsuario);
                rptInmuebles.DataBind();

                rptPoliticas.DataSource = iInmueble.ListarInformacionInmueblePoliticas(idInmueble, IdUsuario);
                rptPoliticas.DataBind();

                rptReglas.DataSource = iInmueble.ListarInformacionInmuebleReglas(idInmueble, IdUsuario);
                rptReglas.DataBind();
            }
        }

        protected void rptInmuebles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Encuentra el DropDownList en la fila actual del Repeater
                DropDownList ddlHuespedes = (DropDownList)e.Item.FindControl("ddlHuespedes");

                // Encuentra la etiqueta Cantidad_Huespedes en la fila actual del Repeater
                Label lblCantidadHuespedes = (Label)e.Item.FindControl("lblCantidadHuespedes");

                if (ddlHuespedes != null && lblCantidadHuespedes != null)
                {
                    // Obtiene el valor de Cantidad_Huespedes
                    int cantidadHuespedes = Convert.ToInt32(lblCantidadHuespedes.Text);

                    // Agrega opciones al DropDownList según la cantidad de huéspedes
                    for (int i = 1; i <= cantidadHuespedes; i++)
                    {
                        ddlHuespedes.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    }
                }
            }
        }

    }
}