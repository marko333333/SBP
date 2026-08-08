using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
namespace Gradjevinska_firma.Mapiranja
{
    public class PreduzeteMereIncidentaMap:ClassMap<PreduzeteMereIncidenta>
    {
        public PreduzeteMereIncidentaMap() 
        {
            Table("PreduzeteMereIncidenta");

            Id(x => x.ID, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Tekst, "TEKST");

            References(x => x.BezbednosniIncident, "IDBEZBEDNOSNOGINDICENTA");
        }
    }
}
