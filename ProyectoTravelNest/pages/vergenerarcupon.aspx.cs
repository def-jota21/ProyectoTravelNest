using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;

namespace ProyectoTravelNest.pages
{
    public partial class vergenerarcupon : System.Web.UI.Page
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
                Negocios.Negocio_Cupon icupon = new Negocios.Negocio_Cupon();


                rptCupon.DataSource = icupon.ListarCuponGestor();
                rptCupon.DataBind();
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string Cantidad = txtCantidad.Text;


                Negocios.Negocio_Cupon icupon = new Negocios.Negocio_Cupon();

                icupon.AgregarCupones(Int32.Parse(Cantidad));


                txtCantidad.Text = string.Empty;

                rptCupon.DataSource = icupon.ListarCuponGestor();
                rptCupon.DataBind();
                string script = "Swal.fire('¡Éxito!', 'Los cupones se generaron con exito', 'success');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
                // Response.Redirect("gestionpoliticas.aspx?idInmueble=" + IdInmueble);
            }
            catch (Exception)
            {
                Negocios.Negocio_Cupon icupon = new Negocios.Negocio_Cupon();

                string script = "Swal.fire('¡Error!', 'Error al generar los cupones', 'error');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);

                rptCupon.DataSource = icupon.ListarCuponGestor();
                rptCupon.DataBind();
            }

            

        }
    }
}