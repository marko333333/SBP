using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    //zar nismo rekli da ovo brisemo iz dijagrama, i da ostavljamo to kao atribute u BezbednosniIncident????
    public class PoslediceIncidenta
    {
        public virtual int ID { get; set; }
        public virtual string Tekst { get; set; }
        public virtual BezbednosniIncident BezbednosniIncident { get; set; }
    }
}
