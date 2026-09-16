using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class ZadatakView
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public decimal ProcenjeniTrosak { get; set; }
        public DateTime PlaniraniZavrsetak { get; set; }
        public DateTime? StvarniZavrsetak { get; set; }
        public DateTime PlaniraniPocetak { get; set; }
        public DateTime? StvarniPocetak { get; set; }
        public int Prioritet { get; set; }
        public string Status { get; set; }
        public int FazaId { get; set; }
        public int? RoditeljId { get; set; }

        public virtual IList<Zadatak>? Podzadaci { get; set; }
        public virtual IList<RadniNalog> RadniNalozi { get; set; }
        public virtual IList<Napredak> Napreci { get; set; }
        public virtual IList<KontrolaKvaliteta> KontroleKvaliteta { get; set; }
        public virtual IList<Angazovan> Angazovani { get; set; }
        public virtual IList<Angazuje> AngazovanaOprema { get; set; }

        public virtual IList<Koristi> Koristi { get; set; }

        public ZadatakView()
        {
        }

        internal ZadatakView(Zadatak zadatak)
        {
            Id = zadatak.Id;
            Naziv = zadatak.Naziv;
            Opis = zadatak.Opis;
            ProcenjeniTrosak = zadatak.ProcenjeniTrosak;
            PlaniraniZavrsetak = zadatak.PlaniraniZavrsetak;
            StvarniZavrsetak = zadatak.StvarniZavrsetak;
            PlaniraniPocetak = zadatak.PlaniraniPocetak;
            StvarniPocetak = zadatak.StvarniPocetak;
            Prioritet=zadatak.Prioritet;
            Status=zadatak.Status;
            FazaId = zadatak.Faza.Id;
            RoditeljId = zadatak.Roditelj?.Id;
        }
    }
}
