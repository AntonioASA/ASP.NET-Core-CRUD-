using System;
using System.Collections.Generic;

namespace AplicacionCRUD.Models
{
    public partial class Sales
    {
        public int QuotationNo { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool? BanActivo { get; set; }
    }
}
