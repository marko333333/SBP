using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firmaLibrary.Entiteti;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class MehanizacijaView : OpremaView
    {
        public string TipMehanizacije { get; set; }

        public MehanizacijaView() { }
        internal MehanizacijaView(Mehanizacija m) : base(m) 
        {
            TipMehanizacije = m.TipMehanizacije;
        }
    }
}
