using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Koristi//klasa za M:N zadatak-materijal
    {
        public virtual int ID { get; set; }//surogat kljuc ili mora kompozitni? ZA SVAKU M:N SAM KORISTIO SUROGAT
        public virtual Zadatak Zadatak { get; set; }
        public virtual Materijal Materijal { get; set; }
        public virtual int Kolicina { get; set; }
    }
}
