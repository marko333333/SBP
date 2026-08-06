using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class PravnaLica:Osoba
    {
        public virtual bool FlagPB { get; set; }

        public virtual bool FlagInve { get; set; }

        public virtual bool FlagIzv { get; set; }

        public virtual bool FlagP { get; set; }

        public virtual bool FlagD { get; set; }

        public virtual bool FlagN { get; set; }
    }
}
