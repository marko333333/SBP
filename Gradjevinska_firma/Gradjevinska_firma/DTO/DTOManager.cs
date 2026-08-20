using Gradjevinska_firma.Data;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firma.Entiteti;
using System.Windows.Forms;

namespace Gradjevinska_firma.DTO
{
    public class DTOManager
    {

        #region Osobe

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

                osoba.Kontakti = vratiKontakteOsobe(id);
                osoba.Licence = vratiLicenceOsobe(id);
                osoba.BezbednosniIncidenti = vratiBezbednosniIncidentOsobe(id);

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
                    lice.Kontakti = vratiKontakteOsobe(id);
                    lice.Licence = vratiLicenceOsobe(id);
                    lice.BezbednosneObuke = vratiBezbednosneObukeOsobe(id);
                    lice.LekarskiPregledi = vratiLekarskePregledeOsobe(id);
                    lice.ZastitneOpreme = vratiZastitneOpremeOsobe(id);
                    lice.SertifikatiSpecOpreme = vratiSertifikateSpecOpremeOsobe(id);

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
                    lice.Kontakti = vratiKontakteOsobe(id);
                    lice.Licence = vratiLicenceOsobe(id);
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

        #endregion

        #endregion

        #region Kontakti

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

        #endregion

        #region Licence

