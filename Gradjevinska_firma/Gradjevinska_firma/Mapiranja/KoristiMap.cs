using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;

namespace Gradjevinska_firma.Mapiranja
{
    public class KoristiMap:ClassMap<Koristi>
    {
        public KoristiMap()
        {
            Table("KORISTI");
            Id(x => x.ID, "ID").GeneratedBy.TriggerIdentity();

            References(x => x.Zadatak, "IDZADATAK");
            References(x => x.Materijal, "IDMATERIJAL");

            Map(x => x.Kolicina, "KOLICINA");
        }
    }
}
