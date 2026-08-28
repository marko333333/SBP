using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class PravnaLicaView:OsobaView
    {
        public bool FlagPB { get; set; }
        public bool FlagInve { get; set; }
        public bool FlagIzv { get; set; }
        public bool FlagP { get; set; }
        public bool FlagD { get; set; }
        public bool FlagN { get; set; }

        public PravnaLicaView()
        {
        }

        internal PravnaLicaView(PravnaLica p)
            : base(p)
        {
            FlagPB = p.FlagPB;
            FlagInve = p.FlagInve;
            FlagIzv = p.FlagIzv;
            FlagP = p.FlagP;
            FlagD = p.FlagD;
            FlagN = p.FlagN;
        }
    }
}
