using System;
using Xunit;
using Moq; // Må legge til pakken Moq.EntityFreamworkCore
using KundeApp2.Controllers; // må legge til en prosjektreferanse i Project-> Add Reference -> Project
using KundeApp2.DAL;
using KundeApp2.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace KundeApp2Test
{
    public class KundeControllerTest
    {
        [Fact]
        public async Task HentAlle()
        {
            var kunde1 = new Kunde
            {
                Id = 1,
                Fornavn = "Per",
                Etternavn = "Hansen",
                Adresse = "Askerveien 82",
                Postnr = "1370",
                Poststed = "Asker"
            };
            var kunde2 = new Kunde
            {
                Id = 2,
                Fornavn = "Ole",
                Etternavn = "Olsen",
                Adresse = "Osloveien 82",
                Postnr = "0270",
                Poststed = "Oslo"
            };
            var kunde3 = new Kunde
            {
                Id = 1,
                Fornavn = "Finn",
                Etternavn = "Finnsen",
                Adresse = "Bergensveien 82",
                Postnr = "5000",
                Poststed = "Bergen"
            };

            var kundeListe = new List<Kunde>();
            kundeListe.Add(kunde1);
            kundeListe.Add(kunde2);
            kundeListe.Add(kunde3);

            var mock = new Mock<IKundeRepository>();
            mock.Setup(k => k.HentAlle()).ReturnsAsync(kundeListe); // merk: parantesene, de må stå på rett plass ellers fås rare feilmeldinger!
            var kundeController = new KundeController(mock.Object);
            List<Kunde> resultat = await kundeController.HentAlle();
            Assert.Equal<List<Kunde>>(kundeListe,resultat);
        }

        [Fact]
        public async Task Lagre()
        {
            var innKunde = new Kunde
            {
                Id = 1,
                Fornavn = "Per",
                Etternavn = "Hansen",
                Adresse = "Askerveien 82",
                Postnr = "1370",
                Poststed = "Asker"
            };
            var mock = new Mock<IKundeRepository>();
            mock.Setup(k => k.Lagre(innKunde)).ReturnsAsync(true);
            var kundeController = new KundeController(mock.Object);
            bool resultat = await kundeController.Lagre(innKunde);
            Assert.True(resultat);
        }

        [Fact]
        public async Task HentEn()
        {
            var returKunde = new Kunde
            {
                Id = 1,
                Fornavn = "Per",
                Etternavn = "Hansen",
                Adresse = "Askerveien 82",
                Postnr = "1370",
                Poststed = "Asker"
            };
            var mock = new Mock<IKundeRepository>();
            mock.Setup(k => k.HentEn(1)).ReturnsAsync(returKunde);
            var kundeController = new KundeController(mock.Object);
            Kunde resultat = await kundeController.HentEn(1);
            Assert.Equal<Kunde>(returKunde, resultat);
        }

        [Fact]
        public async Task Slett()
        {
            var mock = new Mock<IKundeRepository>();
            mock.Setup(k => k.Slett(1)).ReturnsAsync(true);
            var kundeController = new KundeController(mock.Object);
            bool resultat = await kundeController.Slett(1);
            Assert.True(resultat);
        }

        [Fact]
        public async Task Endre()
        {
            var innKunde = new Kunde
            {
                Id = 1,
                Fornavn = "Per",
                Etternavn = "Hansen",
                Adresse = "Askerveien 82",
                Postnr = "1370",
                Poststed = "Asker"
            };
            var mock = new Mock<IKundeRepository>();
            mock.Setup(k => k.Endre(innKunde)).ReturnsAsync(true);
            var kundeController = new KundeController(mock.Object);
            bool resultat = await kundeController.Endre(innKunde);
            Assert.True(resultat);
        }
    }
}
