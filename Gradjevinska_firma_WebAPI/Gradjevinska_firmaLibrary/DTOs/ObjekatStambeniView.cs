using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firmaLibrary.Entiteti;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class ObjekatStambeniView
    {
        public int Id { get; set; }
        public int Br_objekta { get; set; }
        public int Spratnost { get; set; }
        public int Br_jedinica { get; set; }
        public int StambeniId { get; set; }

        public ObjekatStambeniView() { }
        internal ObjekatStambeniView(ObjekatStambeni o)
        {
            Id = o.Id;
            Br_objekta = o.Br_objekta;
            Spratnost = o.Spratnost;
            Br_jedinica = o.Br_jedinica;
            StambeniId = o.Stambeni.ID;
        }
    }
}
