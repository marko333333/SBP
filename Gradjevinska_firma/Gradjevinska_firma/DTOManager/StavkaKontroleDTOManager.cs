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
    public class StavkaKontroleDTOManager
    {
        #region StavkaKontrole

        public static List<StavkaKontroleBasic> vratiSveStavke(int idKontrole)
        {
            List<StavkaKontroleBasic> stavke = new List<StavkaKontroleBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<StavkaKontrole> sveStavke =
                    from k in s.Query<StavkaKontrole>()
                    where k.Kontrola.Id == idKontrole
                    select k;

                foreach (StavkaKontrole k in sveStavke)
                {
                    stavke.Add(new StavkaKontroleBasic(k.Id, null, k.RedniBrojStavke, k.Uzorci, k.LabNalazi, k.RezultatiIspitivanja, k.KorektivneMere, k.RokZaOtklanjanje));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return stavke;
        }

        public static StavkaKontroleBasic vratiStavku(int id)
        {
            StavkaKontroleBasic stavka = new StavkaKontroleBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                StavkaKontrole k = s.Load<StavkaKontrole>(id);

                KontrolaKvalitetaBasic kontrola = null;

                if (k.Kontrola != null)
                {
                    kontrola = new KontrolaKvalitetaBasic();
                    kontrola.Id = k.Id;
                }

                stavka = new StavkaKontroleBasic(
                  k.Id, kontrola, k.RedniBrojStavke, k.Uzorci, k.LabNalazi, k.RezultatiIspitivanja, k.KorektivneMere, k.RokZaOtklanjanje);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return stavka;
        }

        public static void dodajStavku(StavkaKontroleBasic stavka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                KontrolaKvaliteta kontrola = s.Load<KontrolaKvaliteta>(stavka.Kontrola.Id);

                StavkaKontrole k = new StavkaKontrole();
                k.RedniBrojStavke = stavka.RedniBrojStavke;
                k.Uzorci = stavka.Uzorci;
                k.LabNalazi = stavka.LabNalazi;
                k.RezultatiIspitivanja = stavka.RezultatiIspitivanja;
                k.KorektivneMere = stavka.KorektivneMere;
                k.RokZaOtklanjanje = stavka.RokZaOtklanjanje;
                k.Kontrola = kontrola;

                s.Save(k);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniStavku(StavkaKontroleBasic k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StavkaKontrole stavka = s.Load<StavkaKontrole>(k.Id);


                stavka.RedniBrojStavke = k.RedniBrojStavke;
                stavka.Uzorci = k.Uzorci;
                stavka.LabNalazi = k.LabNalazi;
                stavka.RezultatiIspitivanja = k.RezultatiIspitivanja;
                stavka.KorektivneMere = k.KorektivneMere;
                stavka.RokZaOtklanjanje = k.RokZaOtklanjanje;

                s.Update(stavka);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiStavku(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StavkaKontrole stavka = s.Load<StavkaKontrole>(id);

                s.Delete(stavka);
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
