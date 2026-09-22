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
    public class NapredakDTOManager
    {
        #region Napreci

        public static List<NapredakBasic> vratiNapretke(int idZadatka)
        {
            List<NapredakBasic> napreci = new List<NapredakBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Napredak> sviNapreci =
                    from n in s.Query<Napredak>()
                    where n.Zadatak.Id == idZadatka
                    select n;

                foreach (Napredak n in sviNapreci)
                {
                    napreci.Add(new NapredakBasic(
                        n.Id, n.Datum, null, n.DnevniIzvestaj, n.ProcenatRealizacije, n.PrimedbaNadzora, n.KorektivnaMera));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return napreci;
        }

        public static NapredakBasic vratiNapredak(int id)
        {
            NapredakBasic napredak = new NapredakBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Napredak n = s.Load<Napredak>(id);

                ZadatakBasic zadatak = null;

                if (n.Zadatak != null)
                {
                    zadatak = new ZadatakBasic();
                    zadatak.Id = n.Zadatak.Id;
                    zadatak.Naziv = n.Zadatak.Naziv;
                }

                napredak = new NapredakBasic(
                   n.Id, n.Datum, zadatak, n.DnevniIzvestaj, n.ProcenatRealizacije, n.PrimedbaNadzora, n.KorektivnaMera);

                napredak.Fotografije = FotografijaDTOManager.vratiFotografije(id);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return napredak;
        }

        public static void dodajNapredak(NapredakBasic napredak)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zadatak zadatak = s.Load<Zadatak>(napredak.Zadatak.Id);

                Napredak n = new Napredak();

                n.Datum = napredak.Datum;
                n.DnevniIzvestaj = napredak.DnevniIzvestaj;
                n.ProcenatRealizacije = napredak.ProcenatRealizacije;
                n.PrimedbaNadzora = napredak.PrimedbaNadzora;
                n.KorektivnaMera = napredak.KorektivnaMera;
                n.Zadatak = zadatak;

                s.Save(n);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniNapredak(NapredakBasic n)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Napredak napredak = s.Load<Napredak>(n.Id);

                napredak.Datum = n.Datum;
                napredak.DnevniIzvestaj = n.DnevniIzvestaj;
                napredak.ProcenatRealizacije = n.ProcenatRealizacije;
                napredak.PrimedbaNadzora = n.PrimedbaNadzora;
                napredak.KorektivnaMera = n.KorektivnaMera;

                s.Update(napredak);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiNapredak(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Napredak napredak = s.Load<Napredak>(id);

                s.Delete(napredak);
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