        public static List<LicencaBasic> vratiLicenceOsobe(int idOsobe)
        {
            List<LicencaBasic> licence = new List<LicencaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Licenca> sveLicence =
                    from l in s.Query<Licenca>()
                    where l.Osoba.Id == idOsobe
                    select l;

                foreach (Licenca l in sveLicence)
                {
                    licence.Add(
                        new LicencaBasic(
                            l.Id,
                            l.Osoba.Id,
                            l.NazivLicence));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return licence;
        }

        public static LicencaBasic vratiLicencu(int id)
        {
            LicencaBasic licenca = new LicencaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Licenca l = s.Load<Licenca>(id);

                licenca = new LicencaBasic(
                        l.Id, l.Osoba.Id, l.NazivLicence);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return licenca;
        }
        public static void dodajLicencu(LicencaBasic l)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Osoba osoba = s.Load<Osoba>(l.IdOsoba);

                Licenca licenca = new Licenca();

                licenca.Osoba = osoba;
                licenca.NazivLicence = l.NazivLicence;

                s.Save(licenca);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniLicencu(LicencaBasic l)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Licenca licenca = s.Load<Licenca>(l.Id);

                licenca.NazivLicence = l.NazivLicence;

                s.Update(licenca);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void obrisiLicencu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Licenca licenca = s.Load<Licenca>(id);

                s.Delete(licenca);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region BezbednosnaObuka

        public static List<BezbednosnaObukaBasic> vratiBezbednosneObukeOsobe(int idOsobe)
        {
            List<BezbednosnaObukaBasic> obuke = new List<BezbednosnaObukaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<BezbednosnaObuka> sveObuke =
                    from b in s.Query<BezbednosnaObuka>()
                    where b.FizickoLice.Id == idOsobe
                    select b;

                foreach (BezbednosnaObuka b in sveObuke)
                {
                    obuke.Add(new BezbednosnaObukaBasic(
                        b.Id,
                        b.FizickoLice.Id,
                        b.NazivObuke,
                        b.Datum));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return obuke;
        }

        public static BezbednosnaObukaBasic vratiObuku(int id)
        {
            BezbednosnaObukaBasic obuka = new BezbednosnaObukaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                BezbednosnaObuka b = s.Load<BezbednosnaObuka>(id);

                obuka = new BezbednosnaObukaBasic(
                        b.Id, b.FizickoLice.Id, b.NazivObuke, b.Datum);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return obuka;
        }

        public static void dodajBezbednosnuObuku(BezbednosnaObukaBasic bezObuka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FizickoLice lice = s.Load<FizickoLice>(bezObuka.IdFizickoLice);

                BezbednosnaObuka obuka = new BezbednosnaObuka();

                obuka.FizickoLice = lice;
                obuka.NazivObuke = bezObuka.NazivObuke;
                obuka.Datum = bezObuka.Datum;

                s.Save(obuka);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        public static void izmeniBezbednosnuObuku(BezbednosnaObukaBasic bo)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BezbednosnaObuka bezobuka = s.Load<BezbednosnaObuka>(bo.Id);

                bezobuka.NazivObuke = bo.NazivObuke;
                bezobuka.Datum = bo.Datum;

                s.Update(bezobuka);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void obrisiBezbednosnuObuku(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BezbednosnaObuka bezobuka = s.Load<BezbednosnaObuka>(id);

                s.Delete(bezobuka);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region LekPregled

        public static List<LekarskiPregledBasic> vratiLekarskePregledeOsobe(int idOsobe)
        {
            List<LekarskiPregledBasic> pregledi = new List<LekarskiPregledBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<LekarskiPregled> sviPregledi =
                    from p in s.Query<LekarskiPregled>()
                    where p.FizickoLice.Id == idOsobe
                    select p;

                foreach (LekarskiPregled p in sviPregledi)
                {
                    pregledi.Add(new LekarskiPregledBasic(
                        p.Id,
                        p.FizickoLice.Id,
                        p.Rezultat,
                        p.Datum));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return pregledi;
        }

        public static LekarskiPregledBasic vratiLekPregled(int id)
        {
            LekarskiPregledBasic lekpregled = new LekarskiPregledBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                LekarskiPregled lp = s.Load<LekarskiPregled>(id);

                lekpregled = new LekarskiPregledBasic(
                        lp.Id, lp.FizickoLice.Id, lp.Rezultat, lp.Datum);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return lekpregled;
        }

        public static void dodajLekPregled(LekarskiPregledBasic lp)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FizickoLice fizicko = s.Load<FizickoLice>(lp.IdFizickoLice);

                LekarskiPregled lekpregled = new LekarskiPregled();


                lekpregled.FizickoLice = fizicko;
                lekpregled.Rezultat = lp.Rezultat;
                lekpregled.Datum = lp.Datum;

                s.Save(lekpregled);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniLekPregled(LekarskiPregledBasic lp)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LekarskiPregled lekpregled = s.Load<LekarskiPregled>(lp.Id);

                lekpregled.Rezultat = lp.Rezultat;
                lekpregled.Datum = lp.Datum;

                s.Update(lekpregled);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void obrisiLekPregled(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LekarskiPregled lekpregled = s.Load<LekarskiPregled>(id);


                s.Delete(lekpregled);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region SertifikatSpecOpreme

        public static List<SertifikatSpecOpremeBasic> vratiSertifikateSpecOpremeOsobe(int idOsobe)
        {
            List<SertifikatSpecOpremeBasic> sertifikati =new List<SertifikatSpecOpremeBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<SertifikatSpecOpreme> sviSertifikati =
                    from ss in s.Query<SertifikatSpecOpreme>()
                    where ss.FizickoLice.Id == idOsobe
                    select ss;

                foreach (SertifikatSpecOpreme ss in sviSertifikati)
                {
                    sertifikati.Add(new SertifikatSpecOpremeBasic(
                        ss.Id,
                        ss.FizickoLice.Id,
                        ss.Sertifikat));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return sertifikati;
        }

        public static SertifikatSpecOpremeBasic vratiSertifikat(int id)
        {
            SertifikatSpecOpremeBasic sertifkatspec = new SertifikatSpecOpremeBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                SertifikatSpecOpreme sso = s.Load<SertifikatSpecOpreme>(id);

                sertifkatspec = new SertifikatSpecOpremeBasic(
                        sso.Id, sso.FizickoLice.Id, sso.Sertifikat);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return sertifkatspec;
        }

        public static void dodajSertifikatSpecOpreme(SertifikatSpecOpremeBasic sso)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FizickoLice fizicko = s.Load<FizickoLice>(sso.IdFizickoLice);

                SertifikatSpecOpreme sertifikatspec = new SertifikatSpecOpreme();

                sertifikatspec.FizickoLice = fizicko;
                sertifikatspec.Sertifikat = sso.Sertifikat;

                s.Save(sertifikatspec);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniSertifikatSpecOpreme(SertifikatSpecOpremeBasic sso)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SertifikatSpecOpreme sertifikatSpec = s.Load<SertifikatSpecOpreme>(sso.Id);

                sertifikatSpec.Sertifikat = sso.Sertifikat;

                s.Update(sertifikatSpec);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void obrisiSertifikatSpecOpreme(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SertifikatSpecOpreme sertifikatSpec = s.Load<SertifikatSpecOpreme>(id);

                s.Delete(sertifikatSpec);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region ZastitnaOprema

        public static List<ZastitnaOpremaBasic> vratiZastitneOpremeOsobe(int idOsobe)
        {
            List<ZastitnaOpremaBasic> opreme =new List<ZastitnaOpremaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ZastitnaOprema> sveOpreme =
                    from zo in s.Query<ZastitnaOprema>()
                    where zo.FizickoLice.Id == idOsobe
                    select zo;

                foreach (ZastitnaOprema zo in sveOpreme)
                {
                    opreme.Add(new ZastitnaOpremaBasic(
                        zo.Id,
                        zo.FizickoLice.Id,
                        zo.NazivOpreme));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return opreme;
        }

        public static ZastitnaOpremaBasic vratiZastitnuOpremu(int id)
        {
            ZastitnaOpremaBasic zastitnaOprema = new ZastitnaOpremaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                ZastitnaOprema zo = s.Load<ZastitnaOprema>(id);

                zastitnaOprema = new ZastitnaOpremaBasic(
                        zo.Id, zo.FizickoLice.Id, zo.NazivOpreme);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return zastitnaOprema;
        }

        public static void dodajZastitnuOpremu(ZastitnaOpremaBasic zo)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FizickoLice fizicko = s.Load<FizickoLice>(zo.IdFizickoLice);

                ZastitnaOprema zastitnaOprema = new ZastitnaOprema();

                zastitnaOprema.FizickoLice = fizicko;
                zastitnaOprema.NazivOpreme = zo.NazivOpreme;

                s.Save(zastitnaOprema);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniZastitnuOpremu(ZastitnaOpremaBasic zo)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZastitnaOprema zastitnaOprema = s.Load<ZastitnaOprema>(zo.Id);

                zastitnaOprema.NazivOpreme = zo.NazivOpreme;

                s.Update(zastitnaOprema);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void obrisiZastitnuOpremu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZastitnaOprema zastitnaOprema = s.Load<ZastitnaOprema>(id);

                s.Delete(zastitnaOprema);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Projekat

        public static List<ProjekatPregled> vratiSveProjekte()
        {
            List<ProjekatPregled> projekti = new List<ProjekatPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Projekat> sviProjekti = from p in s.Query<Projekat>() select p;
                foreach (Projekat p in sviProjekti)
                {
                    projekti.Add(new ProjekatPregled(p.ID, p.Naziv, p.Opis, p.Lokacija, p.Datum_pocetka, p.Budzet, p.Status, p.Planirani_Zavrsetak, p.Stvarni_Zavrsetak));
                }
                s.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return projekti;
        }

        public static ProjekatBasic vratiProjekat(int id)
        {
            ProjekatBasic projekat = new ProjekatBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Projekat p = s.Load<Projekat>(id);

                projekat = new ProjekatBasic(p.ID, p.Naziv, p.Opis, p.Lokacija, p.Datum_pocetka, p.Budzet, p.Status, p.Planirani_Zavrsetak, p.Stvarni_Zavrsetak);

                projekat.Ugovori = vratiUgovoreProjekta(id);
                projekat.BezbednosniIncidenti = vratiBezbednosniIncidenteProjekta(id);
                projekat.Faze = vratiFazeProjekta(id);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return projekat;
        }

        public static void obrisiProjekat(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Projekat p = s.Load<Projekat>(id);

                s.Delete(p);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        

        #region Infrastruktura

        public static List<InfrastrukturaPregled> vratiSveInfrasrukture()
        {
            List<InfrastrukturaPregled> infrastrukture = new List<InfrastrukturaPregled>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Infrastruktura> sveInfrastrukture =
                    from i in s.Query<Infrastruktura>()
                    select i;

                foreach (Infrastruktura i in sveInfrastrukture)
                {
                    infrastrukture.Add(new InfrastrukturaPregled(i.ID,i.Naziv,i.Opis, i.Lokacija, i.Datum_pocetka, i.Budzet, i.Status, i.Planirani_Zavrsetak, i.Stvarni_Zavrsetak));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return infrastrukture;
        }

        public static InfrastrukturaBasic vratiInfrastrukturu(int id)
        {
            InfrastrukturaBasic infra = new InfrastrukturaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Infrastruktura i = s.Get<Infrastruktura>(id);
                if (i != null)
                {
                    infra = new InfrastrukturaBasic(i.ID, i.Naziv, i.Opis, i.Lokacija, i.Datum_pocetka, i.Budzet, i.Status, i.Planirani_Zavrsetak, i.Stvarni_Zavrsetak);

                    infra.Deonice = vratiDeoniceInfrastrukture(id);
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return infra;
        }

        public static void dodajInfrastrukturu(InfrastrukturaBasic infra)//Deonice se dodaju odvojeno iako Entitet ima listu Deonica
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Infrastruktura i = new Infrastruktura();

                i.Naziv = infra.Naziv;
                i.Opis = infra.Opis;
                i.Lokacija = infra.Lokacija;
                i.Datum_pocetka = infra.Datum_pocetka;
                i.Budzet = infra.Budzet;
                i.Status = infra.Status;
                i.Planirani_Zavrsetak = infra.Planirani_zavrsetak;
                i.Stvarni_Zavrsetak = infra.Stvarni_zavrsetak;


                s.Save(i);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniInfrastrukturu(InfrastrukturaBasic infra)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Infrastruktura i = s.Load<Infrastruktura>(infra.ID);

                i.Naziv = infra.Naziv;
                i.Opis = infra.Opis;
                i.Lokacija = infra.Lokacija;
                i.Datum_pocetka = infra.Datum_pocetka;
                i.Budzet = infra.Budzet;
                i.Status = infra.Status;
                i.Planirani_Zavrsetak = infra.Planirani_zavrsetak;
                i.Stvarni_Zavrsetak = infra.Stvarni_zavrsetak;

                s.Update(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Industrijski

        public static List<IndustrijskiPregled> vratiSveIndustrijske()
        {
            List<IndustrijskiPregled> ind = new List<IndustrijskiPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Industrijski> sviIndustrijski =
                   from inds in s.Query<Industrijski>()
                   select inds;

                foreach (Industrijski inds in sviIndustrijski)
                {
                    ind.Add(new IndustrijskiPregled(inds.ID, inds.Naziv, inds.Opis, inds.Lokacija, inds.Datum_pocetka, inds.Budzet, inds.Status, inds.Planirani_Zavrsetak, inds.Stvarni_Zavrsetak));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ind;
        }
        public static IndustrijskiBasic vratiIndustrijski(int id)
        {
            IndustrijskiBasic ind = new IndustrijskiBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Industrijski inds = s.Get<Industrijski>(id);
                if (inds != null)
                {
                    ind = new IndustrijskiBasic(inds.ID, inds.Naziv, inds.Opis, inds.Lokacija, inds.Datum_pocetka, inds.Budzet, inds.Status, inds.Planirani_Zavrsetak, inds.Stvarni_Zavrsetak);
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ind;
        }

        public static void dodajIndustrijski(IndustrijskiBasic ind)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Industrijski inds = new Industrijski();

                inds.Naziv = ind.Naziv;
                inds.Opis = ind.Opis;
                inds.Lokacija = ind.Lokacija;
                inds.Datum_pocetka = ind.Datum_pocetka;
                inds.Budzet = ind.Budzet;
                inds.Status = ind.Status;
                inds.Planirani_Zavrsetak = ind.Planirani_zavrsetak;
                inds.Stvarni_Zavrsetak = ind.Stvarni_zavrsetak;

                s.Save(inds);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniIndustrijski(IndustrijskiBasic ind)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Industrijski inds = s.Load<Industrijski>(ind.ID);

                inds.Naziv = ind.Naziv;
                inds.Opis = ind.Opis;
                inds.Lokacija = ind.Lokacija;
                inds.Datum_pocetka = ind.Datum_pocetka;
                inds.Budzet = ind.Budzet;
                inds.Status = ind.Status;
                inds.Planirani_Zavrsetak = ind.Planirani_zavrsetak;
                inds.Stvarni_Zavrsetak = ind.Stvarni_zavrsetak;

                s.Update(inds);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Poslovni

        public static List<PoslovniPregled> vratiSvePoslovne()
        {
            List<PoslovniPregled> posl = new List<PoslovniPregled>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Poslovni> sviPoslovni =
                    from p in s.Query<Poslovni>()
                    select p;

                foreach (Poslovni p in sviPoslovni)
                {
                    posl.Add(new PoslovniPregled(p.ID,p.Naziv,p.Opis,p.Lokacija,p.Datum_pocetka,p.Budzet,p.Status,p.Planirani_Zavrsetak,p.Stvarni_Zavrsetak));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return posl;
        }

        public static PoslovniBasic vratiPoslovni(int id)
        {
            PoslovniBasic posl = new PoslovniBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Poslovni p = s.Get<Poslovni>(id);
                if (p != null)
                {
                    posl = new PoslovniBasic(p.ID,p.Naziv,p.Opis,p.Lokacija,p.Datum_pocetka,p.Budzet,p.Status,p.Planirani_Zavrsetak,p.Stvarni_Zavrsetak);

                    posl.Objekti = vratiObjektePoslovne(id);
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return posl;
        }

        public static void dodajPoslovni(PoslovniBasic posl)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Poslovni p = new Poslovni();

                p.Naziv = posl.Naziv;
                p.Opis = posl.Opis;
                p.Lokacija = posl.Lokacija;
                p.Datum_pocetka = posl.Datum_pocetka;
                p.Budzet = posl.Budzet;
                p.Status = posl.Status;
                p.Planirani_Zavrsetak = posl.Planirani_zavrsetak;
                p.Stvarni_Zavrsetak = posl.Stvarni_zavrsetak;

                s.Save(p);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniPoslovni(PoslovniBasic posl)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Poslovni p = s.Load<Poslovni>(posl.ID);

                p.Naziv = posl.Naziv;
                p.Opis = posl.Opis;
                p.Lokacija = posl.Lokacija;
                p.Datum_pocetka = posl.Datum_pocetka;
                p.Budzet = posl.Budzet;
                p.Status = posl.Status;
                p.Planirani_Zavrsetak = posl.Planirani_zavrsetak;
                p.Stvarni_Zavrsetak = posl.Stvarni_zavrsetak;

                s.Update(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region ObjekatPoslovni

        public static List<ObjekatPoslovniBasic> vratiObjektePoslovne(int idProjekta)
        {
            List<ObjekatPoslovniBasic> obj = new List<ObjekatPoslovniBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ObjekatPoslovni> sviPoslovni =
                         from p in s.Query<ObjekatPoslovni>()
                         where p.Poslovni.ID == idProjekta
                         select p;

                foreach (ObjekatPoslovni p in sviPoslovni)
                {
                    PoslovniBasic poslovni = new PoslovniBasic(
                        p.Poslovni.ID,
                        p.Poslovni.Naziv,
                        p.Poslovni.Opis,
                        p.Poslovni.Lokacija,
                        p.Poslovni.Datum_pocetka,
                        p.Poslovni.Budzet,
                        p.Poslovni.Status,
                        p.Poslovni.Planirani_Zavrsetak,
                        p.Poslovni.Stvarni_Zavrsetak
                    );

                    obj.Add(new ObjekatPoslovniBasic(p.Id,p.Br_objekta,p.Spratnost,p.Br_jedinica, poslovni));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return obj;
        }

        public static void dodajObjekatPoslovni(ObjekatPoslovniBasic p)//proveri
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Poslovni objP = s.Get<Poslovni>(p.Poslovni.ID);

                if (p == null || p.Poslovni == null)
                {
                    MessageBox.Show("Podaci nisu ispravni.");
                    return;
                }

                if (objP == null)
                {
                    MessageBox.Show("ObjekatPoslovni ne postoji.");
                    return;
                }

                ObjekatPoslovni objPoslovni = new ObjekatPoslovni();

                objPoslovni.Br_objekta = p.Br_objekta;
                objPoslovni.Spratnost = p.Spratnost;
                objPoslovni.Br_jedinica = p.Br_jedinica;
                objPoslovni.Poslovni = objP;

                s.Save(objPoslovni);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Stambeni

        public static List<StambeniPregled> vratiSveStambene()
        {
            List<StambeniPregled> stam = new List<StambeniPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Stambeni> sviStambeni =
                   from st in s.Query<Stambeni>()
                   select st;

                foreach (Stambeni st in sviStambeni)
                {
                    stam.Add(new StambeniPregled(st.ID, st.Naziv, st.Opis, st.Lokacija, st.Datum_pocetka, st.Budzet, st.Status, st.Planirani_Zavrsetak, st.Stvarni_Zavrsetak));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return stam;
        }

        public static StambeniBasic vratiStambeni(int id)
        {
            StambeniBasic stam = new StambeniBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Stambeni st = s.Get<Stambeni>(id);
                if (st != null)
                {
                    stam = new StambeniBasic(st.ID, st.Naziv, st.Opis, st.Lokacija, st.Datum_pocetka, st.Budzet, st.Status, st.Planirani_Zavrsetak, st.Stvarni_Zavrsetak);

                    stam.Objekti = vratiObjekteStambene(id);
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return stam;
        }

        public static void dodajStambeni(StambeniBasic stam)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Stambeni st = new Stambeni();

                st.Naziv = stam.Naziv;
                st.Opis = stam.Opis;
                st.Lokacija = stam.Lokacija;
                st.Datum_pocetka = stam.Datum_pocetka;
                st.Budzet = stam.Budzet;
                st.Status = stam.Status;
                st.Planirani_Zavrsetak = stam.Planirani_zavrsetak;
                st.Stvarni_Zavrsetak = stam.Stvarni_zavrsetak;

                s.Save(st);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniStambeni(StambeniBasic stam)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Stambeni st = s.Load<Stambeni>(stam.ID);

                st.Naziv = stam.Naziv;
                st.Opis = stam.Opis;
                st.Lokacija = stam.Lokacija;
                st.Datum_pocetka = stam.Datum_pocetka;
                st.Budzet = stam.Budzet;
                st.Status = stam.Status;
                st.Planirani_Zavrsetak = stam.Planirani_zavrsetak;
                st.Stvarni_Zavrsetak = stam.Stvarni_zavrsetak;

                s.Update(st);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        #region ObjekatStambeni

        public static List<ObjekatStambeniBasic> vratiObjekteStambene(int idProjekta)
        {
            List<ObjekatStambeniBasic> obj = new List<ObjekatStambeniBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ObjekatStambeni> sviStambeni =
                        from ss in s.Query<ObjekatStambeni>()
                        where ss.Stambeni.ID == idProjekta
                        select ss;

                foreach (ObjekatStambeni ss in sviStambeni)
                {
                    StambeniBasic stambeni = new StambeniBasic(
                        ss.Stambeni.ID,
                        ss.Stambeni.Naziv,
                        ss.Stambeni.Opis,
                        ss.Stambeni.Lokacija,
                        ss.Stambeni.Datum_pocetka,
                        ss.Stambeni.Budzet,
                        ss.Stambeni.Status,
                        ss.Stambeni.Planirani_Zavrsetak,
                        ss.Stambeni.Stvarni_Zavrsetak
                    );

                    obj.Add(new ObjekatStambeniBasic(ss.Id, ss.Br_objekta, ss.Spratnost, ss.Br_jedinica, stambeni));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return obj;
        }

        public static void dodajObjekatStambeni(ObjekatStambeniBasic os)//proveri
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Stambeni objS = s.Get<Stambeni>(os.Stambeni.ID);

                if (os == null || os.Stambeni == null)
                {
                    MessageBox.Show("Podaci nisu ispravni.");
                    return;
                }

                if (objS == null)
                {
                    MessageBox.Show("ObjekatPoslovni ne postoji.");
                    return;
                }

                ObjekatStambeni objStambeni = new ObjekatStambeni();

                objStambeni.Br_objekta = os.Br_objekta;
                objStambeni.Spratnost = os.Spratnost;
                objStambeni.Br_jedinica = os.Br_jedinica;
                objStambeni.Stambeni = objS;

                s.Save(objStambeni);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #endregion

        #region Sanacija

        public static List<SanacijaPregled> vratiSveSanacije()
        {
            List<SanacijaPregled> sanac = new List<SanacijaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Sanacija> sveSanacije =
                   from sa in s.Query<Sanacija>()
                   select sa;

                foreach (Sanacija sa in sveSanacije)
                {
                    sanac.Add(new SanacijaPregled(sa.ID, sa.Naziv, sa.Opis, sa.Lokacija, sa.Datum_pocetka, sa.Budzet, sa.Status, sa.Planirani_Zavrsetak, sa.Stvarni_Zavrsetak));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return sanac;
        }
        public static SanacijaBasic vratiSanaciju(int id)
        {
            SanacijaBasic sanac = new SanacijaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Sanacija sa = s.Get<Sanacija>(id);
                if (sa != null)
                {
                    sanac = new SanacijaBasic(sa.ID, sa.Naziv, sa.Opis, sa.Lokacija, sa.Datum_pocetka, sa.Budzet, sa.Status, sa.Planirani_Zavrsetak, sa.Stvarni_Zavrsetak);
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return sanac;
        }

        public static void dodajSanaciju(SanacijaBasic sanac)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sanacija sa = new Sanacija();

                sa.Naziv = sanac.Naziv;
                sa.Opis = sanac.Opis;
                sa.Lokacija = sanac.Lokacija;
                sa.Datum_pocetka = sanac.Datum_pocetka;
                sa.Budzet = sanac.Budzet;
                sa.Status = sanac.Status;
                sa.Planirani_Zavrsetak = sanac.Planirani_zavrsetak;
                sa.Stvarni_Zavrsetak = sanac.Stvarni_zavrsetak;

                s.Save(sa);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniSanaciju(SanacijaBasic sanac)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sanacija sa = s.Load<Sanacija>(sanac.ID);

                sa.Naziv = sanac.Naziv;
                sa.Opis = sanac.Opis;
                sa.Lokacija = sanac.Lokacija;
                sa.Datum_pocetka = sanac.Datum_pocetka;
                sa.Budzet = sanac.Budzet;
                sa.Status = sanac.Status;
                sa.Planirani_Zavrsetak = sanac.Planirani_zavrsetak;
                sa.Stvarni_Zavrsetak = sanac.Stvarni_zavrsetak;

                s.Update(sa);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Rekonstrukcija

        public static List<RekonstrukcijaPregled> vratiSveRekonstrukcije()
        {
            List<RekonstrukcijaPregled> rek = new List<RekonstrukcijaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Rekonstrukcija> sveRekonstrukcije =
                   from re in s.Query<Rekonstrukcija>()
                   select re;

                foreach (Rekonstrukcija re in sveRekonstrukcije)
                {
                    rek.Add(new RekonstrukcijaPregled(re.ID, re.Naziv, re.Opis, re.Lokacija, re.Datum_pocetka, re.Budzet, re.Status, re.Planirani_Zavrsetak, re.Stvarni_Zavrsetak));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return rek;
        }
        public static RekonstrukcijaBasic vratiRekonstrukciju(int id)
        {
            RekonstrukcijaBasic rek = new RekonstrukcijaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Rekonstrukcija re = s.Get<Rekonstrukcija>(id);
                if (re != null)
                {
                    rek = new RekonstrukcijaBasic(re.ID, re.Naziv, re.Opis, re.Lokacija, re.Datum_pocetka, re.Budzet, re.Status, re.Planirani_Zavrsetak, re.Stvarni_Zavrsetak);
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return rek;
        }

        public static void dodajRekonstrukciju(RekonstrukcijaBasic rek)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Rekonstrukcija re = new Rekonstrukcija();

                re.Naziv = rek.Naziv;
                re.Opis = rek.Opis;
                re.Lokacija = rek.Lokacija;
                re.Datum_pocetka = rek.Datum_pocetka;
                re.Budzet = rek.Budzet;
                re.Status = rek.Status;
                re.Planirani_Zavrsetak = rek.Planirani_zavrsetak;
                re.Stvarni_Zavrsetak = rek.Stvarni_zavrsetak;

                s.Save(re);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniRekonstrukciju(RekonstrukcijaBasic rek)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Rekonstrukcija re = s.Load<Rekonstrukcija>(rek.ID);

                re.Naziv = rek.Naziv;
                re.Opis = rek.Opis;
                re.Lokacija = rek.Lokacija;
                re.Datum_pocetka = rek.Datum_pocetka;
                re.Budzet = rek.Budzet;
                re.Status = rek.Status;
                re.Planirani_Zavrsetak = rek.Planirani_zavrsetak;
                re.Stvarni_Zavrsetak = rek.Stvarni_zavrsetak;

                s.Update(re);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #endregion

        #endregion

        #region Ugovor

        public static List<UgovorBasic> vratiUgovoreProjekta(int idProjekta)
        {
            List<UgovorBasic> ugovori = new List<UgovorBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Ugovor> sviUgovori =
                    from u in s.Query<Ugovor>()
                    where u.Projekat.ID == idProjekta
                    select u;

                foreach (Ugovor u in sviUgovori)
                {
                    MaterijalBasic materijal = null;
                    if(u.Materijal != null)
                    {
                        materijal = new MaterijalBasic(
                            u.Materijal.ID,
                            u.Materijal.Naziv,
                            u.Materijal.Cena,
                            u.Materijal.Proizvodjac,
                            u.Materijal.JedinicaMere,
                            u.Materijal.Sertifikat,
                            u.Materijal.Tip

                        );

                    }
                    ProjekatBasic projekat = null;
                    if(u.Projekat != null)
                    {
                        projekat = new ProjekatBasic(
                            u.Projekat.ID,
                            u.Projekat.Naziv,
                            u.Projekat.Opis,
                            u.Projekat.Lokacija,
                            u.Projekat.Datum_pocetka,
                            u.Projekat.Budzet,
                            u.Projekat.Status,
                            u.Projekat.Planirani_Zavrsetak,
                            u.Projekat.Stvarni_Zavrsetak
                        );

                    }
                    OpremaBasic oprema = null;
                    if (u.Oprema != null) 
                    {
                        oprema = new OpremaBasic(
                            u.Oprema.Id,
                            u.Oprema.Naziv,
                            u.Oprema.Tip,
                            u.Oprema.DatumUvoza,
                            u.Oprema.Proizvodjac,
                            u.Oprema.RasponOdrzavanja,
                            u.Oprema.Lokacija,
                            u.Oprema.Status

                        );

                    }

                    ugovori.Add(new UgovorBasic(
                        u.Id,
                        u.DatumPotpisivanja,
                        u.Vrednost,
                        u.PredmetUgovora,
                        u.Valuta,
                        u.Rok,
                        materijal,
                        projekat,
                        oprema
                    ));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ugovori;
        }

        public static UgovorBasic vratiUgovor(int id)
        {
            UgovorBasic ugovor = new UgovorBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Ugovor u = s.Load<Ugovor>(id);

                MaterijalBasic materijal = new MaterijalBasic(u.Materijal.ID, u.Materijal.Naziv, u.Materijal.Cena, u.Materijal.Proizvodjac, u.Materijal.JedinicaMere, u.Materijal.Sertifikat, u.Materijal.Tip);
                ProjekatBasic projekat = new ProjekatBasic(u.Projekat.ID, u.Projekat.Naziv, u.Projekat.Opis, u.Projekat.Lokacija, u.Projekat.Datum_pocetka, u.Projekat.Budzet, u.Projekat.Status, u.Projekat.Planirani_Zavrsetak, u.Projekat.Stvarni_Zavrsetak);
                OpremaBasic oprema = new OpremaBasic(u.Oprema.Id,u.Oprema.Naziv, u.Oprema.Tip, u.Oprema.DatumUvoza, u.Oprema.Proizvodjac, u.Oprema.RasponOdrzavanja, u.Oprema.Lokacija, u.Oprema.Status);

                ugovor = new UgovorBasic(u.Id,u.DatumPotpisivanja, u.Vrednost, u.PredmetUgovora, u.Valuta, u.Rok, materijal, projekat, oprema);

                //ugovor.Materijal = vratiKontakteOsobe(id);
                //ugovor.Projekat = vratiLicenceOsobe(id);
                //ugovor.Oprema = vratiBezbednosniIncidentOsobe(id);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ugovor;
        }

        #endregion

        #region BezbednosniIncident

        public static List<BezbednosniIncidentBasic> vratiBezbednosniIncidenteProjekta(int idProjekta)
        {
            List<BezbednosniIncidentBasic> incidenti = new List<BezbednosniIncidentBasic>();

            try
            {
                ISession s = DataLayer.GetSession();


                IEnumerable<BezbednosniIncident> sviIncidenti =
                         from i in s.Query<BezbednosniIncident>()
                         where i.Projekat.ID == idProjekta
                         select i;

                foreach (BezbednosniIncident i in sviIncidenti)
                {
                    ProjekatBasic projekat = new ProjekatBasic(
                        i.Projekat.ID,
                        i.Projekat.Naziv,
                        i.Projekat.Opis,
                        i.Projekat.Lokacija,
                        i.Projekat.Datum_pocetka,
                        i.Projekat.Budzet,
                        i.Projekat.Status,
                        i.Projekat.Planirani_Zavrsetak,
                        i.Projekat.Stvarni_Zavrsetak
                    );
                    OsobaBasic osoba = new OsobaBasic(
                        i.Osoba.Id,
                        i.Osoba.Jmbg,
                        i.Osoba.Ime,
                        i.Osoba.Prezime,
                        i.Osoba.DatumRodjenja,
                        i.Osoba.Struka
                        );

                    incidenti.Add(new BezbednosniIncidentBasic(i.ID, i.Opis, i.Datum, i.Lokacija, i.Preduzete_mere, i.Posledice, i.Tip_incidenta, projekat, osoba));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return incidenti;
        }

        public static List<BezbednosniIncidentBasic> vratiBezbednosniIncidentOsobe(int idOsobe)
        {
            List<BezbednosniIncidentBasic> incidenti = new List<BezbednosniIncidentBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<BezbednosniIncident> sviIncidenti =
                    from i in s.Query<BezbednosniIncident>()
                    where i.Osoba.Id == idOsobe
                    select i;

                foreach (BezbednosniIncident i in sviIncidenti)
                {
                    ProjekatBasic proj = new ProjekatBasic(
                        i.Projekat.ID,
                        i.Projekat.Naziv,
                        i.Projekat.Opis,
                        i.Projekat.Lokacija,
                        i.Projekat.Datum_pocetka,
                        i.Projekat.Budzet,
                        i.Projekat.Status,
                        i.Projekat.Planirani_Zavrsetak,
                        i.Projekat.Stvarni_Zavrsetak
                    );
                    OsobaBasic osob = new OsobaBasic(
                        i.Osoba.Id,
                        i.Osoba.Jmbg,
                        i.Osoba.Ime,
                        i.Osoba.Prezime,
                        i.Osoba.DatumRodjenja,
                        i.Osoba.Struka
                        );


                    incidenti.Add(new BezbednosniIncidentBasic(i.ID, i.Opis, i.Datum, i.Lokacija, i.Preduzete_mere, i.Posledice, i.Tip_incidenta, proj, osob));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return incidenti;
        }

        public static void obrisiBezbednosniIncident(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BezbednosniIncident inci = s.Load<BezbednosniIncident>(id);

                s.Delete(inci);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void dodajBezbednosniIncident(BezbednosniIncidentBasic d, string tipIncidenta)//proveri
        {
            try
            {
                 ISession s = DataLayer.GetSession();

                Osoba osoba = s.Get<Osoba>(d.Osoba.Id);

                if (osoba == null)
                {
                    MessageBox.Show("Osoba ne postoji.");
                    return;
                }

                Projekat projekat = s.Get<Projekat>(d.Projekat.ID);
                if(projekat == null)
                {
                    MessageBox.Show("Projekat ne postoji.");
                    return;
                }


                BezbednosniIncident incident = tipIncidenta switch
                {
                    "PovredaNaRadu" => new PovredaNaRadu(),
                    "KvarOpreme" => new KvarOpreme(),
                    "NepostovanjeProcedura" => new NepostovanjeProcedura(),
                    "OpasnaSituacija" => new OpasnaSituacija(),
                    "EkoloskiIncident" => new EkoloskiIncident(),
                    _ => throw new ArgumentException("Nepoznat tip incidenta.")
                };

                incident.Opis = d.Opis;
                incident.Datum = d.Datum;
                incident.Lokacija = d.Lokacija;
                incident.Preduzete_mere = d.Preduzete_mere;
                incident.Posledice = d.Posledice;
                incident.Tip_incidenta = d.Tip_incidenta;
                incident.Osoba = osoba;
                incident.Projekat = projekat;

                s.Save(incident);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniBezbednosniIncident(BezbednosniIncidentBasic inc)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                BezbednosniIncident b = s.Load<BezbednosniIncident>(inc.ID);

                b.Opis = inc.Opis;
                b.Datum = inc.Datum;
                b.Lokacija = inc.Lokacija;
                b.Preduzete_mere = inc.Preduzete_mere;
                b.Posledice = inc.Posledice;
                b.Tip_incidenta = inc.Tip_incidenta;



                s.Update(b);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Deonice

        public static List<DeonicaBasic> vratiDeoniceInfrastrukture(int idProjekta)
        {
            List<DeonicaBasic> deonice = new List<DeonicaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Deonica> sveDeonice =
                    from d in s.Query<Deonica>()
                    where d.Infrastruktura.ID == idProjekta
                    select d;

                foreach (Deonica d in sveDeonice)
                {
                    InfrastrukturaBasic infra = new InfrastrukturaBasic(
                        d.Infrastruktura.ID,
                        d.Infrastruktura.Naziv,
                        d.Infrastruktura.Opis,
                        d.Infrastruktura.Lokacija,
                        d.Infrastruktura.Datum_pocetka,
                        d.Infrastruktura.Budzet,
                        d.Infrastruktura.Status,
                        d.Infrastruktura.Planirani_Zavrsetak,
                        d.Infrastruktura.Stvarni_Zavrsetak
                        );

                    deonice.Add(new DeonicaBasic(d.Id, d.Br_deonice, infra));

                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return deonice;
        }

        public static DeonicaBasic vratiDeonicu(int id)
        {
            DeonicaBasic deonica = new DeonicaBasic();


            try
            {
                ISession s = DataLayer.GetSession();

                Deonica d = s.Load<Deonica>(id);

                InfrastrukturaBasic infra = new InfrastrukturaBasic(
                    d.Infrastruktura.ID,
                    d.Infrastruktura.Naziv,
                    d.Infrastruktura.Opis,
                    d.Infrastruktura.Lokacija,
                    d.Infrastruktura.Datum_pocetka,
                    d.Infrastruktura.Budzet,
                    d.Infrastruktura.Status,
                    d.Infrastruktura.Planirani_Zavrsetak,
                    d.Infrastruktura.Stvarni_Zavrsetak
                    );

                deonica = new DeonicaBasic(d.Id, d.Br_deonice, infra);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return deonica;
        }

        public static void dodajDeonicu(DeonicaBasic d)//proveri
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Infrastruktura infra = s.Get<Infrastruktura>(d.Infrastruktura.ID);

                if (infra == null)
                {
                    MessageBox.Show("Infrastuktura ne postoji.");
                    return;
                }

                Deonica deonica = new Deonica();

                deonica.Br_deonice = d.Br_deonice;
                deonica.Infrastruktura = infra;

                s.Save(deonica);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniDeonicu(DeonicaBasic d)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Deonica deonica = s.Load<Deonica>(d.ID);

                deonica.Br_deonice = d.Br_deonice;

                s.Update(deonica);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void obrisiDeonicu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Deonica deonica = s.Load<Deonica>(id);

                s.Delete(deonica);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

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
                        z.Id,z.Naziv,z.Opis,z.ProcenjeniTrosak,z.PlaniraniZavrsetak,z.StvarniZavrsetak,z.PlaniraniPocetak,z.StvarniPocetak,z.Prioritet,z.Status,faza,roditelj
                    );
                    zadaci.Add(zp);
                    
                }
             s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                   z.Id,z.Naziv,z.Opis,z.ProcenjeniTrosak,z.PlaniraniZavrsetak,z.StvarniZavrsetak,z.PlaniraniPocetak,z.StvarniPocetak,z.Prioritet,z.Status,faza,roditelj);

                zadatak.Podzadaci = vratiSvePodzadatke(id);
                zadatak.RadniNalozi = vratiRadneNaloge(id);
                zadatak.Napreci = vratiNapretke(id);
                zadatak.KontroleKvaliteta = vratiKontroleKvaliteta(id);
                zadatak.Angazovani = vratiSveAngazovanja(id);
                zadatak.AngazovanaOprema = vratiSveAngazuje(id);
                zadatak.Koristi = vratiKoristiZadatka(id);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                    MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
            }
        }

        public static void obrisiPodzadatak(int idPodzadatka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zadatak podzadatak =s.Load<Zadatak>(idPodzadatka);

                podzadatak.Roditelj = null;

                s.Update(podzadatak);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region RadniNalozi

        public static List<RadniNalogBasic> vratiRadneNaloge(int idZadatka)
        {
            List<RadniNalogBasic> radniNalozi =
                new List<RadniNalogBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<RadniNalog> sviRadniNalozi =
                    from rn in s.Query<RadniNalog>()
                    where rn.Zadatak.Id == idZadatka
                    select rn;

                foreach (RadniNalog rn in sviRadniNalozi)
                {
                    radniNalozi.Add(new RadniNalogBasic(
                      rn.BrojNaloga, null, rn.Status, rn.DatumIzdavanja));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return radniNalozi;
        }

        public static RadniNalogBasic vratiRadniNalog(int id)
        {
            RadniNalogBasic radniNalog = new RadniNalogBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                RadniNalog rn = s.Load<RadniNalog>(id);

                ZadatakBasic zadatak = null;

                if (rn.Zadatak != null)
                {
                    zadatak = new ZadatakBasic();
                    zadatak.Id = rn.Zadatak.Id;
                    zadatak.Naziv = rn.Zadatak.Naziv;
                }

                radniNalog = new RadniNalogBasic(
                   rn.BrojNaloga, zadatak, rn.Status, rn.DatumIzdavanja);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return radniNalog;
        }

        public static void dodajRadniNalog(RadniNalogBasic radniNalog)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zadatak zadatak = s.Load<Zadatak>(radniNalog.Zadatak.Id);

                RadniNalog rn=new RadniNalog();

                rn.DatumIzdavanja = radniNalog.DatumIzdavanja;
                rn.Status = radniNalog.Status;
                rn.Zadatak = zadatak;

                s.Save(rn);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniRadniNalog(RadniNalogBasic rn)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadniNalog radniNalog = s.Load<RadniNalog>(rn.BrNaloga);

                radniNalog.Status=rn.Status;
                radniNalog.DatumIzdavanja = rn.DatumIzdavanja;

                s.Update(radniNalog);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void obrisiRadniNalog(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadniNalog radniNalog = s.Load<RadniNalog>(id);

                s.Delete(radniNalog);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Napreci

        public static List<NapredakBasic> vratiNapretke(int idZadatka)
        {
            List<NapredakBasic> napreci =
                new List<NapredakBasic>();

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
                        n.Id, n.Datum,null, n.DnevniIzvestaj, n.ProcenatRealizacije, n.PrimedbaNadzora, n.KorektivnaMera));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return napreci;
        }

        public static NapredakBasic vratiNapredak(int id)
        {
            NapredakBasic napredak = new NapredakBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Napredak n = s.Load<Napredak   >(id);

                ZadatakBasic zadatak = null;

                if (n.Zadatak != null)
                {
                    zadatak = new ZadatakBasic();
                    zadatak.Id = n.Zadatak.Id;
                    zadatak.Naziv = n.Zadatak.Naziv;
                }

                napredak = new NapredakBasic(
                   n.Id,n.Datum,zadatak,n.DnevniIzvestaj,n.ProcenatRealizacije,n.PrimedbaNadzora,n.KorektivnaMera);
                
                napredak.Fotografije=vratiFotografije(id);
                
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

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
                         kk.Id, kk.DatumInspekcije, kk.PrimedbeNadzora, kk.Zapisnik, kk.ZabranaNastavkaRadova, kk.RazlogZabrane, kk.DatumOtklanjanjaZabrane,null));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                   n.Id,n.DatumInspekcije,n.PrimedbeNadzora,n.Zapisnik,n.ZabranaNastavkaRadova,n.RazlogZabrane,n.DatumOtklanjanjaZabrane,zadatak);

                kontrolaKvaliteta.StavkeKontrole=vratiSveStavke(id);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Faza

        public static List<FazaPregled> vratiSveFaze()
        {
            List<FazaPregled> faze = new List<FazaPregled>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Faza> sveFaze =
                    from f in s.Query<Faza>()
                    select f;

                foreach (Faza f in sveFaze)
                {
                    ProjekatPregled projekat = null;

                    if (f.Projekat != null)
                    {
                        projekat = new ProjekatPregled();
                        projekat.ID = f.Projekat.ID;
                        projekat.Naziv = f.Projekat.Naziv;
                    }

                    FizickoLicePregled fizickoLice = null;

                    if (f.FizickoLice != null)
                    {
                        fizickoLice = new FizickoLicePregled();
                        fizickoLice.Id = f.FizickoLice.Id;
                        fizickoLice.Ime = f.FizickoLice.Ime;
                        fizickoLice.Prezime = f.FizickoLice.Prezime;
                    }

                    FazaPregled nadFaza = null;

                    if (f.NadFaza != null)
                    {
                        nadFaza = new FazaPregled();
                        nadFaza.Id = f.NadFaza.Id;
                        nadFaza.Naziv = f.NadFaza.Naziv;
                    }

                    FazaPregled faza = new FazaPregled(
                        f.Id,f.Naziv,f.DatumOd,f.DatumDo,f.Status,f.Budzet,projekat,fizickoLice,nadFaza
                    );

                    faze.Add(faza);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return faze;
        }

        public static List<FazaBasic> vratiFazeProjekta(int idProjekta)
        {
            List<FazaBasic> faze = new List<FazaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Faza> sveFaze =
                    from f in s.Query<Faza>()
                    where f.Projekat.ID == idProjekta
                    select f;

                foreach (Faza f in sveFaze)
                {
                  
                    ProjekatBasic projekat = null;
                    if (f.Projekat != null)
                    {
                        projekat = new ProjekatBasic(
                            f.Projekat.ID,
                            f.Projekat.Naziv,
                            f.Projekat.Opis,
                            f.Projekat.Lokacija,
                            f.Projekat.Datum_pocetka,
                            f.Projekat.Budzet,
                            f.Projekat.Status,
                            f.Projekat.Planirani_Zavrsetak,
                            f.Projekat.Stvarni_Zavrsetak
                        );

                    }
                    FizickoLiceBasic fizickoLice = null;
                    if(f.FizickoLice != null)
                    {
                        fizickoLice = new FizickoLiceBasic(
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
                        );

                    }

                    FazaBasic nadFaza = null;
                    if(f.NadFaza != null)
                    {
                        nadFaza = new FazaBasic(
                            f.NadFaza.Id,
                            f.NadFaza.Naziv,
                            f.NadFaza.DatumOd,
                            f.NadFaza.DatumDo,
                            f.NadFaza.Status,
                            f.NadFaza.Budzet,
                            projekat,
                            fizickoLice,
                            nadFaza//mozda pravi problem
                            );
                    }

                    faze.Add(new FazaBasic(
                        f.Id,
                        f.Naziv,
                        f.DatumOd,
                        f.DatumDo,
                        f.Status,
                        f.Budzet,
                        projekat,
                        fizickoLice,
                        nadFaza
                    ));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return faze;
        }

        #endregion

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
                    stavke.Add(new StavkaKontroleBasic(k.Id,null,k.RedniBrojStavke,k.Uzorci,k.LabNalazi,k.RezultatiIspitivanja,k.KorektivneMere,k.RokZaOtklanjanje));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                    kontrola.Id=k.Id;
                }

                stavka = new StavkaKontroleBasic(
                  k.Id,kontrola,k.RedniBrojStavke,k.Uzorci,k.LabNalazi,k.RezultatiIspitivanja,k.KorektivneMere,k.RokZaOtklanjanje);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Fotografije

        public static List<FotografijaBasic> vratiFotografije(int idNapredak)
        {
            List<FotografijaBasic> fotografije =new List<FotografijaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Fotografija> slike =
                    from f in s.Query<Fotografija>()
                    where f.Napredak.Id == idNapredak
                    select f;

                foreach (Fotografija f in slike)
                {
                    fotografije.Add(new FotografijaBasic(
                            f.Napredak.Id,
                            f.Putanja
                        )
                    );
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return fotografije;
        }

        public static void dodajFotografiju(FotografijaBasic fotografija)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Napredak napredak =s.Load<Napredak>(fotografija.IdNapredak);

                Fotografija f = new Fotografija();

                f.Napredak = napredak;
                f.Putanja = fotografija.Putanja;

                s.Save(f);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void obrisiFotografiju(int idNapredak,string putanja)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Fotografija fotografija =
                       (from f in s.Query<Fotografija>()
                        where f.Napredak.Id == idNapredak
                           && f.Putanja == putanja
                        select f).FirstOrDefault();

                //za svaki slucaj proveravamo, ali mislim da nema potrebe
                if (fotografija == null)
                {
                    MessageBox.Show("Fotografija nije pronadjena.");
                    s.Close();
                    return;
                }

                s.Delete(fotografija);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Faktura

        public static List<FakturaBasic> vratiFaktureProjekta(int idProjekta)
        {
            List<FakturaBasic> fakture = new List<FakturaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Faktura> sveFakture =
                    from f in s.Query<Faktura>()
                    where f.IDProjekta.ID == idProjekta
                    select f;

                foreach (Faktura f in sveFakture)
                {
                    ProjekatBasic projekat = null;
                    if (f.IDProjekta != null)
                    {
                        projekat = new ProjekatBasic(
                            f.IDProjekta.ID,
                            f.IDProjekta.Naziv,
                            f.IDProjekta.Opis,
                            f.IDProjekta.Lokacija,
                            f.IDProjekta.Datum_pocetka,
                            f.IDProjekta.Budzet,
                            f.IDProjekta.Status,
                            f.IDProjekta.Planirani_Zavrsetak,
                            f.IDProjekta.Stvarni_Zavrsetak
                        );
                    }
                    PravnaLicaBasic pravnoLiceIzdaje = null;
                    if(f.PravnoLiceIzdaje != null)
                    {
                        pravnoLiceIzdaje = new PravnaLicaBasic(
                            f.PravnoLiceIzdaje.Id,
                            f.PravnoLiceIzdaje.Jmbg,
                            f.PravnoLiceIzdaje.Ime,
                            f.PravnoLiceIzdaje.Prezime,
                            f.PravnoLiceIzdaje.DatumRodjenja,
                            f.PravnoLiceIzdaje.Struka,
                            f.PravnoLiceIzdaje.FlagPB,
                            f.PravnoLiceIzdaje.FlagInve,
                            f.PravnoLiceIzdaje.FlagIzv,
                            f.PravnoLiceIzdaje.FlagP,
                            f.PravnoLiceIzdaje.FlagD,
                            f.PravnoLiceIzdaje.FlagN
                        );
                    }
                    PravnaLicaBasic pravnoLicePrima = null;
                    if(f.PravnoLicePrima != null)
                    {
                        pravnoLiceIzdaje = new PravnaLicaBasic(
                            f.PravnoLiceIzdaje.Id,
                            f.PravnoLiceIzdaje.Jmbg,
                            f.PravnoLiceIzdaje.Ime,
                            f.PravnoLiceIzdaje.Prezime,
                            f.PravnoLiceIzdaje.DatumRodjenja,
                            f.PravnoLiceIzdaje.Struka,
                            f.PravnoLiceIzdaje.FlagPB,
                            f.PravnoLiceIzdaje.FlagInve,
                            f.PravnoLiceIzdaje.FlagIzv,
                            f.PravnoLiceIzdaje.FlagP,
                            f.PravnoLiceIzdaje.FlagD,
                            f.PravnoLiceIzdaje.FlagN
                        );
                    }

                    fakture.Add(new FakturaBasic(f.Br_fakture, f.Iznos, f.Valuta, f.statusPlacanja, f.Datum, projekat, pravnoLiceIzdaje, pravnoLicePrima));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return fakture;
        }

        #endregion

        #region Angazovani

        public static List<AngazovanBasic> vratiSveAngazovanja(int idZadatka)
        {
            List<AngazovanBasic> angazovanja =new List<AngazovanBasic>();

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

                    AngazovanBasic ab =new AngazovanBasic(
                            zadatak,osoba,a.DatumOd,a.DatumDo,a.StatusAngazovanja
                        );

                    angazovanja.Add(ab);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
            }
            return angazovanje;
        }

        public static void dodajAngazovanje(AngazovanBasic angazovanje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zadatak zadatak =s.Load<Zadatak>(angazovanje.Zadatak.Id);

                Osoba osoba =s.Load<Osoba>(angazovanje.Osoba.Id);

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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
            }
        }

        public static void obrisiAngazovanje(int idZadatka,int idOsobe)
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
                MessageBox.Show(ex.ToString());
            }
        }


        #endregion

        #region AngazujeOpremu

        public static List<AngazujeBasic> vratiSveAngazuje(int idZadatka)
        {
            List<AngazujeBasic> angazuje =new List<AngazujeBasic>();

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
                        oprema.Naziv= a.Oprema.Naziv;
                    }

                    angazuje.Add(
                        new AngazujeBasic(
                            zadatak,oprema,a.DatumOd,a.DatumDo,a.BrojSati
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

        public static AngazujeBasic vratiAngazuje(int idZadatka,int idOpreme)
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
                        zadatak,oprema,a.DatumOd,a.DatumDo,a.BrojSati
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

                if (opremaJeZauzeta(s,angazuje.Zadatak.Id,angazuje.Oprema.Id,angazuje.DatumOd,angazuje.DatumDo))
                {
                    MessageBox.Show("Izabrana oprema je vec angazovana u tom periodu");
                    s.Close();
                    return;
                }

                Zadatak zadatak =s.Load<Zadatak>(angazuje.Zadatak.Id);

                Oprema oprema =s.Load<Oprema>(angazuje.Oprema.Id);

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

        public static void obrisiAngazuje(int idZadatka,int idOpreme)
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

        private static bool opremaJeZauzeta(ISession s,int idZadatka,int idOpreme,DateTime datumOd,DateTime? datumDo)
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
                   noviKraj =datumDo.Value;
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
                       o.Id,o.Naziv,o.Tip,o.DatumUvoza,o.Proizvodjac,o.RasponOdrzavanja,o.Lokacija,o.Status));
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
                    m.Id,m.Naziv,m.Tip,m.DatumUvoza,m.Proizvodjac,m.RasponOdrzavanja,m.Lokacija,m.Status);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Materijali
        public static List<MaterijalPregled> vratiSavMaterijal()
        {
            List<MaterijalPregled> materijali = new List<MaterijalPregled>();

            try
            {
                ISession s = DataLayer.GetSession();

                IList<Materijal> sviMaterijali = s.Query<Materijal>().ToList();

                foreach (Materijal m in sviMaterijali)
                {
                    string tip = "";

                    if (m is Zastitni)
                        tip = "Zastitni";
                    else if (m is Masinski)
                        tip = "Masinski";
                    else if (m is Gradjevinski)
                        tip = "Gradjevinski";
                    else if (m is Elektro)
                        tip = "Elektro";
                    else if (m is Zavrsni)
                        tip = "Zavrsni";

                    materijali.Add(new MaterijalPregled(
                            m.ID,m.Naziv,m.Cena,m.Proizvodjac,m.JedinicaMere,m.Sertifikat,tip
                        ));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return materijali;
        }
        public static void obrisiMaterijal(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Materijal materijal = s.Load<Materijal>(id);

                s.Delete(materijal);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region Zastitni
        public static List<ZastitniPregled> vratiSavZastitniMaterijal()
        {
            List<ZastitniPregled> materijali = new List<ZastitniPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Zastitni> savMaterijal = from m in s.Query<Zastitni>()
                                                      select m;
                foreach (Zastitni m in savMaterijal)
                {
                    materijali.Add(new ZastitniPregled(
                      m.ID, m.Naziv, m.Cena, m.Proizvodjac, m.JedinicaMere, m.Sertifikat, m.Tip));
                }
                s.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return materijali;
        }

        public static ZastitniBasic vratiZastitniMaterijal(int id)
        {
            ZastitniBasic materijal = new ZastitniBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Zastitni m = s.Load<Zastitni>(id);

                materijal = new ZastitniBasic(
                    m.ID, m.Naziv, m.Cena, m.Proizvodjac, m.JedinicaMere, m.Sertifikat, m.Tip);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return materijal;
        }

        public static void dodajZastitniMaterijal(ZastitniBasic m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zastitni materijal = new Zastitni();

                materijal.Naziv = m.Naziv;
                materijal.Cena = m.Cena;
                materijal.Proizvodjac = m.Proizvodjac;
                materijal.JedinicaMere = m.JedinicaMere;
                materijal.Sertifikat = m.Sertifikat;
                materijal.Tip = m.Tip;

                s.Save(materijal);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniZastitniMaterijal(ZastitniBasic m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zastitni materijal = s.Load<Zastitni>(m.ID);

                materijal.Naziv = m.Naziv;
                materijal.Cena = m.Cena;
                materijal.Proizvodjac = m.Proizvodjac;
                materijal.JedinicaMere = m.JedinicaMere;
                materijal.Sertifikat = m.Sertifikat;

                s.Update(materijal);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Masinski

        public static List<MasinskiPregled> vratiSavMasinskiMaterijal()
        {
            List<MasinskiPregled> materijali = new List<MasinskiPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Masinski> savMaterijal = from m in s.Query<Masinski>()
                                                     select m;
                foreach (Masinski m in savMaterijal)
                {
                    materijali.Add(new MasinskiPregled(
                      m.ID, m.Naziv, m.Cena, m.Proizvodjac, m.JedinicaMere, m.Sertifikat, m.Tip));
                }
                s.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return materijali;
        }

        public static MasinskiBasic vratiMasinskiMaterijal(int id)
        {
            MasinskiBasic materijal = new MasinskiBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Masinski m = s.Load<Masinski>(id);

                materijal = new MasinskiBasic(
                    m.ID, m.Naziv, m.Cena, m.Proizvodjac, m.JedinicaMere, m.Sertifikat, m.Tip);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return materijal;
        }

        public static void dodajMasinskiMaterijal(MasinskiBasic m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Masinski materijal = new Masinski();

                materijal.Naziv = m.Naziv;
                materijal.Cena = m.Cena;
                materijal.Proizvodjac = m.Proizvodjac;
                materijal.JedinicaMere = m.JedinicaMere;
                materijal.Sertifikat = m.Sertifikat;
                materijal.Tip = m.Tip;

                s.Save(materijal);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniMasinskiMaterijal(MasinskiBasic m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Masinski materijal = s.Load<Masinski>(m.ID);

                materijal.Naziv = m.Naziv;
                materijal.Cena = m.Cena;
                materijal.Proizvodjac = m.Proizvodjac;
                materijal.JedinicaMere = m.JedinicaMere;
                materijal.Sertifikat = m.Sertifikat;

                s.Update(materijal);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Gradjevinski

        public static List<GradjevinskiPregled> vratiSavGradjevinskiMaterijal()
        {
            List<GradjevinskiPregled> materijali = new List<GradjevinskiPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Gradjevinski> savMaterijal = from m in s.Query<Gradjevinski>()
                                                     select m;
                foreach (Gradjevinski m in savMaterijal)
                {
                    materijali.Add(new GradjevinskiPregled(
                      m.ID, m.Naziv, m.Cena, m.Proizvodjac, m.JedinicaMere, m.Sertifikat,m.Tip));
                }
                s.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return materijali;
        }

        public static GradjevinskiBasic vratiGradjevinskiMaterijal(int id)
        {
            GradjevinskiBasic materijal = new GradjevinskiBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Gradjevinski m = s.Load<Gradjevinski>(id);

                materijal = new GradjevinskiBasic(
                    m.ID, m.Naziv, m.Cena, m.Proizvodjac, m.JedinicaMere, m.Sertifikat, m.Tip);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return materijal;
        }

        public static void dodajGradjevinskiMaterijal(GradjevinskiBasic m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Gradjevinski materijal = new Gradjevinski();

                materijal.Naziv = m.Naziv;
                materijal.Cena = m.Cena;
                materijal.Proizvodjac = m.Proizvodjac;
                materijal.JedinicaMere = m.JedinicaMere;
                materijal.Sertifikat = m.Sertifikat;
                materijal.Tip = m.Tip;

                s.Save(materijal);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniGradjevinskiMaterijal(GradjevinskiBasic m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Gradjevinski materijal = s.Load<Gradjevinski>(m.ID);

                materijal.Naziv = m.Naziv;
                materijal.Cena = m.Cena;
                materijal.Proizvodjac = m.Proizvodjac;
                materijal.JedinicaMere = m.JedinicaMere;
                materijal.Sertifikat = m.Sertifikat;

                s.Update(materijal);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Elektro

        public static List<ElektroPregled> vratiSavElektroMaterijal()
        {
            List<ElektroPregled> materijali = new List<ElektroPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Elektro> savMaterijal = from m in s.Query<Elektro>()
                                                         select m;
                foreach (Elektro m in savMaterijal)
                {
                    materijali.Add(new ElektroPregled(
                      m.ID, m.Naziv, m.Cena, m.Proizvodjac, m.JedinicaMere, m.Sertifikat, m.Tip));
                }
                s.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return materijali;
        }

        public static ElektroBasic vratiElektroMaterijal(int id)
        {
            ElektroBasic materijal = new ElektroBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Elektro m = s.Load<Elektro>(id);

                materijal = new ElektroBasic(
                    m.ID, m.Naziv, m.Cena, m.Proizvodjac, m.JedinicaMere, m.Sertifikat, m.Tip);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return materijal;
        }

        public static void dodajElektroMaterijal(ElektroBasic m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Elektro materijal = new Elektro();

                materijal.Naziv = m.Naziv;
                materijal.Cena = m.Cena;
                materijal.Proizvodjac = m.Proizvodjac;
                materijal.JedinicaMere = m.JedinicaMere;
                materijal.Sertifikat = m.Sertifikat;
                materijal.Tip = m.Tip;

                s.Save(materijal);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniElektroMaterijal(ElektroBasic m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Elektro materijal = s.Load<Elektro>(m.ID);

                materijal.Naziv = m.Naziv;
                materijal.Cena = m.Cena;
                materijal.Proizvodjac = m.Proizvodjac;
                materijal.JedinicaMere = m.JedinicaMere;
                materijal.Sertifikat = m.Sertifikat;

                s.Update(materijal);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Zavrsni

        public static List<ZavrsniPregled> vratiSavZavrsniMaterijal()
        {
            List<ZavrsniPregled> materijali = new List<ZavrsniPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Zavrsni> savMaterijal = from m in s.Query<Zavrsni>()
                                                         select m;
                foreach (Zavrsni m in savMaterijal)
                {
                    materijali.Add(new ZavrsniPregled(
                      m.ID, m.Naziv, m.Cena, m.Proizvodjac, m.JedinicaMere, m.Sertifikat, m.Tip));
                }
                s.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return materijali;
        }

        public static ZavrsniBasic vratiZavrsniMaterijal(int id)
        {
            ZavrsniBasic materijal = new ZavrsniBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Zavrsni m = s.Load<Zavrsni>(id);

                materijal = new ZavrsniBasic(
                    m.ID, m.Naziv, m.Cena, m.Proizvodjac, m.JedinicaMere, m.Sertifikat, m.Tip);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return materijal;
        }

        public static void dodajZavrsniMaterijal(ZavrsniBasic m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zavrsni materijal = new Zavrsni();

                materijal.Naziv = m.Naziv;
                materijal.Cena = m.Cena;
                materijal.Proizvodjac = m.Proizvodjac;
                materijal.JedinicaMere = m.JedinicaMere;
                materijal.Sertifikat = m.Sertifikat;
                materijal.Tip = m.Tip;

                s.Save(materijal);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniZavrsniMaterijal(ZavrsniBasic m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zavrsni materijal = s.Load<Zavrsni>(m.ID);

                materijal.Naziv = m.Naziv;
                materijal.Cena = m.Cena;
                materijal.Proizvodjac = m.Proizvodjac;
                materijal.JedinicaMere = m.JedinicaMere;
                materijal.Sertifikat = m.Sertifikat;

                s.Update(materijal);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #endregion

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

                    koristi.Add(new KoristiBasic(k.ID,k.Kolicina,zadatak,materijal));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                        k.ID,k.Kolicina,zadatak,materijal);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                koristi.Kolicina=k.Kolicina; 

                s.Save(koristi);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion
    }


}
