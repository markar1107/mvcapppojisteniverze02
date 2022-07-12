using System.ComponentModel.DataAnnotations;

namespace mvcapppojisteniverze02.Models
{
    public class ZaznamPojisteni
    {
        public int ZaznamPojisteniID { get; set; }
        public int KlientID { get; set; }
        [Display(Name = "Produkt")]
        public int ProduktID { get; set; }
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
