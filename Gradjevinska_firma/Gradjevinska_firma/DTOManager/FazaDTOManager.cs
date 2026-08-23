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
    public class FazaDTOManager
    {
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
                        f.Id, f.Naziv, f.DatumOd, f.DatumDo, f.Status, f.Budzet, projekat, fizickoLice, nadFaza
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
                    if (f.FizickoLice != null)
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
                    if (f.NadFaza != null)
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

        public static void dodajFazu(FazaBasic f)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Faza nadFaza = s.Load<Faza>(f.NadFaza.Id);

                FizickoLice fizickoLice = s.Load<FizickoLice>(f.FizickoLice.Id);

                Projekat projekat = s.Load<Projekat>(f.Projekat.ID);

                Faza faza = new Faza();

                faza.Naziv = f.Naziv;
                faza.DatumDo = f.DatumDo;
                faza.Status = f.Status;
                faza.DatumOd = f.DatumOd;
                faza.Budzet = f.Budzet;
                faza.Projekat = projekat;
                faza.FizickoLice = fizickoLice;
                faza.NadFaza = nadFaza;


                s.Save(faza);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void obrisiFazu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Faza faza = s.Get<Faza>(id);
                if (faza == null)
                {
                    MessageBox.Show("Faza ne postoji.");
                    return;
                }

                s.Delete(faza);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniFazu(FazaBasic f)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Faza faza = s.Get<Faza>(f.Id);
                if (faza == null)
                {
                    MessageBox.Show("Faza ne postoji.");
                    return;
                }

                Faza nadFaza = s.Load<Faza>(f.NadFaza.Id);

                FizickoLice fizickoLice = s.Load<FizickoLice>(f.FizickoLice.Id);

                Projekat projekat = s.Load<Projekat>(f.Projekat.ID);

                faza.Naziv = f.Naziv;
                faza.DatumDo = f.DatumDo;
                faza.Status = f.Status;
                faza.DatumOd = f.DatumOd;
                faza.Budzet = f.Budzet;
                faza.Projekat = projekat;
                faza.FizickoLice = fizickoLice;
                faza.NadFaza = nadFaza;


                s.Update(faza);
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
