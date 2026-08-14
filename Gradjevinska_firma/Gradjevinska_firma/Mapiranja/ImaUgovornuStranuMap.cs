using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class ImaUgovornuStranuMap:ClassMap<ImaUgovornuStranu>
    {
        public ImaUgovornuStranuMap()
        {
            Table("IMAUGOVORNUSTRANU");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            References(x => x.Osoba, "IDOSOBA");

            References(x => x.Ugovor, "IDUGOVOR");

            Map(x => x.Uloga, "ULOGA");

        }

    }
}
