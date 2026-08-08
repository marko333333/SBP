using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Materijal
    {
        public virtual int ID { get; set; }
        public virtual string? Naziv { get; set; }
        public virtual string? Tip { get; set; }
        public virtual int Cena { get; set; }
        public virtual required string Proizvodjac { get; set; }
        public virtual required string JedinicaMere { get; set; }
        public virtual required string Sertifikat { get; set; }
        public virtual required string TipMaterijala { get; set; }
        public virtual IList<Ugovor> Ugovori { get; set; }
        public virtual IList<Koristi> Koristi { get; set; }
        public virtual IList<NabavkaMaterijal> NabavkaMaterijal { get; set; }
        public Materijal()
        {
            Ugovori = new List<Ugovor>();
        }

    }
}
