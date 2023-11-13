using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocios
{
    public class Neg_Reglas
    {
        public void crud(Entidades.Reglas regla, String opcion)
        {
            try
            {
                string strNombreSP = "CRUDReglas";
                List<SqlParameter> lstParametros = new List<SqlParameter>();
                lstParametros.Add(new SqlParameter("@Opcion", opcion));
                lstParametros.Add(new SqlParameter("@NombreRegla", regla.NombreRegla));
                lstParametros.Add(new SqlParameter("@Explicacion", regla.Explicacion));
                lstParametros.Add(new SqlParameter("@IdInmueble", regla.IdInmueble));
                lstParametros.Add(new SqlParameter("@IdRegla", regla.IdRegla));

                Datos.ConexionSQL.ExecuteQuery(strNombreSP, lstParametros);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable getReglas(String IdInmueble)
        {
            DataTable dt = new DataTable();
            string strNombreSP = "CRUDReglas";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", "Consultar"));
            lstParametros.Add(new SqlParameter("@IdInmueble", IdInmueble));
            dt = ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);
            return dt;
        }
    }
}
