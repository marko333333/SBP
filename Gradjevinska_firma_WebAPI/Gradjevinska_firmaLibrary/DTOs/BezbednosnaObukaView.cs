using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class BezbednosnaObukaView
    {
        public int Id { get; set; }
        public int FizickoLiceId { get; set; }
        public string NazivObuke { get; set; }
        public DateTime Datum { get; set; }

        public BezbednosnaObukaView()
        {
        }

        internal BezbednosnaObukaView(BezbednosnaObuka bezObuka)
        {
            Id = bezObuka.Id;
            FizickoLiceId = bezObuka.FizickoLice.Id;
            NazivObuke = bezObuka.NazivObuke;
            Datum = bezObuka.Datum;
        }
    }
}
