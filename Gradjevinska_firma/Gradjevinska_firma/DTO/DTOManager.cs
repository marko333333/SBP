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

        public static OsobaBasic azurirajOsobu(OsobaBasic o)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Osoba osoba = s.Load<Osoba>(o.Id);
                osoba.Jmbg = o.Jmbg;
                osoba.Ime = o.Ime;
                osoba.Prezime = o.Prezime;
                osoba.DatumRodjenja = o.DatumRodjenja;
                osoba.Struka = o.Struka;

                s.Update(osoba);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return o;
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
            PravnaLicaBasic lice = null;

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

        public static void obrisiKontakt(KontaktBasic k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Kontakt kontakt = s.Load<Kontakt>(k.Id);

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

        public static void obrisiLicencu(LicencaBasic l)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Licenca licenca = s.Load<Licenca>(l.Id);

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

        //brisanje i izmena bezbednosne obuke!!!!!

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

                //ovo mora da se prepravi
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

        public static void obrisiBezbednosnuObuku(BezbednosnaObukaBasic bo)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //ovo mora da se prepravi
                BezbednosnaObuka bezobuka = s.Load<BezbednosnaObuka>(bo.Id);

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

        public static void obrisiLekPregled(LekarskiPregledBasic lp)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LekarskiPregled lekpregled = s.Load<LekarskiPregled>(lp.Id);


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
    }
}
