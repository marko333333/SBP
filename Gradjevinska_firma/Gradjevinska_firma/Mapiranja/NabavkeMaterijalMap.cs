using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
namespace Gradjevinska_firma.Mapiranja
{
    public class NabavkeMaterijalMap:ClassMap<NabavkaMaterijal>
    {
        public NabavkeMaterijalMap()
        {
            Table("NABAVKAMATERIJAL");

            Id(x => x.ID).GeneratedBy.TriggerIdentity();

            References(x => x.Nabavke, "IDNABAVKA");
            References(x => x.Materijal, "IDMATERIJAL");

            Map(x => x.Kolicina, "KOLICINA");
            Map(x => x.Cena, "CENA");
            Map(x => x.Status_isporuke, "STATUS_ISPORUKE");
        }
    }
}
