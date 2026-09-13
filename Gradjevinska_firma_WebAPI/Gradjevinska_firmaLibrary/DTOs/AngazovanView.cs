using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class AngazovanView
    {
        public int ZadatakId { get; set; }
        public int OsobaId { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }
        public string StatusAngazovanja { get; set; }

        public AngazovanView()
        {
        }

        internal AngazovanView(Angazovan angazovan)
        {
            ZadatakId = angazovan.Zadatak.Id;
            OsobaId = angazovan.Osoba.Id;
            DatumOd = angazovan.DatumOd;
            DatumDo = angazovan.DatumDo;
            StatusAngazovanja = angazovan.StatusAngazovanja;
        }
    }
}
