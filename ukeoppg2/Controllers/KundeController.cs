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

        public bool Lagre(Kunde innKunde)
        {
            try
            {
                _DB.Kunder.Add(innKunde);
                _DB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public List<Kunde> HentAlle()
        {
            try
            {
                List<Kunde> alleKundene = _DB.Kunder.ToList();
                return alleKundene;
            }
            catch
            {
                return null;
            }
        }

        public bool Slett(int id)
        {
            try
            {
                Kunde enKunde = _DB.Kunder.Find(id);
                _DB.Kunder.Remove(enKunde);
                _DB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public Kunde HentEn(int id)
        {
            try
            {
                Kunde enKunde = _DB.Kunder.Find(id);
                return enKunde;
            }
            catch
            {
                return null;
            }
        }

        public bool Endre(Kunde endreKunde)
        {
            try
            {
                Kunde enKunde = _DB.Kunder.Find(endreKunde.Id);
                enKunde.navn = endreKunde.navn;
                enKunde.adresse = endreKunde.adresse;
                enKunde.tlf = endreKunde.tlf;
                enKunde.antall = endreKunde.antall;
                _DB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
