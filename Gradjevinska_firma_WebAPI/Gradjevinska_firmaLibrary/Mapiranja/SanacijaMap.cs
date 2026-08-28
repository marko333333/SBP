using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Gradjevinska_firmaLibrary.Entiteti;
namespace Gradjevinska_firmaLibrary.Mapiranja
{
    public class SanacijaMap : SubclassMap<Sanacija>
    {
        public SanacijaMap()
        {
            Table("SANACIJA");
            KeyColumn("IDPROJEKTA");
        }
    }
}
