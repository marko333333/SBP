using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Nabavke
    {
        public virtual int Br_nabavke { get; set; }
        public virtual DateTime Datum { get; set; }
        public virtual Projekat Projekat { get; set; }
        public virtual IList<NabavkaMaterijal> NabavkaMaterijal { get; set; }
        public virtual IList<NabavkaOprema> NabavkaOprema { get; set; }
    }
}
