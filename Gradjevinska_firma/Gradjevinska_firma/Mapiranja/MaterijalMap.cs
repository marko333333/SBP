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

            DiscriminateSubClassesOnColumn("TIP_MATERIJALA");

            Id(x => x.ID, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Cena, "CENA");
            Map(x => x.JedinicaMere, "JEDINICA_MERE");
            Map(x => x.Sertifikat, "SERTIFIKAT");
            Map(x => x.Proizvodjac, "PROIZVODJAC");
            Map(x => x.Tip, "TIP");


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
            DiscriminatorValue("ZASTITNI");
        }
    }
    class MasinskiMap : SubclassMap<Masinski>
    {
        public MasinskiMap()
        {
            DiscriminatorValue("MASINSKI");
        }
    }
    class GradjevinskiMap : SubclassMap<Gradjevinski>
    {
        public GradjevinskiMap()
        {
            DiscriminatorValue("GRADJEVINSKI");
        }
    }
    class ElektroMap : SubclassMap<Elektro>
    {
        public ElektroMap()
        {
            DiscriminatorValue("ELEKTRO");
        }
    }
    class ZavrsniMap : SubclassMap<Zavrsni>
    {
        public ZavrsniMap()
        {
            DiscriminatorValue("ZAVRSNI");
        }
    }
}
