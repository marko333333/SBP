using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class ObjekatPoslovni
    {
        public virtual int  Br_objekta {get;set;}
        public virtual int Spratnost { get; set; }
        public virtual int Br_jedinica { get; set; }
        public virtual Poslovni Poslovni { get; set; }
    }
}
