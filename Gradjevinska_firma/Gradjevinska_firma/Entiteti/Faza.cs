using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Faza
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual string TipFaze { get; set; }
        public virtual DateTime? DatumOd { get; set; }
        public virtual DateTime? DatumDo { get; set; }
        public virtual string Status { get; set; }
        public virtual int? Budzet { get; set; }
        public virtual Projekat Projekat { get; set; }
        public virtual FizickoLice FizickoLice { get; set; }
        public virtual Faza NadFaza { get; set; }

        public virtual IList<Faza> PodFaze { get; set; }

        public virtual IList<Zadatak> Zadaci { get; set; }

        public Faza()
        {
            PodFaze = new List<Faza>();
            Zadaci = new List<Zadatak>();
        }
    }
}
