using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ukeoppg1.Models;

namespace ukeoppg1.DAL
{
    public interface IKundeRepository
    {
        Task<bool> Lagre(Kunde innKunde);
        Task<List<Kunde>> HentAlle();
        Task<bool> Slett(int id);

        Task<Kunde> HentEn(int id);
        Task<bool> Endre(Kunde endreKunde);


    }
}
