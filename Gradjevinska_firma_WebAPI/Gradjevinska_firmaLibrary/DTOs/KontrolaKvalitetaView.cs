using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class KontrolaKvalitetaView
    {
        public int Id { get; set; }
        public DateTime DatumInspekcije { get; set; }
        public string? PrimedbeNadzora { get; set; }
        public string? Zapisnik { get; set; }
        public bool ZabranaNastavkaRadova { get; set; }
        public string? RazlogZabrane { get; set; }
        public DateTime? DatumOtklanjanjaZabrane { get; set; }
        public int ZadatakId { get; set; }

        public KontrolaKvalitetaView()
        {
        }

        internal KontrolaKvalitetaView(KontrolaKvaliteta kontrolaKvaliteta)
        {
            Id = kontrolaKvaliteta.Id;
            DatumInspekcije = kontrolaKvaliteta.DatumInspekcije;
            PrimedbeNadzora = kontrolaKvaliteta.PrimedbeNadzora;
            Zapisnik = kontrolaKvaliteta.Zapisnik;
            ZabranaNastavkaRadova = kontrolaKvaliteta.ZabranaNastavkaRadova;
            RazlogZabrane = kontrolaKvaliteta.RazlogZabrane;
            DatumOtklanjanjaZabrane = kontrolaKvaliteta.DatumOtklanjanjaZabrane;
            ZadatakId = kontrolaKvaliteta.Zadatak.Id;
        }
    }
}
