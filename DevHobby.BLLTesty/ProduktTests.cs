using DevHobby.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevHobby.DLL.Tests
{
    [TestClass()]
    public class ProduktTests
    {
        [TestMethod()]
        public void PowiedzWitajTest()
        {
            //arrange
            var produkt = new Produkt();
            produkt.ProduktId = 1;
            produkt.NazwaProduktu = "Biurko";
            produkt.Opis = "Czerwone biurko";
            produkt.DostawcaProduktu.NazwaFirmy = "DevHobby";
            var oczekiwana = "Witaj Biurko(1): Czerwone biurko Dostepny od: ";

            //act
            var aktualna = produkt.PowiedzWitaj();

            //assert
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void PowiedzWitaj_SparametryzowanyKonstruktorTest()
        {
            //arrange
            var produkt = new Produkt(1, "Biurko", "Czerwone biurko");
            var oczekiwana = "Witaj Biurko(1): Czerwone biurko Dostepny od: ";

            //act
            var aktualna = produkt.PowiedzWitaj();

            //assert
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void PowiedzWitaj_InicjalizatorObiektuTest()
        {
            //arrange
            var produkt = new Produkt
            {
                ProduktId = 1,
                NazwaProduktu = "Biurko",
                Opis = "Czerwone biurko"
            };
            var oczekiwana = "Witaj Biurko(1): Czerwone biurko Dostepny od: ";

            //act
            var aktualna = produkt.PowiedzWitaj();

            //assert
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void Produkt_NullTest()
        {
            //arrange
            Produkt produkt = null;
            string oczekiwana = null;

            //act
            var aktualna = produkt?.DostawcaProduktu?.NazwaFirmy;

            //assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}