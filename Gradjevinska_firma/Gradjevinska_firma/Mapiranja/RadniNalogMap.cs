using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class RadniNalogMap:ClassMap<RadniNalog>
    {
        public RadniNalogMap()
        {
            Table("RADNI_NALOG");

            Id(x => x.BrojNaloga, "BR_NALOGA")
           .GeneratedBy.TriggerIdentity();

            Map(x => x.Status, "STATUS");

            Map(x => x.DatumIzdavanja, "DATUM_IZDAVANJA");

            References(x => x.Zadatak)
                .Column("IDZADATAK");
        }
    }
}
