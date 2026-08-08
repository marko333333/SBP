using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class PreduzeteMereIncidenta
    {
        public virtual int ID { get; set; }
        public virtual string Tekst { get; set; }
        public virtual BezbednosniIncident BezbednosniIncident { get; set; }
    }
}
