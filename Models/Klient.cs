using System.ComponentModel.DataAnnotations;

namespace mvcapppojisteniverze02.Models
{
    public class Klient
    {
       
        public int ID { get; set; }

        [Display(Name = "Jméno")]
        [Required(ErrorMessage = "Vyplňte jméno")]
        [StringLength(50, ErrorMessage = "Jméno je příliš dlouhé, max.50 znaků")]
        public string  Jmeno { get; set; }
        [Display(Name = "Příjmení")]
        [Required(ErrorMessage = "Vyplňte příjmení")]
        [StringLength(50, ErrorMessage = "Příjmení je příliš dlouhé, max.50 znaků")]
        public string Prijmeni { get; set; }
        public int Telefon { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Neplatný email")]
        public string Email { get; set; }

        [Display(Name = "Ulice a č.popisné")]
        [Required(ErrorMessage = "Vyplňte adresu")]
        [StringLength(60, ErrorMessage = "Název ulice je příliš dlouhý, max.60 znaků")]
        public string Ulice { get; set; }

        [Display(Name = "Město")]
        [Required(ErrorMessage = "Vyplňte adresu")]
        [StringLength(50, ErrorMessage = "Název města je příliš dlouhý, max.50 znaků")]
        public string Mesto { get; set; }

        [Display(Name = "PSČ")]
        [Required(ErrorMessage = "Vyplňte adresu")]
        [StringLength(6, ErrorMessage = "PSČ je příliš dlouhé, max.6 znaků")]
        public string Psc { get; set; }

        [Display(Name = "Sjednaná pojištění")]
        public ICollection<ZaznamPojisteni> ZaznamPojisteniKolekce { get; set; }
    }
}
