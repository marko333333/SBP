using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firma.Entiteti;


namespace Gradjevinska_firma.Mapiranja
{
    public class LekarskiPregledMap:ClassMap<LekarskiPregled>
    {   
        public LekarskiPregledMap() {

            Table("LEK_PREGLED");

            CompositeId()
                .KeyReference(x => x.FizickoLice, "IDOSOBA")
                .KeyProperty(x => x.Rezultat, "REZULTAT");

            Map(x => x.Datum, "DATUM");
        }
    }
}
