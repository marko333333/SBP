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

            Table("Materijal");

            Id(x => x.ID, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Tip, "TIP");
            Map(x => x.Cena, "CENA");
            Map(x => x.JedinicaMere, "JEDINICAMERE");
            Map(x => x.Sertifikat, "SERTIFIKAT");
            Map(x => x.TipMaterijala, "TIPMATERIJALA");


            HasMany(x => x.Ugovori)
                .KeyColumn("IDMATERIJAL")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            HasMany(x => x.Koristi).KeyColumn("IDMATERIJAL").LazyLoad().Cascade.All().Inverse();

            HasMany(x=>x.NabavkaMaterijal).KeyColumn("IDMATERIJAL").LazyLoad().Cascade.All().Inverse();
        }
    }
}
