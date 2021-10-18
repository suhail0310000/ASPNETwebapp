using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ukeoppg1.Models
{
    public class Ordre
    {
        public int Id { get; set; }
        public string Dato { get; set; }
        public virtual Kunde Kunde { get; set; }
        public virtual List<OrdreLinje> OrdreLinjer { get; set; }
    }
}
