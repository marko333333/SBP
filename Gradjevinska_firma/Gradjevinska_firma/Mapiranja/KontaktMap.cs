using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firma.Entiteti;

namespace Gradjevinska_firma.Mapiranja
{
    public class KontaktMap : ClassMap<Kontakt>
    {
        public KontaktMap()
        {
            Table("KONTAKT");

            CompositeId()
                .KeyReference(x => x.Osoba, "IDOSOBA")
                .KeyProperty(x => x.Broj, "KONTAKT");
        }
    }
}
