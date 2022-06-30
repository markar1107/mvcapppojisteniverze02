namespace mvcapppojisteniverze02.Models
{
    public class ZaznamPojisteni
    {
        public int ZaznamPojisteniID { get; set; }
        public int KlientID { get; set; }
        public int ProduktID { get; set; }
        public int Cena { get; set; }
        public DateTime ZacatekPojisteni { get; set; }
        public DateTime KonecPojisteni { get; set; }

        public Klient Klient { get; set; }
        public Produkt Produkt{ get; set; }
    }
}
