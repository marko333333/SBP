using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class ZastitnaOpremaView
    {
        public int Id { get; set; }
        public int FizickoLiceId { get; set; }
        public string NazivOpreme { get; set; }

        public ZastitnaOpremaView()
        {
        }

        internal ZastitnaOpremaView(ZastitnaOprema zastitnaOprema)
        {
            Id = zastitnaOprema.Id;
            FizickoLiceId = zastitnaOprema.FizickoLice.Id;
            NazivOpreme = zastitnaOprema.NazivOpreme;
        }
    }
}
