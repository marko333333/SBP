using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class AngazujeView
    {
        public int ZadatakId { get; set; }
        public int OpremaId { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }
        public int BrojSati { get; set; }

        public AngazujeView()
        {
        }

        internal AngazujeView(Angazuje angazuje)
        {
            ZadatakId = angazuje.Zadatak.Id;
            OpremaId = angazuje.Oprema.Id;
            DatumOd=angazuje.DatumOd;
            DatumDo = angazuje.DatumDo;
            BrojSati = angazuje.BrojSati;
        }
    }
}
