using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace ProyectoTravelNest.pages
{
    public partial class crearalojamiento : System.Web.UI.Page
    {
        Entidades.Usuarios eUsuarios = new Entidades.Usuarios();
        static bool VerificacionAceptado;
        static bool VerificacionMiBanco;
        protected void Page_Load(object sender, EventArgs e)
        {
             eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

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

                DataTable tablaPoliticas = neg_Inmueble.ObtenerPoliticas();

                if (tablaAmenidades.Rows.Count > 0)
                {
                    selectElementPoliticas.DataSource = tablaPoliticas;
                    selectElementPoliticas.DataTextField = "Nombre";
                    selectElementPoliticas.DataValueField = "IdPolitica";
                    selectElementPoliticas.DataBind();
                }

                Neg_MiBanco neg_MiBanco = new Neg_MiBanco();
                VerificacionMiBanco = neg_MiBanco.VerificarMiBanco(eUsuarios.IdUsuario);

                if (VerificacionMiBanco)
                {
                    lblMiBanco.Visible = false;

                }
                else
                {
                    lblMiBanco.Visible = true;
                }

                Neg_VerificarIdentidad neg_VerificarIdentidad = new Neg_VerificarIdentidad();
                string estado = neg_VerificarIdentidad.getEstado(eUsuarios.IdUsuario);

                if (estado == "A")
                {
                    VerificacionAceptado = true;
                    lblVerificacion.Visible = false;

                }
                else
                {
                    VerificacionAceptado = false;
                    lblVerificacion.Visible = true;
                }

                if (VerificacionAceptado && VerificacionMiBanco)
                {
                    btnPublicar.Enabled = true;

                }
                else
                {
                    btnPublicar.Enabled = false;

                }
            }



        }

        protected void btnPublicar_Click(object sender, EventArgs e)
        {
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

            // La validación de Descripcion no necesita mensaje personalizado, así que no se agrega aquí

            // Verificar si hay algún mensaje de error en cualquiera de los campos
            if (string.IsNullOrWhiteSpace(mensajeNombre) && string.IsNullOrWhiteSpace(mensajeUbicacion) && string.IsNullOrWhiteSpace(mensajePrecio) && string.IsNullOrWhiteSpace(mensajeHuespedes) && string.IsNullOrWhiteSpace(mensajeHabitaciones) && string.IsNullOrWhiteSpace(mensajeBanhos))
            {

                string categoriaString = categoria.SelectedValue;
                Entidades.Inmueble inmueble = new Entidades.Inmueble();
                
                inmueble.Nombre = txtnombre.Text;
                inmueble.Direccion = txtubicacion.Text;
                inmueble.Precio = float.Parse(txtprecio.Text);
                inmueble.Cantidad_Huesped = txthuespedes.Text;
                inmueble.Habitaciones = txthabitaciones.Text;
                inmueble.Banhos = txtbaños.Text;
                inmueble.Descripcion = descripcion.Text;
                inmueble.Estado = "Inactivo";

                List<string> listaElementosServidor = new List<string>(); ;
                List<string> listaElementosAmenidades = new List<string>();
                List<string> listaElementosPoliticas = new List<string>();
                List<string> listaDescripcionesPoliticas = new List<string>();
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

                // Obtener el valor del HiddenField para los elementos de políticas
                string elementosPoliticas = hiddenIdsPoliticas.Value; 
                if (!string.IsNullOrEmpty(elementosPoliticas))
                {
                    listaElementosPoliticas = elementosPoliticas.Split(',').ToList();
                }

                string descripcionesPoliticas = hiddenDescripcionesPoliticas.Value; 
                if (!string.IsNullOrEmpty(descripcionesPoliticas))
                {
                    listaDescripcionesPoliticas = descripcionesPoliticas.Split(',').ToList();
                }

                Negocios.Neg_Inmueble neg_Inmueble = new Neg_Inmueble();
                string idInmueble = neg_Inmueble.InsertarInmueble(inmueble, categoriaString, "", listaElementosServidor, listaElementosAmenidades, eUsuarios.IdUsuario, listaElementosPoliticas, listaDescripcionesPoliticas);

                txtnombre.Text = string.Empty;
                txtubicacion.Text = string.Empty;
                txtprecio.Text = string.Empty;
                txthuespedes.Text = string.Empty;
                txthabitaciones.Text = string.Empty;
                txtbaños.Text = string.Empty;
                descripcion.Text = string.Empty;

                // Crear la carpeta Uploads si no existe
                string uploadFolder = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                foreach (HttpPostedFile uploadedFile in fileUpload.PostedFiles)
                {
                    // Guardar el archivo en el servidor
                    string filePath = uploadFolder + Path.GetFileName(uploadedFile.FileName);
                    uploadedFile.SaveAs(filePath);

                    // Convertir el archivo en un arreglo de bytes
                    byte[] fileData;
                    using (var binaryReader = new BinaryReader(uploadedFile.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(uploadedFile.ContentLength);
                    }
                    bool inserto = neg_Inmueble.InsertarImagenInmueble(idInmueble, fileData);

                    if (!inserto)
                    {
                        CantidadImagenesFallidas = +1;
                    }
                }

            }
            

        }

    }

}