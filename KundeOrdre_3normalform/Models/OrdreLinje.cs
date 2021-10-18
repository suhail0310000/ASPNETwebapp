using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ukeoppg1.Models
{
    public class OrdreLinje
    {
        public int Id { get; set; }
        public int Antall { get; set; }
        public virtual Vare Vare { get; set; }
        public virtual Ordre Ordre { get; set; }
    }
}
