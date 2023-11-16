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

        public void compararImagenes(string IdUsuario, byte[] img1, byte[] img2)
        {

            var rekognitionClient = new AmazonRekognitionClient("AKIAZ32ALRGQS5YMFRTJ", "jcF/edCr7vHvtJr/saAY6KM7WImeakyGbCMgXnL+", Amazon.RegionEndpoint.USEast1);

            var compareFacesRequest = new CompareFacesRequest
            {
                SourceImage = new Amazon.Rekognition.Model.Image { Bytes = new MemoryStream(img1) },
                TargetImage = new Amazon.Rekognition.Model.Image { Bytes = new MemoryStream(img2) },
                SimilarityThreshold = 0F,
            };

            var compareFacesResponse = rekognitionClient.CompareFacesAsync(compareFacesRequest).Result;

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
    }
}
