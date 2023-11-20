using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class editaranuncio : System.Web.UI.Page
    {
        Entidades.Usuarios eUsuarios = new Entidades.Usuarios();
        string parametro = "";
        List<string> serviciosOriginales = new List<string>();
        List<string> amenidadesOriginales = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;
            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack & eUsuarios != null)
            {
                Negocio_Inmuebles negocio_Inmuebles = new Negocio_Inmuebles();
                RepeaterImagen.DataSource = negocio_Inmuebles.ListarInformacionInmuebleImagenes(parametro, "");
                RepeaterImagen.DataBind();
                parametro = Request.QueryString["IdInmueble"];
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

                DataTable tablaPoliticas = neg_Inmueble.ObtenerPoliticas();

                if (tablaAmenidades.Rows.Count > 0)
                {
                    selectElementPoliticas.DataSource = tablaPoliticas;
                    selectElementPoliticas.DataTextField = "Nombre";
                    selectElementPoliticas.DataValueField = "IdPolitica";
                    selectElementPoliticas.DataBind();
                }

                List<Tuple<string, string>> serviciosInmueble = new List<Tuple<string, string>>();
                serviciosInmueble = neg_Inmueble.ObtenerServiciosDelInmueble(parametro);
                List<Tuple<string, string>> amenidadesInmueble = new List<Tuple<string, string>>();
                amenidadesInmueble = neg_Inmueble.ObtenerAmenidadDelInmueble(parametro);


                foreach (var servicio in serviciosInmueble)
                {
                    string idServicio = servicio.Item1;
                    serviciosOriginales.Add(idServicio);
                    string nombreServicio = servicio.Item2;

                    string htmlServicio = $@"
                <li style='display: flex;' data-idservicio='{idServicio}'>
                    <div style='width: 200px;'>{nombreServicio}</div>
                    <div style='margin-left: 1rem; margin-top: -1rem;'>
                        <button class='btn btn-danger my-3' style='font-size: 12px;' onclick='this.parentElement.parentElement.remove();'>
                            <i class='fa-solid fa-x' style='color: #f5f5f5;'></i>
                        </button>
                    </div>
                </li>";

                    LiteralControl literalControl = new LiteralControl(htmlServicio);
                    listaElementos.Controls.Add(literalControl);
                }

                foreach (var amenidad in amenidadesInmueble)
                {
                    string idAmenidad = amenidad.Item1;
                    amenidadesOriginales.Add(idAmenidad);
                    string nombreAmenidad = amenidad.Item2;

                    string htmlAmenidad = $@"
                <li style='display: flex;' data-idamenidad='{idAmenidad}'>
                    <div style='width: 200px;'>{nombreAmenidad}</div>
                    <div style='margin-left: 1rem; margin-top: -1rem;'>
                        <button class='btn btn-danger my-3' style='font-size: 12px;' onclick='this.parentElement.parentElement.remove();'>
                            <i class='fa-solid fa-x' style='color: #f5f5f5;'></i>
                        </button>
                    </div>
                </li>";

                    LiteralControl literalControlAmenidad = new LiteralControl(htmlAmenidad);
                    listaElementosAmenidades.Controls.Add(literalControlAmenidad);
                }

                DataTable tablaInmueble = new DataTable();
                tablaInmueble = neg_Inmueble.ObtenerDatosInmueble(parametro);

                txtnombre.Text = tablaInmueble.Rows[0][2].ToString();
                txtubicacion.Text = tablaInmueble.Rows[0][3].ToString();
                descripcion.Text = tablaInmueble.Rows[0][4].ToString();
                ddlEstado.SelectedValue = tablaInmueble.Rows[0][5].ToString();

                //string idCategoria = neg_Inmueble.ObtenerNombreCategoriaPorId();
                categoria.SelectedValue = tablaInmueble.Rows[0][6].ToString();
                txthuespedes.Text = tablaInmueble.Rows[0][7].ToString();

                string valorRecuperado = tablaInmueble.Rows[0][8].ToString();


                string[] partes = valorRecuperado.Split(',');


                txtprecio.Text = partes[0];
                txthabitaciones.Text = tablaInmueble.Rows[0][9].ToString();
                txtbaños.Text = tablaInmueble.Rows[0][10].ToString();
            }
            
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Neg_Inmueble neg_Inmueble = new Neg_Inmueble();
            int CantidadImagenesFallidas = 0;
            string mensajeNombre = "";
            string mensajeUbicacion = "";
            string mensajePrecio = "";
            string mensajeHuespedes = "";
            string mensajeHabitaciones = "";
            string mensajeBanhos = "";
            string mensajeDescripcion = "";
            string mensajeImagenes = "";

            if (string.IsNullOrWhiteSpace(txtnombre.Text))
            {
                mensajeNombre = "Nombre no puede estar vacío.";
                lblErrorNombre.Text = mensajeNombre;
                lblErrorNombre.Visible = true;
            }
            else
            {
                lblErrorNombre.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txtubicacion.Text))
            {
                mensajeUbicacion = "Ubicación no puede estar vacío.";
                lblErrorUbicacion.Text = mensajeUbicacion;
                lblErrorUbicacion.Visible = true;
            }

            if (!float.TryParse(txtprecio.Text, out float precio))
            {
                mensajePrecio = "Precio debe ser un número válido.";
                lblErrorPrecio.Text = mensajePrecio;
                lblErrorPrecio.Visible = true;
            }

            if (string.IsNullOrWhiteSpace(txthuespedes.Text))
            {
                mensajeHuespedes = "Cantidad de Huéspedes no puede estar vacío.";
                lblErrorHuespedes.Text = mensajeHuespedes;
                lblErrorHuespedes.Visible = true;
            }

            if (string.IsNullOrWhiteSpace(txthabitaciones.Text))
            {
                mensajeHabitaciones = "Habitaciones no puede estar vacío.";
                lblErrorHabitaciones.Text = mensajeHabitaciones;
                lblErrorHabitaciones.Visible = true;
            }

            if (string.IsNullOrWhiteSpace(txtbaños.Text))
            {
                mensajeBanhos = "Baños no puede estar vacío.";
                lblErrorBanhos.Text = mensajeBanhos;
                lblErrorBanhos.Visible = true;
            }

            // Comprobar si el FileUpload tiene archivos
            if (fileUpload.HasFiles)
            {
                // Obtener el número de archivos cargados
                int fileCount = fileUpload.PostedFiles.Count;

                // Validar la cantidad de archivos
                if (fileCount < 5)
                {
                    mensajeImagenes = "Por favor, selecciona al menos 5 imágenes.";
                    lblErrorImagenes.Visible = true;
                    lblErrorImagenes.Text = mensajeImagenes;
                    return; // Salir del método
                }
                else if (fileCount > 10)
                {
                    mensajeImagenes = "Por favor, selecciona no más de 10 imágenes.";
                    lblErrorImagenes.Visible = true;
                    lblErrorImagenes.Text = mensajeImagenes;
                    return; // Salir del método
                }

            }
            else
            {
                mensajeImagenes = "No se seleccionaron archivos.";
                lblErrorImagenes.Visible = true;
                lblErrorImagenes.Text = mensajeImagenes;
                return; // Salir del método
            }

            if (string.IsNullOrWhiteSpace(mensajeNombre) && string.IsNullOrWhiteSpace(mensajeUbicacion) && string.IsNullOrWhiteSpace(mensajePrecio) && string.IsNullOrWhiteSpace(mensajeHuespedes) && string.IsNullOrWhiteSpace(mensajeHabitaciones) && string.IsNullOrWhiteSpace(mensajeBanhos))
            {
                List<string> serviciosActuales = new List<string>();
                List<string> amenidadesActuales = new List<string>();

                string categoriaString = categoria.SelectedValue;
                string estado = ddlEstado.SelectedValue;
                Entidades.Inmueble inmueble = new Entidades.Inmueble();

                inmueble.Nombre = txtnombre.Text;
                inmueble.Direccion = txtubicacion.Text;
                inmueble.Precio = float.Parse(txtprecio.Text);
                inmueble.Cantidad_Huesped = txthuespedes.Text;
                inmueble.Habitaciones = txthabitaciones.Text;
                inmueble.Banhos = txtbaños.Text;
                inmueble.Descripcion = descripcion.Text;
                inmueble.Estado = estado;

                string elementos = hiddenElementos.Value;
                if (!string.IsNullOrEmpty(elementos))
                {
                    serviciosActuales = elementos.Split(',').ToList();
                }
                string elementosAme = elementosAmenidades.Value;
                if (!string.IsNullOrEmpty(elementosAme))
                {
                    amenidadesActuales = elementosAme.Split(',').ToList();
                }

                List<string> serviciosEliminados = new List<string>();
                List<string> serviciosAgregados = new List<string>();

                // Determinar los servicios eliminados
                foreach (var idServicio in serviciosOriginales)
                {
                    if (!serviciosActuales.Contains(idServicio.Trim()))
                    {
                        serviciosEliminados.Add(idServicio);
                    }
                }
                List<string> serviciosOriginalesLimpios = serviciosOriginales.Select(id => id.Trim()).ToList();
                List<string> serviciosActualesLimpios = serviciosActuales.Select(id => id.Trim()).ToList();
                // Determinar los servicios agregados
                foreach (var idServicio in serviciosActualesLimpios)
                {
                    if (!serviciosOriginalesLimpios.Contains(idServicio))
                    {
                        serviciosAgregados.Add(idServicio);
                    }
                }

                List<string> amenidadesEliminados = new List<string>();
                List<string> amenidadesAgregados = new List<string>();

                List<string> amenidadesOriginalesLimpios = amenidadesOriginales.Select(id => id.Trim()).ToList();
                List<string> amenidadesActualesLimpios = amenidadesActuales.Select(id => id.Trim()).ToList();

                // Determinar los amenidades eliminados
                foreach (var idAmenidad in amenidadesOriginalesLimpios)
                {
                    if (!amenidadesActualesLimpios.Contains(idAmenidad.Trim()))
                    {
                        amenidadesEliminados.Add(idAmenidad);
                    }
                }

                // Determinar los amenidades agregados
                List<string> amenidadesAgregadas = amenidadesActualesLimpios
                .Except(amenidadesOriginalesLimpios)
                .ToList();



                //INSERTAR O ELIMINAR SERVICIOS
                if (serviciosActuales.Count > 0)
                {
                    foreach (var idServicios in serviciosAgregados)
                    {
                        neg_Inmueble.InsertarServicioxInmueble(parametro, idServicios);
                    }

                    foreach (var idServicios in serviciosEliminados)
                    {
                        neg_Inmueble.EliminarServicioxInmueble(parametro, idServicios);
                    }
                }

                //INSERTAR O ELIMINAR AMENIDADES        
                if (amenidadesActuales.Count > 0)
                {
                    foreach (var idAmenidad in amenidadesAgregadas)
                    {
                        neg_Inmueble.InsertarAmeindadxInmueble(parametro, idAmenidad);
                    }
                    foreach (var idAmenidad in amenidadesEliminados)
                    {
                        neg_Inmueble.EliminarAmenidadAInmueble(parametro, idAmenidad);
                    }
                }

                bool valor = neg_Inmueble.EditarInmueble(inmueble, categoriaString, parametro);


                if (valor)
                {
                    string script = "Swal.fire('¡Éxito!', 'Los datos se editaron correctamente.', 'success');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
                    Response.Redirect("editaranuncio.aspx");
                }
                else
                {
                    string script = "Swal.fire('ERROR', 'Ocurrio un error.', 'error');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
                    Response.Redirect("editaranuncio.aspx");
                }
            }
            

        }
    }
}