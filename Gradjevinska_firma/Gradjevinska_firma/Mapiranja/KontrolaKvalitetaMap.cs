using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class KontrolaKvalitetaMap:ClassMap<KontrolaKvaliteta>
    {
        public KontrolaKvalitetaMap()
        {
            Table("KONTROLA_KVALITETA");

            Id(x => x.Id, "ID")
                .GeneratedBy.TriggerIdentity();

            Map(x => x.DatumInspekcije, "DATUM_INSPEKCIJE");
            Map(x => x.PrimedbeNadzora, "PRIMEDBE_NADZORA");
            Map(x => x.Zapisnik, "ZAPISNIK");
            Map(x => x.ZabranaNastavkaRadova, "ZABRANA_NASTAVKA_RADOVA");
            Map(x => x.RazlogZabrane, "RAZLOG_ZABRANE");
            Map(x => x.DatumOtklanjanjaZabrane, "DATUM_OTKLANJANJA_ZABRANE");

            References(x => x.Zadatak)
                .Column("IDZADATKA");

            HasMany(x => x.StavkeKontrole)
                .KeyColumn("IDKONTROLE")
                .LazyLoad()
                .Cascade.All()
                .Inverse();
        }
    }
}
