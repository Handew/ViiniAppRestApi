using System;
using System.Collections.Generic;

#nullable disable

namespace ViiniAppRestAPI.Models
{
    public partial class Viinit
    {
        public int ViiniId { get; set; }
        public string ViiniNimi { get; set; }
        public int? TyyppiId { get; set; }
        public int? RypaleId { get; set; }
        public int? MaaId { get; set; }
        public decimal? Hinta { get; set; }

        public virtual Maa Maa { get; set; }
        public virtual Rypale Rypale { get; set; }
        public virtual Tyyppi Tyyppi { get; set; }
    }
}
