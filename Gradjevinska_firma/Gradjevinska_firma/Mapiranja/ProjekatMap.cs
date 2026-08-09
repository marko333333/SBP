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

            Table("PROJEKAT");


            Id(x => x.ID, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Opis, "OPIS");
            Map(x => x.Lokacija, "LOKACIJA");
            Map(x => x.Datum_pocetka, "DATUM_POCETKA");
            Map(x => x.Budzet, "BUDZET");
            Map(x => x.Status, "STATUS");
            Map(x => x.Planirani_Zavrsetak, "PLANIRANI_ZAVRSETAK");
            Map(x => x.Stvarni_Zavrsetak, "STVARNI_ZAVRSETAK");


            HasMany(x => x.Ugovori)
                .KeyColumn("IDPROJEKTA")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            HasMany(x=>x.BezbednosniIncidenti).KeyColumn("IDBEZBEDNOSNOGINCIDENTA").LazyLoad().Cascade.All().Inverse();
        }
    }
}