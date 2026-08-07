using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Oprema
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual string Tip { get; set; }
        public virtual DateTime DatumUvoza { get; set; }
        public virtual string Proizvodjac { get; set; }
        public virtual DateTime DatumNabavke { get; set; }
        public virtual string RasponOdrzavanja { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual string Status { get; set; }

        public virtual IList<Ugovor> Ugovori { get; set; }
        public virtual IList<Angazuje> Angazovanja { get; set; }
        public Oprema()
        {
            Ugovori = new List<Ugovor>();
            Angazovanja = new List<Angazuje>();
        }
    }
}
