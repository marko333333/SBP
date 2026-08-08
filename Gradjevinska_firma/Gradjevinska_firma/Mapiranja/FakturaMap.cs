using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;

namespace Gradjevinska_firma.Mapiranja
{
    public class FakturaMap : ClassMap<Faktura>
    {
        public FakturaMap() 
        {
            Table("Faktura");

            Id(x => x.Br_fakture, "Br_fakture").GeneratedBy.TriggerIdentity();

            Map(x => x.Iznos, "IZNOS");
            Map(x => x.Valuta, "VALUTA");
            Map(x => x.statusPlacanja, "STATUSPLACANJA");
            Map(x => x.Datum, "DATUM");

            References(x => x.IDProjekta).Column("IDPROJEKTA");
        }
    }

}
