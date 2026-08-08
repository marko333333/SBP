using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
namespace Gradjevinska_firma.Mapiranja
{
    public class RekonstrukcijaMap : SubclassMap<Rekonstrukcija>
    {
        public RekonstrukcijaMap()
        {
            Table("Rekonstrukcija");
            KeyColumn("IDPROJEKTA");
        }
    }
}
