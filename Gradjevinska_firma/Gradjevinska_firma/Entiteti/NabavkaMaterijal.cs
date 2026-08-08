using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class NabavkaMaterijal
    {
        public virtual int ID { get; set; }
        public virtual int Kolicina { get; set; }
        public virtual int Cena { get; set; }
        public virtual bool Status_isporuke { get; set; }

        public virtual Materijal Materijal { get; set; }
        public virtual Nabavke Nabavke { get; set; }
    }
}
