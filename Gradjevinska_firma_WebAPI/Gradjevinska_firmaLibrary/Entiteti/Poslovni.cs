using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.Entiteti
{
    public class Poslovni : Projekat
    {
        public virtual IList<ObjekatPoslovni> Objekti { get; set; }
    }
}
