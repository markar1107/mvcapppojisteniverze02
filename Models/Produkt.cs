namespace mvcapppojisteniverze02.Models
{
    public class Produkt
    {
        public int ProduktID { get; set; }
        public string Nazev { get; set; }
        public string Popis { get; set; }

        public ICollection<ZaznamPojisteni> ZaznamPojisteniKolekce { get; set; }
    }
}
