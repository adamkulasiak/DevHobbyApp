﻿using System;

namespace DevHobby.Common
{
    /// <summary>
    /// zapewnia logowanie
    /// </summary>
    public static class LogowanieService
    {
        /// <summary>
        /// Loguje akcje
        /// </summary>
        /// <param name="akcja">Akcja do zalogowania</param>
        /// <returns></returns>
        public static string Logowanie(string akcja)
        {
            var tekstDoZalogowania = "Akcja: " + akcja;
            Console.WriteLine(tekstDoZalogowania);

            return tekstDoZalogowania;
        }
    }
}
