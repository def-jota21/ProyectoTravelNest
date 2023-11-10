using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocios
{
    public class Neg_filtrarcategorias
    {
        public DataTable ObtenerTodasLasCategorias()
        {
            string spName = "[Proyecto].[Sp_TraerCategorias]";
            var lstParametros = new List<SqlParameter>(); // No hay parámetros para este procedimiento almacenado

            Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
            return iConexion.ExecuteSPWithDT(spName, lstParametros);
        }


    }
}