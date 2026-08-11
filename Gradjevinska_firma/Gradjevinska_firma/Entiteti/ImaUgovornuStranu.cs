using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class ImaUgovornuStranu
    {
        public virtual Osoba Osoba { get; set; }
        public virtual Ugovor Ugovor { get; set; }
        public virtual string Uloga { get; set; }
        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof(ImaUgovornuStranu))
                return false;

            ImaUgovornuStranu recievedObject = (ImaUgovornuStranu)obj;

            if ((Osoba.Id == recievedObject.Osoba.Id) &&
                (Ugovor.Id == recievedObject.Ugovor.Id))
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
