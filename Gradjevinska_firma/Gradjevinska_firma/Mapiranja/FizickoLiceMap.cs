using Gradjevinska_firma.Entiteti;
using FluentNHibernate.Mapping;
using NHibernate.Mapping.ByCode.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class FizickoLiceMap: SubclassMap<FizickoLice>
    {
        public FizickoLiceMap()
        {
            Table("FIZICKA_LICA");

            KeyColumn("IDOSOBA");

            Map(x => x.FlagBK, "FLAGBK");
            Map(x => x.FlagR, "FLAGR");
            Map(x => x.Kvalifikacija, "KVALIFIKACIJA");
            Map(x => x.FlagI, "FLAGI");
            Map(x => x.OblastRada, "OBLASTRADA");
            Map(x => x.Odgovornosti, "ODGOVORNOSTI");
            Map(x => x.FlagA, "FLAGA");
            Map(x => x.FlagP, "FLAGP");
            Map(x => x.FlagN, "FLAGN");
            Map(x => x.FlagAO, "FLAGAO");

            HasMany(x => x.BezbednosneObuke)
                .KeyColumn("IDOSOBA")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            HasMany(x => x.LekarskiPregledi)
                .KeyColumn("IDOSOBA")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            HasMany(x => x.SertifikatiSpecOpreme)
                .KeyColumn("IDOSOBA")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

            HasMany(x => x.ZastitneOpreme)
                .KeyColumn("IDOSOBA")
                .LazyLoad()
                .Cascade.All()
                .Inverse();
        }
    }
}
