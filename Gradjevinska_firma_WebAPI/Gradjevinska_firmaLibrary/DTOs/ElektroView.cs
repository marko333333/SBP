using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firmaLibrary.Entiteti;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class ElektroView : MaterijalView
    {
        public ElektroView() { }
        internal ElektroView(Elektro e) : base(e) { }
    }
}
