using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Gradjevinska_firmaLibrary.Entiteti;
namespace Gradjevinska_firmaLibrary.Mapiranja
{
    public class PoslovniMap : SubclassMap<Poslovni>
    {
        public PoslovniMap()
        {
            Table("POSLOVNI");
            KeyColumn("IDPROJEKTA");

            HasMany(x => x.Objekti).Table("ObjekatPoslovni").KeyColumn("IDPROJEKTA").Cascade.AllDeleteOrphan().Inverse().LazyLoad();
        }
    }
}
