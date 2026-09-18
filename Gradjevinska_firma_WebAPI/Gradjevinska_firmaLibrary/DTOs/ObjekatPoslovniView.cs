using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firmaLibrary.Entiteti;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class ObjekatPoslovniView
    {
        public int Id {  get; set; }
        public  int Br_objekta { get; set; }
        public  int Spratnost { get; set; }
        public  int Br_jedinica { get; set; }
        public int PoslovniId { get; set; }

        public ObjekatPoslovniView() { }
        internal ObjekatPoslovniView(ObjekatPoslovni o)
        {
            Id = o.Id;
            Br_objekta = o.Br_objekta;
            Spratnost = o.Spratnost;
            Br_jedinica = o.Br_jedinica;
            PoslovniId = o.Poslovni.ID;
        }
    }
}
