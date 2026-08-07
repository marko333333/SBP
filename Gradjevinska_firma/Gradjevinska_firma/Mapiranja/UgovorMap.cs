using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class UgovorMap :ClassMap<Ugovor>
    {   
        public UgovorMap() {

            Table("UGOVOR");

            Id(x => x.Id, "ID")
                .GeneratedBy.TriggerIdentity();

            Map(x => x.DatumPotpisivanja, "DATUM_POTPISIVANJA");
            Map(x => x.Vrednost, "VREDNOST");
            Map(x => x.PredmetUgovora, "PREDMET_UGOVORA");
            Map(x => x.Valuta, "VALUTA");
            Map(x => x.Rok, "ROK");

           References(x => x.Materijal)
                .Column("IDMATERIJAL")
                .LazyLoad();

            References(x => x.Projekat)
                .Column("IDPROJEKTA")
                .LazyLoad();
           
            References(x => x.Oprema)
                .Column("IDOPREMA")
                .LazyLoad();

            HasMany(x => x.UgovorneStrane)
                .KeyColumn("IDUGOVOR")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            HasMany(x => x.PosebneKlauzule)
                .KeyColumn("IDUGOVOR")
                .LazyLoad()
                .Cascade.All()
                .Inverse();
        }
    }
}
