using FluentNHibernate.Mapping;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Mapiranja
{
    public class ProjekatMap: ClassMap<Projekat>
    {   
        public ProjekatMap() {

            //dodaj vezano za mapiranje


            HasMany(x => x.Ugovori)
                .KeyColumn("IDPROJEKTA")
                .LazyLoad()
                .Cascade.All()
                .Inverse();

        }
    }
}
