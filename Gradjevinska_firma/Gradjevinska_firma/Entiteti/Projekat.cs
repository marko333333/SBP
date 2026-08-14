using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Projekat
    {   
        public virtual int ID { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Opis { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual DateTime Datum_pocetka { get; set; }
        public virtual int Budzet { get; set; }
        public virtual string Status { get; set; }
        public virtual DateTime Planirani_Zavrsetak { get; set; }
        public virtual DateTime Stvarni_Zavrsetak { get; set; }

        public virtual IList<Ugovor> Ugovori { get; set; }
        public virtual IList<BezbednosniIncident> BezbednosniIncidenti { get; set; }

        public Projekat()
        {
            Ugovori = new List<Ugovor>();
            BezbednosniIncidenti = new List<BezbednosniIncident>();
        }
    }
}
