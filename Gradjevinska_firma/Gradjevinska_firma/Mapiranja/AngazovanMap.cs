using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class AngazovanMap:ClassMap<Angazovan>
    {
        public AngazovanMap()
        {
            Table("ANGAZOVAN");

            CompositeId()
                .KeyReference(x => x.Zadatak, "IDZADATAK")
                .KeyReference(x => x.Osoba, "IDOSOBA");

            Map(x => x.DatumOd, "DATUM_OD");
            Map(x => x.DatumDo, "DATUM_DO");
            Map(x => x.StatusAngazovanja, "STATUS_ANGAZOVANJA");
        }
    }
}
