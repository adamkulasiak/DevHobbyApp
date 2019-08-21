using System;

namespace DevHobby.Common
{
    /// <summary>
    /// zapewnia logowanie
    /// </summary>
    public class LogowanieService
    {
        /// <summary>
        /// Loguje akcje
        /// </summary>
        /// <param name="akcja">Akcja do zalogowania</param>
        /// <returns></returns>
        public string Logowanie(string akcja)
        {
            var tekstDoZalogowania = "Akcja: " + akcja;
            Console.WriteLine(tekstDoZalogowania);

            return tekstDoZalogowania;
        }
    }
}
