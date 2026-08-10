using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firma.Entiteti;

namespace Gradjevinska_firma.Mapiranja
{
    public class LicencaMap:ClassMap<Licenca>
    {
        public LicencaMap() {

            Table("LICENCA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            References(x => x.Osoba, "IDOSOBE");

            Map(x => x.NazivLicence, "LICENCA");

        }

    }
}
