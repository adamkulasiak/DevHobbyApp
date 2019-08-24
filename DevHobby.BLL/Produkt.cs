using DevHobby.Common;
using static DevHobby.Common.LogowanieService;
using System;

namespace DevHobby.BLL
{
    /// <summary>
    /// Zarzadza produktami
    /// </summary>
    public class Produkt
    {
        #region konstruktory
        public Produkt()
        {
            Console.WriteLine("Produkt zostal utworzony");
            //this.DostawcaProduktu = new Dostawca();
        }

        public Produkt(int produktId, string nazwaProduktu, string opis) : this()
        {
            this.ProduktId = produktId;
            this.NazwaProduktu = nazwaProduktu;
            this.Opis = opis;
            Console.WriteLine("Produkt ma nazwe " + nazwaProduktu);
        }

        #endregion

        #region Pola i wlasciwosci
        private int produktId;

        public int ProduktId
        {
            get { return produktId; }
            set { produktId = value; }
        }

        private string nazwaProduktu;

        public string NazwaProduktu
        {
            get { return nazwaProduktu; }
            set { nazwaProduktu = value; }
        }

        private string opis;

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        private Dostawca dostawcaProduktu;

        public Dostawca DostawcaProduktu
        {
            get
            {
                if (dostawcaProduktu == null)
                {
                    dostawcaProduktu = new Dostawca();
                }
                return dostawcaProduktu;
            }
            set { dostawcaProduktu = value; }
        }
        #endregion

        public string PowiedzWitaj()
        {
            //var dostawca = new Dostawca();
            //dostawca.WyslijEmailWitamy("Wiadomosc z produktu");

            var emailService = new EmailService();
            var potwierdzenie = emailService.WyslijWiadomosc("Nowy produkt", this.NazwaProduktu, "marketing@dev-hobby.pl");

            var wynik = Logowanie("Powiedziano witaj");

            return "Witaj " + NazwaProduktu + "(" + ProduktId + "): " + Opis;
        }
    }
}
