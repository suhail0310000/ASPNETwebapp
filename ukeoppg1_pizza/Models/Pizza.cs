using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ukeoppg1.Models
{
    public class Pizza
    {
        public string PizzaType { get; set; }
        public string Tykkelse { get; set; }
        public int Antall { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public string Telefonnr { get; set; }
    }
}
