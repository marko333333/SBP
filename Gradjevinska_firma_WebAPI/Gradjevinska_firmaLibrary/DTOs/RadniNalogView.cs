using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class RadniNalogView
    {
        public int BrojNaloga { get; set; }
        public string Status { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public int ZadatakId { get; set; }

        public RadniNalogView()
        {
        }

        internal RadniNalogView(RadniNalog radni)
        {
            BrojNaloga = radni.BrojNaloga;
            Status = radni.Status;
            DatumIzdavanja = radni.DatumIzdavanja;
            ZadatakId = radni.Zadatak.Id;
        }
    }   
}
