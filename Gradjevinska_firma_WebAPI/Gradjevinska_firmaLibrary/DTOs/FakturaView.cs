using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class FakturaView
    {
        public int Br_fakture { get; set; }
        public int Iznos { get; set; }
        public string Valuta { get; set; }
        public bool statusPlacanja { get; set; }
        public DateTime Datum { get; set; }

        public int IDProjekta { get; set; }
        public int PravnoLiceIzdajeId { get; set; }
        public int PravnoLicePrimaId { get; set; }

        public FakturaView()
        {
        }

        internal FakturaView(Faktura faktura)
        {
            Br_fakture=faktura.Br_fakture;
            Iznos=faktura.Iznos;
            Valuta=faktura.Valuta;
            statusPlacanja = faktura.statusPlacanja;
            Datum=faktura.Datum;
            IDProjekta = faktura.IDProjekta.ID;
            PravnoLiceIzdajeId = faktura.PravnoLiceIzdaje.Id;
            PravnoLicePrimaId = faktura.PravnoLicePrima.Id;
        }
    }
}
