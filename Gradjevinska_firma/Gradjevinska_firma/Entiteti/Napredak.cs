using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Napredak
    {   
        public virtual int Id { get; protected set; }
        public virtual DateTime Datum { get; set; }
        public virtual Zadatak Zadatak { get; set; }
        public virtual string DnevniIzvestaj { get; set; }
        public virtual int ProcenatRealizacije { get; set; }
        public virtual string PrimedbaNadzora { get; set; }
        public virtual string KorektivnaMera { get; set; }
        public virtual IList<Fotografija> Fotografije { get; set; }

        public Napredak()
        {
            Fotografije = new List<Fotografija>();
        }
    }
}
