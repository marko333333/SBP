using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class KoristiView
    {
        public int ID { get; protected set; }
        public int ZadatakId { get; set; }
        public int MaterijalId { get; set; }
        public int Kolicina { get; set; }

        public KoristiView()
        {
        }

        internal KoristiView(Koristi koristi)
        {
            ID = koristi.ID;
            ZadatakId=koristi.Zadatak.Id;
            MaterijalId = koristi.Materijal.ID;
            Kolicina = koristi.Kolicina;
        }
    }   

}
