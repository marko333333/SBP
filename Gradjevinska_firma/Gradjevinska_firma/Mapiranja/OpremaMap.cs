using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class OpremaMap:ClassMap<Oprema>
    {   
        public OpremaMap()
        {
            Table("OPREMA");

            Id(x => x.Id, "ID")
                .GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Tip, "TIP");
            Map(x => x.DatumUvoza, "DATUM_UVOZA");
            Map(x => x.Proizvodjac, "PROIZVODJAC");
            Map(x => x.DatumNabavke, "DATUM_NABAVKE");
            Map(x => x.RasponOdrzavanja, "RASPON_ODRZAVANJA");
            Map(x => x.Lokacija, "LOKACIJA");
            Map(x => x.Status, "STATUS");

            HasMany(x => x.Ugovori)
                .KeyColumn("IDOPREMA")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            HasMany(x => x.Angazovanja)
                .KeyColumn("IDOPREMA")
                .LazyLoad()
                .Cascade.All()
                .Inverse();
        }
    }
}
