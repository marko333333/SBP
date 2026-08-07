using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class AngazujeMap:ClassMap<Angazuje>
    {
        public AngazujeMap()
        {
            Table("ANGAZUJE");

            CompositeId()
                .KeyReference(x => x.Zadatak, "IDZADATAK")
                .KeyReference(x => x.Oprema, "IDOPREMA");

            Map(x => x.DatumOd, "DATUM_OD");
            Map(x => x.DatumDo, "DATUM_DO");
            Map(x => x.BrojSati, "BROJ_SATI");
        }
    }
}
