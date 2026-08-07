using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Angazovan
    {
        public virtual Zadatak Zadatak { get; set; }
        public virtual Osoba Osoba { get; set; }
        public virtual DateTime DatumOd { get; set; }
        public virtual DateTime? DatumDo { get; set; }
        public virtual string StatusAngazovanja { get; set; }

        public Angazovan()
        {
        }
    }
}
