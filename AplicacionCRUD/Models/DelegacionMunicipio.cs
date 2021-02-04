using System;
using System.Collections.Generic;

namespace AplicacionCRUD.Models
{
    public partial class DelegacionMunicipio
    {
        public DelegacionMunicipio()
        {
            Colonia = new HashSet<Colonia>();
        }

        public long IdDelMun { get; set; }
        public long? IdciudadEstado { get; set; }
        public string Nombre { get; set; }

        public virtual CiudadEstado IdciudadEstadoNavigation { get; set; }
        public virtual ICollection<Colonia> Colonia { get; set; }
    }
}
