using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class ImaUgovornuStranuMap:ClassMap<ImaUgovornuStranu>
    {
        public ImaUgovornuStranuMap()
        {
            Table("IMAUGOVORNUSTRANU");

            CompositeId()
                .KeyReference(x => x.Osoba, "IDOSOBA")
                .KeyReference(x => x.Ugovor, "IDUGOVOR");

            Map(x => x.Uloga, "ULOGA");
        }

    }
}
