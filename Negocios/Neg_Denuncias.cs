using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocios
{
    public class Neg_Denuncias
    {
        string _idDenuncia, _idDenunciante, _idDenunciado, _motivoDenuncia, _sancion, _tipoUsuario, _descripcionDenuncia, _estado, _rol, idUsuario, _instruccion;
        DenunciasBD gestorDenuncias = new DenunciasBD();

        #region PROPIEDADES
        public string IdDenuncia { get => _idDenuncia; set => _idDenuncia = value; }
        public string IdDenunciante { get => _idDenunciante; set => _idDenunciante = value; }
        public string IdDenunciado { get => _idDenunciado; set => _idDenunciado = value; }
        public string MotivoDenuncia { get => _motivoDenuncia; set => _motivoDenuncia = value; }
        public string Sancion { get => _sancion; set => _sancion = value; }
        public string TipoUsuario { get => _tipoUsuario; set => _tipoUsuario = value; }
        public string DescripcionDenuncia { get => _descripcionDenuncia; set => _descripcionDenuncia = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Instruccion { get => _instruccion; set => _instruccion = value; }
        public string Rol { get => _rol; set => _rol = value; }
        public string IdUsuario { get => idUsuario; set => idUsuario = value; }

        #endregion

        #region MetodosCRUD

        public void CRUDDenuncias()
        {
            gestorDenuncias.CRUDDenunciasBD(IdDenuncia, IdDenunciante, IdDenunciado, MotivoDenuncia, Sancion, TipoUsuario, DescripcionDenuncia, Estado, Instruccion);
        }

        public DataSet ObtenerDenunciasGestor()
        {
            return gestorDenuncias.ObtenerDataDenunciasGestorBD(Instruccion);
        }

        public DataSet ObtenerDenunciasPorId()
        {
            return gestorDenuncias.ObtenerDataDenunciasPorID(Instruccion, IdDenunciante);
        }

        public DataSet GetDataInmueble()
        {
            return gestorDenuncias.GetInmuebles(IdUsuario, Rol);
        }

        #endregion
    }
}
