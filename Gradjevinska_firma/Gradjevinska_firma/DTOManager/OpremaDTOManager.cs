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
    public class OpremaDTOManager
    {
        #region Opreme
        public static List<OpremaPregled> vratiSvuOpremu()
        {
            List<OpremaPregled> oprema = new List<OpremaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Oprema> svuOpremu = from o in s.Query<Oprema>()
                                                select o;
                foreach (Oprema o in svuOpremu)
                {
                    oprema.Add(new OpremaPregled(
                       o.Id, o.Naziv, o.Tip, o.DatumUvoza, o.Proizvodjac, o.RasponOdrzavanja, o.Lokacija, o.Status));
                }
                s.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return oprema;
        }

        public static OpremaBasic vratiOpremu(int id)
        {
            OpremaBasic oprema = new OpremaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Oprema m = s.Load<Oprema>(id);

                oprema = new OpremaBasic(
                    m.Id, m.Naziv, m.Tip, m.DatumUvoza, m.Proizvodjac, m.RasponOdrzavanja, m.Lokacija, m.Status);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return oprema;
        }

        public static void dodajOpremu(OpremaBasic oprema)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Oprema o = new Oprema();

                o.Naziv = oprema.Naziv;
                o.Tip = oprema.Tip;
                o.DatumUvoza = oprema.DatumUvoza;
                o.Proizvodjac = oprema.Proizvodjac;
                o.RasponOdrzavanja = oprema.RasponOdrzavanja;
                o.Lokacija = oprema.Lokacija;
                o.Status = oprema.Status;

                s.Save(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniOpremu(OpremaBasic m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Oprema oprema = s.Load<Oprema>(m.Id);

                oprema.Naziv = m.Naziv;
                oprema.Tip = m.Tip;
                oprema.DatumUvoza = m.DatumUvoza;
                oprema.Proizvodjac = m.Proizvodjac;
                oprema.RasponOdrzavanja = m.RasponOdrzavanja;
                oprema.Lokacija = m.Lokacija;
                oprema.Status = m.Status;

                s.Update(oprema);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiOpremu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Oprema oprema = s.Load<Oprema>(id);

                s.Delete(oprema);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        #region Mehanizacija

        public static List<MehanizacijaPregled> vratiSveMehanizacije()
        {
            List<MehanizacijaPregled> mehanizacije = new List<MehanizacijaPregled>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Mehanizacija> sveMehanizacije =
                    from m in s.Query<Mehanizacija>()
                    select m;

                foreach (Mehanizacija m in sveMehanizacije)
                {
                    mehanizacije.Add(new MehanizacijaPregled(
                            m.Id, m.Naziv, m.Tip, m.DatumUvoza, m.Proizvodjac, m.RasponOdrzavanja, m.Lokacija, m.Status, m.TipMehanizacije)
                    );
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return mehanizacije;
        }

        public static MehanizacijaBasic vratiMehanizaciju(int id)
        {
            MehanizacijaBasic mehanizacija = null;

            try
            {
                ISession s = DataLayer.GetSession();

                Mehanizacija m = s.Load<Mehanizacija>(id);

                mehanizacija = new MehanizacijaBasic(
                    m.Id, m.Naziv, m.Tip, m.DatumUvoza, m.Proizvodjac, m.RasponOdrzavanja, m.Lokacija, m.Status, m.TipMehanizacije
                );

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return mehanizacija;
        }

        public static void dodajMehanizaciju(MehanizacijaBasic m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Mehanizacija mehanizacija = new Mehanizacija();

                mehanizacija.Naziv = m.Naziv;
                mehanizacija.Tip = m.Tip;
                mehanizacija.DatumUvoza = m.DatumUvoza;
                mehanizacija.Proizvodjac = m.Proizvodjac;
                mehanizacija.RasponOdrzavanja = m.RasponOdrzavanja;
                mehanizacija.Lokacija = m.Lokacija;
                mehanizacija.Status = m.Status;

                mehanizacija.TipMehanizacije = m.TipMehanizacije;

                s.Save(mehanizacija);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniMehanizaciju(MehanizacijaBasic m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Mehanizacija mehanizacija = s.Load<Mehanizacija>(m.Id);

                mehanizacija.Naziv = m.Naziv;
                mehanizacija.Tip = m.Tip;
                mehanizacija.DatumUvoza = m.DatumUvoza;
                mehanizacija.Proizvodjac = m.Proizvodjac;
                mehanizacija.RasponOdrzavanja = m.RasponOdrzavanja;
                mehanizacija.Lokacija = m.Lokacija;
                mehanizacija.Status = m.Status;
                mehanizacija.TipMehanizacije = m.TipMehanizacije;

                s.Update(mehanizacija);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        #endregion

        #endregion
    }
}
