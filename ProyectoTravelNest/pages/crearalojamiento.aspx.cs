using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace ProyectoTravelNest.pages
{
    public partial class crearalojamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack & eUsuarios != null)
            {
                Negocios.Neg_Inmueble neg_Inmueble = new Neg_Inmueble();
                DataTable tablaServicios = neg_Inmueble.ObtenerServicios();

                if (tablaServicios.Rows.Count > 0)
                {
                    selectElement.DataSource = tablaServicios;
                    selectElement.DataTextField = "Nombre";
                    selectElement.DataValueField = "IdServicio";
                    selectElement.DataBind();
                }

                DataTable tablaCategoria = neg_Inmueble.ObtenerCategorias();

                if (tablaCategoria.Rows.Count > 0)
                {
                    categoria.DataSource = tablaCategoria;
                    categoria.DataTextField = "Nombre";
                    categoria.DataValueField = "IdCategoria";
                    categoria.DataBind();
                }

                DataTable tablaAmenidades = neg_Inmueble.ObtenerAmenidades();

                if (tablaAmenidades.Rows.Count > 0)
                {
                    selectElementAmenidades.DataSource = tablaAmenidades;
                    selectElementAmenidades.DataTextField = "Nombre";
                    selectElementAmenidades.DataValueField = "IdAmenidades";
                    selectElementAmenidades.DataBind();
                }
            }

            

        }

        protected void btnPublicar_Click(object sender, EventArgs e)
        {
            List<string> listaElementosServidor = new List<string>(); ;
            List<string> listaElementosAmenidades = new List<string>(); ;
            string elementos = hiddenElementos.Value;
            if (!string.IsNullOrEmpty(elementos))
            {
                listaElementosServidor = elementos.Split(',').ToList();
            }

            string elementosAmen = elementosAmenidades.Value;
            if (!string.IsNullOrEmpty(elementos))
            {
                listaElementosAmenidades = elementosAmen.Split(',').ToList();
            }

            string categoriaString = categoria.SelectedValue;
            Entidades.Inmueble inmueble = new Entidades.Inmueble();

            inmueble.Nombre = txtnombre.Text;
            inmueble.Direccion = txtubicacion.Text;
            inmueble.Precio = float.Parse(txtprecio.Text);
            inmueble.Cantidad_Huesped = txthuespedes.Text;
            inmueble.Habitaciones = txthabitaciones.Text;
            inmueble.Banhos = txtbaños.Text;
            inmueble.Descripcion = descripcion.Text;
            inmueble.Estado = "Activo";


            Negocios.Neg_Inmueble neg_Inmueble = new Neg_Inmueble();
            neg_Inmueble.InsertarInmueble(inmueble,categoriaString,"", listaElementosServidor, listaElementosAmenidades);

        }
    }
}