using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firmaLibrary.Entiteti;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class InfrastrukturaView : ProjekatView
    {
        public InfrastrukturaView() { }
        internal InfrastrukturaView(Infrastruktura i) : base(i) { }
    }
}
