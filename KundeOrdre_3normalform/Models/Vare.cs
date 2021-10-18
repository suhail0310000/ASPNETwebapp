using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ukeoppg1.Models
{
    public class Vare
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public double Pris { get; set; }
        public virtual List<OrdreLinje> OrdreLinjer { get; set; }
    }
}
