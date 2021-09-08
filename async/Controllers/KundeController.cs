using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        /*Det er blitt en standard i. .Net.Core å bruke asynkron programmering mot databasen. 
         * Dette for å kunne håndtere store mengder trafikk inn på et system når skriving til disk er en flaskehals. Derfor bruker jeg aync */

        public async Task<bool> Lagre(Kunde innKunde)
        {
            try
            {
                _DB.Kunder.Add(innKunde);
                await _DB.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<List<Kunde>> HentAlle()
        {
            try
            {
                List<Kunde> alleKundene = await _DB.Kunder.ToListAsync();
                return alleKundene;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Slett(int id)
        {
            try
            {
                Kunde enKunde = await _DB.Kunder.FindAsync(id);
                _DB.Kunder.Remove(enKunde);
                await _DB.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<Kunde> HentEn(int id)
        {
            try
            {
                Kunde enKunde = await _DB.Kunder.FindAsync(id);
                return enKunde;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Endre(Kunde endreKunde)
        {
            try
            {
                Kunde enKunde = await _DB.Kunder.FindAsync(endreKunde.Id);
                enKunde.navn = endreKunde.navn;
                enKunde.adresse = endreKunde.adresse;
                enKunde.tlf = endreKunde.tlf;
                enKunde.antall = endreKunde.antall;
                await _DB.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
