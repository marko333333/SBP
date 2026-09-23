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
    public class NabavkeDTOManager
    {
        #region Nabavke

        public static List<NabavkeBasic> vratiNabavkeDobavljaca(int idPravnogLica)
        {
            List<NabavkeBasic> nabavke = new List<NabavkeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Nabavke> sveNabavke =
                    from n in s.Query<Nabavke>()
                    where n.Dobavljac.Id == idPravnogLica
                    select n;

                foreach (Nabavke n in sveNabavke)
                {
                    ProjekatBasic projekat = new ProjekatBasic(n.Projekat.ID, n.Projekat.Naziv, n.Projekat.Opis, n.Projekat.Lokacija,
                        n.Projekat.Datum_pocetka, n.Projekat.Budzet, n.Projekat.Status, n.Projekat.Planirani_Zavrsetak, n.Projekat.Stvarni_Zavrsetak);

                    nabavke.Add(new NabavkeBasic(n.Br_nabavke, n.Datum, projekat, null));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return nabavke;
        }

        public static List<NabavkePregled> vratiSveNabavke()
        {
            List<NabavkePregled> nabavke = new List<NabavkePregled>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Nabavke> sveNabavke =
                    from n in s.Query<Nabavke>()
                    select n;

                foreach (Nabavke n in sveNabavke)
                {

                    ProjekatPregled projekat = null;
                    PravnaLicaPregled dobavljac = null;

                    if (n.Dobavljac != null)
                    {
                        dobavljac = new PravnaLicaPregled(n.Dobavljac.Id, n.Dobavljac.Jmbg, n.Dobavljac.Ime, n.Dobavljac.Prezime,
                            n.Dobavljac.DatumRodjenja, n.Dobavljac.Struka, n.Dobavljac.FlagPB, n.Dobavljac.FlagInve, n.Dobavljac.FlagIzv, n.Dobavljac.FlagP,
                            n.Dobavljac.FlagD, n.Dobavljac.FlagN);
                    }

                    if (n.Projekat != null)
                    {
                        projekat = new ProjekatPregled();

                        projekat.ID = n.Projekat.ID;
                        projekat.Naziv = n.Projekat.Naziv;
                    }

                    nabavke.Add(new NabavkePregled(
                            n.Br_nabavke,n.Datum,projekat, dobavljac)

                    );

                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return nabavke;
        }

        public static NabavkeBasic vratiNabavku(int id)
        {
            NabavkeBasic nabavka = null;

            try
            {
                ISession s = DataLayer.GetSession();

                Nabavke n = s.Load<Nabavke>(id);

                ProjekatBasic projekat = null;
                PravnaLicaBasic dobavljac = null;

                if (n.Projekat != null)
                {
                    projekat = new ProjekatBasic();

                    projekat.ID = n.Projekat.ID;
                    projekat.Naziv = n.Projekat.Naziv;
                }

                if(n.Dobavljac != null)
                {
                    dobavljac = new PravnaLicaBasic(n.Dobavljac.Id, n.Dobavljac.Jmbg, n.Dobavljac.Ime, n.Dobavljac.Prezime,
                            n.Dobavljac.DatumRodjenja, n.Dobavljac.Struka, n.Dobavljac.FlagPB, n.Dobavljac.FlagInve, n.Dobavljac.FlagIzv, n.Dobavljac.FlagP,
                            n.Dobavljac.FlagD, n.Dobavljac.FlagN);
                }

                nabavka = new NabavkeBasic(
                   n.Br_nabavke,n.Datum,projekat, dobavljac
                );

                nabavka.NabavkaOprema = vratiNabavkeOpreme(id);
                nabavka.NabavkaMaterijal = vratiNabavkeMaterijala(id);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return nabavka;
        }

        public static void dodajNabavku(NabavkeBasic n)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Nabavke nabavka = new Nabavke();

                Projekat projekat = s.Get<Projekat>(n.Projekat.ID);
                if (projekat == null) { MessageBox.Show("Projekat ne postoji."); return; }

                PravnaLica dobavljac = null;
                if (n.Dobavljac != null)
                {
                    dobavljac = s.Get<PravnaLica>(n.Dobavljac.Id);
                    if (dobavljac == null) { MessageBox.Show("Dobavljac ne postoji."); return; }
                }

                nabavka.Datum = n.Datum;
                nabavka.Projekat = projekat;
                nabavka.Dobavljac = dobavljac;

                s.Save(nabavka);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniNabavku(NabavkeBasic n)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Nabavke nabavka = s.Load<Nabavke>(n.Br_nabavke);

                nabavka.Datum = n.Datum;

                if (n.Projekat != null)
                {
                    Projekat projekat = s.Load<Projekat>(n.Projekat.ID);
                    nabavka.Projekat = projekat;
                }
                else
                {
                    nabavka.Projekat = null;
                }
                if(n.Dobavljac != null)
                {
                    nabavka.Dobavljac = s.Load<PravnaLica>(n.Dobavljac.Id);
                }

                s.Update(nabavka);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiNabavku(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Nabavke nabavka = s.Load<Nabavke>(id);

                s.Delete(nabavka);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static List<NabavkeBasic> vratiNabavkeProjekta(int idProjekta)
        {
            List<NabavkeBasic> nabavke = new List<NabavkeBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Nabavke> sveNabavke =
                    from n in s.Query<Nabavke>()
                    where n.Projekat.ID == idProjekta
                    select n;

                foreach (Nabavke n in sveNabavke)
                {
                    ProjekatBasic projekat = null;
                    if (n.Projekat != null)
                    {
                        projekat = new ProjekatBasic(
                            n.Projekat.ID,
                            n.Projekat.Naziv,
                            n.Projekat.Opis,
                            n.Projekat.Lokacija,
                            n.Projekat.Datum_pocetka,
                            n.Projekat.Budzet,
                            n.Projekat.Status,
                            n.Projekat.Planirani_Zavrsetak,
                            n.Projekat.Stvarni_Zavrsetak
                        );

                    }
                    PravnaLicaBasic dobavljac = null;
                    if(n.Dobavljac != null)
                    {
                        dobavljac = new PravnaLicaBasic(n.Dobavljac.Id, n.Dobavljac.Jmbg, n.Dobavljac.Ime, n.Dobavljac.Prezime,
                            n.Dobavljac.DatumRodjenja, n.Dobavljac.Struka, n.Dobavljac.FlagPB, n.Dobavljac.FlagInve, n.Dobavljac.FlagIzv, n.Dobavljac.FlagP,
                            n.Dobavljac.FlagD, n.Dobavljac.FlagN);
                    }

                    nabavke.Add(new NabavkeBasic(
                        n.Br_nabavke,
                        n.Datum,
                        projekat,
                        dobavljac
                    ));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return nabavke;
        }

        #endregion

        #region NabavkaMaterijal

        public static List<NabavkaMaterijalBasic> vratiNabavkeMaterijala(int brNabavke)
        {
            List<NabavkaMaterijalBasic> lista = new List<NabavkaMaterijalBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<NabavkaMaterijal> stavke =
                    from nm in s.Query<NabavkaMaterijal>()
                    where nm.Nabavke.Br_nabavke == brNabavke
                    select nm;

                foreach (NabavkaMaterijal nm in stavke)
                {
                    MaterijalBasic materijal = null;

                    if (nm.Materijal != null)
                    {
                        materijal = new MaterijalBasic();

                        materijal.ID = nm.Materijal.ID;
                        materijal.Naziv = nm.Materijal.Naziv;
                    }

                    NabavkaMaterijalBasic stavka = new NabavkaMaterijalBasic(
                        nm.ID,nm.Kolicina,nm.Cena,nm.Status_isporuke,materijal,null
                    );

                    lista.Add(stavka);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return lista;
        }

        public static NabavkaMaterijalBasic vratiNabavkuMaterijala(int id)
        {
            NabavkaMaterijalBasic nabavkaMaterijal = null;

            try
            {
                ISession s = DataLayer.GetSession();

                NabavkaMaterijal nm = s.Load<NabavkaMaterijal>(id);

                MaterijalBasic materijal = null;
                NabavkeBasic nabavka = null;

                if (nm.Materijal != null)
                {
                    materijal = new MaterijalBasic();
                    materijal.ID = nm.Materijal.ID;
                    materijal.Naziv = nm.Materijal.Naziv;
                }

                if (nm.Nabavke != null)
                {
                    nabavka = new NabavkeBasic();
                    nabavka.Br_nabavke = nm.Nabavke.Br_nabavke;
                    nabavka.Datum = nm.Nabavke.Datum;
                }

                nabavkaMaterijal = new NabavkaMaterijalBasic(
                    nm.ID,nm.Kolicina,nm.Cena,nm.Status_isporuke,materijal,nabavka
                );

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return nabavkaMaterijal;
        }

        public static void dodajNabavkaMaterijal(NabavkaMaterijalBasic nm)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Materijal materijal = s.Load<Materijal>(nm.Materijal.ID);

                Nabavke nabavka = s.Load<Nabavke>(nm.Nabavke.Br_nabavke);

                NabavkaMaterijal novaStavka = new NabavkaMaterijal();

                novaStavka.Kolicina = nm.Kolicina;
                novaStavka.Cena = nm.Cena;
                novaStavka.Status_isporuke = nm.Status_isporuke;
                novaStavka.Materijal = materijal;
                novaStavka.Nabavke = nabavka;

                s.Save(novaStavka);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniNabavkaMaterijal(NabavkaMaterijalBasic nm)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                NabavkaMaterijal stavka = s.Load<NabavkaMaterijal>(nm.ID);

                stavka.Kolicina = nm.Kolicina;
                stavka.Cena = nm.Cena;
                stavka.Status_isporuke = nm.Status_isporuke;

                if (nm.Materijal != null)
                {
                    Materijal materijal = s.Load<Materijal>(nm.Materijal.ID);

                    stavka.Materijal = materijal;
                }

                s.Update(stavka);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiNabavkaMaterijal(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                NabavkaMaterijal nm = s.Load<NabavkaMaterijal>(id);

                s.Delete(nm);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        #endregion

        #region NabavkaOprema

        public static List<NabavkaOpremaBasic> vratiNabavkeOpreme(int brNabavke)
        {
            List<NabavkaOpremaBasic> lista = new List<NabavkaOpremaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<NabavkaOprema> stavke =
                    from no in s.Query<NabavkaOprema>()
                    where no.Nabavka.Br_nabavke == brNabavke
                    select no;

                foreach (NabavkaOprema no in stavke)
                {
                    OpremaBasic oprema = null;

                    if (no.Oprema != null)
                    {
                        oprema = new OpremaBasic();

                        oprema.Id = no.Oprema.Id;
                        oprema.Naziv = no.Oprema.Naziv;
                    }

                    NabavkaOpremaBasic stavka = new NabavkaOpremaBasic(
                        no.ID,no.Kolicina,no.Cena,no.Status_isporuke,oprema,null
                    );

                    lista.Add(stavka);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return lista;
        }

        public static NabavkaOpremaBasic vratiNabavkuOpremu(int id)
        {
            NabavkaOpremaBasic nabavkaOprema = null;

            try
            {
                ISession s = DataLayer.GetSession();

                NabavkaOprema no = s.Load<NabavkaOprema>(id);

                OpremaBasic oprema = null;
                NabavkeBasic nabavka = null;

                if (no.Oprema != null)
                {
                    oprema = new OpremaBasic();

                    oprema.Id = no.Oprema.Id;
                    oprema.Naziv = no.Oprema.Naziv;
                }

                if (no.Nabavka != null)
                {
                    nabavka = new NabavkeBasic();

                    nabavka.Br_nabavke = no.Nabavka.Br_nabavke;

                    nabavka.Datum = no.Nabavka.Datum;
                }

                nabavkaOprema = new NabavkaOpremaBasic(
                    no.ID, no.Kolicina, no.Cena, no.Status_isporuke, oprema, nabavka
                );

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return nabavkaOprema;
        }

        public static void dodajNabavkaOprema(NabavkaOpremaBasic no)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Oprema oprema = s.Load<Oprema>(no.Oprema.Id);

                Nabavke nabavka = s.Load<Nabavke>(no.Nabavka.Br_nabavke);

                NabavkaOprema novaStavka = new NabavkaOprema();

                novaStavka.Kolicina = no.Kolicina;
                novaStavka.Cena = no.Cena;
                novaStavka.Status_isporuke =
                    no.Status_isporuke;

                novaStavka.Oprema = oprema;
                novaStavka.Nabavka = nabavka;

                s.Save(novaStavka);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniNabavkaOprema(NabavkaOpremaBasic no)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                NabavkaOprema stavka = s.Load<NabavkaOprema>(no.ID);

                stavka.Kolicina = no.Kolicina;
                stavka.Cena = no.Cena;
                stavka.Status_isporuke = no.Status_isporuke;

                if (no.Oprema != null)
                {
                    Oprema oprema = s.Load<Oprema>(no.Oprema.Id);

                    stavka.Oprema = oprema;
                }

                s.Update(stavka);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiNabavkaOprema(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                NabavkaOprema no = s.Load<NabavkaOprema>(id);

                s.Delete(no);
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
