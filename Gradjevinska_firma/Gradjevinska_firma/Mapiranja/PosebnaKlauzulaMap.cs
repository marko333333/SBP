using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class PosebnaKlauzulaMap:ClassMap<PosebnaKlauzula>
    {
        public PosebnaKlauzulaMap()
        {
            Table("POSEBNA_KLAUZULA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.TekstKlauzule, "POSEBNA_KLAUZULA");

            References(x => x.Ugovor, "IDUGOVOR");
        }
    }
}
