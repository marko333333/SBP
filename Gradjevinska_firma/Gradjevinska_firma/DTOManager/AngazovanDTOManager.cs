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
    public class AngazovanDTOManager
    {
        #region Angazovani

        public static List<AngazovanBasic> vratiSveAngazovanja(int idZadatka)
        {
            List<AngazovanBasic> angazovanja = new List<AngazovanBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Angazovan> svaAngazovanja =
                    from a in s.Query<Angazovan>()
                    where a.Zadatak.Id == idZadatka
                    select a;

                foreach (Angazovan a in svaAngazovanja)
                {
                    ZadatakBasic zadatak = null;

                    if (a.Zadatak != null)
                    {
                        zadatak = new ZadatakBasic();
                        zadatak.Id = a.Zadatak.Id;
                        zadatak.Naziv = a.Zadatak.Naziv;
                    }

                    OsobaBasic osoba = null;

                    if (a.Osoba != null)
                    {
                        osoba = new OsobaBasic();
                        osoba.Id = a.Osoba.Id;
                        osoba.Ime = a.Osoba.Ime;
                        osoba.Prezime = a.Osoba.Prezime;
                    }

                    AngazovanBasic ab = new AngazovanBasic(
                            zadatak, osoba, a.DatumOd, a.DatumDo, a.StatusAngazovanja
                        );

                    angazovanja.Add(ab);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());
            }

            return angazovanja;
        }

        public static AngazovanBasic vratiAngazovanje(int idZadatka, int idOsobe)
        {
            AngazovanBasic angazovanje = null;

            try
            {
                ISession s = DataLayer.GetSession();

                Angazovan a = (
                    from x in s.Query<Angazovan>()
                    where x.Zadatak.Id == idZadatka
                       && x.Osoba.Id == idOsobe
                    select x
                ).FirstOrDefault();

                if (a != null)
                {
                    ZadatakBasic zadatak = new ZadatakBasic();
                    zadatak.Id = a.Zadatak.Id;
                    zadatak.Naziv = a.Zadatak.Naziv;

                    OsobaBasic osoba = new OsobaBasic();
                    osoba.Id = a.Osoba.Id;
                    osoba.Ime = a.Osoba.Ime;
                    osoba.Prezime = a.Osoba.Prezime;

                    angazovanje = new AngazovanBasic(
                        zadatak,
                        osoba,
                        a.DatumOd,
                        a.DatumDo,
                        a.StatusAngazovanja
                    );
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return angazovanje;
        }

        public static void dodajAngazovanje(AngazovanBasic angazovanje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zadatak zadatak = s.Load<Zadatak>(angazovanje.Zadatak.Id);

                Osoba osoba = s.Load<Osoba>(angazovanje.Osoba.Id);

                Angazovan a = new Angazovan();

                a.Zadatak = zadatak;
                a.Osoba = osoba;
                a.DatumOd = angazovanje.DatumOd;
                a.DatumDo = angazovanje.DatumDo;
                a.StatusAngazovanja = angazovanje.StatusAngazovanja;

                s.Save(a);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniAngazovanje(AngazovanBasic angazovanje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Angazovan a =
                    (from x in s.Query<Angazovan>()
                     where x.Zadatak.Id == angazovanje.Zadatak.Id
                        && x.Osoba.Id == angazovanje.Osoba.Id
                     select x).FirstOrDefault();

                a.DatumOd = angazovanje.DatumOd;
                a.DatumDo = angazovanje.DatumDo;
                a.StatusAngazovanja = angazovanje.StatusAngazovanja;

                s.Update(a);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiAngazovanje(int idZadatka, int idOsobe)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Angazovan a =
                    (from x in s.Query<Angazovan>()
                     where x.Zadatak.Id == idZadatka
                        && x.Osoba.Id == idOsobe
                     select x).FirstOrDefault();

                s.Delete(a);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }


        #endregion
    }
}
