using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Angazovan
    {
        public virtual Zadatak Zadatak { get; set; }
        public virtual Osoba Osoba { get; set; }
        public virtual DateTime DatumOd { get; set; }
        public virtual DateTime? DatumDo { get; set; }
        public virtual string StatusAngazovanja { get; set; }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof(Angazovan))
                return false;

            Angazovan recievedObject = (Angazovan)obj;

            if ((Zadatak.Id == recievedObject.Zadatak.Id) &&
                (Osoba.Id == recievedObject.Osoba.Id))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

