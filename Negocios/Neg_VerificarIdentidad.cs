using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Datos;
using System.Text.RegularExpressions;

namespace Negocios
{
    public class Neg_VerificarIdentidad
    {
        public DataTable getVerificacionIdentidad(String IdUsuario)
        {
            DataTable dt = new DataTable();
            string strNombreSP = "VerificarIdentidad";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", "Consultar"));
            lstParametros.Add(new SqlParameter("@IdUsuario", IdUsuario));
            dt = ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);
            return dt;
        }

        public String getEstado(string IdUsuario)
        {
            DataTable dt = new DataTable();
            string strNombreSP = "VerificarIdentidad";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", "Estado"));
            lstParametros.Add(new SqlParameter("@IdUsuario", IdUsuario));
            dt = ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);
            return dt.Rows[0]["Estado"].ToString();
        }

        private void verificacion(String IdUsuario, byte[] Documento, byte[] Rostro, String Estado)
        {
            DataTable dt = new DataTable();
            string strNombreSP = "VerificarIdentidad";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", "Verificar"));
            lstParametros.Add(new SqlParameter("@IdUsuario", IdUsuario));
            lstParametros.Add(new SqlParameter("@Documento", Documento));
            lstParametros.Add(new SqlParameter("@Rostro", Rostro));
            lstParametros.Add(new SqlParameter("@Estado", Estado));
            ConexionSQL.ExecuteQuery(strNombreSP, lstParametros);
        }
        private void cancelar(String IdUsuario)
        {
            DataTable dt = new DataTable();
            string strNombreSP = "VerificarIdentidad";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", "Cancelar"));
            lstParametros.Add(new SqlParameter("@IdUsuario", IdUsuario));
            ConexionSQL.ExecuteQuery(strNombreSP, lstParametros);
        }

        public async Task compararCedula(string IdUsuario, byte[] img1)
        {
            String texto = await ObtenerTexto(img1, 0.0f, 0.0f, 1.0f, 0.6667f);
            Match match = Regex.Match(texto.Replace(" ",""), "\\d{9}");
            String Id = Regex.Replace(IdUsuario, "[ -]", "");
            if (!match.Value.Equals(Id))
            {
                cancelar(IdUsuario);
                throw new Exception("El número de cédula presente en la imagen no coincide con el registrado en nuestro sistema.");
            }
        }

        public async Task compararImagenes(string IdUsuario, byte[] img1, byte[] img2)
        {
            var rekognitionClient = new AmazonRekognitionClient("AKIAZ32ALRGQS5YMFRTJ", "jcF/edCr7vHvtJr/saAY6KM7WImeakyGbCMgXnL+", Amazon.RegionEndpoint.USEast1);

            // Verificar contenido inapropiado en img1
            var detectarInapropiadoImg1 = new DetectModerationLabelsRequest
            {
                Image = new Amazon.Rekognition.Model.Image { Bytes = new MemoryStream(img1) }
            };

            var contenidoInapropiadoRespuestaImg1 = await rekognitionClient.DetectModerationLabelsAsync(detectarInapropiadoImg1);
            if (contenidoInapropiadoRespuestaImg1.ModerationLabels.Any())
            {
                throw new Exception("Se detectó contenido inapropiado en la imagen del documento proporcionada.");
            }

            // Verificar contenido inapropiado en img2
            var detectarInapropiadoImg2 = new DetectModerationLabelsRequest
            {
                Image = new Amazon.Rekognition.Model.Image { Bytes = new MemoryStream(img2) }
            };

            var contenidoInapropiadoRespuestaImg2 = await rekognitionClient.DetectModerationLabelsAsync(detectarInapropiadoImg2);
            if (contenidoInapropiadoRespuestaImg2.ModerationLabels.Any())
            {
                throw new Exception("Se detectó contenido inapropiado en la imagen del rostro proporcionada.");
            }

            var compareFacesRequest = new CompareFacesRequest
            {
                SourceImage = new Amazon.Rekognition.Model.Image { Bytes = new MemoryStream(img1) },
                TargetImage = new Amazon.Rekognition.Model.Image { Bytes = new MemoryStream(img2) },
                SimilarityThreshold = 0F,
            };
            try
            {
                var compareFacesResponse = await rekognitionClient.CompareFacesAsync(compareFacesRequest);
                if (compareFacesResponse.SourceImageFace == null || compareFacesResponse.FaceMatches.Count == 0)
                {
                    throw new Exception("No se detectó un rostro en las imágenes proporcionadas.");
                }

                foreach (var match in compareFacesResponse.FaceMatches)
                {
                    if (match.Similarity > 50)
                    {
                        verificacion(IdUsuario, img1, img2, "A");
                    }
                    else
                    {
                        verificacion(IdUsuario, img1, img2, "R");
                    }
                }
            }
            catch
            {
                throw new Exception("Por favor, verifica que el peso de las imágenes no exceda los 2 MB y que ambas sean del mismo formato, ya sea JPEG o PNG.");
            }
        }

        private async Task<string> ObtenerTexto(byte[] img, float izq, float top, float ancho, float altura)
        {
            var rekognitionClient = new AmazonRekognitionClient("AKIAZ32ALRGQS5YMFRTJ", "jcF/edCr7vHvtJr/saAY6KM7WImeakyGbCMgXnL+", Amazon.RegionEndpoint.USEast1);

            var detectTextRequest = new DetectTextRequest
            {
                Image = new Amazon.Rekognition.Model.Image { Bytes = new MemoryStream(img) }
            };

            var detectTextResponse = await rekognitionClient.DetectTextAsync(detectTextRequest);

            var textoEncontrado = detectTextResponse.TextDetections
                                 .Where(t => t.Type == "LINE" || t.Type == "WORD")
                                 .Where(t => EstaDentroBoundingBox(t.Geometry.BoundingBox, izq, top, ancho, altura))
                                 .Select(t => t.DetectedText)
                                 .Aggregate(string.Empty, (current, text) => current + " " + text);

            return textoEncontrado.Trim() ?? string.Empty;
        }
        private bool EstaDentroBoundingBox(BoundingBox boundingBox, float izq, float top, float ancho, float altura)
        {
            // Verificar si la bounding box del texto detectado está dentro de la región especificada
            return boundingBox.Left >= izq && boundingBox.Top >= top
                && boundingBox.Left + boundingBox.Width <= izq + ancho
                && boundingBox.Top + boundingBox.Height <= top + altura;
        }
    }
}
