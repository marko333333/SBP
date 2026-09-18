using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firmaLibrary.Entiteti;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class DeonicaView
    {
        public int Id {  get; set; }
        public int Br_deonice { get; set; }
        public int infrastrukturaId { get; set; }

        public DeonicaView() { }
        internal DeonicaView(Deonica d)
        {
            Id = d.Id;
            Br_deonice = d.Br_deonice;
            infrastrukturaId = d.Infrastruktura.ID;
        }
    }
}
