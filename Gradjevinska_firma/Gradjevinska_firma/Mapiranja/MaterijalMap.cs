using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class MaterijalMap:ClassMap<Materijal>
    {   
        public MaterijalMap() {

            Table("MATERIJAL");

            DiscriminateSubClassesOnColumn("TIP");

            Id(x => x.ID, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Cena, "CENA");
            Map(x => x.JedinicaMere, "JEDINICA_MERE");
            Map(x => x.Sertifikat, "SERTIFIKAT");
            Map(x => x.Proizvodjac, "PROIZVODJAC");


            HasMany(x => x.Ugovori)
                .KeyColumn("IDMATERIJAL")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            HasMany(x => x.Koristi).KeyColumn("IDMATERIJAL").LazyLoad().Cascade.All().Inverse();

            HasMany(x=>x.NabavkaMaterijal).KeyColumn("IDMATERIJAL").LazyLoad().Cascade.All().Inverse();
        }
    }
    class ZastitniMap : SubclassMap<Zastitni>
    {
        public ZastitniMap()
        {
            DiscriminatorValue("Zastitni");
        }
    }
    class MasinskiMap : SubclassMap<Masinski>
    {
        public MasinskiMap()
        {
            DiscriminatorValue("Masinski");
        }
    }
    class GradjevinskiMap : SubclassMap<Gradjevinski>
    {
        public GradjevinskiMap()
        {
            DiscriminatorValue("Gradjevinski");
        }
    }
    class ElektroMap : SubclassMap<Elektro>
    {
        public ElektroMap()
        {
            DiscriminatorValue("Elektro");
        }
    }
    class ZavrsniMap : SubclassMap<Zavrsni>
    {
        public ZavrsniMap()
        {
            DiscriminatorValue("Zavrsni");
        }
    }
}
