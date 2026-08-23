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

                    if (n.Projekat != null)
                    {
                        projekat = new ProjekatPregled();

                        projekat.ID = n.Projekat.ID;
                        projekat.Naziv = n.Projekat.Naziv;
                    }

                    nabavke.Add(new NabavkePregled(
                            n.Br_nabavke,n.Datum,projekat)

                    );

                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

                if (n.Projekat != null)
                {
                    projekat = new ProjekatBasic();

                    projekat.ID = n.Projekat.ID;
                    projekat.Naziv = n.Projekat.Naziv;
                }

                nabavka = new NabavkeBasic(
                   n.Br_nabavke,n.Datum,projekat
                );

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return nabavka;
        }

        public static void dodajNabavku(NabavkeBasic n)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Nabavke nabavka = new Nabavke();

                nabavka.Projekat = s.Load<Projekat>(n.Projekat.ID);

                nabavka.Datum = n.Datum;

                s.Save(nabavka);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

                s.Update(nabavka);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region NabavkaMaterijal

        public static List<NabavkaMaterijalPregled> vratiNabavkeMaterijala(int brNabavke)
        {
            List<NabavkaMaterijalPregled> lista = new List<NabavkaMaterijalPregled>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<NabavkaMaterijal> stavke =
                    from nm in s.Query<NabavkaMaterijal>()
                    where nm.Nabavke.Br_nabavke == brNabavke
                    select nm;

                foreach (NabavkaMaterijal nm in stavke)
                {
                    MaterijalPregled materijal = null;

                    if (nm.Materijal != null)
                    {
                        materijal = new MaterijalPregled(
                            nm.Materijal.ID,
                            nm.Materijal.Naziv,
                            nm.Materijal.Cena,
                            nm.Materijal.Proizvodjac,
                            nm.Materijal.JedinicaMere,
                            nm.Materijal.Sertifikat,
                            nm.Materijal.Tip
                        );
                    }

                    NabavkePregled nabavka = null;

                    if (nm.Nabavke != null)
                    {
                        ProjekatPregled projekat = null;

                        if (nm.Nabavke.Projekat != null)
                        {
                            projekat = new ProjekatPregled();

                            projekat.ID = nm.Nabavke.Projekat.ID;
                            projekat.Naziv = nm.Nabavke.Projekat.Naziv;
                            
                            
                        }

                        nabavka = new NabavkePregled(
                            nm.Nabavke.Br_nabavke,
                            nm.Nabavke.Datum,
                            projekat
                        );
                    }

                    lista.Add(
                        new NabavkaMaterijalPregled(
                            nm.ID,nm.Kolicina,nm.Cena,nm.Status_isporuke,materijal,nabavka
                        )
                    );
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region NabavkaOprema

        public static List<NabavkaOpremaPregled> vratiNabavkeOpreme(int brNabavke)
        {
            List<NabavkaOpremaPregled> lista = new List<NabavkaOpremaPregled>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<NabavkaOprema> stavke =
                    from no in s.Query<NabavkaOprema>()
                    where no.Nabavka.Br_nabavke == brNabavke
                    select no;

                foreach (NabavkaOprema no in stavke)
                {
                    OpremaPregled oprema = null;

                    if (no.Oprema != null)
                    {
                        oprema = new OpremaPregled(
                            no.Oprema.Id,
                            no.Oprema.Naziv,
                            no.Oprema.Tip,
                            no.Oprema.DatumUvoza,
                            no.Oprema.Proizvodjac,
                            no.Oprema.RasponOdrzavanja,
                            no.Oprema.Lokacija,
                            no.Oprema.Status
                        );
                    }

                    NabavkePregled nabavka = null;

                    if (no.Nabavka != null)
                    {
                        ProjekatPregled projekat = null;

                        if (no.Nabavka.Projekat != null)
                        {
                            projekat = new ProjekatPregled();

                            projekat.ID = no.Nabavka.Projekat.ID;
                            projekat.Naziv = no.Nabavka.Projekat.Naziv;
                        }

                        nabavka = new NabavkePregled(
                            no.Nabavka.Br_nabavke,no.Nabavka.Datum,projekat
                        );
                    }

                    lista.Add(
                        new NabavkaOpremaPregled(
                            no.ID,no.Kolicina,no.Cena,no.Status_isporuke,oprema,nabavka
                        )
                    );
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion
    }
}
