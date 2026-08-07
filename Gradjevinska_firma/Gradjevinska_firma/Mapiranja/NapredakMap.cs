using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class NapredakMap:ClassMap<Napredak>
    {
        public NapredakMap()
        {
            Table("NAPREDAK");

            Id(x => x.Id, "ID")
                .GeneratedBy.TriggerIdentity();

            Map(x => x.Datum, "DATUM");
            Map(x => x.DnevniIzvestaj, "DNEVNI_IZVESTAJ");
            Map(x => x.ProcenatRealizacije, "PROCENAT_REALIZACIJE");
            Map(x => x.PrimedbaNadzora, "PRIMEDBA_NADZORA");
            Map(x => x.KorektivnaMera, "KOREKTIVNA_MERA");

            References(x => x.Zadatak)
                .Column("IDZADATAK");

            HasMany(x => x.Fotografije)
                .KeyColumn("IDNAPREDAK")
                .LazyLoad()
                .Cascade.All()
                .Inverse();
        }
    }
}
