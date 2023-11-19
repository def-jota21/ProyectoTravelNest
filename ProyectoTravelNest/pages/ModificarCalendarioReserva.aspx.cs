using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Microsoft.SqlServer.Server;
using Negocios;

namespace ProyectoTravelNest.pages
{
    public partial class ModificarCalendarioReserva : System.Web.UI.Page
    {
        Neg_AjustarReserva iReserva = new Neg_AjustarReserva();

        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                ObtenerIdInmueble();
            }
        }

        private void ObtenerIdInmueble()
        {
            try
            {
                Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

                // Llama al método para obtener los inmuebles por anfitrión
                DataSet dsInmuebles = iReserva.ObtenerInmueblesPorAnfitrion(eUsuarios.IdUsuario.ToString());

                // Llena el DropDownList con los inmuebles obtenidos
                ddlInmuebles.Items.Clear(); // Limpia los elementos existentes
                ddlInmueble.Items.Clear(); // Limpia los elementos existentes

                // Agrega un elemento por defecto
                ddlInmueble.Items.Add(new ListItem("Selecciona un inmueble", ""));
                ddlInmuebles.Items.Add(new ListItem("Selecciona un inmueble", ""));

                // Verifica si el conjunto de datos tiene al menos una tabla y si esa tabla tiene al menos una fila
                if (dsInmuebles.Tables.Count > 0 && dsInmuebles.Tables[0].Rows.Count > 0)
                {
                    // Itera a través de las filas del conjunto de datos y agrega elementos al DropDownList
                    foreach (DataRow row in dsInmuebles.Tables[0].Rows)
                    {
                        // Ajusta el código según la estructura de tu conjunto de datos
                        string idInmueble = row["IdInmueble"].ToString(); // Reemplaza "IdInmueble" con el nombre real de la columna

                        ddlInmueble.Items.Add(new ListItem(idInmueble, idInmueble));
                        ddlInmuebles.Items.Add(new ListItem(idInmueble, idInmueble));
                    }
                }
                else
                {
                    // Manejar el caso en que no se encuentren inmuebles
                    ddlInmuebles.Items.Add(new ListItem("No se encontraron inmuebles", ""));
                }
            }
            catch (Exception ex)
            {
                // Mostrar el mensaje de fallo usando SweetAlert
                string errorScript = "Swal.fire('¡Error!', '" + ex.Message + "', 'error');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlertaError", errorScript, true);
            }
        }




        private void ObtenerDatos(string idInmueble)
        {
            try
            {
                string precio = iReserva.GetPrecioNoche(idInmueble);
                PrecioporNoche.Text = precio;

                UpdPanel_Modificar.Update();

            }
            catch (Exception ex)
            {
                // Mostrar el mensaje de fallo
                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "success-message"; // Puedes definir una clase CSS para el estilo
                lblMessage.Visible = true;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string IdInmueble = Session["idInmueble"].ToString();

                decimal precioNoche = Convert.ToDecimal(PrecioporNoche.Text);

                // Llamar al método para insertar en la base de datos
                iReserva.AjustarDataPrecio(IdInmueble, precioNoche);

                // Mostrar el mensaje de éxito
                lblMessage.Text = "Modificación de reserva exitosa";
                lblMessage.CssClass = "success-message"; // Puedes definir una clase CSS para el estilo
                lblMessage.Visible = true;
                UpdPanel_Modificar.Update();
            }
            catch (Exception ex)
            {
                // Mostrar el mensaje de fallo usando SweetAlert
                string errorScript = "Swal.fire('¡Error!', '" + ex.Message + "', 'error');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlertaError", errorScript, true);
            }
        }

        protected void btn_saveTiempo_Click(object sender, EventArgs e)
        {
            try
            {
                string IdInmueble = ddlInmueble.SelectedValue;

                string Tiempo_EstadiaMinima = estadiaMínima.SelectedValue;
                string Tiempo_EstadiaMaxima = estadíaMáxima.SelectedValue;
                string Tiempo_ReservaMinima = reservaMinima.SelectedValue; // Obtenemos el valor seleccionado del DropDownList
                string Tiempo_ReservaMaxima = reservaMaxima.SelectedValue; // Obtenemos el valor seleccionado del DropDownList

                // Llamar al método para insertar en la base de datos
                iReserva.AjustarTimeReserva(IdInmueble, Tiempo_EstadiaMinima, Tiempo_EstadiaMaxima, Tiempo_ReservaMinima, Tiempo_ReservaMaxima);

                // Mostrar el mensaje de éxito usando SweetAlert
                string successScript = "Swal.fire('¡Éxito!', 'Modificación de tiempos de estadia exitosa', 'success');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", successScript, true);
                UpdPanel_Modificar.Update();
            }
            catch (Exception ex)
            {
                // Mostrar el mensaje de fallo usando SweetAlert
                string errorScript = "Swal.fire('¡Error!', '" + ex.Message + "', 'error');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlertaError", errorScript, true);
            }
        }


        protected void ddlConsultarPrecio_Click(object sender, EventArgs e)
        {
            try
            {
                string idInmueble = ddlInmuebles.SelectedValue;

                if (idInmueble != null)
                {
                    ObtenerDatos(idInmueble);
                }
                UpdPanel_Modificar.Update();
            }
            catch (Exception ex)
            {
                // Mostrar el mensaje de fallo usando SweetAlert
                string errorScript = "Swal.fire('¡Error!', '" + ex.Message + "', 'error');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlertaError", errorScript, true);
            }
        }
    }
}