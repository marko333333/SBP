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
    }
}
