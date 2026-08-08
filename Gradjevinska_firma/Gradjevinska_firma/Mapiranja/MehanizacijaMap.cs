using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    //proveriti kako da se resi problem
    public class MehanizacijaMap :SubclassMap<Mehanizacija>
    {
        public MehanizacijaMap()
        {
            Table("MEHANIZACIJA");

            KeyColumn("IDOPREMA");

            Map(x => x.TipMehanizacije, "TIP_MEHANIZACIJE");
        }
    }
    public class GradjevinskaMasinaMap : SubclassMap<GradjevinskaMasina>
    {
        public GradjevinskaMasinaMap()
        {
            DiscriminatorValue("Gradjevinska masina");
        }
    }
    public class TransportnoSredstvoMap : SubclassMap<TransportnoSredstvo>
    {
        public TransportnoSredstvoMap()
        {
            DiscriminatorValue("Transportno sredstvo");
        }
    }
    public class AlatMap : SubclassMap<Alat>
    {
        public AlatMap()
        {
            DiscriminatorValue("Alat");
        }
    }
    public class SpecijalizovanaOpremaMap : SubclassMap<SpecijalizovanaOprema>
    {
        public SpecijalizovanaOpremaMap()
        {
            DiscriminatorValue("Specijalizovana oprema");
        }
    }
}
