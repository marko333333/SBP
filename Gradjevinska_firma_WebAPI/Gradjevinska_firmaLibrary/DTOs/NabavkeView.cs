using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class NabavkeView
    {
        public int Br_nabavke { get; set; }
        public DateTime Datum { get; set; }

        public int DobavljacId { get; set; }
        public int ProjekatId { get; set; }

        public NabavkeView()
        {
        }

        internal NabavkeView(Nabavke nabavke)
        {
            Br_nabavke = nabavke.Br_nabavke;
            Datum = nabavke.Datum;
            ProjekatId = nabavke.Projekat.ID;
            DobavljacId = nabavke.Dobavljac.Id;
        }
    }   
}
