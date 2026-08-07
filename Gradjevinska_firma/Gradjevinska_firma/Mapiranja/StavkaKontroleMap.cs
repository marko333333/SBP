using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class StavkaKontroleMap:ClassMap<StavkaKontrole>
    {
        public StavkaKontroleMap()
        {
            Table("STAVKA_KONTROLE");

            CompositeId()
                .KeyReference(x => x.Kontrola, "IDKONTROLE")
                .KeyProperty(x => x.RedniBrojStavke, "REDNI_BROJ_STAVKE");

            Map(x => x.Uzorci, "UZORCI");
            Map(x => x.LabNalazi, "LAB_NALAZI");
            Map(x => x.RezultatiIspitivanja, "REZULTATI_ISPITIVANJA");
            Map(x => x.KorektivneMere, "KOREKTIVNE_MERE");
            Map(x => x.RokZaOtklanjanje, "ROK_ZA_OTKLANJANJE");
        }
    }
}
