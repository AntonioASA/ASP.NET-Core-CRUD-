using System;
using System.Collections.Generic;

namespace AplicacionCRUD.Models
{
    public partial class Colonia
    {
        public long IdColonia { get; set; }
        public long? IdDelMun { get; set; }
        public string Nombre { get; set; }

        public virtual DelegacionMunicipio IdDelMunNavigation { get; set; }
    }
}
