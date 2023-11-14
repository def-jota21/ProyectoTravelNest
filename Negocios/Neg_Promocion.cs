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
    public class Neg_Promocion
    {
        public void crud(Entidades.Promocion promocion, String opcion)
        {
            try
            {
                string strNombreSP = "CRUDPromociones";
                List<SqlParameter> lstParametros = new List<SqlParameter>();
                lstParametros.Add(new SqlParameter("@Opcion", opcion));
                lstParametros.Add(new SqlParameter("@NombrePromocion", promocion.Nombre));
                lstParametros.Add(new SqlParameter("@Detalle", promocion.Detalle));
                lstParametros.Add(new SqlParameter("@IdInmueble", promocion.IdInmueble));
                lstParametros.Add(new SqlParameter("@IdPromocion", promocion.IdPromocion));

                Datos.ConexionSQL.ExecuteQuery(strNombreSP, lstParametros);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable getPromociones(String IdInmueble)
        {
            DataTable dt = new DataTable();
            string strNombreSP = "CRUDPromociones";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", "Consultar"));
            lstParametros.Add(new SqlParameter("@IdInmueble", IdInmueble));
            dt = ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);
            return dt;
        }
    }
}
