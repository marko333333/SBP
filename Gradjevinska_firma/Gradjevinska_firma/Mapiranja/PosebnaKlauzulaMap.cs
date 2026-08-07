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

            CompositeId()
                .KeyProperty(x => x.TekstKlauzule, "POSEBNA_KLAUZULA")
                .KeyReference(x => x.Ugovor, "IDUGOVOR");
        }
    }
}
