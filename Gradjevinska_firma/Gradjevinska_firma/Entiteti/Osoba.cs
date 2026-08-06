using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Osoba
    {
        public virtual int Id { get; protected set; }

        public virtual long Jmbg { get; set; }

        public virtual string Ime { get; set; } = string.Empty;

        public virtual string Prezime { get; set; } = string.Empty;

        public virtual DateTime DatumRodjenja { get; set; }

        public virtual string Struka { get; set; } = string.Empty;
    }
}
