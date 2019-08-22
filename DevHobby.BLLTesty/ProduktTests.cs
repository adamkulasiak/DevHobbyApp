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
            var oczekiwana = "Witaj Biurko(1): Czerwone biurko";

            //act
            var aktualna = produkt.PowiedzWitaj();

            //assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}