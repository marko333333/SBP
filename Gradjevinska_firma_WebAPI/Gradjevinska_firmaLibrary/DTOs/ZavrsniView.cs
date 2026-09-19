using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firmaLibrary.Entiteti;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class ZavrsniView : MaterijalView
    {
        public ZavrsniView() { }
        internal ZavrsniView(Zavrsni z) : base(z) { }
    }
}
