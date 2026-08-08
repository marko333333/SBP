using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Stambeni : Projekat
    {
        public virtual IList<ObjekatStambeni> Objekti { get; set; }
    }
}
