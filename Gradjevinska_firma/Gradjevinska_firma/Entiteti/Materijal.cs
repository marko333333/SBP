using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public abstract class Materijal
    {
        public virtual int ID { get; set; }
        public virtual string Naziv { get; set; }
        public virtual int Cena { get; set; }
        public virtual string Proizvodjac { get; set; }
        public virtual string JedinicaMere { get; set; }
        public virtual string Sertifikat { get; set; }
        public virtual string Tip { get; set; }

        public virtual IList<Ugovor> Ugovori { get; set; }
        public virtual IList<Koristi> Koristi { get; set; }
        public virtual IList<NabavkaMaterijal> NabavkaMaterijal { get; set; }
        public Materijal()
        {
            Ugovori = new List<Ugovor>();
            Koristi = new List<Koristi>();
            NabavkaMaterijal = new List<NabavkaMaterijal>();
        }

    }
        public class Zastitni : Materijal { }
        public class Masinski : Materijal { }
        public class Gradjevinski : Materijal { }
        public class Elektro : Materijal { }
        public class Zavrsni : Materijal { }
}
