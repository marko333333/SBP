using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firmaLibrary.Entiteti;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class ProjekatView
    {
        public virtual int ID { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string? Opis { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual DateTime Datum_pocetka { get; set; }
        public virtual int? Budzet { get; set; }
        public virtual string Status { get; set; }
        public virtual DateTime Planirani_Zavrsetak { get; set; }
        public virtual DateTime? Stvarni_Zavrsetak { get; set; }

        public ProjekatView() { }

        internal ProjekatView(Projekat projekat)
        {
            ID = projekat.ID;
            Naziv = projekat.Naziv;
            Opis = projekat.Opis;
            Lokacija = projekat.Lokacija;
            Datum_pocetka = projekat.Datum_pocetka;
            Budzet = projekat.Budzet;
            Status = projekat.Status;
            Planirani_Zavrsetak = projekat.Planirani_Zavrsetak;
            Stvarni_Zavrsetak = projekat.Stvarni_Zavrsetak;
        }
    }
}
