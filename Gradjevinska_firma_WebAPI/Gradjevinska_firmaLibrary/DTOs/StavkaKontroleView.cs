using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class StavkaKontroleView
    {
        public int Id { get; protected set; }
        public int KontrolaId { get; set; }
        public int RedniBrojStavke { get; set; }
        public string Uzorci { get; set; }
        public string LabNalazi { get; set; }
        public string RezultatiIspitivanja { get; set; }
        public string KorektivneMere { get; set; }
        public DateTime? RokZaOtklanjanje { get; set; }

        public StavkaKontroleView()
        {
        }

        internal StavkaKontroleView(StavkaKontrole stavka)
        {
            Id = stavka.Id;
            KontrolaId = stavka.Kontrola.Id;
            RedniBrojStavke = stavka.RedniBrojStavke;
            Uzorci= stavka.Uzorci;
            LabNalazi = stavka.LabNalazi;
            RezultatiIspitivanja = stavka.RezultatiIspitivanja;
            KorektivneMere = stavka.KorektivneMere;
            RokZaOtklanjanje = stavka.RokZaOtklanjanje;
        }


    }
}
