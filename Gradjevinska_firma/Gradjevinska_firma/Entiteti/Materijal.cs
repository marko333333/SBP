using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Materijal
    {
        //dodaj vezano za materijal
        //ovde bi napravila one dodatne klase
        //Gradjevinski materijal, ElektroMaterijal...
        public virtual IList<Ugovor> Ugovori { get; set; }
        public Materijal()
        {
            Ugovori = new List<Ugovor>();
        }

    }
}
