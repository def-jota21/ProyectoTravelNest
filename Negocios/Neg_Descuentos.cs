using Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Neg_Descuentos
    {
        public void crud(Entidades.Descuentos descuento, String opcion)
        {
            try
            {
                string strNombreSP = "CRUDDescuentos";
                List<SqlParameter> lstParametros = new List<SqlParameter>();
                lstParametros.Add(new SqlParameter("@Opcion", opcion));
                lstParametros.Add(new SqlParameter("@Porcentaje", descuento.Porcentaje));
                lstParametros.Add(new SqlParameter("@IdInmueble", descuento.IdInmueble));
                lstParametros.Add(new SqlParameter("@IdDescuento", descuento.IdDescuento));

                Datos.ConexionSQL.ExecuteQuery(strNombreSP, lstParametros);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable getDescuentos(String IdInmueble)
        {
            DataTable dt = new DataTable();
            string strNombreSP = "CRUDDescuentos";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", "Consultar"));
            lstParametros.Add(new SqlParameter("@IdInmueble", IdInmueble));
            dt = ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);
            return dt;
        }
    }
}
