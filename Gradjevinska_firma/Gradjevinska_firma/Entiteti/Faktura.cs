using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Faktura
    {
        public virtual int Br_fakture { get; set; }
        public virtual int Iznos { get; set; }
        public virtual string Valuta { get; set; }
        public virtual bool statusPlacanja { get; set; }
        public virtual DateTime Datum { get; set; }

        public virtual Projekat  IDProjekta { get; set; }
        public virtual PravnaLica PravnoLiceIzdaje { get; set; }
        public virtual PravnaLica PravnoLicePrima { get; set; }

    }
}
