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
    public class MaterijalDTOManager
    {
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
                            m.ID, m.Naziv, m.Cena, m.Proizvodjac, m.JedinicaMere, m.Sertifikat, tip
                        ));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                      m.ID, m.Naziv, m.Cena, m.Proizvodjac, m.JedinicaMere, m.Sertifikat, m.Tip));
                }
                s.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

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
                MessageBox.Show(ex.HandleError());

            }
        }

        #endregion

        #endregion
    }
}
