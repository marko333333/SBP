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
    public class KoristiDataProvider
    {
        public static async Task<Result<List<KoristiView>, ErrorMessage>> VratiSveKoristiAsync()
        {
            List<KoristiView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Koristi>().ListAsync())
                    .Select(l => new KoristiView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja koristi".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<KoristiView, ErrorMessage>> vratiKoristiAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Koristi? koristi = await s.QueryOver<Koristi>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (koristi == null)
                    return "Koristi ne postoji.".ToError(404);

                return new KoristiView(koristi);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja koristi.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<KoristiView, ErrorMessage>> DodajKoristiAsync(KoristiView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Materijal? materijal = await s.QueryOver<Materijal>()
                    .Where(x => x.ID == f.MaterijalId)
                    .SingleOrDefaultAsync();
                if (materijal == null)
                    return "Nepostojeci materijal".ToError();

                Zadatak? zadatak = await s.QueryOver<Zadatak>().Where(x => x.Id == f.ZadatakId).SingleOrDefaultAsync();
                if (zadatak == null)
                    return "Nepostojeci zadatak".ToError();

                Koristi koristi = new Koristi
                {
                    Zadatak = zadatak,
                    Materijal = materijal,
                    Kolicina = f.Kolicina
                };

                await s.SaveAsync(koristi);
                await s.FlushAsync();

                return new KoristiView(koristi);
            }
            catch (Exception ex)
            {
                return ex.ToString().ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<KoristiView, ErrorMessage>> izmeniKoristiAsync(KoristiView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Zadatak? zadatak = await s.QueryOver<Zadatak>().Where(x => x.Id == f.ZadatakId).SingleOrDefaultAsync();
                if (zadatak == null)
                    return "Zadatak ne postoji.".ToError();


                Materijal? materijal = await s.QueryOver<Materijal>().Where(x => x.ID == f.MaterijalId).SingleOrDefaultAsync();
                if (zadatak == null)
                    return "Zadatak ne postoji.".ToError();

                Koristi? koristi = await s.QueryOver<Koristi>()
                    .Where(x => x.ID == f.ID)
                    .SingleOrDefaultAsync();

                if (koristi == null)
                    return "Koristi ne postoji.".ToError(404);

                koristi.Zadatak = zadatak;
                koristi.Materijal = materijal;
                koristi.Kolicina = f.Kolicina;


                await s.UpdateAsync(zadatak);
                await s.FlushAsync();

                return new KoristiView(koristi);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene koristi.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiKoristiAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Koristi? koristi = await s.QueryOver<Koristi>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (koristi == null)
                    return "Koristi ne postoji.".ToError(404);

                await s.DeleteAsync(koristi);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja koristi.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<List<KoristiView>, ErrorMessage>> vratiKoristiZadatka(int idZadatka)
        {
            List<KoristiView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Koristi>()
                    .Where(l => l.Zadatak.Id == idZadatka)
                    .ListAsync())
                    .Select(k => new KoristiView(k))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Zadatak nema koristi".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja koristi zadatka".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<KoristiView>, ErrorMessage>> vratiKoristiMaterijala(int idMaterijala)
        {
            List<KoristiView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Koristi>()
                    .Where(l => l.Materijal.ID == idMaterijala)
                    .ListAsync())
                    .Select(k => new KoristiView(k))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Materijal nema koristi".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja koristi materijala".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

    }
}
