using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
namespace Gradjevinska_firma.Mapiranja
{
    public class DeonicaMap : ClassMap<Deonica>
    {
        public DeonicaMap()
        {
            Table("DEONICA");

            Id(x => x.Br_deonice, "BRDEONICE").GeneratedBy.TriggerIdentity();
            References(x => x.Infrastruktura, "IDPROJEKTA");
        }
    }
}
