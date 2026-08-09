using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firma.Entiteti;

namespace Gradjevinska_firma.Mapiranja
{
    public class BezbednosnaObukaMap:ClassMap<BezbednosnaObuka>
    {   
        public BezbednosnaObukaMap() {

            Table("BEZBEDNOSNA_OBUKA");

            CompositeId()
                .KeyReference(x => x.FizickoLice, "IDOSOBA")
                .KeyProperty(x => x.NazivObuke, "BEZBEDNOSNA_OBUKA");

            Map(x => x.Datum, "DATUM");
        
        }
    }
}
