using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
namespace Gradjevinska_firma.Mapiranja
{
    public class NabavkeMap:ClassMap<Nabavke>
    {
        public NabavkeMap() 
        {
            Table("NABAVKE");

            Id(x => x.Br_nabavke, "BR_NABAVKE").GeneratedBy.TriggerIdentity();

            Map(x => x.Datum, "DATUM");

            References(x=>x.Projekat, "IDPROJEKTA");

            References(x => x.Dobavljac, "IDOSOBA");

            HasMany(x => x.NabavkaMaterijal).KeyColumn("IDNABAVKA").LazyLoad().Cascade.All().Inverse();

            HasMany(x => x.NabavkaOprema).KeyColumn("IDNABAVKA").LazyLoad().Cascade.All().Inverse();
        }
    }
}
