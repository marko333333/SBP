using FluentNHibernate.Mapping;
using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.Mapiranja
{
    public class FotografijaMap:ClassMap<Fotografija>
    {
        public FotografijaMap()
        {
            Table("FOTOGRAFIJA");

            CompositeId()
                .KeyReference(x => x.Napredak,"IDNAPREDAK")
                .KeyProperty(x => x.Putanja, "FOTOGRAFIJA");
        }
    }
}
