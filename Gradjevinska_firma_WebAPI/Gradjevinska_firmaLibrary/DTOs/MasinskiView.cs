using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firmaLibrary.Entiteti;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class MasinskiView : MaterijalView
    {
        public MasinskiView() { }
        internal MasinskiView(Masinski m) : base(m) { }
    }
}
