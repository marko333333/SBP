using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class SertifikatSpecOpreme
    {   
        public virtual int Id { get; protected set; }
        public virtual FizickoLice FizickoLice { get; set; }
        public virtual string Sertifikat { get; set; }
    }
}
