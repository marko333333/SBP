using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public abstract class BezbednosniIncident
    {
        public virtual int ID { get; set; }
        public virtual string Opis { get; set; }
        public virtual DateTime Datum { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual string Preduzete_mere { get; set; }
        public virtual string Posledice { get; set; }
        public virtual string Tip_incidenta { get; set; }
        public virtual Projekat Projekat { get; set; }
        public virtual Osoba Osoba { get; set; }
    }
    public class PovredaNaRadu : BezbednosniIncident { }
    public class KvarOpreme : BezbednosniIncident { }
    public class NepostovanjeProcedura : BezbednosniIncident { }
    public class OpasnaSituacija : BezbednosniIncident { }
    public class EkoloskiIncident : BezbednosniIncident { }
}
