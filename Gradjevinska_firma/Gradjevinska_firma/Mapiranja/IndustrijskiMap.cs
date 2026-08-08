using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
namespace Gradjevinska_firma.Mapiranja
{
    public class IndustrijskiMap : SubclassMap<Industrijski>
    {
        public IndustrijskiMap()
        {
            Table("Industrijski");
            KeyColumn("IDPROJEKTA");
        }
    }
}
