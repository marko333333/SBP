using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class FizickoLice: Osoba
    {
        public virtual bool FlagBK { get; set; }

        public virtual bool FlagR { get; set; }

        public virtual string Kvalifikacija { get; set; }

        public virtual bool FlagI { get; set; }

        public virtual string OblastRada { get; set; }

        public virtual string Odgovornosti { get; set; }

        public virtual bool FlagA { get; set; }

        public virtual bool FlagP { get; set; }

        public virtual bool FlagN { get; set; }

        public virtual bool FlagAO { get; set; }
    }
}
