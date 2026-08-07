using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Ugovor
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime DatumPotpisivanja { get; set; }
        public virtual decimal Vrednost { get; set; }
        public virtual string PredmetUgovora { get; set; }
        public virtual string Valuta { get; set; }
        public virtual DateTime Rok { get; set; }
       public virtual Materijal Materijal { get; set; }
       public virtual Projekat Projekat { get; set; }
        public virtual Oprema Oprema { get; set; }

        public virtual IList<ImaUgovornuStranu> UgovorneStrane { get; set; }
        public virtual IList<PosebnaKlauzula> PosebneKlauzule { get; set; }
        public Ugovor()
        {
            UgovorneStrane = new List<ImaUgovornuStranu>();
            PosebneKlauzule = new List<PosebnaKlauzula>();
        }
    }
}
