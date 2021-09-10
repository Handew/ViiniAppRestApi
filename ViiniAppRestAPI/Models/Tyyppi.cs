using System;
using System.Collections.Generic;

#nullable disable

namespace ViiniAppRestAPI.Models
{
    public partial class Tyyppi
    {
        public Tyyppi()
        {
            Viinits = new HashSet<Viinit>();
        }

        public int TyyppiId { get; set; }
        public string Tyyppi1 { get; set; }

        public virtual ICollection<Viinit> Viinits { get; set; }
    }
}
