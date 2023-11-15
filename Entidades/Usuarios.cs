using System;

namespace Entidades
{
    public class Usuarios
    {
        public string IdUsuario { get; set; }
        public string IdUsuarioRegistro { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public char T_Rol { get; set; }
        public int Telefono { get; set; }
        public string Estado { get; set; }

        public byte[] ImagenPerfil { get; set; }
    }
}

