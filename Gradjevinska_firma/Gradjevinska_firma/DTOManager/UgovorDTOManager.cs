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
    public class UgovorDTOManager
    {
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
                    if (u.Materijal != null)
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
                    if (u.Projekat != null)
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
                MessageBox.Show(ex.HandleError());

            }
            return ugovori;
        }



        public static UgovorBasic vratiUgovor(int id)
        {
            UgovorBasic ugovor = null;

            try
            {
                ISession s = DataLayer.GetSession();

                Ugovor u = s.Load<Ugovor>(id);

                MaterijalBasic materijal = null;

                if (u.Materijal != null)
                {
                    materijal = new MaterijalBasic();

                    materijal.ID = u.Materijal.ID;
                    materijal.Naziv = u.Materijal.Naziv;
                }

                ProjekatBasic projekat = null;

                if (u.Projekat != null)
                {
                    projekat = new ProjekatBasic();

                    projekat.ID = u.Projekat.ID;
                    projekat.Naziv = u.Projekat.Naziv;
                }

                OpremaBasic oprema = null;

                if (u.Oprema != null)
                {
                    oprema = new OpremaBasic();

                    oprema.Id = u.Oprema.Id;
                    oprema.Naziv = u.Oprema.Naziv;
                }

                ugovor = new UgovorBasic(
                    u.Id, u.DatumPotpisivanja, u.Vrednost, u.PredmetUgovora, u.Valuta, u.Rok, materijal, projekat, oprema
                );

                ugovor.UgovorneStrane = ImaUgovorneStraneDTOManager.vratiUgovorneStrane(id);
                ugovor.PosebneKlauzule = PosebnaKlauzulaDTOManager.vratiPosebneKlauzule(id);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return ugovor;
        }

        public static List<UgovorPregled> vratiSveUgovore()
        {
            List<UgovorPregled> ugovori = new List<UgovorPregled>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Ugovor> sviUgovori =
                    from u in s.Query<Ugovor>()
                    select u;

                foreach (Ugovor u in sviUgovori)
                {
                    MaterijalPregled materijal = null;

                    if (u.Materijal != null)
                    {
                        materijal = new MaterijalPregled();

                        materijal.ID = u.Materijal.ID;
                        materijal.Naziv = u.Materijal.Naziv;
                    }

                    ProjekatPregled projekat = null;

                    if (u.Projekat != null)
                    {
                        projekat = new ProjekatPregled();

                        projekat.ID = u.Projekat.ID;
                        projekat.Naziv = u.Projekat.Naziv;
                    }

                    OpremaPregled oprema = null;

                    if (u.Oprema != null)
                    {
                        oprema = new OpremaPregled();

                        oprema.Id = u.Oprema.Id;
                        oprema.Naziv = u.Oprema.Naziv;
                    }

                    ugovori.Add(new UgovorPregled(
                            u.Id, u.DatumPotpisivanja, u.Vrednost, u.PredmetUgovora, u.Valuta, u.Rok, materijal, projekat, oprema
                        )

                    );

                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return ugovori;
        }

        public static void dodajUgovor(UgovorBasic u)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ugovor ugovor = new Ugovor();

                ugovor.DatumPotpisivanja = u.DatumPotpisivanja;
                ugovor.Vrednost = u.Vrednost;
                ugovor.PredmetUgovora = u.PredmetUgovora;
                ugovor.Valuta = u.Valuta;
                ugovor.Rok = u.Rok;




                if (u.Materijal != null)
                {
                    ugovor.Materijal = s.Load<Materijal>(u.Materijal.ID);
                }

                if (u.Projekat != null)
                {
                    ugovor.Projekat = s.Load<Projekat>(u.Projekat.ID);
                }

                if (u.Oprema != null)
                {
                    ugovor.Oprema = s.Load<Oprema>(u.Oprema.Id);
                }

                s.Save(ugovor);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniUgovor(UgovorBasic u)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ugovor ugovor = s.Load<Ugovor>(u.Id);

                ugovor.DatumPotpisivanja = u.DatumPotpisivanja;
                ugovor.Vrednost = u.Vrednost;
                ugovor.PredmetUgovora = u.PredmetUgovora;
                ugovor.Valuta = u.Valuta;
                ugovor.Rok = u.Rok;

                if (u.Materijal != null)
                {
                    ugovor.Materijal = s.Load<Materijal>(u.Materijal.ID);
                }
                else
                {
                    ugovor.Materijal = null;
                }

                if (u.Projekat != null)
                {
                    ugovor.Projekat = s.Load<Projekat>(u.Projekat.ID);
                }
                else
                {
                    ugovor.Projekat = null;
                }

                if (u.Oprema != null)
                {
                    ugovor.Oprema = s.Load<Oprema>(u.Oprema.Id);
                }
                else
                {
                    ugovor.Oprema = null;
                }

                s.Update(ugovor);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiUgovor(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ugovor ugovor = s.Load<Ugovor>(id);

                s.Delete(ugovor);
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
