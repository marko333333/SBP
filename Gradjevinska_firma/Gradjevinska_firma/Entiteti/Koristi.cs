using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Koristi//klasa za M:N zadatak-materijal
    {
        //ja sam stavljala da negde bude surogat, tipa kod napredak sada imamo da ima Id, i jos negde
        public virtual int ID { get; protected set; }//surogat kljuc ili mora kompozitni? ZA SVAKU M:N SAM KORISTIO SUROGAT
        public virtual Zadatak Zadatak { get; set; }
        public virtual Materijal Materijal { get; set; }
        public virtual int Kolicina { get; set; }
    }
}
