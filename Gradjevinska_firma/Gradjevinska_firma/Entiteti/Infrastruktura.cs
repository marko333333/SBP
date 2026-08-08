using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Infrastruktura : Projekat
    {
        public virtual IList<Deonica> Deonice { get; set; }
    }
}
