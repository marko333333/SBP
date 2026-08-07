using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class PosebnaKlauzula
    {
        public virtual string TekstKlauzule { get; set; }
        public virtual Ugovor Ugovor { get; set; }

        public PosebnaKlauzula()
        {

        }
    }
}
