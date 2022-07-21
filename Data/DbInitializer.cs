using mvcapppojisteniverze02.Models;

namespace mvcapppojisteniverze02.Data
{
    public static class DbInitializer
    {
        public static void Initialize(mvcapppojisteniverze02Context context)
        {
            if (context.Klienti.Any())
            {
                return;
            }

            var klienti = new Klient[]
            {
                new Klient{Jmeno="Martin", Prijmeni="Kára", Telefon=608960709, Email="martin.kara@volny.cz", Ulice="Lábkova 25", Mesto="Plzeň", Psc="318 06"},
                new Klient{Jmeno="Aleš", Prijmeni="Bláha", Telefon=734256825, Email="blaha.ales@seznam.cz", Ulice="Slovanská 254", Mesto="Plzeň", Psc="316 00"},
                new Klient{Jmeno="Lenka", Prijmeni="Pejčeva", Telefon=728287956, Email="lenka.pejceva@seznam.cz", Ulice="U lesa 30", Mesto="Drmoul", Psc="456 01"},
                new Klient{Jmeno="Pavel", Prijmeni="Kaucký", Telefon=602562456, Email="kaucky.pavel@gmail.com", Ulice="Slovanských hrdinů 354", Mesto="Praha", Psc="256 41"},
                new Klient{Jmeno="Robert", Prijmeni="Zubkovský", Telefon=754256489, Email="zubkovsky.robert@tiscali.cz", Ulice="Drážďanská 452", Mesto="Praha", Psc="254 01"},
            };

            context.Klienti.AddRange(klienti);
            context.SaveChanges();

            var produkty = new Produkt[]
            {
                new Produkt{Nazev="Pojištění domácnosti",Popis="základní pojištění bytu nebo rodinného domu"},
                new Produkt{Nazev="Autopojištění osobních vozidel", Popis="standardní pojištění osobního vozidla do 3500kg"},
                new Produkt{Nazev="Autopojištění nákladních vozidel a přívěsů", Popis="standardní pojištění nákladních vozidel nad 3500kg"},
                new Produkt{Nazev="Živostní pojištění", Popis="pojištění mimořádné události úmrtí či poškození zdraví"},
                new Produkt{Nazev="Cestovní pojištění", Popis="pojištění rizik ztráty majetku nebo úrazu při cestování v rámci EU"},
                new Produkt{Nazev="Úrazové pojištění", Popis="pojištění proti úrazu při výkonu zaměstnání či jiné mimopracovní aktivity"},
                new Produkt{Nazev="Pojištění rizik spojených s výkonem podnikatelské činnosti", Popis="pojištění proti neočekávané události omezující podnikání či proti úpadku"},
            };

            context.Produkty.AddRange(produkty);
            context.SaveChanges();

            var zaznamyPojisteni = new ZaznamPojisteni[]
            {
                new ZaznamPojisteni{KlientID=1, ProduktID=1, PredmetPojisteni="byt v osobním vlastnictví", Cena=1000, ZacatekPojisteni=DateTime.Parse("2022/02/05"), KonecPojisteni=DateTime.Parse("2023/02/04")},
                new ZaznamPojisteni{KlientID=1, ProduktID=6, PredmetPojisteni="zdraví osoby", Cena=530, ZacatekPojisteni=DateTime.Parse("2021/08/12"), KonecPojisteni=DateTime.Parse("2022/08/11")},

                new ZaznamPojisteni{KlientID=2 ,ProduktID=2 ,PredmetPojisteni="osobní auto Opel Astra", Cena=3500, ZacatekPojisteni=DateTime.Parse("2021/08/16"), KonecPojisteni=DateTime.Parse("2022/08/15")},
                new ZaznamPojisteni{KlientID=3, ProduktID=7, PredmetPojisteni="kavárna", Cena=8400, ZacatekPojisteni=DateTime.Parse("2022/01/05"), KonecPojisteni=DateTime.Parse("2023/01/04")},
                new ZaznamPojisteni{KlientID=4, ProduktID=5, PredmetPojisteni="život osoby", Cena=580, ZacatekPojisteni=DateTime.Parse("2022/02/14"), KonecPojisteni=DateTime.Parse("2023/08/25")},
                new ZaznamPojisteni{KlientID=5, ProduktID=3, PredmetPojisteni="nákladní auto Mercedes", Cena=8500, ZacatekPojisteni=DateTime.Parse("2021/04/25"), KonecPojisteni=DateTime.Parse("2023/04/24")},


            };

            context.ZaznamyPojisteni.AddRange(zaznamyPojisteni);
            context.SaveChanges();
        }
    }
}
