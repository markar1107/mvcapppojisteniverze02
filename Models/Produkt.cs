using System.ComponentModel.DataAnnotations;

namespace mvcapppojisteniverze02.Models
{
    public class Produkt
    {
        public int ProduktID { get; set; }
        [Display(Name = "Název")]
        public string Nazev { get; set; }
        public string Popis{ get; set; }

        public ICollection<ZaznamPojisteni> ZaznamPojisteniKolekce { get; set; }
    }
}
