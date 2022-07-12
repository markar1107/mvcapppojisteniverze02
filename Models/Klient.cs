using System.ComponentModel.DataAnnotations;

namespace mvcapppojisteniverze02.Models
{
    public class Klient
    {
        public int ID { get; set; }
        [Display(Name="Jméno")]
        public string  Jmeno { get; set; }
        [Display(Name = "Příjmení")]
        public string Prijmeni { get; set; }

        public int Telefon { get; set; }
        public string Email { get; set; }
        [Display(Name = "Ulice a č.popisné")]
        public string Ulice { get; set; }
        [Display(Name = "Město")]
        public string Mesto { get; set; }
        [Display(Name = "PSČ")]
        public string Psc { get; set; }
        [Display(Name = "Sjednaná pojištění")]
        public ICollection<ZaznamPojisteni> ZaznamPojisteniKolekce { get; set; }
    }
}
