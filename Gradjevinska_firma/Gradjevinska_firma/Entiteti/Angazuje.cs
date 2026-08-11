using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class Angazuje
    {
        public virtual Zadatak Zadatak { get; set; }
        public virtual Oprema Oprema { get; set; }
        public virtual DateTime? DatumOd { get; set; }
        public virtual DateTime? DatumDo { get; set; }
        public virtual int BrojSati { get; set; }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof(Angazuje))
                return false;

            Angazuje recievedObject = (Angazuje)obj;

            if ((Zadatak.Id == recievedObject.Zadatak.Id) &&
                (Oprema.Id == recievedObject.Oprema.Id))
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
