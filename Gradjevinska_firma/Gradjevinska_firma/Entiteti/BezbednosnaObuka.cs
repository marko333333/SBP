using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.Entiteti
{
    public class BezbednosnaObuka
    {
        public virtual FizickoLice FizickoLice { get; set; }
        public virtual string NazivObuke { get; set; }
        public virtual DateTime Datum { get; set; }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof(BezbednosnaObuka))
                return false;

            BezbednosnaObuka recievedObject = (BezbednosnaObuka)obj;

            if ((FizickoLice.Id == recievedObject.FizickoLice.Id) &&
                (NazivObuke == recievedObject.NazivObuke))
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
