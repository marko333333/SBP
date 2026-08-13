using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class FazaMap:ClassMap<Faza>
    {
        public FazaMap()
        {
            Table("FAZA");

            Id(x => x.Id, "ID")
                .GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.DatumOd, "DATUM_OD");
            Map(x => x.DatumDo, "DATUM_DO");
            Map(x => x.Status, "STATUS");
            Map(x => x.Budzet, "BUDZET");

            References(x => x.Projekat)
                .Column("IDPROJEKTA");

            References(x => x.FizickoLice)
                .Column("IDFIZICKO_LICE");

            References(x => x.NadFaza)
                .Column("ID_NADFAZE");

            HasMany(x => x.PodFaze)
                .KeyColumn("ID_NADFAZE")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            HasMany(x => x.Zadaci)
                .KeyColumn("IDFAZA")
                .LazyLoad()
                .Cascade.All()
                .Inverse();
        }
    }

}
