using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Angazuje
    {
        public virtual Zadatak Zadatak { get; set; }
        public virtual Oprema Oprema { get; set; }
        public virtual DateTime? DatumOd { get; set; }
        public virtual DateTime? DatumDo { get; set; }
        public virtual int BrojSati { get; set; }

        public Angazuje()
        {
        }
    }
}
