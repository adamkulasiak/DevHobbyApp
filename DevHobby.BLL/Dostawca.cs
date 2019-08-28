using DevHobby.Common;
using System;

namespace DevHobby.BLL
{
    /// <summary>
    /// Zarzadza dostawcami od ktorych kupujemy nasze produkty
    /// </summary>
    public class Dostawca
    {
        public enum DolaczAdres { Tak, Nie };
        public enum WyslijKopie { Tak, Nie };

        #region wlasciwosci
        public int DostawcaId { get; set; }
        public string NazwaFirmy { get; set; }
        public string Email { get; set; }

        #endregion

        #region metody
        /// <summary>
        /// Wysyla wiadomosc email, aby powitac nowego dostawce
        /// </summary>
        /// <param name="wiadomosc"></param>
        /// <returns></returns>
        public string WyslijEmailWitamy(string wiadomosc)
        {
            var emailService = new EmailService();
            var temat = ("Witaj " + this.NazwaFirmy).Trim();
            var potwierdzenie = emailService.WyslijWiadomosc(temat, wiadomosc, this.Email);

            return potwierdzenie;
        }

        /// <summary>
        /// Wysyla zamowienie na produkt do dostawcy
        /// </summary>
        /// <param name="produkt">Produkt do zamowienia</param>
        /// <param name="ilosc">Ilosc produktu do zamowienia</param>
        /// <param name="data">Data dostawy zamowienia</param>
        /// <param name="instrukcje">Instrukcje dostawy</param>
        /// <returns></returns>
        public WynikOperacji ZlozZamowienie(Produkt produkt, int ilosc, DateTimeOffset? data = null, string instrukcje = "Standardowa dostawa")
        {
            if (produkt == null)
                throw new ArgumentNullException(nameof(produkt));
            if (ilosc <= 0)
                throw new ArgumentOutOfRangeException(nameof(ilosc));
            if (data <= DateTimeOffset.Now)
                throw new ArgumentOutOfRangeException(nameof(data));

            var sukces = false;

            var tekstZamowienia = "Zamowienie z DevHobby.pl" + Environment.NewLine +
                                       "Produkt: " + produkt.KodProduktu + Environment.NewLine +
                                       "Ilość: " + ilosc;

            if (data.HasValue)
            {
                tekstZamowienia += Environment.NewLine + "Data dostawy: " + data.Value.ToString("d");
            }

            if (!string.IsNullOrWhiteSpace(instrukcje))
            {
                tekstZamowienia += Environment.NewLine + "Instrukcje: " + instrukcje;
            }

            var emailService = new EmailService();
            var potwierdzenie = emailService.WyslijWiadomosc("Nowe zamowienie", tekstZamowienia, this.Email);

            if (potwierdzenie.StartsWith("Wiadomosc wyslana"))
                sukces = true;

            var wynikOperacji = new WynikOperacji(sukces, tekstZamowienia);

            return wynikOperacji;
        }

        /// <summary>
        /// Wysyla zamowienie na produkt do dostawcy
        /// </summary>
        /// <param name="produkt">Produkt do zamowienia</param>
        /// <param name="ilosc">Ilosc produktu do zamowienia</param>
        /// <param name="dolaczAdres">true jesli zawiera adres wysylki</param>
        /// <param name="wyslijKopie">true jesli wysylamy kopie wiadomosci email</param>
        /// <returns>flaga sukcesu i tekst zamowienia</returns>
        public WynikOperacji ZlozZamowienie(Produkt produkt, int ilosc, DolaczAdres dolaczAdres, WyslijKopie wyslijKopie)
        {
            var tekstZamowienia = "Tekst zamowienia";

            if (dolaczAdres == DolaczAdres.Tak)
                tekstZamowienia += " Dołączamy adres";

            if (wyslijKopie == WyslijKopie.Tak)
                tekstZamowienia += " Wysyłamy kopie";

            var wynikOperacji = new WynikOperacji(true, tekstZamowienia);

            return wynikOperacji;
        }
        #endregion
    }
}
