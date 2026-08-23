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
    public class KontaktDTOManager
    {
        public static List<KontaktBasic> vratiKontakteOsobe(int idOsobe)
        {
            List<KontaktBasic> kontakti = new List<KontaktBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Kontakt> sviKontakti =
                    from k in s.Query<Kontakt>()
                    where k.Osoba.Id == idOsobe
                    select k;

                foreach (Kontakt k in sviKontakti)
                {
                    kontakti.Add(new KontaktBasic(k.Id, k.Osoba.Id, k.Broj));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return kontakti;
        }
        public static KontaktBasic vratiKontakt(int id)
        {
            KontaktBasic kontakt = new KontaktBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Kontakt k = s.Load<Kontakt>(id);

                kontakt = new KontaktBasic(
                        k.Id, k.Osoba.Id, k.Broj);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return kontakt;
        }
        public static void dodajKontakt(KontaktBasic k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Osoba osoba = s.Load<Osoba>(k.IdOsoba);

                Kontakt kontakt = new Kontakt();

                kontakt.Osoba = osoba;
                kontakt.Broj = k.Broj;

                s.Save(kontakt);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniKontakt(KontaktBasic k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Kontakt kontakt = s.Load<Kontakt>(k.Id);

                kontakt.Broj = k.Broj;

                s.Update(kontakt);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void obrisiKontakt(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Kontakt kontakt = s.Load<Kontakt>(id);

                s.Delete(kontakt);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
