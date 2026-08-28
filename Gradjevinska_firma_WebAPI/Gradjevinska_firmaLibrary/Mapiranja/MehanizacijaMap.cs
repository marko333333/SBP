using FluentNHibernate.Mapping;
using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.Mapiranja
{
    public class MehanizacijaMap :SubclassMap<Mehanizacija>
    {
        public MehanizacijaMap()
        {
            Table("MEHANIZACIJA");

            KeyColumn("IDOPREMA");

            Map(x => x.TipMehanizacije, "TIP_MEHANIZACIJE");
        }
    }
   
}
