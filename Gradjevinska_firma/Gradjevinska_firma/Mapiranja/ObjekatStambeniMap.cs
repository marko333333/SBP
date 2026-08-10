using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
namespace Gradjevinska_firma.Mapiranja
{
    public class ObjekatStambeniMap : ClassMap<ObjekatStambeni>
    {
        public ObjekatStambeniMap() 
        {
            Table("OBJEKAT_STAMBENI");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Br_objekta, "BR_OBJEKTA");

            Map(x => x.Spratnost, "SPRATNOST");
            Map(x => x.Br_jedinica, "BR_JEDINICA");

            References(x => x.Stambeni, "IDPROJEKTA");
        }
    }
}
