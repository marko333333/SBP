using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Projekat
    {   
        //dodaj ostale vezane stvari za Projekat
        //ovde isto one klase Stambeni, Poslovni sve bih ovde stavila
        public virtual IList<Ugovor> Ugovori { get; set; }

        public Projekat()
        {
            Ugovori = new List<Ugovor>();
        }
    }
}
