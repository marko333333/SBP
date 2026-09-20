using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class FazaView
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }
        public string Status { get; set; }
        public int? Budzet { get; set; }
        public int ProjekatId { get; set; }
        public int FizickoLiceId { get; set; }
        public int? NadFazaId { get; set; }

        public FazaView()
        {
        }

        internal FazaView(Faza faza)
        {
            Id = faza.Id;
            Naziv=faza.Naziv;
            DatumDo = faza.DatumDo;
            DatumOd = faza.DatumOd;
            Status = faza.Status;
            Budzet = faza.Budzet;
            ProjekatId = faza.Projekat.ID;
            FizickoLiceId = faza.FizickoLice.Id;
            NadFazaId = faza.NadFaza?.Id;

        }
    }
}
