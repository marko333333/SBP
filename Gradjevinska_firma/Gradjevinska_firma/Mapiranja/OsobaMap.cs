using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class OsobaMap : ClassMap<Osoba>
    {
        public OsobaMap()
        {
            Table("OSOBA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Jmbg, "JMBG");
            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.DatumRodjenja, "DATUM_RODJENJA");
            Map(x => x.Struka, "STRUKA");

            HasMany(x => x.Kontakti)
                .KeyColumn("IDOSOBA")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            HasMany(x => x.Licence)
                .KeyColumn("IDOSOBE")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            HasMany(x => x.Angazovanja)
                .KeyColumn("IDOSOBA")
                .LazyLoad()
                .Cascade.All()
                .Inverse();
            HasMany(x => x.UgovorneStrane)
                .KeyColumn("IDOSOBA")
                .LazyLoad()
                .Cascade.All()
                .Inverse();
        }
    }
}
