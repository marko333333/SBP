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
    public class KoristiDTOManager
    {
        #region Koristi

        public static List<KoristiBasic> vratiKoristiZadatka(int idZadatka)
        {
            List<KoristiBasic> koristi = new List<KoristiBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Koristi> sveKoristi =
                    from k in s.Query<Koristi>()
                    where k.Zadatak.Id == idZadatka
                    select k;

                foreach (Koristi k in sveKoristi)
                {
                    ZadatakBasic zadatak = null;

                    if (k.Zadatak != null)
                    {
                        zadatak = new ZadatakBasic();
                        zadatak.Id = k.Zadatak.Id;
                        zadatak.Naziv = k.Zadatak.Naziv;
                    }

                    MaterijalBasic materijal = null;

                    if (k.Materijal != null)
                    {
                        materijal = new MaterijalBasic();
                        materijal.ID = k.Materijal.ID;
                        materijal.Naziv = k.Materijal.Naziv;
                    }

                    koristi.Add(new KoristiBasic(k.ID, k.Kolicina, zadatak, materijal));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return koristi;
        }

        public static KoristiBasic vratiKoristZadatka(int idKorist)
        {
            KoristiBasic korist = new KoristiBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Koristi k = s.Load<Koristi>(idKorist);

                ZadatakBasic zadatak = null;

                if (k.Zadatak != null)
                {
                    zadatak = new ZadatakBasic();
                    zadatak.Id = k.Zadatak.Id;
                    zadatak.Naziv = k.Zadatak.Naziv;
                }

                MaterijalBasic materijal = null;

                if (k.Materijal != null)
                {
                    materijal = new MaterijalBasic();
                    materijal.ID = k.Materijal.ID;
                    materijal.Naziv = k.Materijal.Naziv;
                }

                korist = new KoristiBasic(
                        k.ID, k.Kolicina, zadatak, materijal);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return korist;
        }

        public static void dodajKoristiZadatka(KoristiBasic k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zadatak zadatak = s.Load<Zadatak>(k.Zadatak.Id);

                Materijal materijal = s.Load<Materijal>(k.Materijal.ID);

                Koristi koristi = new Koristi();

                koristi.Zadatak = zadatak;
                koristi.Materijal = materijal;
                koristi.Kolicina = k.Kolicina;

                s.Save(koristi);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniKoristi(KoristiBasic k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Koristi koristi = s.Load<Koristi>(k.ID);

                koristi.Kolicina = k.Kolicina;

                s.Update(koristi);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiKoristi(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Koristi koristi = s.Load<Koristi>(id);

                s.Delete(koristi);
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
