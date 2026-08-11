using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firma.Entiteti;

namespace Gradjevinska_firma.Mapiranja
{
    public class KontaktMap : ClassMap<Kontakt>
    {
        public KontaktMap()
        {
            Table("KONTAKT");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            References(x => x.Osoba, "IDOSOBA");

            Map(x => x.Broj, "KONTAKT");

        }
    }
}
