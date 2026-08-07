using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class RadniNalog
    {
        public virtual int BrojNaloga { get; protected set; }
        public virtual string Status { get; set; }
        public virtual DateTime? DatumIzdavanja { get; set; }
        public virtual Zadatak Zadatak { get; set; }
    }
}
