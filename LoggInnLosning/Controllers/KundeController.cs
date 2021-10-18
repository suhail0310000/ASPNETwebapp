using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ukeoppg1.DAL;
using ukeoppg1.Models;

namespace ukeoppg1.Controllers
{
    [Route("[controller]/[action]")]
    public class KundeController : ControllerBase
    {
        private readonly IKundeRepository _DB;

        private ILogger<KundeController> _log;

        public KundeController(IKundeRepository Db, ILogger<KundeController> log)
        {
            _DB = Db;
            _log = log;
        }
        
        public async Task<ActionResult> Lagre(Kunde innKunde)
        {
            if (ModelState.IsValid)
            {
                bool returOK = await _DB.Lagre(innKunde);
                if (!returOK)
                {
                    _log.LogInformation("Kunden ble ikke lagret");
                    return BadRequest("Kunden ble ikke lagret");
                }
                return Ok("Kunden ble lagret");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i input validering");
           
        }

        public async Task<ActionResult> HentAlle()
        {
            List<Kunde> alleKunder = await _DB.HentAlle();
            return Ok(alleKunder);
        }

        public async Task<ActionResult> Slett(int id)
        {
            bool returOK = await _DB.Slett(id);
            if (!returOK)
            {
                _log.LogInformation("Kunden ble ikke sletter");
                return BadRequest("Kunden ble ikke slettet");
            }
            return Ok("Kunden ble slettet");
        }

        public async Task<ActionResult> HentEn(int id)
        {
            Kunde enKunde = await _DB.HentEn(id);
            if (enKunde == null)
            {
                _log.LogInformation("Fant ikke kunden");
                return BadRequest("Fant ikke kunden");
            }
            return Ok("Kunde funnet");
        }
        public async Task<ActionResult> Endre(Kunde endreKunde)
        {
            if (ModelState.IsValid)
            {
                bool returOK = await _DB.Endre(endreKunde);
                if (!returOK)
                {
                    _log.LogInformation("Kunden ble ikke endret");
                    return NotFound("Kunden ble ikke endret");
                }
                return Ok("Kunden ble endret");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i input validering");

        }

        public async Task<ActionResult> LoggInn(Bruker bruker)
        {
            if (ModelState.IsValid)
            {
                bool returnOK = await _DB.LoggInn(bruker);
                if (!returnOK)
                {
                    _log.LogInformation("Innloggingen feilet for bruker" + bruker.Brukernavn);
                    return Ok(false);
                }
                return Ok(true);
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }
    }
}
