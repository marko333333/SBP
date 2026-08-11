using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class SertifikatSpecOpremeMap: ClassMap<SertifikatSpecOpreme>
    {   
        public SertifikatSpecOpremeMap()
        {
            Table("SERTIFIKAT_SPEC_OPREME");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Sertifikat, "SERTIFIKAT_SPEC_OPREME");

            References(x => x.FizickoLice, "IDOSOBA");

        }
    }
}
