using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firmaLibrary.Entiteti;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class GradjevinskiView : MaterijalView
    {
        public GradjevinskiView() { }
        internal GradjevinskiView(Gradjevinski g) : base(g) { }
    }
}
