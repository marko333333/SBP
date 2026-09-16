using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class UgovorView
    {
        public int Id { get; set; }
        public DateTime DatumPotpisivanja { get; set; }
        public decimal Vrednost { get; set; }
        public string PredmetUgovora { get; set; }
        public string Valuta { get; set; }
        public DateTime Rok { get; set; }
        public int? MaterijalId { get; set; }
        public int? ProjekatId { get; set; }
        public int? OpremaId { get; set; }

        public UgovorView()
        {
        }

        internal UgovorView(Ugovor ugovor)
        {
            Id = ugovor.Id;
            DatumPotpisivanja = ugovor.DatumPotpisivanja;
            Vrednost=ugovor.Vrednost;
            PredmetUgovora = ugovor.PredmetUgovora;
            Valuta=ugovor.Valuta;
            Rok = ugovor.Rok;
            MaterijalId = ugovor.Materijal?.ID;
            ProjekatId = ugovor.Projekat?.ID;
            OpremaId = ugovor.Oprema?.Id;
        }
    }
}
