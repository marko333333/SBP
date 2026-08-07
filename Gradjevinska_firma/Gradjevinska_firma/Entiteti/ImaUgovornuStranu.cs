using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class ImaUgovornuStranu
    {
        public virtual Osoba Osoba { get; set; }
        public virtual Ugovor Ugovor { get; set; }
        public virtual string Uloga { get; set; }

        public ImaUgovornuStranu()
        {

        }
    }
}
