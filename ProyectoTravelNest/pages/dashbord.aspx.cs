using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class dashbord : System.Web.UI.Page
    {
        Entidades.Usuarios eUsuarios = new Entidades.Usuarios();
        public int ContadorActivos { get; private set; }
        public int ContadorInactivos { get; private set; }

        public int UsuariosActivos { get; private set; }
        public int UsuariosInactivos { get; private set; }
        public int ReserActivos { get; private set; }
        public int ReserFinalizados { get; private set; }

        protected string NombresCategoriasJson;
        protected string CantidadesCategoriasJson;
        protected void Page_Load(object sender, EventArgs e)
        {
            eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack & eUsuarios != null)
            {
                Neg_Inmueble neg_Inmueble = new Neg_Inmueble();
                ContadorActivos = neg_Inmueble.ObtenerContadorInmuebleActivos();
                ContadorInactivos = neg_Inmueble.ObtenerContadorInmuebleInactivos();
                UsuariosActivos = neg_Inmueble.ObtenerContadorUsuarioseActivos();
                UsuariosInactivos = neg_Inmueble.ObtenerContadorusuariosInactivos();
                ReserFinalizados = neg_Inmueble.ObtenerContadorReserFinal();
                ReserActivos = neg_Inmueble.ObtenerContadorReserActivo();

                List<string> nombres = new List<string>();
                List<int> cantidades = new List<int>();
                DataTable dataTable = neg_Inmueble.ObtenerContadorCategorias();
                foreach (DataRow row in dataTable.Rows)
                {
                    nombres.Add(row["Nombre"].ToString());
                    cantidades.Add(Convert.ToInt32(row["CantidadInmuebles"]));
                }

                NombresCategoriasJson = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(nombres);
                CantidadesCategoriasJson = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(cantidades);
            }


        }
    }
}