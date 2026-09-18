using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class NabavkaMaterijalView
    {
        public int ID { get; set; }
        public int Kolicina { get; set; }
        public int Cena { get; set; }
        public bool Status_isporuke { get; set; }

        public int MaterijalId { get; set; }
        public int NabavkeId { get; set; }

        public NabavkaMaterijalView()
        {
        }

        internal NabavkaMaterijalView(NabavkaMaterijal nabavkaMaterijal)
        {
            ID = nabavkaMaterijal.ID;
            Kolicina = nabavkaMaterijal.Kolicina;
            Cena = nabavkaMaterijal.Cena;
            Status_isporuke = nabavkaMaterijal.Status_isporuke;
            MaterijalId = nabavkaMaterijal.Materijal.ID;
            NabavkeId = nabavkaMaterijal.Nabavke.Br_nabavke;
        }
    }
}
