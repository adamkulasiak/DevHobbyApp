using System;

namespace DevHobby.BLL
{
    /// <summary>
    /// Zarzadza produktami
    /// </summary>
    public class Produkt
    {
        public Produkt()
        {
            Console.WriteLine("Produkt zostal utworzony");
        }

        public Produkt(int produktId, string nazwaProduktu, string opis) : this()
        {
           this.ProduktId = produktId;
           this.NazwaProduktu = nazwaProduktu;
           this.Opis = opis;
            Console.WriteLine("Produkt ma nazwe " + nazwaProduktu);
        }

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

        public string PowiedzWitaj()
        {
            return "Witaj " + NazwaProduktu + "(" + ProduktId + "): " + Opis;
        }
    }
}
