﻿namespace DevHobby.Common
{
    public class EmailService
    {
        /// <summary>
        /// Wysyla wiadomosc email
        /// </summary>
        /// <param name="temat">Temat wiadomosci</param>
        /// <param name="wiadomosc">Wiadomosc tekstowa</param>
        /// <param name="odbiorca">Adres email odbiorcy wiadomosci</param>
        /// <returns></returns>
        public string WyslijWiadomosc(string temat, string wiadomosc, string odbiorca)
        {
            // kod, aby wyslac wiadomosc email

            var potwierdzenie = "Wiadomosc wyslana: " + temat;
            LogowanieService.Logowanie(potwierdzenie);

            return potwierdzenie;
        }
    }
}
