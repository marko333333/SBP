using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class StavkaKontrole
    {   
        public virtual int Id { get; protected set; }
        public virtual KontrolaKvaliteta Kontrola { get; set; }
        public virtual int RedniBrojStavke { get; set; }
        public virtual string Uzorci { get; set; }
        public virtual string LabNalazi { get; set; }
        public virtual string RezultatiIspitivanja { get; set; }
        public virtual string KorektivneMere { get; set; }
        public virtual DateTime? RokZaOtklanjanje { get; set; }
    }
}
