using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
namespace Gradjevinska_firma.Mapiranja
{
    public class ObjekatPoslovniMap : ClassMap<ObjekatPoslovni>
    {
        public ObjekatPoslovniMap() 
        {
            Table("OBJEKAT_POSLOVNI");

            Id(x => x.Br_objekta, "BR_OBJEKTA").GeneratedBy.TriggerIdentity();

            Map(x => x.Spratnost, "SPRATNOST");
            Map(x => x.Br_jedinica, "BR_JEDINICA");

            References(x => x.Poslovni, "IDPROJEKTA");

        }
    }
}
