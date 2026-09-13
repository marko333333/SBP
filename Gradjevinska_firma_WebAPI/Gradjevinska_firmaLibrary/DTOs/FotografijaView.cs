using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class FotografijaView
    {
        public int NapredakId { get; set; }
        public string Putanja { get; set; }

        public FotografijaView()
        {
        }

        internal FotografijaView(Fotografija fotografija)
        {
            NapredakId = fotografija.Napredak.Id;
            Putanja = fotografija.Putanja;
        }
    }
}
