using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ukeoppg1.Models
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public virtual List<Ordre> Ordre { get; set; }
    }
}
