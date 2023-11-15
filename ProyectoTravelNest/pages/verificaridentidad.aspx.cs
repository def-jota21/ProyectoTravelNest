using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class verificaridentidad : System.Web.UI.Page
    {
        byte[] imgDocumento;
        byte[] imgRostro;
        Negocios.Neg_VerificarIdentidad verificarIdentidad = new Negocios.Neg_VerificarIdentidad();
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack & eUsuarios != null)
            {

            }

        }

        protected void btnVerificar_Click(object sender, EventArgs e)
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
            verificarIdentidad.compararImagenes(Session["IdUsuario"].ToString(), imgRostro, imgDocumento);
        }
    }
}