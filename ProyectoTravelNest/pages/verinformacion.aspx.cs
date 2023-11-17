using Negocios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace ProyectoTravelNest.pages
{
    public partial class verinformacion : System.Web.UI.Page
    {
       
        static string IdUsuario = "";
        static string idInmueble = "";
        static float Precio = 0;
        static DateTime[] fechasOcupadas;
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;
            
            

            if (!IsPostBack & eUsuarios == null)
            {
                txtTotal.Text = "$ 0";

                if (Request.QueryString["IdUsuario"] != null && Request.QueryString["IdInmueble"] != null)
                {
                    // Lee los valores de los parámetros
                    IdUsuario = Request.QueryString["IdUsuario"];
                    idInmueble = Request.QueryString["IdInmueble"];

                }
                fechasOcupadas = ObtenerFechasOcupadasDesdeBD(idInmueble);

                btnReservar.Enabled = false;

                btnReservar.Text = "Debe Iniciar Sesíon";


                lblFechaSalida.Text = "Seleccione una fecha";

                lblFechaEntrada.Text = "Seleccione una fecha";

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

                RepeaterServicios.DataSource = iInmueble.ListarInformacionInmuebleServicios(idInmueble); 
                RepeaterServicios.DataBind();
            }

            if (!IsPostBack & eUsuarios != null)
            {
                if (Request.QueryString["IdUsuario"] != null && Request.QueryString["IdInmueble"] != null)
                {
                    // Lee los valores de los parámetros
                    IdUsuario = Request.QueryString["IdUsuario"];
                    idInmueble = Request.QueryString["IdInmueble"];

                }
                fechasOcupadas = ObtenerFechasOcupadasDesdeBD(idInmueble);

                if(eUsuarios.T_Rol != 'H')
                {
                    btnReservar.Enabled = false;

                    btnReservar.Text = "Debe ser un huésped";
                }
                else
                {
                    btnReservar.Enabled = true;

                    btnReservar.Text = "Continuar";
                }

               


                lblFechaSalida.Text = "Seleccione una fecha";

                lblFechaEntrada.Text = "Seleccione una fecha";

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

                
                Precio = (float)Math.Round(Convert.ToDecimal(DataBinder.Eval(e.Item.DataItem, "Precio")), 2);

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



        protected void CalendarInicio_DayRender(object sender, DayRenderEventArgs e)
        {
            

            foreach (DateTime fechaOcupada in fechasOcupadas)
            {
                if (e.Day.Date == fechaOcupada.Date)
                {
                    // Si la fecha actual coincide con una fecha ocupada, deshabilita la fecha en el calendario
                    e.Day.IsSelectable = false;
                    e.Cell.ForeColor = System.Drawing.Color.Red; // Cambia el color del texto a gris u otro color de tu elección
                    break; // Puedes salir del bucle si encuentras una coincidencia
                }
            }

            // Deshabilita las fechas anteriores a la fecha actual
            if (e.Day.Date < DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Red;
            }

            // Deshabilita las fechas posteriores a la fecha seleccionada en el CalendarFinal
            if (CalendarFinal.SelectedDate != DateTime.MinValue && e.Day.Date >= CalendarFinal.SelectedDate)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void CalendarFinal_DayRender(object sender, DayRenderEventArgs e)
        {
            // Deshabilita las fechas anteriores a la fecha actual
            if (e.Day.Date < DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Red;
            }

            // Deshabilita las fechas anteriores a la fecha seleccionada en el CalendarInicio
            if (CalendarInicio.SelectedDate != DateTime.MinValue && e.Day.Date <= CalendarInicio.SelectedDate)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Red;
            }

            foreach (DateTime fechaOcupada in fechasOcupadas)
            {
                if (e.Day.Date == fechaOcupada.Date)
                {
                    // Si la fecha actual coincide con una fecha ocupada, deshabilita la fecha en el calendario
                    e.Day.IsSelectable = false;
                    e.Cell.ForeColor = System.Drawing.Color.Red; // Cambia el color del texto a gris u otro color de tu elección
                    break; // Puedes salir del bucle si encuentras una coincidencia
                }
            }

          
        }

        protected void CalendarInicio_SelectionChanged(object sender, EventArgs e)
        {
            // Actualiza la fecha seleccionada en el CalendarFinal

            // Obtén las fechas seleccionadas de los DatePicker
            DateTime fecha1 = CalendarInicio.SelectedDate;
            DateTime fecha2 = CalendarFinal.SelectedDate;
            string fechaString = "1/1/0001 00:00:00";
            DateTime fecha;
            DateTime.TryParseExact(fechaString, "M/d/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha);
            // Calcula la diferencia de días
            TimeSpan diferencia = fecha2 - fecha1;
            int diferenciaDias = diferencia.Days;

            if (fecha2 == fecha)
            {

                txtTotal.Text = "$ 0";
            }
            else
            {
                txtTotal.Text = "$ "+(Precio * diferenciaDias).ToString();
            }

            lblFechaEntrada.Text = CalendarInicio.SelectedDate.ToString("d/MM/yyyy");


        }

        protected void CalendarFinal_SelectionChanged(object sender, EventArgs e)
        {
            // Actualiza la fecha seleccionada en el CalendarInicio

            // Obtén las fechas seleccionadas de los DatePicker
            DateTime fecha1 = CalendarInicio.SelectedDate;
            DateTime fecha2 = CalendarFinal.SelectedDate;
            string fechaString = "1/1/0001 00:00:00";
            DateTime fecha;
            DateTime.TryParseExact(fechaString, "M/d/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha);
            // Calcula la diferencia de días
            TimeSpan diferencia = fecha2 - fecha1;
            int diferenciaDias = diferencia.Days;

            if(fecha1 == fecha)
            {

                txtTotal.Text = "$ 0";
            }
            else
            {
                txtTotal.Text = "$ " + (Precio * diferenciaDias).ToString();
            }

            

            lblFechaSalida.Text = CalendarFinal.SelectedDate.ToString("d/MM/yyyy");
            

        }

        private DateTime[] ObtenerFechasOcupadasDesdeBD(string idInmueble)
        {
            List<DateTime> fechasOcupadas = new List<DateTime>();

            Negocios.Negocio_Inmuebles iInmueble = new Negocios.Negocio_Inmuebles();

            // Aquí debes obtener el DataTable desde tu base de datos
            DataTable dataTable = iInmueble.ListarFechasOcupadas(idInmueble); // Reemplaza con tu lógica para obtener el DataTable

            // Convierte las filas del DataTable a fechas y agrega a la lista
            foreach (DataRow row in dataTable.Rows)
            {
                if (DateTime.TryParse(row["Fecha"].ToString(), out DateTime fechaReserva))
                {
                    fechasOcupadas.Add(fechaReserva);
                }
            }

            // Convierte la lista a un arreglo de DateTime
            DateTime[] arregloFechas = fechasOcupadas.ToArray();

            return arregloFechas;
        }



    }
}