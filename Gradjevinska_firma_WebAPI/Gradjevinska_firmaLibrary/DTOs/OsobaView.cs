using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class OsobaView
    {
        public int Id { get; set; }
        public string Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string? Struka { get; set; }

        public OsobaView()
        {
        }

        internal OsobaView(Osoba o)
        {
            Id = o.Id;
            Jmbg = o.Jmbg;
            Ime = o.Ime;
            Prezime = o.Prezime;
            DatumRodjenja = o.DatumRodjenja;
            Struka = o.Struka;
        }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }
    }
}
