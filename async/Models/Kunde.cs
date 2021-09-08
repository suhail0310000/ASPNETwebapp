using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ukeoppg1.Models
{
    public class Kunde
    {
        public int Id { get; set; }
        public string navn { get; set; }
        public string adresse { get; set; }
        public string tlf { get; set; }

        public int antall { get; set; }
    }
}

