using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevHobby.Common.Tests
{
    [TestClass()]
    public class LogowanieServiceTests
    {
        [TestMethod()]
        public void LogowanieTest()
        {
            //arrange
            var oczekiwana = "Akcja: Test Akcja";

            //act
            var aktualna = LogowanieService.Logowanie("Test Akcja");

            //assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}