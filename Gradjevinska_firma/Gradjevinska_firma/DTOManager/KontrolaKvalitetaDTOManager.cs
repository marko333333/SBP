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
    public class KontrolaKvalitetaDTOManager
    {
        #region KontroleKvaliteta

        public static List<KontrolaKvalitetaBasic> vratiKontroleKvaliteta(int idZadatka)
        {
            List<KontrolaKvalitetaBasic> kontrole =
                new List<KontrolaKvalitetaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<KontrolaKvaliteta> sveKontrole =
                    from kk in s.Query<KontrolaKvaliteta>()
                    where kk.Zadatak.Id == idZadatka
                    select kk;

                foreach (KontrolaKvaliteta kk in sveKontrole)
                {
                    kontrole.Add(new KontrolaKvalitetaBasic(
                         kk.Id, kk.DatumInspekcije, kk.PrimedbeNadzora, kk.Zapisnik, kk.ZabranaNastavkaRadova, kk.RazlogZabrane, kk.DatumOtklanjanjaZabrane, null));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return kontrole;
        }

        public static KontrolaKvalitetaBasic vratiKontroluKvaliteta(int id)
        {
            KontrolaKvalitetaBasic kontrolaKvaliteta = new KontrolaKvalitetaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                KontrolaKvaliteta n = s.Load<KontrolaKvaliteta>(id);

                ZadatakBasic zadatak = null;

                if (n.Zadatak != null)
                {
                    zadatak = new ZadatakBasic();
                    zadatak.Id = n.Zadatak.Id;
                    zadatak.Naziv = n.Zadatak.Naziv;
                }

                kontrolaKvaliteta = new KontrolaKvalitetaBasic(
                   n.Id, n.DatumInspekcije, n.PrimedbeNadzora, n.Zapisnik, n.ZabranaNastavkaRadova, n.RazlogZabrane, n.DatumOtklanjanjaZabrane, zadatak);

                kontrolaKvaliteta.StavkeKontrole = StavkaKontroleDTOManager.vratiSveStavke(id);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return kontrolaKvaliteta;
        }

        public static void dodajKontrolu(KontrolaKvalitetaBasic kontrola)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zadatak zadatak = s.Load<Zadatak>(kontrola.Zadatak.Id);

                KontrolaKvaliteta k = new KontrolaKvaliteta();

                k.DatumInspekcije = kontrola.DatumInspekcije;
                k.PrimedbeNadzora = kontrola.PrimedbeNadzora;
                k.Zapisnik = kontrola.Zapisnik;
                k.ZabranaNastavkaRadova = kontrola.ZabranaNastavkaRadova;
                k.RazlogZabrane = kontrola.RazlogZabrane;
                k.DatumOtklanjanjaZabrane = kontrola.DatumOtklanjanjaZabrane;
                k.Zadatak = zadatak;

                s.Save(k);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniKontrolu(KontrolaKvalitetaBasic k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                KontrolaKvaliteta kontrola = s.Load<KontrolaKvaliteta>(k.Id);

                kontrola.DatumInspekcije = k.DatumInspekcije;
                kontrola.PrimedbeNadzora = k.PrimedbeNadzora;
                kontrola.Zapisnik = k.Zapisnik;
                kontrola.ZabranaNastavkaRadova = k.ZabranaNastavkaRadova;
                kontrola.RazlogZabrane = k.RazlogZabrane;
                kontrola.DatumOtklanjanjaZabrane = k.DatumOtklanjanjaZabrane;

                s.Update(kontrola);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiKontrolu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                KontrolaKvaliteta kontrola = s.Load<KontrolaKvaliteta>(id);

                s.Delete(kontrola);
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
