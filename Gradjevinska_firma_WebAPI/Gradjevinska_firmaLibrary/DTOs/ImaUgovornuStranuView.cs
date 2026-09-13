using Gradjevinska_firmaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class ImaUgovornuStranuView
    {
        public int Id { get; protected set; }
        public int OsobaId { get; set; }
        public int UgovorId { get; set; }
        public string Uloga { get; set; }

        public ImaUgovornuStranuView()
        {
        }

        internal ImaUgovornuStranuView(ImaUgovornuStranu strana)
        {
            Id = strana.Id;
            OsobaId = strana.Osoba.Id;
            UgovorId = strana.Ugovor.Id;
            Uloga=strana.Uloga;
        }
    }
}
