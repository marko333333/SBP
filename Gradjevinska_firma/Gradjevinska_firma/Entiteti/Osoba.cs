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
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual string Struka { get; set; }
        
        public virtual IList<Kontakt> Kontakti { get; set; }
        public virtual IList<Licenca> Licence { get; set; }
        public virtual IList<Angazovan> Angazovanja { get; set; }
        public virtual IList<ImaUgovornuStranu> UgovorneStrane { get; set; }
        public virtual IList<BezbednosniIncident> BezbednosniIncidenti { get; set; }
        public Osoba()
        {
            Kontakti = new List<Kontakt>();
            Licence = new List<Licenca>();
            Angazovanja = new List<Angazovan>();
            UgovorneStrane = new List<ImaUgovornuStranu>();
            BezbednosniIncidenti=new List<BezbednosniIncident>();
        }
    }
}
