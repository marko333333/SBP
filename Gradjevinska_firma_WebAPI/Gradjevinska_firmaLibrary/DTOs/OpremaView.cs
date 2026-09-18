using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firmaLibrary.Entiteti;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class OpremaView
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public DateTime DatumUvoza { get; set; }
        public string Proizvodjac { get; set; }
        public string RasponOdrzavanja { get; set; }
        public string Lokacija { get; set; }
        public string Status { get; set; }

        public OpremaView() { }
        internal OpremaView(Oprema o)
        {
            Id = o.Id;
            Naziv = o.Naziv;
            Tip = o.Tip;
            DatumUvoza = o.DatumUvoza;
            Proizvodjac = o.Proizvodjac;
            RasponOdrzavanja = o.RasponOdrzavanja;
            Lokacija = o.Lokacija;
            Status = o.Status;
        }
    }
}
