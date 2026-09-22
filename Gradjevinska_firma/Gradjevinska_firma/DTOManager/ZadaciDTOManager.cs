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
    public class ZadaciDTOManager
    {
        #region Zadaci

        public static List<ZadatakPregled> vratiSveZadatke()
        {
            List<ZadatakPregled> zadaci = new List<ZadatakPregled>();

            try
            {
                ISession s = DataLayer.GetSession();

                IList<Zadatak> sviZadaci = s.Query<Zadatak>().ToList();

                foreach (Zadatak z in sviZadaci)
                {
                    FazaPregled faza = null;

                    if (z.Faza != null)
                    {
                        faza = new FazaPregled();
                        faza.Id = z.Faza.Id;
                        faza.Naziv = z.Faza.Naziv;
                    }

                    ZadatakPregled roditelj = null;

                    if (z.Roditelj != null)
                    {
                        roditelj = new ZadatakPregled();
                        roditelj.Id = z.Roditelj.Id;
                        roditelj.Naziv = z.Roditelj.Naziv;
                    }

                    ZadatakPregled zp = new ZadatakPregled(
                        z.Id, z.Naziv, z.Opis, z.ProcenjeniTrosak, z.PlaniraniZavrsetak, z.StvarniZavrsetak, z.PlaniraniPocetak, z.StvarniPocetak, z.Prioritet, z.Status, faza, roditelj
                    );
                    zadaci.Add(zp);

                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return zadaci;
        }

        public static ZadatakBasic vratiZadatak(int id)
        {
            ZadatakBasic zadatak = new ZadatakBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Zadatak z = s.Load<Zadatak>(id);


                FazaBasic faza = null;

                if (z.Faza != null)
                {
                    faza = new FazaBasic();
                    faza.Id = z.Faza.Id;
                    faza.Naziv = z.Faza.Naziv;
                }

                ZadatakBasic roditelj = null;

                if (z.Roditelj != null)
                {
                    roditelj = new ZadatakBasic();
                    roditelj.Id = z.Roditelj.Id;
                    roditelj.Naziv = z.Roditelj.Naziv;
                }

                zadatak = new ZadatakBasic(
                   z.Id, z.Naziv, z.Opis, z.ProcenjeniTrosak, z.PlaniraniZavrsetak, z.StvarniZavrsetak, z.PlaniraniPocetak, z.StvarniPocetak, z.Prioritet, z.Status, faza, roditelj);

                zadatak.Podzadaci = vratiSvePodzadatke(id);
                zadatak.RadniNalozi = RadniNaloziDTOManager.vratiRadneNaloge(id);
                zadatak.Napreci = NapredakDTOManager.vratiNapretke(id);
                zadatak.KontroleKvaliteta = KontrolaKvalitetaDTOManager.vratiKontroleKvaliteta(id);
                zadatak.Angazovani = AngazovanDTOManager.vratiSveAngazovanja(id);
                zadatak.AngazovanaOprema = AngazujOpremuDTOManager.vratiSveAngazuje(id);
                zadatak.Koristi = KoristiDTOManager.vratiKoristiZadatka(id);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return zadatak;
        }

        public static List<ZadatakBasic> vratiSvePodzadatke(int idZadatka)
        {
            List<ZadatakBasic> podzadaci =
                new List<ZadatakBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Zadatak> sviPodzadaci =
                    from z in s.Query<Zadatak>()
                    where z.Roditelj.Id == idZadatka
                    select z;

                foreach (Zadatak z in sviPodzadaci)
                {
                    podzadaci.Add(new ZadatakBasic(
                       z.Id, z.Naziv, z.Opis, z.ProcenjeniTrosak, z.PlaniraniZavrsetak, z.StvarniZavrsetak, z.PlaniraniPocetak, z.StvarniPocetak, z.Prioritet, z.Status, null, null));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return podzadaci;
        }

        public static void dodajZadatak(ZadatakBasic zadatak)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Faza faza = s.Load<Faza>(zadatak.Faza.Id);

                Zadatak nadzadatak = null;

                if (zadatak.Roditelj != null)
                {
                    nadzadatak = s.Load<Zadatak>(zadatak.Roditelj.Id);
                }

                Zadatak z = new Zadatak();

                z.Naziv = zadatak.Naziv;
                z.Opis = zadatak.Opis;
                z.ProcenjeniTrosak = zadatak.ProcenjeniTrosak;
                z.PlaniraniZavrsetak = zadatak.PlaniraniZavrsetak;
                z.StvarniZavrsetak = zadatak.StvarniZavrsetak;
                z.PlaniraniPocetak = zadatak.PlaniraniPocetak;
                z.StvarniPocetak = zadatak.StvarniPocetak;
                z.Prioritet = zadatak.Prioritet;
                z.Status = zadatak.Status;

                z.Faza = faza;
                z.Roditelj = nadzadatak;

                s.Save(z);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniZadatak(ZadatakBasic zadatak)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zadatak z = s.Load<Zadatak>(zadatak.Id);

                Faza faza = s.Load<Faza>(zadatak.Faza.Id);

                Zadatak roditelj = null;

                if (zadatak.Roditelj != null)
                {
                    roditelj = s.Load<Zadatak>(zadatak.Roditelj.Id);
                }

                z.Naziv = zadatak.Naziv;
                z.Opis = zadatak.Opis;
                z.ProcenjeniTrosak = zadatak.ProcenjeniTrosak;
                z.PlaniraniZavrsetak = zadatak.PlaniraniZavrsetak;
                z.StvarniZavrsetak = zadatak.StvarniZavrsetak;
                z.PlaniraniPocetak = zadatak.PlaniraniPocetak;
                z.StvarniPocetak = zadatak.StvarniPocetak;
                z.Prioritet = zadatak.Prioritet;
                z.Status = zadatak.Status;

                z.Faza = faza;
                z.Roditelj = roditelj;

                s.Update(z);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiZadatak(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zadatak zadatak = s.Load<Zadatak>(id);

                s.Delete(zadatak);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void dodajPodzadatak(int idRoditelja, int idPodzadatka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zadatak roditelj = s.Load<Zadatak>(idRoditelja);
                Zadatak podzadatak = s.Load<Zadatak>(idPodzadatka);

                podzadatak.Roditelj = roditelj;

                s.Update(podzadatak);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiPodzadatak(int idPodzadatka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zadatak podzadatak = s.Load<Zadatak>(idPodzadatka);

                podzadatak.Roditelj = null;

                s.Update(podzadatak);
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
