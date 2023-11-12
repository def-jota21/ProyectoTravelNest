using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class elegirinmueble : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["pagina"] = "reglas";
            if (!IsPostBack)
            {
                if (Session["pagina"].Equals("reglas"))
                {
                    h1_titulo.InnerText = "Agregar, modificar o eliminar una regla";
                }
                else if (Session["pagina"].Equals("promociones"))
                {
                    h1_titulo.InnerText = "Agregar, modificar o eliminar una promoción";
                }
                else if (Session["pagina"].Equals("descuentos"))
                {
                    h1_titulo.InnerText = "Agregar, modificar o eliminar un descuento";
                }
                else if (Session["pagina"].Equals("calendario"))
                {
                    h1_titulo.InnerText = "Seleccione el alojamiento que desee cambiar fecha disponible";
                }
                else
                {
                    h1_titulo.InnerText = " - Error -";
                }
                ContentPlaceHolder mainContent = (ContentPlaceHolder)this.Master.FindControl("MainContent");
                Control div_row = mainContent.FindControl("row");

                Dictionary<string, string> images = imagenes();

                foreach (KeyValuePair<string, string> image in images)
                {
                    LiteralControl htmlSnippet = new LiteralControl();
                    htmlSnippet.Text = $@"
                                    <div class='col-lg-3 col-md-5 p-0 mb-5 me-4 bg-white rounded'>
                                        <a href='/pages/reglas.aspx?IdInmueble={image.Key}' class='text-decoration-none' style='color: initial;'>
                                            <div class='package-item bg-white mb-2'>
                                                <img class='img-fluid' src='data:image/jpeg;base64,{image.Value}' style='border-radius: 7px;'>
                                                <div style='clear: both;'>
                                                    <h5 class='ms-1'>Islas Canarias</h5>
                                                    <label class='text-muted'>Lorem ipsum dolor sit amet consectetur adipisicing elit.
                                                        Vero quae ipsum quas accusantium eum, consectetur...</label>
                                                    <div class='border-top mt-4 pt-4'>
                                                        <div class='d-flex justify-content-around'>
                                                            <h6 class='m-0'><i class='fa fa-star text-primary'></i>4.5
                                                                <small>(250)</small></h6>
                                                            <h5 class='m-0'>$350</h5>
                                                            <p><b>por noche</b></p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </a>
                                    </div>";
                    div_row.Controls.Add(htmlSnippet);
                }

                    
            }
        }

        public Dictionary<string, string> imagenes()
        {
            string connectionString = "Data Source=tiusr21pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019;Initial Catalog=ProyectoG6;Persist Security Info=True;User ID=Proyecto;Password=Proyecto#12345";
            Dictionary<string, string> images = new Dictionary<string, string>();
            string queryString = "SELECT IdInmueble, MAX(Imagen) as Imagen FROM ImagenesxInmueble GROUP BY IdInmueble";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["IdInmueble"].ToString();
                            byte[] imageBytes = (byte[])reader["Imagen"];
                            string base64String = Convert.ToBase64String(imageBytes);
                            images.Add(id, base64String);
                        }
                    }
                    connection.Close();
                }
            }
            return images;
        }
    }



}