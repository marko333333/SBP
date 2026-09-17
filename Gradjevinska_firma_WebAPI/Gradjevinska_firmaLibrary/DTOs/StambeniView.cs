using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firmaLibrary.Entiteti;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class StambeniView : ProjekatView
    {
        public StambeniView() { }
        internal StambeniView(Stambeni s) : base(s) { }
    }
}
