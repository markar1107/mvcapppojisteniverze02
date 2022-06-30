namespace mvcapppojisteniverze02.Models
{
    public class Klient
    {
        public int ID { get; set; }
        public string  Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public int Telefon { get; set; }

        public ICollection<ZaznamPojisteni> ZaznamPojisteniKolekce { get; set; }
    }
}
