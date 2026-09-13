using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class NapredakView
    {
        public int Id { get; protected set; }
        public DateTime Datum { get; set; }
        public int ZadatakId { get; set; }
        public string DnevniIzvestaj { get; set; }
        public int ProcenatRealizacije { get; set; }
        public string PrimedbaNadzora { get; set; }
        public string KorektivnaMera { get; set; }

        public NapredakView()
        {
        }

        internal NapredakView(Napredak napredak)
        {
            Id = napredak.Id;
            Datum=napredak.Datum;
            ZadatakId = napredak.Zadatak.Id;
            DnevniIzvestaj = napredak.DnevniIzvestaj;
            ProcenatRealizacije = napredak.ProcenatRealizacije;
            PrimedbaNadzora = napredak.PrimedbaNadzora;
            KorektivnaMera = napredak.KorektivnaMera;

        }
    }
}
