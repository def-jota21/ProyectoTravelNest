using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class cotizacion : System.Web.UI.Page
    {

        DataTable dtInformacionInmueble = new DataTable();
        static string parametro1 = "";
        static string parametro2 = "";
        static string parametro3 = "";
        static string parametro4 = "";
        static string parametro5 = "";
        static string parametro6 = "";
        static decimal totalTarifas;
        static decimal tarifaPorNoche;
        static decimal tarifaServicio;
        static bool aplicoCupon = false;
        Entidades.Usuarios eUsuarios;
        protected void Page_Load(object sender, EventArgs e)
        {
            eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack & eUsuarios != null)
            {
                // Verifica si los parámetros se pasaron en la URL
                if (Request.QueryString["parametro1"] != null &&
                    Request.QueryString["parametro2"] != null &&
                    Request.QueryString["parametro3"] != null &&
                    Request.QueryString["parametro4"] != null &&
                    Request.QueryString["parametro5"] != null && 
                    Request.QueryString["parametro6"] != null)
                {
                    // Obtiene los valores de los parámetros desde la URL
                    parametro1 = Request.QueryString["parametro1"];
                    parametro2 = Request.QueryString["parametro2"];
                    parametro3 = Request.QueryString["parametro3"];
                    parametro4 = Request.QueryString["parametro4"];
                    parametro5 = Request.QueryString["parametro5"];
                    parametro6 = Request.QueryString["parametro6"];

                    Negocios.Negocio_Inmuebles iInmueble = new Negocio_Inmuebles();
                    RepeaterImagen.DataSource = iInmueble.ListarInformacionInmuebleImagenes(parametro6, parametro5);
                    RepeaterImagen.DataBind();
                    
                    Negocio_Cupon negocio_Cupon = new Negocio_Cupon();


                    var cupones = negocio_Cupon.ListarCuponHuesped(eUsuarios.IdUsuario);

                    foreach (var cupon in cupones)
                    {
                        string textoCupon = $"{cupon.NombreCupon}  ({cupon.PorcentajeDescuento}%)";
                        ListItem item = new ListItem(textoCupon, cupon.PorcentajeDescuento.ToString());
                        ddlCupones.Items.Add(item);
                    }

                    ddlCupones.Items.Insert(0, new ListItem("No aplicar", "0"));
                    ddlCupones.DataBind();


                    dtInformacionInmueble = iInmueble.ListarInformacionInmueble(parametro6, parametro5);

                    if (dtInformacionInmueble.Rows.Count > 0)
                    {
                        
                        lblCodigo.Text = dtInformacionInmueble.Rows[0][0].ToString();

                        
                        lblNombreInmueble.Text = dtInformacionInmueble.Rows[0][2].ToString();

                        txtf_inicio.Text = parametro1;
                        txtf_fin.Text = parametro2;
                        txthuesped.Text = parametro4;

                       
                        tarifaPorNoche = decimal.Parse(dtInformacionInmueble.Rows[0][7].ToString()); // Ajusta esto según tu estructura de datos

                        


                        DateTime fechaUno;
                        DateTime.TryParseExact(parametro2, "d/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaUno);

                        DateTime fechaDos;
                        DateTime.TryParseExact(parametro1, "d/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaDos);

                        TimeSpan diferencia = fechaUno - fechaDos;

                        int diferenciaDias = diferencia.Days;

                        // Porcentajes de las tarifas adicionales (en este caso, 10% para limpieza, 2% para servicio, 5% para impuestos)
                        decimal porcentajeLimpieza = 0.20m;
                        decimal porcentajeServicio = 0.15m;
                        decimal porcentajeImpuestos = 0.13m;

                        // Calcula las tarifas adicionales como porcentaje del costo por noche
                        decimal tarifaLimpieza = tarifaPorNoche * porcentajeLimpieza;
                        tarifaServicio = tarifaPorNoche * porcentajeServicio;
                        decimal impuestos = tarifaPorNoche * porcentajeImpuestos;

                        // Calcula el total de la tarifa por noche
                        decimal totalPorNoche = tarifaPorNoche * diferenciaDias;

                        // Calcula el total de todas las tarifas
                        totalTarifas = totalPorNoche + tarifaLimpieza + tarifaServicio + impuestos;

                        // Asigna los resultados a los controles
                        txtf_inicio.Text = parametro1;
                        txtf_fin.Text = parametro2;
                        lblNoches.Text = string.Format("${0:N2} x {1} noches", tarifaPorNoche, diferenciaDias);
                        lblLimpieza.Text = string.Format("${0:N2}", tarifaLimpieza);
                        lblServicio.Text = string.Format("${0:N2}", tarifaServicio);
                        lblImpuestos.Text = string.Format("${0:N2}", impuestos);
                        lblCupon.Text = "No aplicar";
                        lblTotal.Text = string.Format("${0:N2}", totalTarifas);

                    }


                }
            }
                    
                
        }
        protected void btnPagar_Click(object sender, EventArgs e)
        {
            Negocios.Neg_Reservaciones reservaciones = new Neg_Reservaciones();

            Negocio_Cupon negocio_Cupon = new Negocio_Cupon();
            Neg_Inmueble neg_Inmueble = new Neg_Inmueble();

            try
            {
                string fechaEntrada = parametro1;
                string fechaSalida = parametro2;

                // Separar las partes de la fecha
                string[] partesFechaEntrada = fechaEntrada.Split('/');
                string[] partesFechaSalida = fechaSalida.Split('/');

                // Agregar un cero inicial al día si es necesario
                string diaEntrada = partesFechaEntrada[0].PadLeft(2, '0');
                string diaSalida = partesFechaSalida[0].PadLeft(2, '0');

                // Reemplazar el día original con el día corregido
                string fechaEntradaCorregida = diaEntrada + "/" + partesFechaEntrada[1] + "/" + partesFechaEntrada[2];
                string fechaSalidaCorregida = diaSalida + "/" + partesFechaSalida[1] + "/" + partesFechaSalida[2];

                // Analizar las fechas en formato dd/MM/yyyy
                DateTime fechaEntradaParse = DateTime.ParseExact(fechaEntradaCorregida, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime fechaSalidaParse = DateTime.ParseExact(fechaSalidaCorregida, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                // Formatear las fechas en formato yyyy-MM-dd
                string fechaEntradaFormateada = fechaEntradaParse.ToString("yyyy-MM-dd");
                string fechaSalidaFormateada = fechaSalidaParse.ToString("yyyy-MM-dd");


                //valida las fechas nuevamente, si da error se va para el catch e informa
                negocio_Cupon.ValidarFechasReserva(eUsuarios.IdUsuario, parametro6, fechaEntradaFormateada, fechaSalidaFormateada);

                string idAnfitrion = neg_Inmueble.ObtenerIdAnfitrion(parametro6);

                mibanco.mibanco mibanco = new mibanco.mibanco();
                //consumir un metodo en mi banco tipo string, si se paga "Se Pago"  y si no "No Pago"
                bool pago = mibanco.ValidarPago(1, (float)totalTarifas, eUsuarios.IdUsuario, idAnfitrion, (float)tarifaPorNoche, (float)tarifaServicio);

                //recuperar el numero de identificacion del usaurio


                //AQUI MISMO PONER UNA VALIDACION COMO LA ANTERIOR; QUE VALIDE LA TRANSACCION EN MIBANCO 
                //EJEMPLO

                if (pago)
                {
                    //si no da error, continua
                    bool insertoReser = reservaciones.InsertarReservacion(parametro6, parametro5, fechaEntradaFormateada, fechaSalidaFormateada);

                    if (insertoReser)
                    {
                        if (aplicoCupon)
                        {

                            //si se inserta cambiar el estado del cupon
                            negocio_Cupon = new Negocio_Cupon();

                            negocio_Cupon.UsarCupon(ddlCupones.SelectedItem.Text.Substring(0, 6), eUsuarios.IdUsuario);

                        }
                        string script = "Swal.fire('¡Éxito!', 'Se reservo con Exito', 'success');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
                        reservaciones.enviarCorreo(eUsuarios.IdUsuario, totalTarifas);
                    }
                    else
                    {
                        string script = "Swal.fire('¡Error!', 'Ocurrio un error', 'error');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
                    }


                }
                else
                {

                    string script = "Swal.fire('¡Error!', 'Ocurrio un error', 'error');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);


                }


                //si no da error, continua
                bool inserto = reservaciones.InsertarReservacion(parametro6, parametro5, fechaEntradaFormateada, fechaSalidaFormateada);

                if (inserto)
                {
                    if (aplicoCupon)
                    {

                        //si se inserta cambiar el estado del cupon
                         negocio_Cupon = new Negocio_Cupon();

                        negocio_Cupon.UsarCupon(ddlCupones.SelectedItem.Text.Substring(0,6), eUsuarios.IdUsuario);

                    }
                    string script = "Swal.fire('¡Éxito!', 'Se reservo con Exito', 'success');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
                    reservaciones.enviarCorreo(eUsuarios.IdUsuario, totalTarifas);
                }
                else
                {
                    string script = "Swal.fire('¡Error!', 'Ocurrio un error', 'error');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
                }


            }
            catch (Exception ex)
            {

                string mensajeError = ex.Message.Replace("'", "\\'"); 
                string script = $"Swal.fire('¡Error!', '{mensajeError}', 'error');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
            }


           
        }
            protected void RepeaterImagen_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Obtenemos el índice del elemento actual
                int itemIndex = e.Item.ItemIndex;

                // Obtenemos el control Image dentro del ItemTemplate
                Image imgMueble = (Image)e.Item.FindControl("imgMueble");

                // Si el índice es 0 (el primer elemento), mantenemos la imagen visible
                // Para los demás elementos, la ocultamos
                imgMueble.Visible = (itemIndex == 0);
            }
        }


        protected void ddlCupones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlCupones.SelectedItem.Text != "No aplicar")
            {
                Negocios.Negocio_Inmuebles iInmueble = new Negocio_Inmuebles();
                dtInformacionInmueble = iInmueble.ListarInformacionInmueble(parametro6, parametro5);
                aplicoCupon = true;

                if (dtInformacionInmueble.Rows.Count > 0)
                {

                    lblCodigo.Text = dtInformacionInmueble.Rows[0][0].ToString();


                    lblNombreInmueble.Text = dtInformacionInmueble.Rows[0][2].ToString();

                    txtf_inicio.Text = parametro1;
                    txtf_fin.Text = parametro2;
                    txthuesped.Text = parametro4;


                    decimal tarifaPorNoche = decimal.Parse(dtInformacionInmueble.Rows[0][7].ToString()); // Ajusta esto según tu estructura de datos

                    string porcentajeDescuentoStr = ddlCupones.SelectedValue;
                    int porcentajeDescuento = int.Parse(porcentajeDescuentoStr);
                    decimal porcentajeDescuentoDecimal = Convert.ToDecimal(porcentajeDescuento);
                    decimal descuento = (porcentajeDescuentoDecimal / 100) * tarifaPorNoche;
                    tarifaPorNoche = tarifaPorNoche - descuento;


                    DateTime fechaUno;
                    DateTime.TryParseExact(parametro2, "d/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaUno);

                    DateTime fechaDos;
                    DateTime.TryParseExact(parametro1, "d/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaDos);

                    TimeSpan diferencia = fechaUno - fechaDos;

                    int diferenciaDias = diferencia.Days;

                    // Porcentajes de las tarifas adicionales (en este caso, 10% para limpieza, 2% para servicio, 5% para impuestos)
                    decimal porcentajeLimpieza = 0.20m;
                    decimal porcentajeServicio = 0.15m;
                    decimal porcentajeImpuestos = 0.13m;

                    // Calcula las tarifas adicionales como porcentaje del costo por noche
                    decimal tarifaLimpieza = tarifaPorNoche * porcentajeLimpieza;
                    decimal tarifaServicio = tarifaPorNoche * porcentajeServicio;
                    decimal impuestos = tarifaPorNoche * porcentajeImpuestos;

                    // Calcula el total de la tarifa por noche
                    decimal totalPorNoche = tarifaPorNoche * diferenciaDias;

                    // Calcula el total de todas las tarifas
                    totalTarifas = totalPorNoche + tarifaLimpieza + tarifaServicio + impuestos;

                    // Asigna los resultados a los controles
                    txtf_inicio.Text = parametro1;
                    txtf_fin.Text = parametro2;
                    lblNoches.Text = string.Format("${0:N2} x {1} noches", tarifaPorNoche, diferenciaDias);
                    lblLimpieza.Text = string.Format("${0:N2}", tarifaLimpieza);
                    lblServicio.Text = string.Format("${0:N2}", tarifaServicio);
                    lblImpuestos.Text = string.Format("${0:N2}", impuestos);
                   
                    lblCupon.Text = ddlCupones.SelectedValue+"%"+" (-"+ string.Format("${0:N2}",descuento) +")";
                    lblTotal.Text = string.Format("${0:N2}", totalTarifas);
                    UpdatePanel1.Update();
                }

            }
            else
            {
                Negocios.Negocio_Inmuebles iInmueble = new Negocio_Inmuebles();
                dtInformacionInmueble = iInmueble.ListarInformacionInmueble(parametro6, parametro5);
                aplicoCupon = false;
                if (dtInformacionInmueble.Rows.Count > 0)
                {

                    lblCodigo.Text = dtInformacionInmueble.Rows[0][0].ToString();


                    lblNombreInmueble.Text = dtInformacionInmueble.Rows[0][2].ToString();

                    txtf_inicio.Text = parametro1;
                    txtf_fin.Text = parametro2;
                    txthuesped.Text = parametro4;


                    decimal tarifaPorNoche = decimal.Parse(dtInformacionInmueble.Rows[0][7].ToString()); // Ajusta esto según tu estructura de datos




                    DateTime fechaUno;
                    DateTime.TryParseExact(parametro2, "d/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaUno);

                    DateTime fechaDos;
                    DateTime.TryParseExact(parametro1, "d/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaDos);

                    TimeSpan diferencia = fechaUno - fechaDos;

                    int diferenciaDias = diferencia.Days;

                    // Porcentajes de las tarifas adicionales (en este caso, 10% para limpieza, 2% para servicio, 5% para impuestos)
                    decimal porcentajeLimpieza = 0.20m;
                    decimal porcentajeServicio = 0.15m;
                    decimal porcentajeImpuestos = 0.13m;

                    // Calcula las tarifas adicionales como porcentaje del costo por noche
                    decimal tarifaLimpieza = tarifaPorNoche * porcentajeLimpieza;
                    decimal tarifaServicio = tarifaPorNoche * porcentajeServicio;
                    decimal impuestos = tarifaPorNoche * porcentajeImpuestos;

                    // Calcula el total de la tarifa por noche
                    decimal totalPorNoche = tarifaPorNoche * diferenciaDias;

                    // Calcula el total de todas las tarifas
                    totalTarifas = totalPorNoche + tarifaLimpieza + tarifaServicio + impuestos;

                    // Asigna los resultados a los controles
                    txtf_inicio.Text = parametro1;
                    txtf_fin.Text = parametro2;
                    lblNoches.Text = string.Format("${0:N2} x {1} noches", tarifaPorNoche, diferenciaDias);
                    lblLimpieza.Text = string.Format("${0:N2}", tarifaLimpieza);
                    lblServicio.Text = string.Format("${0:N2}", tarifaServicio);
                    lblImpuestos.Text = string.Format("${0:N2}", impuestos);
                    lblCupon.Text = "No aplicar";
                    lblTotal.Text = string.Format("${0:N2}", totalTarifas);
                    UpdatePanel1.Update();
                }

            }
        }
    }
}


