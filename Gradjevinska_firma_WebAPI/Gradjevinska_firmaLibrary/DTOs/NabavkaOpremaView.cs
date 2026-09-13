using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class NabavkaOpremaView
    {
        public int ID { get; protected set; }
        public int Kolicina { get; set; }
        public int Cena { get; set; }
        public bool Status_isporuke { get; set; }

        public int OpremaId { get; set; }
        public int NabavkaId { get; set; }

        public NabavkaOpremaView()
        {
        }

        internal NabavkaOpremaView(NabavkaOprema nabavkaOprema)
        {
            ID = nabavkaOprema.ID;
            Kolicina = nabavkaOprema.Kolicina;
            Cena = nabavkaOprema.Cena;
            Status_isporuke = nabavkaOprema.Status_isporuke;
            OpremaId = nabavkaOprema.Oprema.Id;
            NabavkaId = nabavkaOprema.Nabavka.Br_nabavke;
        }
    }
}
