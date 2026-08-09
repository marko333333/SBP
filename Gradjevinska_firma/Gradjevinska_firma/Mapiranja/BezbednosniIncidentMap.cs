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
            Table("BEZBEDNOSNI_INCIDENT");

            DiscriminateSubClassesOnColumn("TIP_INCIDENTA");

            Id(x => x.ID, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Opis, "OPIS");
            Map(x => x.Datum,"DATUM");
            Map(x => x.Lokacija, "LOKACIJA");
            Map(x => x.Preduzete_mere, "PREDUZETE_MERE");
            Map(x => x.Posledice, "POSLEDICE");

            References(x => x.Projekat).Column("IDPROJEKTA");
            References(x => x.Osoba).Column("IDOSOBE");

            //HasMany(x => x.PoslediceIncidenta).KeyColumn("IDBEZBEDNOSNOGINCIDENTA").Cascade.AllDeleteOrphan().Inverse().LazyLoad();

            //HasMany(x=>x.PreduzeteMereIncidenta).KeyColumn("IDBEZBEDNOSNOGINCIDENTA").Cascade.AllDeleteOrphan().Inverse().LazyLoad();//deleteorphan jer All nema smisla, ne postoji preduzeta mera bez incidenta
        }
    }
    class PovredaNaRaduMap:SubclassMap<PovredaNaRadu> 
    {
        public PovredaNaRaduMap()
        {
            DiscriminatorValue("POVREDANARADU");
        }
    }
    class KvarOpremeMap : SubclassMap<KvarOpreme>
    {
        public KvarOpremeMap()
        {
            DiscriminatorValue("KVAROPREME");
        }
    }
    class NepostovanjeProceduraMap : SubclassMap<NepostovanjeProcedura>
    {
        public NepostovanjeProceduraMap()
        {
            DiscriminatorValue("NEPOSTOVANJEPROCEDURA");
        }
    }
    class OpasnaSituacijaMap : SubclassMap<OpasnaSituacija>
    {
        public OpasnaSituacijaMap()
        {
            DiscriminatorValue("OPASNASITUACIJA");
        }
    }
    class EkoloskiIncidentMap : SubclassMap<EkoloskiIncident>
    {
        public EkoloskiIncidentMap()
        {
            DiscriminatorValue("EKOLOSKIINCIDENT");
        }
    }
}
