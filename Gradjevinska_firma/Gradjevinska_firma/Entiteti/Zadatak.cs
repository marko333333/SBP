using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Zadatak
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual string Opis { get; set; }
        public virtual decimal ProcenjeniTrosak { get; set; }
        public virtual DateTime? PlaniraniZavrsetak { get; set; }
        public virtual DateTime? StvarniZavrsetak { get; set; }
        public virtual DateTime? PlaniraniPocetak { get; set; }
        public virtual DateTime? StvarniPocetak { get; set; }
        public virtual int Prioritet { get; set; }
        public virtual string Status { get; set; }
        public virtual Faza Faza { get; set; }
        public virtual Zadatak Roditelj { get; set; }

        public virtual IList<Zadatak> Podzadaci { get; set; }
        public virtual IList<RadniNalog> RadniNalozi { get; set; }
        public virtual IList<Napredak> Napreci { get; set; }
        public virtual IList<KontrolaKvaliteta> KontroleKvaliteta { get; set; }
        public virtual IList<Angazovan> Angazovani { get; set; }
        public virtual IList<Angazuje> AngazovanaOprema { get; set; }


        public Zadatak() {

            Podzadaci = new List<Zadatak>();
            RadniNalozi = new List<RadniNalog>();
            Napreci = new List<Napredak>();
            KontroleKvaliteta = new List<KontrolaKvaliteta>();
            Angazovani = new List<Angazovan>();
            AngazovanaOprema = new List<Angazuje>();
        }
    }
}
