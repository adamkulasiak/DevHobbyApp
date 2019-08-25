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
        public const double CaliNaMetr = 38.87;
        public readonly decimal MinimalnaCena;

        #region konstruktory
        public Produkt()
        {
            Console.WriteLine("Produkt zostal utworzony");
            //this.DostawcaProduktu = new Dostawca();
            this.MinimalnaCena = 10.50m;
            this.Kategoria = "Informatyka";
        }

        public Produkt(int produktId, string nazwaProduktu, string opis) : this()
        {
            this.ProduktId = produktId;
            this.NazwaProduktu = nazwaProduktu;
            this.Opis = opis;
            if (NazwaProduktu.StartsWith("Krzesło"))
            {
                this.MinimalnaCena = 120.99m;
            }
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
            get
            {
                var sformatowanaNazwaProduktu = nazwaProduktu?.Trim();
                return sformatowanaNazwaProduktu;
            }
            set
            {
                if (value.Length < 4)
                {
                    Wiadomosc = "Nazwa produktu musi byc dluzsza niz 4 znaki";
                }
                else if(value.Length > 30)
                {
                    Wiadomosc = "Nazwa produktu musi byc krotsza niz 30 znakow";
                }
                else
                {
                    nazwaProduktu = value;
                }
            }
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

        private DateTime? dataDostepnosci;

        public DateTime? DataDostepnosci
        {
            get { return dataDostepnosci; }
            set { dataDostepnosci = value; }
        }

        public string Wiadomosc { get; private set; }

        public string Kategoria { get; set; }
        public int Numer { get; set; } = 1;


        #endregion

        public string PowiedzWitaj()
        {
            //var dostawca = new Dostawca();
            //dostawca.WyslijEmailWitamy("Wiadomosc z produktu");

            var emailService = new EmailService();
            var potwierdzenie = emailService.WyslijWiadomosc("Nowy produkt", this.NazwaProduktu, "marketing@dev-hobby.pl");

            var wynik = Logowanie("Powiedziano witaj");

            return "Witaj " + NazwaProduktu + "(" + ProduktId + "): " + Opis + 
                    " Dostepny od: " + DataDostepnosci?.ToShortDateString();
        }
    }
}
