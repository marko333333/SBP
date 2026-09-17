using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class SertifikatSpecOpremeView
    {
        public int Id { get; set; }
        public int FizickoLiceId { get; set; }
        public string Sertifikat { get; set; }

        public SertifikatSpecOpremeView()
        {
        }

        internal SertifikatSpecOpremeView(SertifikatSpecOpreme sertifikatSpec)
        {
            Id = sertifikatSpec.Id;
            FizickoLiceId = sertifikatSpec.FizickoLice.Id;
            Sertifikat = sertifikatSpec.Sertifikat;
        }
    }
}
