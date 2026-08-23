using Gradjevinska_firma.Data;
using Gradjevinska_firma.DTO;
using Gradjevinska_firma.Entiteti;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.DTOManager
{
    public class ImaUgovorneStraneDTOManager
    {
        #region ImaUgovorneStrane

        public static List<ImaUgovornuStranuBasic> vratiUgovorneStrane(int idUgovora)
        {
            List<ImaUgovornuStranuBasic> strane = new List<ImaUgovornuStranuBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ImaUgovornuStranu> sveStrane =
                    from i in s.Query<ImaUgovornuStranu>()
                    where i.Ugovor.Id == idUgovora
                    select i;

                foreach (ImaUgovornuStranu i in sveStrane)
                {
                    OsobaBasic osoba = null;

                    if (i.Osoba != null)
                    {
                        osoba = new OsobaBasic();
                        osoba.Id = i.Osoba.Id;
                        osoba.Ime = i.Osoba.Ime;
                        osoba.Prezime = i.Osoba.Prezime;
                    }

                    UgovorBasic ugovor = null;

                    if (i.Ugovor != null)
                    {
                        ugovor = new UgovorBasic();
                        ugovor.Id = i.Ugovor.Id;
                    }

                    strane.Add(new ImaUgovornuStranuBasic(
                            i.Id, osoba, ugovor, i.Uloga
                        )
                    );
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return strane;
        }

        public static ImaUgovornuStranuBasic vratiImaUgovornuStranu(int id)
        {
            ImaUgovornuStranuBasic strana = null;

            try
            {
                ISession s = DataLayer.GetSession();

                ImaUgovornuStranu i = s.Load<ImaUgovornuStranu>(id);

                OsobaBasic osoba = null;

                if (i.Osoba != null)
                {
                    osoba = new OsobaBasic();
                    osoba.Id = i.Osoba.Id;
                    osoba.Ime = i.Osoba.Ime;
                    osoba.Prezime = i.Osoba.Prezime;
                }

                UgovorBasic ugovor = null;

                if (i.Ugovor != null)
                {
                    ugovor = new UgovorBasic();
                    ugovor.Id = i.Ugovor.Id;
                }

                strana = new ImaUgovornuStranuBasic(
                    i.Id, osoba, ugovor, i.Uloga
                );

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return strana;
        }

        public static void dodajUgovornuStranu(ImaUgovornuStranuBasic i)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Osoba osoba = s.Load<Osoba>(i.Osoba.Id);

                Ugovor ugovor = s.Load<Ugovor>(i.Ugovor.Id);

                ImaUgovornuStranu strana = new ImaUgovornuStranu();

                strana.Osoba = osoba;
                strana.Ugovor = ugovor;
                strana.Uloga = i.Uloga;

                s.Save(strana);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniUgovornuStranu(ImaUgovornuStranuBasic i)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ImaUgovornuStranu strana = s.Load<ImaUgovornuStranu>(i.Id);

                strana.Uloga = i.Uloga;

                s.Update(strana);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void obrisiUgovornuStranu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ImaUgovornuStranu strana = s.Load<ImaUgovornuStranu>(id);

                s.Delete(strana);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion
    }
}
