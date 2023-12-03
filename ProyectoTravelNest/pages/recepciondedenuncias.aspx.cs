using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace ProyectoTravelNest.pages
{
    public partial class recepciondedenuncias : System.Web.UI.Page
    {
        Neg_Denuncias gestorDenuncias = new Neg_Denuncias();
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (!IsPostBack)
            {
                if (eUsuarios.T_Rol.ToString() == "H")
                {
                    divDdlInmuebles.Visible = true;
                    ObtenerInmuebles();
                }

                if (eUsuarios.T_Rol.ToString() == "A")
                {
                    divDdlHuespedes.Visible = true;
                    ObtenerHuespedes();
                }

                if (eUsuarios.T_Rol.ToString() == "G")
                {
                    divDdlInmuebles.Visible = true;
                    ObtenerInmuebles();
                }
            }
        }

        private void ObtenerInmuebles()
        {
            try
            {
                Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

                if (eUsuarios.T_Rol == 'H')
                {
                    gestorDenuncias.IdUsuario = eUsuarios.IdUsuario.ToString();
                }

                gestorDenuncias.Rol = eUsuarios.T_Rol.ToString();

                DataSet dsInmuebles = gestorDenuncias.GetDataInmueble();
                ddlInmueble.Items.Clear();

                ddlInmueble.Items.Add(new ListItem("Selecciona un inmueble", ""));

                // Verifica si el conjunto de datos tiene al menos una tabla y si esa tabla tiene al menos una fila
                if (dsInmuebles.Tables.Count > 0 && dsInmuebles.Tables[0].Rows.Count > 0)
                {
                    // Itera a través de las filas del conjunto de datos y agrega elementos al DropDownList
                    foreach (DataRow row in dsInmuebles.Tables[0].Rows)
                    {
                        // Ajusta el código según la estructura de tu conjunto de datos
                        string nombreInmueble = row["Nombre"].ToString();
                        string idInmueble = row["IdInmueble"].ToString();

                        ddlInmueble.Items.Add(new ListItem(nombreInmueble, idInmueble));
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('No hay inmuebles disponibles');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('{ex.Message}');", true);
            }
        }

        private void ObtenerHuespedes()
        {
            try
            {
                Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

                gestorDenuncias.Rol = eUsuarios.T_Rol.ToString();
                gestorDenuncias.IdUsuario = eUsuarios.IdUsuario;

                DataSet dsHuespedes = gestorDenuncias.GetDataInmueble();
                ddlHuesped.Items.Clear();

                ddlHuesped.Items.Add(new ListItem("Selecciona un huesped", ""));

                // Verifica si el conjunto de datos tiene al menos una tabla y si esa tabla tiene al menos una fila
                if (dsHuespedes.Tables.Count > 0 && dsHuespedes.Tables[0].Rows.Count > 0)
                {
                    // Itera a través de las filas del conjunto de datos y agrega elementos al DropDownList
                    foreach (DataRow row in dsHuespedes.Tables[0].Rows)
                    {
                        // Ajusta el código según la estructura de tu conjunto de datos
                        string nombreHuesped = row["Nombre"].ToString();
                        string cedulaHuesped = row["Cedula"].ToString();

                        ddlHuesped.Items.Add(new ListItem(nombreHuesped, cedulaHuesped));
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('No hay huespedes con reservaciones');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('{ex.Message}');", true);
            }
        }


        protected void btnEnviarDenuncia_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

                if (eUsuarios.T_Rol == 'H' || eUsuarios.T_Rol == 'G')
                {
                    gestorDenuncias.IdDenunciado = ddlInmueble.SelectedValue;
                }

                if (eUsuarios.T_Rol == 'A')
                {
                    gestorDenuncias.IdDenunciado = ddlHuesped.SelectedValue;
                }

                gestorDenuncias.IdDenunciante = eUsuarios.IdUsuario;
                gestorDenuncias.MotivoDenuncia = txtMotivo.Text;
                gestorDenuncias.Sancion = txtSancion.Text;
                gestorDenuncias.TipoUsuario = ddlTipoUsuario.SelectedValue;
                gestorDenuncias.DescripcionDenuncia = txtDescripcion.Text;
                gestorDenuncias.Instruccion = "Create";

                gestorDenuncias.CRUDDenuncias();
                LimpiarTexto();
                UpdPanel_CRUDDenuncias.Update();
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionExito", $"mostrarNotificacionExito('Denuncia registrada con éxito!');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarNotificacionError", $"mostrarNotificacionError('{ex.Message}');", true);
            }
        }
        private void LimpiarTexto()
        {
            txtMotivo.Text = "";
            txtSancion.Text = "";
            txtDescripcion.Text = "";
        }
    }
}