using System;
using System.Collections.Generic;

#nullable disable

namespace ViiniAppRestAPI.Models
{
    public partial class Rypale
    {
        public Rypale()
        {
            Viinits = new HashSet<Viinit>();
        }

        public int RypaleId { get; set; }
        public string Rypale1 { get; set; }

        public virtual ICollection<Viinit> Viinits { get; set; }
    }
}
