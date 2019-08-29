using System;
using DevHobby.BLL;
using DevHobby.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevHobby.BLL.Tests
{
    [TestClass]
    public class DostawcaTests
    {
        [TestMethod]
        public void WyslijEmailWitamy_PrawidlowaNazwaFirmy_Sukces()
        {
            //arrange
            var dostawca = new Dostawca();
            dostawca.NazwaFirmy = "DevHobby";
            var oczekiwana = "Wiadomosc wyslana: Witaj DevHobby";

            //act
            var aktualna = dostawca.WyslijEmailWitamy("Wiadomosc testowa");

            //assert
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod]
        public void WyslijEmailWitamy_PustaNazwaFirmy_Sukces()
        {
            //arrange
            var dostawca = new Dostawca();
            dostawca.NazwaFirmy = "";
            var oczekiwana = "Wiadomosc wyslana: Witaj";

            //act
            var aktualna = dostawca.WyslijEmailWitamy("Wiadomosc testowa");

            //assert
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod]
        public void WyslijEmailWitamy_NullNazwaFirmy_Sukces()
        {
            //arrange
            var dostawca = new Dostawca();
            dostawca.NazwaFirmy = null;
            var oczekiwana = "Wiadomosc wyslana: Witaj";

            //act
            var aktualna = dostawca.WyslijEmailWitamy("Wiadomosc testowa");

            //assert
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void ZlozZamowienieTest()
        {
            //arrange
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "Opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Zamowienie z DevHobby.pl\r\nProdukt: Informatyka - 1\r\nIlość: 10\r\nInstrukcje: Standardowa dostawa");

            //act
            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 10);

            //assert
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Wiadomosc, wartoscAktualna.Wiadomosc);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ZlozZamowienie_NullProdukt_ExceptionTest()
        {
            //arrange
            var dostawca = new Dostawca();

            //act
            var wartoscAktualna = dostawca.ZlozZamowienie(null, 10);

            //assert
            //oczekiwany wyjatek
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ZlozZamowienie_Ilosc_ExceptionTest()
        {
            //arrange
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "Opis");

            //act
            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 0);

            //assert
            //oczekiwany wyjatek
        }

        [TestMethod()]
        public void ZlozZamowienie3ParametryTest()
        {
            //arrange
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "Opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Zamowienie z DevHobby.pl\r\nProdukt: Informatyka - 1\r\nIlość: 10\r\nData dostawy: 2020/04/22\r\nInstrukcje: Standardowa dostawa");

            //act
            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 10, new DateTimeOffset(2020, 4, 22, 0, 0, 0, new TimeSpan(8, 0, 0)));

            //assert
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Wiadomosc, wartoscAktualna.Wiadomosc);
        }

        [TestMethod()]
        public void ZlozZamowienie4ParametryTest()
        {
            //arrange
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "Opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Zamowienie z DevHobby.pl\r\nProdukt: Informatyka - 1\r\nIlość: 10\r\nData dostawy: 2020/04/22\r\nInstrukcje: testowe instrukcje");

            //act
            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 10, new DateTimeOffset(2020, 4, 22, 0, 0, 0, new TimeSpan(8, 0, 0)), "testowe instrukcje");

            //assert
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Wiadomosc, wartoscAktualna.Wiadomosc);
        }

        [TestMethod()]
        public void ZlozZamowienieBrakDatyTest()
        {
            //arrange
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "Opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Zamowienie z DevHobby.pl\r\nProdukt: Informatyka - 1\r\nIlość: 10\r\nInstrukcje: testowe instrukcje");

            //act
            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 10, instrukcje: "testowe instrukcje");

            //assert
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Wiadomosc, wartoscAktualna.Wiadomosc);
        }

        [TestMethod()]
        public void ZlozZamowienie_DolaczAdresTest()
        {
            //arrange
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "Opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Tekst zamowienia Dołączamy adres");

            //act
            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 10, Dostawca.DolaczAdres.Tak, Dostawca.WyslijKopie.Nie);

            //assert
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Wiadomosc, wartoscAktualna.Wiadomosc);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            //arrange
            var dostawca = new Dostawca();
            dostawca.DostawcaId = 2;
            dostawca.NazwaFirmy = "DevHobby";
            var oczekiwana = "Dostawca: DevHobby";

            //act
            var aktualna = dostawca.ToString();

            //assert
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void ZwrocTekstTest()
        {
            //arrange
            var dostawca = new Dostawca();
            var oczekiwana = @"Wstawiam \r\n nowa linia";

            //act
            var aktualna = dostawca.ZwrocTekst();
            Console.WriteLine(aktualna);

            //assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}
