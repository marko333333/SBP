using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class PosebnaKlauzulaView
    {
        public int Id { get; protected set; }
        public string TekstKlauzule { get; set; }
        public int UgovorId { get; set; }

        public PosebnaKlauzulaView()
        {
        }

        internal PosebnaKlauzulaView(PosebnaKlauzula posebnaKlauzula)
        {
            Id = posebnaKlauzula.Id;
            TekstKlauzule = posebnaKlauzula.TekstKlauzule;
            UgovorId = posebnaKlauzula.Ugovor.Id;
        }
    }
}
