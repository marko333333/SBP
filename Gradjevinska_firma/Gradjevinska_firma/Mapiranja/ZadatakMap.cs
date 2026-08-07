using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class ZadatakMap:ClassMap<Zadatak>
    {   
        public ZadatakMap() {

            Table("ZADATAK");

            Id(x => x.Id, "ID")
                .GeneratedBy.TriggerIdentity();
            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Opis, "OPIS");
            Map(x => x.ProcenjeniTrosak, "PROCENJENI_TROOSAK");
            Map(x => x.PlaniraniZavrsetak, "PLANIRANI_ZAVRSETAK");
            Map(x => x.StvarniZavrsetak, "STVARNI_ZAVRSETAK");
            Map(x => x.PlaniraniPocetak, "PLANIRANI_POCETAK");
            Map(x => x.StvarniPocetak, "STVARNI_POCETAK");
            Map(x => x.Prioritet, "PRIORITET");
            Map(x => x.Status, "STATUS");

            References(x => x.Faza)
                .Column("ID_FAZE");

            References(x => x.Roditelj)
                .Column("ID_ZADATAK_RODITELJ");

            HasMany(x => x.Podzadaci)
                .KeyColumn("ID_ZADATAK_RODITELJ")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            HasMany(x => x.RadniNalozi)
                .KeyColumn("IDZADATAK")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            HasMany(x => x.Napreci)
                .KeyColumn("IDZADATAK")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            HasMany(x => x.KontroleKvaliteta)
                .KeyColumn("IDZADATKA")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            HasMany(x => x.Angazovani)
                .KeyColumn("IDZADATAK")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            HasMany(x => x.AngazovanaOprema)
                .KeyColumn("IDZADATAK")
                .LazyLoad()
                .Cascade.All()
                .Inverse();
        }
    }
}
