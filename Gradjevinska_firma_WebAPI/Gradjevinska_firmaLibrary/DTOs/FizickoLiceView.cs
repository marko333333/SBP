using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class FizickoLiceView:OsobaView
    {
        public bool FlagBK { get; set; }
        public bool FlagR { get; set; }
        public string? Kvalifikacija { get; set; }
        public bool FlagI { get; set; }
        public string? OblastRada { get; set; }
        public string? Odgovornosti { get; set; }
        public bool FlagA { get; set; }
        public bool FlagP { get; set; }
        public bool FlagN { get; set; }
        public bool FlagAO { get; set; }

        public FizickoLiceView()
        {
        }

        internal FizickoLiceView(FizickoLice f)
            : base(f)
        {
            FlagBK = f.FlagBK;
            FlagR = f.FlagR;
            Kvalifikacija = f.Kvalifikacija;
            FlagI = f.FlagI;
            OblastRada = f.OblastRada;
            Odgovornosti = f.Odgovornosti;
            FlagA = f.FlagA;
            FlagP = f.FlagP;
            FlagN = f.FlagN;
            FlagAO = f.FlagAO;
        }
    }
}
