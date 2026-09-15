using Gradjevinska_firmaLibrary.Data;
using Gradjevinska_firmaLibrary.DTOs;
using Gradjevinska_firmaLibrary.Entiteti;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DataProvider
{
    public static class ImaUgovornuStranuDataProvider
    {
        public static async Task<Result<List<ImaUgovornuStranuView>, ErrorMessage>>VratiSveUgovorneStraneAsync()
        {
            List<ImaUgovornuStranuView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<ImaUgovornuStranu>()
                    .ListAsync())
                    .Select(s => new ImaUgovornuStranuView(s))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja ugovornih strana.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<ImaUgovornuStranuView>, ErrorMessage>>VratiUgovorneStraneOsobeAsync(int idOsobe)
        {
            List<ImaUgovornuStranuView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<ImaUgovornuStranu>()
                    .Where(x => x.Osoba.Id == idOsobe)
                    .ListAsync())
                    .Select(x => new ImaUgovornuStranuView(x))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Osoba nema ugovorne strane.".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja ugovornih strana osobe.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<ImaUgovornuStranuView>, ErrorMessage>>VratiUgovorneStraneUgovoraAsync(int idUgovora)
        {
            List<ImaUgovornuStranuView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<ImaUgovornuStranu>()
                    .Where(x => x.Ugovor.Id == idUgovora)
                    .ListAsync())
                    .Select(x => new ImaUgovornuStranuView(x))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Ugovor nema ugovorne strane.".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja ugovornih strana ugovora.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<ImaUgovornuStranuView, ErrorMessage>>DodajUgovornuStranuAsync(ImaUgovornuStranuView sView)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Osoba? osoba = await s.QueryOver<Osoba>()
                    .Where(x => x.Id == sView.OsobaId)
                    .SingleOrDefaultAsync();

                if (osoba == null)
                    return "Osoba ne postoji.".ToError(404);

                Ugovor? ugovor = await s.QueryOver<Ugovor>()
                    .Where(x => x.Id == sView.UgovorId)
                    .SingleOrDefaultAsync();

                if (ugovor == null)
                    return "Ugovor ne postoji.".ToError(404);

                ImaUgovornuStranu strana = new ImaUgovornuStranu
                {
                    Osoba = osoba,
                    Ugovor = ugovor,
                    Uloga = sView.Uloga
                };

                await s.SaveOrUpdateAsync(strana);
                await s.FlushAsync();

                return new ImaUgovornuStranuView(strana);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanja ugovorne strane.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<ImaUgovornuStranuView, ErrorMessage>>VratiUgovornuStranuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                ImaUgovornuStranu? strana =
                    await s.QueryOver<ImaUgovornuStranu>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (strana == null)
                    return "Ugovorna strana ne postoji.".ToError(404);

                return new ImaUgovornuStranuView(strana);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobijanja ugovorne strane.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<ImaUgovornuStranuView, ErrorMessage>>IzmeniUgovornuStranuAsync(ImaUgovornuStranuView sView)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                ImaUgovornuStranu? strana =
                    await s.QueryOver<ImaUgovornuStranu>()
                    .Where(x => x.Id == sView.Id)
                    .SingleOrDefaultAsync();

                if (strana == null)
                    return "Ugovorna strana ne postoji.".ToError(404);

                Osoba? osoba = await s.QueryOver<Osoba>()
                    .Where(x => x.Id == sView.OsobaId)
                    .SingleOrDefaultAsync();

                if (osoba == null)
                    return "Osoba ne postoji.".ToError(404);

                Ugovor? ugovor = await s.QueryOver<Ugovor>()
                    .Where(x => x.Id == sView.UgovorId)
                    .SingleOrDefaultAsync();

                if (ugovor == null)
                    return "Ugovor ne postoji.".ToError(404);

                strana.Osoba = osoba;
                strana.Ugovor = ugovor;
                strana.Uloga = sView.Uloga;

                await s.UpdateAsync(strana);
                await s.FlushAsync();

                return new ImaUgovornuStranuView(strana);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene ugovorne strane.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>>ObrisiUgovornuStranuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                ImaUgovornuStranu? strana =
                    await s.QueryOver<ImaUgovornuStranu>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (strana == null)
                    return "Ugovorna strana ne postoji.".ToError(404);

                await s.DeleteAsync(strana);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja ugovorne strane.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
    }
}
