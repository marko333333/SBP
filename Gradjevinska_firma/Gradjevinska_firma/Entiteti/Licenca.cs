using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Licenca
    {   
        public virtual int Id { get; protected set; }
        public virtual Osoba Osoba { get; set; }
        public virtual string NazivLicence { get; set; }
    }
}
