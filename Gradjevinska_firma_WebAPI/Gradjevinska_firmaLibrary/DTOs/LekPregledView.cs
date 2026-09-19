using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class LekPregledView
    {
        public int Id { get; set; }
        public int FizickoLiceId { get; set; }
        public string Rezultat { get; set; }
        public DateTime Datum { get; set; }

        public LekPregledView()
        {
        }

        internal LekPregledView(LekarskiPregled lekpregled)
        {
            Id = lekpregled.Id;
            FizickoLiceId = lekpregled.FizickoLice.Id;
            Rezultat = lekpregled.Rezultat;
            Datum = lekpregled.Datum;
        }
    }
}
