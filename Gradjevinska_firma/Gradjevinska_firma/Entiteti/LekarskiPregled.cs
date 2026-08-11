using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class LekarskiPregled
    {
        public virtual int Id { get; protected set; }
        public virtual FizickoLice FizickoLice { get; set; }
        public virtual string Rezultat { get; set; }
        public virtual DateTime Datum { get; set; }
    }
}
