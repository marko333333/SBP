using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Gradjevinska_firmaLibrary.Entiteti;
namespace Gradjevinska_firmaLibrary.Mapiranja
{
    public class RekonstrukcijaMap : SubclassMap<Rekonstrukcija>
    {
        public RekonstrukcijaMap()
        {
            Table("REKONSTRUKCIJA");
            KeyColumn("IDPROJEKTA");
        }
    }
}
