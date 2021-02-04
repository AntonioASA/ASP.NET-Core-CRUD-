using System;
using System.Collections.Generic;

namespace AplicacionCRUD.Models
{
    public partial class Usuarios
    {
        public long IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Email { get; set; }
        public long? Telefono { get; set; }
    }
}
