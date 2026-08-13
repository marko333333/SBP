using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class KontrolaKvaliteta
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime? DatumInspekcije { get; set; }
        public virtual string PrimedbeNadzora { get; set; }
        public virtual string Zapisnik { get; set; }
        public virtual bool ZabranaNastavkaRadova { get; set; }
        public virtual string RazlogZabrane { get; set; }
        public virtual DateTime? DatumOtklanjanjaZabrane { get; set; }
        public virtual Zadatak Zadatak { get; set; }
        public virtual IList<StavkaKontrole> StavkeKontrole { get; set; }

        public KontrolaKvaliteta()
        {
            StavkeKontrole = new List<StavkaKontrole>();
        }
    }
}
