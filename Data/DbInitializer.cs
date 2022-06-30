﻿using mvcapppojisteniverze02.Models;

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
                new Klient{Jmeno="Martin", Prijmeni="Kára",Telefon=123},
                new Klient{Jmeno="Aleš",Prijmeni="Bláha",Telefon=456},
            };

            context.Klienti.AddRange(klienti);
            context.SaveChanges();

            var produkty = new Produkt[]
            {
                new Produkt{Nazev="Pojištění domácnosti",Popis="základní pojištění bytu"},
                new Produkt{Nazev="Autopojištění", Popis="standardní pojištění osobního auta do 3500kg"},
            };

            context.Produkty.AddRange(produkty);
            context.SaveChanges();

            var zaznamyPojisteni = new ZaznamPojisteni[]
            {
                new ZaznamPojisteni{KlientID=1,ProduktID=1,Cena=1000,ZacatekPojisteni=DateTime.Parse("2022/02/05"),KonecPojisteni=DateTime.Parse("2023/02/04")},
                new ZaznamPojisteni{KlientID=2,ProduktID=2,Cena=3500,ZacatekPojisteni=DateTime.Parse("2021/08/16"),KonecPojisteni=DateTime.Parse("2022/08/15")},

            };

            context.ZaznamyPojisteni.AddRange(zaznamyPojisteni);
            context.SaveChanges();
        }
    }
}