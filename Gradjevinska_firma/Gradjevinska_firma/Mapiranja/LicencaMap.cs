using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firma.Entiteti

namespace Gradjevinska_firma.Mapiranja
{
    public class LicencaMap:ClassMap<Licenca>
    {
        public LicencaMap() {

            Table("LICENCA");
            CompositeId()
                .KeyReference(x => x.Osoba, "IDOSOBE")
                .KeyProperty(x => x.NazivLicence, "LICENCA");
        
        }

    }
}
