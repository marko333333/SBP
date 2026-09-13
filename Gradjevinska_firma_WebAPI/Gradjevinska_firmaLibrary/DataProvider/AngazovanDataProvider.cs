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
    public static class AngazovanDataProvider
    {
        public static async Task<Result<List<AngazovanView>, ErrorMessage>> VratiSveAngazovaneAsync()
        {
            List<AngazovanView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Angazovan>()
                    .ListAsync())
                    .Select(a => new AngazovanView(a))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja angazovanja.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<AngazovanView>, ErrorMessage>> VratiAngazovanjaOsobeAsync(int idOsobe)
        {
            List<AngazovanView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Angazovan>()
                    .Where(a => a.Osoba.Id == idOsobe)
                    .ListAsync())
                    .Select(a => new AngazovanView(a))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Osoba nema angazovanja.".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja angazovanja osobe.".ToError(400);
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
