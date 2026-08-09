using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class ProjekatMap: ClassMap<Projekat>
    {   
        public ProjekatMap() {

            Table("Projekat");

            Id(x => x.ID).GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Opis, "OPIS");
            Map(x => x.Lokacija, "LOKACIJA");
            Map(x => x.Datum_pocetka, "DATUMPOCETKA");
            Map(x => x.Budzet, "BUDZET");
            Map(x => x.Status, "STATUS");
            Map(x => x.Planirani_Zavrsetak, "PLANIRANIZAVRSETAK");
            Map(x => x.Stvarni_Zavrsetak, "STVARNIZAVRSETAK");


            HasMany(x => x.Ugovori)
                .KeyColumn("IDPROJEKTA")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            HasMany(x=>x.BezbednosniIncidenti).KeyColumn("IDBEZBEDNOSNOGINCIDENTA").LazyLoad().Cascade.All().Inverse();
        }
    }

    class SanacijaMap : SubclassMap<Sanacija>
    {
        public SanacijaMap()
        {
            Table("Sanacija");
            KeyColumn("IDPROJEKTA");
        }
    }

}