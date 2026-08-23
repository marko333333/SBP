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
    public class AngazujOpremuDTOManager
    {
        #region AngazujeOpremu

        public static List<AngazujeBasic> vratiSveAngazuje(int idZadatka)
        {
            List<AngazujeBasic> angazuje = new List<AngazujeBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Angazuje> svaAngazovanja =
                    from a in s.Query<Angazuje>()
                    where a.Zadatak.Id == idZadatka
                    select a;

                foreach (Angazuje a in svaAngazovanja)
                {
                    ZadatakBasic zadatak = null;

                    if (a.Zadatak != null)
                    {
                        zadatak = new ZadatakBasic();
                        zadatak.Id = a.Zadatak.Id;
                        zadatak.Naziv = a.Zadatak.Naziv;
                    }

                    OpremaBasic oprema = null;

                    if (a.Oprema != null)
                    {
                        oprema = new OpremaBasic();
                        oprema.Id = a.Oprema.Id;
                        oprema.Naziv = a.Oprema.Naziv;
                    }

                    angazuje.Add(
                        new AngazujeBasic(
                            zadatak, oprema, a.DatumOd, a.DatumDo, a.BrojSati
                        )
                    );
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return angazuje;
        }

        public static AngazujeBasic vratiAngazuje(int idZadatka, int idOpreme)
        {
            AngazujeBasic angazuje = null;

            try
            {
                ISession s = DataLayer.GetSession();

                Angazuje a =
                    (from x in s.Query<Angazuje>()
                     where x.Zadatak.Id == idZadatka
                        && x.Oprema.Id == idOpreme
                     select x).FirstOrDefault();

                ZadatakBasic zadatak = null;

                if (a.Zadatak != null)
                {
                    zadatak = new ZadatakBasic();
                    zadatak.Id = a.Zadatak.Id;
                    zadatak.Naziv = a.Zadatak.Naziv;
                }

                OpremaBasic oprema = null;

                if (a.Oprema != null)
                {
                    oprema = new OpremaBasic();
                    oprema.Id = a.Oprema.Id;
                    oprema.Naziv = a.Oprema.Naziv;
                }

                angazuje = new AngazujeBasic(
                    zadatak, oprema, a.DatumOd, a.DatumDo, a.BrojSati
                );

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return angazuje;
        }

        public static void dodajAngazuje(AngazujeBasic angazuje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                if (angazuje.DatumDo.HasValue && angazuje.DatumDo.Value < angazuje.DatumOd)
                {
                    MessageBox.Show("Datum zavrsetka ne moze biti pre datuma pocetka");
                    s.Close();
                    return;
                }

                if (opremaJeZauzeta(s, angazuje.Zadatak.Id, angazuje.Oprema.Id, angazuje.DatumOd, angazuje.DatumDo))
                {
                    MessageBox.Show("Izabrana oprema je vec angazovana u tom periodu");
                    s.Close();
                    return;
                }

                Zadatak zadatak = s.Load<Zadatak>(angazuje.Zadatak.Id);

                Oprema oprema = s.Load<Oprema>(angazuje.Oprema.Id);

                Angazuje a = new Angazuje();

                a.Zadatak = zadatak;
                a.Oprema = oprema;
                a.DatumOd = angazuje.DatumOd;
                a.DatumDo = angazuje.DatumDo;
                a.BrojSati = angazuje.BrojSati;

                s.Save(a);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniAngazuje(AngazujeBasic angazuje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Angazuje a =
                    (from x in s.Query<Angazuje>()
                     where x.Zadatak.Id == angazuje.Zadatak.Id
                        && x.Oprema.Id == angazuje.Oprema.Id
                     select x).FirstOrDefault();

                a.DatumOd = angazuje.DatumOd;
                a.DatumDo = angazuje.DatumDo;
                a.BrojSati = angazuje.BrojSati;

                s.Update(a);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void obrisiAngazuje(int idZadatka, int idOpreme)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Angazuje a =
                    (from x in s.Query<Angazuje>()
                     where x.Zadatak.Id == idZadatka
                        && x.Oprema.Id == idOpreme
                     select x).FirstOrDefault();

                s.Delete(a);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static bool opremaJeZauzeta(ISession s, int idZadatka, int idOpreme, DateTime datumOd, DateTime? datumDo)
        {
            IEnumerable<Angazuje> angazovanja =
                from a in s.Query<Angazuje>()
                where a.Oprema.Id == idOpreme
                 && a.Zadatak.Id != idZadatka
                select a;

            foreach (Angazuje a in angazovanja)
            {
                DateTime postojeciKraj;

                if (a.DatumDo.HasValue)
                {
                    postojeciKraj = a.DatumDo.Value;
                }
                else
                {
                    postojeciKraj = DateTime.MaxValue;
                }

                DateTime noviKraj;

                if (datumDo.HasValue)
                {
                    noviKraj = datumDo.Value;
                }
                else
                {
                    noviKraj = DateTime.MaxValue;
                }

                if (datumOd <= postojeciKraj && a.DatumOd <= noviKraj)
                    return true;
            }

            return false;
        }

        #endregion
    }
}
