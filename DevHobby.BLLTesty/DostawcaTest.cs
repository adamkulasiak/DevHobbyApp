using System;
using DevHobby.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevHobby.BLLTesty
{
    [TestClass]
    public class DostawcaTest
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
    }
}
