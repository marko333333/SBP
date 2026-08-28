using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.Entiteti
{
    public class Koristi
    {

        public virtual int ID { get; protected set; }
        public virtual Zadatak Zadatak { get; set; }
        public virtual Materijal Materijal { get; set; }
        public virtual int Kolicina { get; set; }
    }
}
