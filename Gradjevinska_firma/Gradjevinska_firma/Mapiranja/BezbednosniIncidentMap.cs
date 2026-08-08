using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
namespace Gradjevinska_firma.Mapiranja
{
    public class BezbednosniIncidentMap:ClassMap<BezbednosniIncident>
    {
        public BezbednosniIncidentMap() 
        {
            Table("BezbednosiIncident");

            Id(x => x.ID, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Opis, "OPIS");
            Map(x => x.Datum,"DATUM");
            Map(x => x.Lokacija, "LOKACIJA");
            Map(x => x.Preduzete_mere, "PREDUZETEMERE");
            Map(x => x.Posledice, "POSLEDICE");
            Map(x => x.Tip_incidenta, "TIPINCIDENTA");

            References(x => x.Projekat).Column("IDPROJEKTA");
            References(x => x.Osoba).Column("IDOSOBE");

            HasMany(x => x.PoslediceIncidenta).KeyColumn("IDBEZBEDNOSNOGINCIDENTA").Cascade.AllDeleteOrphan().Inverse().LazyLoad();

            HasMany(x=>x.PreduzeteMereIncidenta).KeyColumn("IDBEZBEDNOSNOGINCIDENTA").Cascade.AllDeleteOrphan().Inverse().LazyLoad();//deleteorphan jer All nema smisla, ne postoji preduzeta mera bez incidenta
        }
    }
}
