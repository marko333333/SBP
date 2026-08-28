using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Gradjevinska_firmaLibrary.Entiteti;
namespace Gradjevinska_firmaLibrary.Mapiranja
{
    public class IndustrijskiMap : SubclassMap<Industrijski>
    {
        public IndustrijskiMap()
        {
            Table("INDUSTRIJSKI");
            KeyColumn("IDPROJEKTA");
        }
    }
}
