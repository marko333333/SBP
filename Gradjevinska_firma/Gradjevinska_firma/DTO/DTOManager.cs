using Gradjevinska_firma.Data;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firma.Entiteti;

namespace Gradjevinska_firma.DTO
{   
    //dodaj kolekciju za BezbednosniIncident u Osoba
    public class DTOManager
    {
        #region PomocneFje
        private static MaterijalPregled MapMaterijalPregled(Materijal m)
        {
            return new MaterijalPregled(m.ID, m.Naziv, m.Cena, m.Proizvodjac, m.JedinicaMere, m.Sertifikat, m.TipMaterijala);
        }

        private static ProjekatPregled MapProjekatPregled(Projekat p)
        {
            return new ProjekatPregled(p.ID, p.Naziv, p.Opis, p.Lokacija, p.Datum_pocetka, p.Budzet, p.Status, p.Planirani_Zavrsetak, p.Stvarni_Zavrsetak);
        }

        private static OpremaPregled MapOpremaPregled(Oprema o)
        {
            return new OpremaPregled(o.Id, o.Naziv, o.Tip, o.DatumUvoza, o.Proizvodjac, o.DatumNabavke, o.RasponOdrzavanja, o.Lokacija, o.Status);
        }

        #endregion
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
                    o.Id,o.Jmbg,o.Ime,o.Prezime,o.DatumRodjenja,o.Struka);
                
                osoba.Kontakti = vratiKontakteOsobe(id);
                osoba.Licence=vratiLicenceOsobe(id);

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
                    lice.BezbednosneObuke=vratiBezbednosneObukeOsobe(id);
                    lice.LekarskiPregledi=vratiLekarskePregledeOsobe(id);
                    lice.ZastitneOpreme=vratiZastitneOpremeOsobe(id) ;
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
                        k.Id,k.Osoba.Id,k.Broj);
              
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

                Osoba osoba = s.Get<Osoba>(k.IdOsoba);

                if (osoba == null)
                {
                    MessageBox.Show("Osoba ne postoji.");
                    return;
                }

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

                kontakt.Broj=k.Broj;

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
            LicencaBasic licenca=new LicencaBasic();

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

                Osoba osoba = s.Get<Osoba>(l.IdOsoba);

                if (osoba == null)
                {
                    MessageBox.Show("Osoba ne postoji.");
                    return;
                }

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
                        b.Id,b.FizickoLice.Id,b.NazivObuke,b.Datum);

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

                FizickoLice lice = s.Get<FizickoLice>(bezObuka.IdFizickoLice);

                if (lice == null)
                {
                    MessageBox.Show("Fizicko lice ne postoji.");
                    return;
                }

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
                        lp.Id,lp.FizickoLice.Id,lp.Rezultat,lp.Datum);

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

                FizickoLice fizicko = s.Get<FizickoLice>(lp.IdFizickoLice);

                if (fizicko == null)
                {
                    MessageBox.Show("Fizicko lice ne postoji.");
                    return;
                }

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
            List<SertifikatSpecOpremeBasic> sertifikati =
                new List<SertifikatSpecOpremeBasic>();

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
                        sso.Id,sso.FizickoLice.Id,sso.Sertifikat);

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

                FizickoLice fizicko = s.Get<FizickoLice>(sso.IdFizickoLice);

                if (fizicko == null)
                {
                    MessageBox.Show("Fizicko lice ne postoji.");
                    return;
                }

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
            List<ZastitnaOpremaBasic> opreme =
                new List<ZastitnaOpremaBasic>();

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
                        zo.Id,zo.FizickoLice.Id,zo.NazivOpreme);

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

                FizickoLice fizicko = s.Get<FizickoLice>(zo.IdFizickoLice);

                if (fizicko == null)
                {
                    MessageBox.Show("Fizicko lice ne postoji.");
                    return;
                }

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

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return projekat;
        }

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
                    MaterijalBasic materijal = new MaterijalBasic(
                        u.Materijal.ID,
                        u.Materijal.Naziv,
                        u.Materijal.Cena,
                        u.Materijal.Proizvodjac,
                        u.Materijal.JedinicaMere,
                        u.Materijal.Sertifikat,
                        u.Materijal.TipMaterijala
                       
             );

                    ProjekatBasic projekat = new ProjekatBasic(
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

                    OpremaBasic oprema = new OpremaBasic(
                        u.Oprema.Id,
                        u.Oprema.Naziv,
                        u.Oprema.Tip,
                        u.Oprema.DatumUvoza,
                        u.Oprema.Proizvodjac,
                        u.Oprema.DatumNabavke,
                        u.Oprema.RasponOdrzavanja,
                        u.Oprema.Lokacija,
                        u.Oprema.Status
                    );

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

                foreach(BezbednosniIncident i in  sviIncidenti)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return incidenti;
        }

        #endregion
    }
}
