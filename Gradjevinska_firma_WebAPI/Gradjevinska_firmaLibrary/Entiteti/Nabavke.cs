using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.Entiteti
{
    public class Nabavke
    {
        public virtual int Br_nabavke { get; protected set; }
        public virtual DateTime Datum { get; set; }
        public virtual Projekat Projekat { get; set; }
        public virtual IList<NabavkaMaterijal> NabavkaMaterijal { get; set; }//dodaj
        public virtual IList<NabavkaOprema> NabavkaOprema { get; set; }//dodaj
    }
}
