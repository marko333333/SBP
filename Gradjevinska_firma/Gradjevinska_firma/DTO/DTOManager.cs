using Gradjevinska_firma.Data;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firma.Entiteti;

namespace Gradjevinska_firma.DTO
{
    public class DTOManager
    {
        #region Osobe

        public static List<OsobaPregled> vratiSveOsobe()
        {
            List<OsobaPregled> osobe = new List<OsobaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Osoba> sveOsobe = from o in s.Query<Osoba>()
                                              select o;
                foreach (Osoba o in sveOsobe)
                {
                    osobe.Add(new OsobaPregled(
                        o.Id, o.Jmbg, o.Ime, o.Prezime, o.DatumRodjenja, o.Struka));
                }
                s.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return osobe;
        }

        public static OsobaBasic vratiOsobu(int id)
        {
            OsobaBasic osoba = new OsobaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Osoba o = s.Load<Osoba>(id);

                osoba = new OsobaBasic(
                    o.Id,
                    o.Jmbg,
                    o.Ime,
                    o.Prezime,
                    o.DatumRodjenja,
                    o.Struka);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return osoba;
        }
        #endregion
    }
}
