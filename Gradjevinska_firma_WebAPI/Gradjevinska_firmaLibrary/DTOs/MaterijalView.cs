using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firmaLibrary.Entiteti;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class MaterijalView
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public int Cena { get; set; }
        public string Proizvodjac { get; set; }
        public string JedinicaMere { get; set; }
        public string Sertifikat { get; set; }
        public string Tip { get; set; }

        public MaterijalView() { }
        internal MaterijalView(Materijal m)
        {
            ID = m.ID;
            Naziv = m.Naziv;
            Cena = m.Cena;
            Proizvodjac = m.Proizvodjac;
            JedinicaMere = m.JedinicaMere;
            Sertifikat = m.Sertifikat;
            Tip = m.GetType().Name;
        }
    }
}
