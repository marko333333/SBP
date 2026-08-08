using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
namespace Gradjevinska_firma.Mapiranja
{
    public class StambeniMap : SubclassMap<Stambeni>
    {
        public StambeniMap()
        {
            Table("Stambeni");
            KeyColumn("IDPROJEKTA");

            HasMany(x => x.Objekti).Table("ObjekatStambeni").KeyColumn("IDPROJEKTA").Cascade.AllDeleteOrphan().Inverse().LazyLoad();
        }
    }
}
