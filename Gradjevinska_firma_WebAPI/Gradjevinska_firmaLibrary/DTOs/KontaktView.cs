using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class KontaktView
    {
        public int Id { get; set; }
        public int OsobaId { get; set; }
        public string Broj { get; set; }

        public KontaktView()
        {
        }

        internal KontaktView(Kontakt kontakt)
        {
            Id = kontakt.Id;
            OsobaId = kontakt.Osoba.Id;
            Broj = kontakt.Broj;
        }
    }
}
