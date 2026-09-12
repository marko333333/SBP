using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class LicencaView
    {
        public int Id { get; set; }
        public int OsobaId { get; set; }
        public string NazivLicence { get; set; }

        public LicencaView()
        {
        }

        internal LicencaView(Licenca licenca)
        {
            Id = licenca.Id;
            OsobaId = licenca.Osoba.Id;
            NazivLicence = licenca.NazivLicence;
        }
    }
}
