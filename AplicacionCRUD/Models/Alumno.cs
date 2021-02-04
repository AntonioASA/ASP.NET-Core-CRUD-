using System;
using System.Collections.Generic;

namespace AplicacionCRUD.Models
{
    public partial class Alumno
    {
        public long IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Email { get; set; }
        public bool? BanActivo { get; set; }
    }
}
