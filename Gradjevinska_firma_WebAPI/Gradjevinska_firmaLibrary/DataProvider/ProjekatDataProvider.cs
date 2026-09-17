using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firmaLibrary.Data;
using Gradjevinska_firmaLibrary.DTOs;
using Gradjevinska_firmaLibrary.Entiteti;
using NHibernate;

namespace Gradjevinska_firmaLibrary.DataProvider
{
    public static class ProjekatDataProvider
    {
        #region Projekat
        public static async Task<Result<List<ProjekatView>, ErrorMessage>> vratiSveProjekte()
        {
            List<ProjekatView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Projekat>().ListAsync())
                    .Select(l => new ProjekatView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja projekata".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<ProjekatView, ErrorMessage>> vratiProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Projekat? projekat = await s.QueryOver<Projekat>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                return new ProjekatView(projekat);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Projekat? projekat = await s.QueryOver<Projekat>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                await s.DeleteAsync(projekat);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
        #endregion

        #region Stambeni

        public static async Task<Result<List<StambeniView>, ErrorMessage>> vratiSveStambene()
        {
            List<StambeniView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Stambeni>().ListAsync())
                    .Select(l => new StambeniView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja stambenih projekata".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<StambeniView, ErrorMessage>> vratiStambeniProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Stambeni? projekat = await s.QueryOver<Stambeni>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                return new StambeniView(projekat);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja stambenog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<StambeniView, ErrorMessage>> DodajStambeniProjekatAsync(StambeniView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Stambeni stan = new Stambeni
                {
                    Naziv = f.Naziv,
                    Opis = f.Opis,
                    Lokacija = f.Lokacija,
                    Datum_pocetka = f.Datum_pocetka,
                    Budzet = f.Budzet,
                    Status = f.Status,
                    Planirani_Zavrsetak = f.Planirani_Zavrsetak,
                    Stvarni_Zavrsetak = f.Stvarni_Zavrsetak


                };

                await s.SaveOrUpdateAsync(stan);
                await s.FlushAsync();

                return new StambeniView(stan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje stambenog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<StambeniView, ErrorMessage>> izmeniStambeniProjekatAsync(StambeniView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Stambeni? stan = await s.QueryOver<Stambeni>().Where(x => x.ID == f.ID).SingleOrDefaultAsync();
                if (stan == null)
                    return "Nepostojeci projekat".ToError();


                stan.Naziv = f.Naziv;
                stan.Opis = f.Opis;
                stan.Lokacija = f.Lokacija;
                stan.Datum_pocetka = f.Datum_pocetka;
                stan.Budzet = f.Budzet;
                stan.Status = f.Status;
                stan.Planirani_Zavrsetak = f.Planirani_Zavrsetak;
                stan.Stvarni_Zavrsetak = f.Stvarni_Zavrsetak;

                await s.UpdateAsync(stan);
                await s.FlushAsync();

                return new StambeniView(stan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene stambenog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiStambeniProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Stambeni? stan = await s.QueryOver<Stambeni>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (stan == null)
                    return "Stambeni projekat ne postoji.".ToError(404);

                await s.DeleteAsync(stan);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja stambenog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        #endregion

        #region Sanacija

        public static async Task<Result<List<SanacijaView>, ErrorMessage>> vratiSveSanacije()
        {
            List<SanacijaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Sanacija>().ListAsync())
                    .Select(l => new SanacijaView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja sanacija projekata".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<SanacijaView, ErrorMessage>> vratiSanacijuProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Sanacija? projekat = await s.QueryOver<Sanacija>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                return new SanacijaView(projekat);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja sanacije projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<SanacijaView, ErrorMessage>> DodajSanacijaProjekatAsync(SanacijaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Sanacija stan = new Sanacija
                {
                    Naziv = f.Naziv,
                    Opis = f.Opis,
                    Lokacija = f.Lokacija,
                    Datum_pocetka = f.Datum_pocetka,
                    Budzet = f.Budzet,
                    Status = f.Status,
                    Planirani_Zavrsetak = f.Planirani_Zavrsetak,
                    Stvarni_Zavrsetak = f.Stvarni_Zavrsetak


                };

                await s.SaveOrUpdateAsync(stan);
                await s.FlushAsync();

                return new SanacijaView(stan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje stambenog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<SanacijaView, ErrorMessage>> izmeniSanacijaProjekatAsync(SanacijaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Sanacija? stan = await s.QueryOver<Sanacija>().Where(x => x.ID == f.ID).SingleOrDefaultAsync();
                if (stan == null)
                    return "Nepostojeci projekat".ToError();


                stan.Naziv = f.Naziv;
                stan.Opis = f.Opis;
                stan.Lokacija = f.Lokacija;
                stan.Datum_pocetka = f.Datum_pocetka;
                stan.Budzet = f.Budzet;
                stan.Status = f.Status;
                stan.Planirani_Zavrsetak = f.Planirani_Zavrsetak;
                stan.Stvarni_Zavrsetak = f.Stvarni_Zavrsetak;

                await s.UpdateAsync(stan);
                await s.FlushAsync();

                return new SanacijaView(stan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene sanacije projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        #endregion

        #region Rekonstrukcija

        public static async Task<Result<List<RekonstrukcijaView>, ErrorMessage>> vratiSveRekonstrukcije()
        {
            List<RekonstrukcijaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Rekonstrukcija>().ListAsync())
                    .Select(l => new RekonstrukcijaView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja rekonstrukcije projekata".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<RekonstrukcijaView, ErrorMessage>> vratiRekonstrukcijuProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Rekonstrukcija? projekat = await s.QueryOver<Rekonstrukcija>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                return new RekonstrukcijaView(projekat);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja rekonstrukcije projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<RekonstrukcijaView, ErrorMessage>> DodajRekonstrukcijaProjekatAsync(RekonstrukcijaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Rekonstrukcija stan = new Rekonstrukcija
                {
                    Naziv = f.Naziv,
                    Opis = f.Opis,
                    Lokacija = f.Lokacija,
                    Datum_pocetka = f.Datum_pocetka,
                    Budzet = f.Budzet,
                    Status = f.Status,
                    Planirani_Zavrsetak = f.Planirani_Zavrsetak,
                    Stvarni_Zavrsetak = f.Stvarni_Zavrsetak


                };

                await s.SaveOrUpdateAsync(stan);
                await s.FlushAsync();

                return new RekonstrukcijaView(stan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje rekonstrukcije projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<RekonstrukcijaView, ErrorMessage>> izmeniRekonstrukcijuProjekatAsync(RekonstrukcijaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Rekonstrukcija? stan = await s.QueryOver<Rekonstrukcija>().Where(x => x.ID == f.ID).SingleOrDefaultAsync();
                if (stan == null)
                    return "Nepostojeci projekat".ToError();


                stan.Naziv = f.Naziv;
                stan.Opis = f.Opis;
                stan.Lokacija = f.Lokacija;
                stan.Datum_pocetka = f.Datum_pocetka;
                stan.Budzet = f.Budzet;
                stan.Status = f.Status;
                stan.Planirani_Zavrsetak = f.Planirani_Zavrsetak;
                stan.Stvarni_Zavrsetak = f.Stvarni_Zavrsetak;

                await s.UpdateAsync(stan);
                await s.FlushAsync();

                return new RekonstrukcijaView(stan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene rekonstrukcije projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        #endregion

    }
}
