using System;
using System.Collections.Generic;

namespace AplicacionCRUD.Models
{
    public partial class CiudadEstado
    {
        public CiudadEstado()
        {
            DelegacionMunicipio = new HashSet<DelegacionMunicipio>();
        }

        public long IdCiudadEstado { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<DelegacionMunicipio> DelegacionMunicipio { get; set; }
    }
}
