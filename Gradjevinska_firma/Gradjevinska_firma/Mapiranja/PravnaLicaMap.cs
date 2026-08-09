using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firma.Entiteti;
using FluentNHibernate.Mapping;

namespace Gradjevinska_firma.Mapiranja
{
    public class PravnaLicaMap: SubclassMap<PravnaLica>
    {
        public PravnaLicaMap()
        {
            Table("PRAVNA_LICA");

            KeyColumn("IDOSOBA");

            Map(x => x.FlagPB, "FLAGPB");
            Map(x => x.FlagInve, "FLAGINVE");
            Map(x => x.FlagIzv, "FLAGIZV");
            Map(x => x.FlagP, "FLAGP");
            Map(x => x.FlagD, "FLAGD");
            Map(x => x.FlagN, "FLAGN");

            HasMany(x => x.IzdateFakture)
           .KeyColumn("IDOSOBE_IZDAJE")
           .Cascade.AllDeleteOrphan()
           .Inverse()
           .LazyLoad();

            HasMany(x => x.PrimljeneFakture)
                .KeyColumn("IDOSOBE_PRIMA")
                .Cascade.AllDeleteOrphan()
                .Inverse()
                .LazyLoad();
        }
    }
}
