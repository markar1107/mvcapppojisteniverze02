using System.ComponentModel.DataAnnotations;

namespace mvcapppojisteniverze02.Models
{
    public class Produkt
    {
        public int ProduktID { get; set; }
        [Display(Name = "Název")]
        [Required(ErrorMessage = "Vyplňte název")]
        [StringLength(100, ErrorMessage = "Název je příliš dlouhý, max.100 znaků")]
        public string Nazev { get; set; }
        [Required(ErrorMessage = "Vyplňte popis")]
        public string Popis{ get; set; }

        public ICollection<ZaznamPojisteni> ZaznamPojisteniKolekce { get; set; }
    }
}
