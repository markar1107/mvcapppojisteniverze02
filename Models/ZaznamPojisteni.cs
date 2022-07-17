using System.ComponentModel.DataAnnotations;

namespace mvcapppojisteniverze02.Models
{
    public class ZaznamPojisteni
    {
        public int ZaznamPojisteniID { get; set; }
        [Display(Name = "Klient")]

        public int KlientID { get; set; }
        [Display(Name = "Produkt")]
        public int ProduktID { get; set; }
        [Required(ErrorMessage = "vyplňte předmět pojištění")]
        [Display(Name = "Předmět pojištění")]
        [StringLength(80, ErrorMessage = "popis předmětu pojištění je příliš dlouhý, max.80 znaků")]
        public string PredmetPojisteni { get; set; }
        [Required(ErrorMessage = "Cena musí být zadána")]
        [Range(1, int.MaxValue, ErrorMessage = "Cena nesmí být záporná ani 0")]
        public int Cena { get; set; }
        [Display(Name ="Začátek pojištění")]
        [DataType(DataType.Date)]
        public DateTime ZacatekPojisteni { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Konec Pojištění")]
        public DateTime KonecPojisteni { get; set; }

        public Klient Klient { get; set; }
        public Produkt Produkt{ get; set; }
    }
}
