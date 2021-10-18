using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ukeoppg1.Models;

namespace ukeoppg1.Controllers
{
    [Route("[controller]/[action]")]
    public class KundeController : ControllerBase
    {
        private readonly DB _DB;

        public KundeController(DB Db)
        {
            _DB = Db;
        }

        public List<Kunde> index()
        {
            return _DB.Kunde.ToList();
        }
    }
}
