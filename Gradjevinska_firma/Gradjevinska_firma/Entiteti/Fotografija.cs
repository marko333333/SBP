using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Fotografija
    {
        public virtual Napredak Napredak { get; set; }
        public virtual string Putanja { get; set; }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof(Fotografija))
                return false;

            Fotografija recievedObject = (Fotografija)obj;

            if ((Napredak.Id == recievedObject.Napredak.Id) &&
                (Putanja == recievedObject.Putanja))
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
