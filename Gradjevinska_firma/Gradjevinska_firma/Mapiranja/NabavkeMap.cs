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
            Table("Nabavke");

            Id(x => x.Br_nabavke, "BRNABAVKE").GeneratedBy.TriggerIdentity();

            Map(x => x.Datum, "DATUM");

            References(x=>x.Projekat, "IDPROJEKAT");

            HasMany(x => x.NabavkaMaterijal).KeyColumn("IDNABAVKE").LazyLoad().Cascade.All().Inverse();

            HasMany(x => x.NabavkaOprema).KeyColumn("IDNABAVKE").LazyLoad().Cascade.All().Inverse();
        }
    }
}
