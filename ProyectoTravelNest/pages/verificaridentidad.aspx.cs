using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class verificaridentidad : System.Web.UI.Page
    {
        byte[] imgDocumento;
        byte[] imgRostro;
        String IdUsuario;
        Negocios.Neg_VerificarIdentidad verificarIdentidad = new Negocios.Neg_VerificarIdentidad();
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;
            IdUsuario = eUsuarios.IdUsuario;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack & eUsuarios != null)
            {
                string[] clases = cajaEstado.Attributes["class"].Split(' ');
                String estado = verificarIdentidad.getEstado(IdUsuario);
                if (estado.Equals("P"))
                {
                    clases = clases.Where(clase => clase != "alert-danger").ToArray();
                    cajaEstado.Attributes["class"] = String.Join(" ", clases);
                    cajaEstado.Attributes["class"] += " alert-warning";
                    lblEstado.Text = "Estado: Pendiente";
                }
                else if (estado.Equals("R"))
                {
                    clases = clases.Where(clase => clase != "alert-warning" && clase != "alert-success").ToArray();
                    cajaEstado.Attributes["class"] = String.Join(" ", clases);
                    cajaEstado.Attributes["class"] += " alert-danger";
                    lblEstado.Text = "Estado: Rechazado";
                }
                else if (estado.Equals("A"))
                {
                    clases = clases.Where(clase => clase != "alert-warning" && clase != "alert-danger").ToArray();
                    cajaEstado.Attributes["class"] = String.Join(" ", clases);
                    cajaEstado.Attributes["class"] += " alert-success";
                    lblEstado.Text = "Estado: Aprobado";
                    //btnVerificar.Visible = false;
                }
                lblIdentificacion.Text = IdUsuario;
            }
        }

        protected async void btnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Documento.HasFile)
                {
                    Stream fs = Documento.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    imgDocumento = br.ReadBytes((Int32)fs.Length);
                }
                if (Rostro.HasFile)
                {
                    Stream fs = Rostro.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    imgRostro = br.ReadBytes((Int32)fs.Length);
                }
                await verificarIdentidad.compararImagenes(IdUsuario, imgDocumento, imgRostro);
                await verificarIdentidad.compararCedula(IdUsuario, imgDocumento);
                Response.Redirect(Request.RawUrl);
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                string[] clases = cajaEstado.Attributes["class"].Split(' ');
                clases = clases.Where(clase => clase != "alert-warning" && clase != "alert-success").ToArray();
                cajaEstado.Attributes["class"] = String.Join(" ", clases);
                cajaEstado.Attributes["class"] += " alert-danger";
                lblEstado.Text = "Error: " + ex.Message;
                cargandoImagen.Style["display"] = "none";
            }
        }
    }
}