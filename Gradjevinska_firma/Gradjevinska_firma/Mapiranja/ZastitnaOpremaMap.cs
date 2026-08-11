using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class ZastitnaOpremaMap:ClassMap<ZastitnaOprema>
    {
        public ZastitnaOpremaMap()
        {
            Table("ZASTITNA_OPREMA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.NazivOpreme, "ZASTITNA_OPREMA");

            References(x => x.FizickoLice, "IDOSOBA");
        }
    }
}
