using System;
using System.Collections.Generic;

#nullable disable

namespace ViiniAppRestAPI.Models
{
    public partial class Maa
    {
        public Maa()
        {
            Viinits = new HashSet<Viinit>();
        }

        public int MaaId { get; set; }
        public string Maa1 { get; set; }

        public virtual ICollection<Viinit> Viinits { get; set; }
    }
}
