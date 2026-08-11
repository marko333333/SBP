using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Deonica
    {   
        public virtual int Id { get; protected set; }
        public virtual int Br_deonice { get; set; }
        public virtual Infrastruktura Infrastruktura { get; set; }

    }
}
