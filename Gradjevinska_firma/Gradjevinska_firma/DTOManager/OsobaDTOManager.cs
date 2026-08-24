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
    public class OsobaDTOManager
    {
        public static List<OsobaPregled> vratiSveOsobe()
        {
            List<OsobaPregled> osobe = new List<OsobaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Osoba> sveOsobe = from o in s.Query<Osoba>()
                                              select o;
                foreach (Osoba o in sveOsobe)
                {
                    osobe.Add(new OsobaPregled(
                        o.Id, o.Jmbg, o.Ime, o.Prezime, o.DatumRodjenja, o.Struka));
                }
                s.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return osobe;
        }

        public static OsobaBasic vratiOsobu(int id)
        {
            OsobaBasic osoba = new OsobaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Osoba o = s.Load<Osoba>(id);

                osoba = new OsobaBasic(
                    o.Id, o.Jmbg, o.Ime, o.Prezime, o.DatumRodjenja, o.Struka);

                osoba.Kontakti = KontaktDTOManager.vratiKontakteOsobe(id);
                osoba.Licence = LicencaDTOManager.vratiLicenceOsobe(id);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return osoba;
        }

        public static void obrisiOsobu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Osoba o = s.Load<Osoba>(id);

                s.Delete(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static List<OsobaPregled> vratiOsobeNaProjektu(int idProjekta)
        {
            List<OsobaPregled> osobe = new List<OsobaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Angazovan> sviAngazovani =
                    from a in s.Query<Angazovan>()
                    where a.Zadatak.Faza.Projekat.ID == idProjekta
                    select a;

                //zasta sluzi ovaj HashSet?
                HashSet<int> dodateOsobe = new HashSet<int>();

                foreach (Angazovan a in sviAngazovani)
                {
                    if (!dodateOsobe.Contains(a.Osoba.Id))
                    {
                        osobe.Add(new OsobaPregled(
                            a.Osoba.Id, a.Osoba.Jmbg, a.Osoba.Ime, a.Osoba.Prezime,
                            a.Osoba.DatumRodjenja, a.Osoba.Struka));

                        dodateOsobe.Add(a.Osoba.Id);
                    }
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return osobe;
        }

        #region FizickaLica

        public static List<FizickoLicePregled> vratiSvaFizickaLica()
        {
            List<FizickoLicePregled> lica = new List<FizickoLicePregled>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<FizickoLice> svaLica =
                    from f in s.Query<FizickoLice>()
                    select f;

                foreach (FizickoLice f in svaLica)
                {
                    lica.Add(new FizickoLicePregled(
                        f.Id, f.Jmbg, f.Ime, f.Prezime, f.DatumRodjenja, f.Struka, f.FlagBK, f.FlagR, f.Kvalifikacija, f.FlagI, f.OblastRada, f.Odgovornosti, f.FlagA, f.FlagP, f.FlagN, f.FlagAO));
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return lica;
        }
        public static FizickoLiceBasic vratiFizickoLice(int id)
        {
            FizickoLiceBasic lice = null;

            try
            {
                ISession s = DataLayer.GetSession();

                FizickoLice f = s.Get<FizickoLice>(id);
                if (f != null)
                {
                    lice = new FizickoLiceBasic(
                        f.Id, f.Jmbg, f.Ime, f.Prezime, f.DatumRodjenja, f.Struka, f.FlagBK, f.FlagR, f.Kvalifikacija, f.FlagI, f.OblastRada, f.Odgovornosti, f.FlagA, f.FlagP, f.FlagN, f.FlagAO);
                    lice.Kontakti = KontaktDTOManager.vratiKontakteOsobe(id);
                    lice.Licence = LicencaDTOManager.vratiLicenceOsobe(id);
                    lice.BezbednosneObuke = BezbednosnaObukaDTOManager.vratiBezbednosneObukeOsobe(id);
                    lice.LekarskiPregledi = LekPregledDTOManager.vratiLekarskePregledeOsobe(id);
                    lice.ZastitneOpreme = ZastitnaOpremaDTOManager.vratiZastitneOpremeOsobe(id);
                    lice.SertifikatiSpecOpreme = SertifikatSpecOpremeDTOManager.vratiSertifikateSpecOpremeOsobe(id);

                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return lice;
        }

        public static void dodajFizickoLice(FizickoLiceBasic lice)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FizickoLice f = new FizickoLice();

                f.Jmbg = lice.Jmbg;
                f.Ime = lice.Ime;
                f.Prezime = lice.Prezime;
                f.DatumRodjenja = lice.DatumRodjenja;
                f.Struka = lice.Struka;

                f.FlagBK = lice.FlagBK;
                f.FlagR = lice.FlagR;
                f.Kvalifikacija = lice.Kvalifikacija;
                f.FlagI = lice.FlagI;
                f.OblastRada = lice.OblastRada;
                f.Odgovornosti = lice.Odgovornosti;
                f.FlagA = lice.FlagA;
                f.FlagP = lice.FlagP;
                f.FlagN = lice.FlagN;
                f.FlagAO = lice.FlagAO;

                s.Save(f);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniFizickoLice(FizickoLiceBasic fizicko)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FizickoLice f = s.Load<FizickoLice>(fizicko.Id);

                f.Jmbg = fizicko.Jmbg;
                f.Ime = fizicko.Ime;
                f.Prezime = fizicko.Prezime;
                f.DatumRodjenja = fizicko.DatumRodjenja;
                f.Struka = fizicko.Struka;

                f.FlagBK = fizicko.FlagBK;
                f.FlagR = fizicko.FlagR;
                f.Kvalifikacija = fizicko.Kvalifikacija;
                f.FlagI = fizicko.FlagI;
                f.OblastRada = fizicko.OblastRada;
                f.Odgovornosti = fizicko.Odgovornosti;
                f.FlagA = fizicko.FlagA;
                f.FlagP = fizicko.FlagP;
                f.FlagN = fizicko.FlagN;
                f.FlagAO = fizicko.FlagAO;

                s.Update(f);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static List<FizickoLicePregled> vratiFizickaLicaNaProjektu(int idProjekta)
        {
            List<FizickoLicePregled> fizickaLica = new List<FizickoLicePregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Faza> sveFaze =
                    from f in s.Query<Faza>()
                    where f.Projekat.ID == idProjekta
                    select f;

                HashSet<int> dodataLica = new HashSet<int>();

                foreach (Faza f in sveFaze)
                {
                    if (f.FizickoLice != null && !dodataLica.Contains(f.FizickoLice.Id))
                    {
                        fizickaLica.Add(new FizickoLicePregled(
                            f.FizickoLice.Id,
                            f.FizickoLice.Jmbg,
                            f.FizickoLice.Ime,
                            f.FizickoLice.Prezime,
                            f.FizickoLice.DatumRodjenja,
                            f.FizickoLice.Struka,
                            f.FizickoLice.FlagBK,
                            f.FizickoLice.FlagR,
                            f.FizickoLice.Kvalifikacija,
                            f.FizickoLice.FlagI,
                            f.FizickoLice.OblastRada,
                            f.FizickoLice.Odgovornosti,
                            f.FizickoLice.FlagA,
                            f.FizickoLice.FlagP,
                            f.FizickoLice.FlagN,
                            f.FizickoLice.FlagAO
                        ));

                        dodataLica.Add(f.FizickoLice.Id);
                    }
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return fizickaLica;
        }

        #endregion

        #region PravnaLica

        public static List<PravnaLicaPregled> vratiSvaPravnaLica()
        {
            List<PravnaLicaPregled> lica = new List<PravnaLicaPregled>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<PravnaLica> svaLica =
                    from p in s.Query<PravnaLica>()
                    select p;

                foreach (PravnaLica p in svaLica)
                {
                    lica.Add(new PravnaLicaPregled(
                        p.Id, p.Jmbg, p.Ime, p.Prezime, p.DatumRodjenja, p.Struka, p.FlagPB, p.FlagInve, p.FlagIzv, p.FlagP, p.FlagD, p.FlagN));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return lica;
        }
        public static PravnaLicaBasic vratiPravnoLice(int id)
        {
            PravnaLicaBasic lice = new PravnaLicaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                PravnaLica p = s.Get<PravnaLica>(id);
                if (p != null)
                {
                    lice = new PravnaLicaBasic(
                        p.Id, p.Jmbg, p.Ime, p.Prezime, p.DatumRodjenja, p.Struka, p.FlagPB, p.FlagInve, p.FlagIzv, p.FlagP, p.FlagD, p.FlagN);
                    lice.Kontakti = KontaktDTOManager.vratiKontakteOsobe(id);
                    lice.Licence = LicencaDTOManager.vratiLicenceOsobe(id);
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return lice;
        }

        public static void dodajPravnoLice(PravnaLicaBasic pravno)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PravnaLica p = new PravnaLica();

                p.Jmbg = pravno.Jmbg;
                p.Ime = pravno.Ime;
                p.Prezime = pravno.Prezime;
                p.DatumRodjenja = pravno.DatumRodjenja;
                p.Struka = pravno.Struka;

                p.FlagPB = pravno.FlagPB;
                p.FlagInve = pravno.FlagInve;
                p.FlagIzv = pravno.FlagIzv;
                p.FlagP = pravno.FlagP;
                p.FlagD = pravno.FlagD;
                p.FlagN = pravno.FlagN;

                s.Save(p);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniPravnoLice(PravnaLicaBasic pravno)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PravnaLica p = s.Load<PravnaLica>(pravno.Id);

                p.Jmbg = pravno.Jmbg;
                p.Ime = pravno.Ime;
                p.Prezime = pravno.Prezime;
                p.DatumRodjenja = pravno.DatumRodjenja;
                p.Struka = pravno.Struka;

                p.FlagPB = pravno.FlagPB;
                p.FlagInve = pravno.FlagInve;
                p.FlagIzv = pravno.FlagIzv;
                p.FlagP = pravno.FlagP;
                p.FlagD = pravno.FlagD;
                p.FlagN = pravno.FlagN;

                s.Update(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static List<PravnaLicaPregled> vratiPravnaLicaNaProjektu(int idProjekta)
        {
            List<PravnaLicaPregled> pravnaLica = new List<PravnaLicaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Faktura> sveFakture =
                    from f in s.Query<Faktura>()
                    where f.IDProjekta.ID == idProjekta
                    select f;

                HashSet<int> dodataLica = new HashSet<int>();

                foreach (Faktura f in sveFakture)
                {
                    if (f.PravnoLiceIzdaje != null && !dodataLica.Contains(f.PravnoLiceIzdaje.Id))
                    {
                        pravnaLica.Add(new PravnaLicaPregled(
                            f.PravnoLiceIzdaje.Id, f.PravnoLiceIzdaje.Jmbg, f.PravnoLiceIzdaje.Ime,
                            f.PravnoLiceIzdaje.Prezime, f.PravnoLiceIzdaje.DatumRodjenja, f.PravnoLiceIzdaje.Struka,
                            f.PravnoLiceIzdaje.FlagPB, f.PravnoLiceIzdaje.FlagInve, f.PravnoLiceIzdaje.FlagIzv,
                            f.PravnoLiceIzdaje.FlagP, f.PravnoLiceIzdaje.FlagD, f.PravnoLiceIzdaje.FlagN));

                        dodataLica.Add(f.PravnoLiceIzdaje.Id);
                    }

                    if (f.PravnoLicePrima != null && !dodataLica.Contains(f.PravnoLicePrima.Id))
                    {
                        pravnaLica.Add(new PravnaLicaPregled(
                            f.PravnoLicePrima.Id, f.PravnoLicePrima.Jmbg, f.PravnoLicePrima.Ime,
                            f.PravnoLicePrima.Prezime, f.PravnoLicePrima.DatumRodjenja, f.PravnoLicePrima.Struka,
                            f.PravnoLicePrima.FlagPB, f.PravnoLicePrima.FlagInve, f.PravnoLicePrima.FlagIzv,
                            f.PravnoLicePrima.FlagP, f.PravnoLicePrima.FlagD, f.PravnoLicePrima.FlagN));

                        dodataLica.Add(f.PravnoLicePrima.Id);
                    }
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return pravnaLica;
        }

        #endregion
    }
}
