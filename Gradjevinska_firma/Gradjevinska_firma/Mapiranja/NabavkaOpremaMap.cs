using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using Gradjevinska_firma.Mapiranja;
namespace Gradjevinska_firma.Mapiranja
{
    public class NabavkaOpremaMap : ClassMap<NabavkaOprema>
    {
        public NabavkaOpremaMap()
        {
            Table("NabavkaOprema");

            Id(x => x.ID, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Kolicina, "KOLICINA");
            Map(x => x.Cena, "CENA");
            Map(x => x.Status_isporuke, "STATUSISPORUKE");

            References(x => x.Nabavka, "IDNABAVKE");
            References(x => x.Oprema, "IDOPREMA");

        }
    }
}