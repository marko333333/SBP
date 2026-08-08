using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
namespace Gradjevinska_firma.Mapiranja
{
    public class PoslovniMap : SubclassMap<Poslovni>
    {
        public PoslovniMap()
        {
            Table("Poslovni");
            KeyColumn("IDPROJEKTA");

            HasMany(x => x.Objekti).Table("ObjekatPoslovni").KeyColumn("IDPROJEKTA").Cascade.AllDeleteOrphan().Inverse().LazyLoad();
        }
    }
}
