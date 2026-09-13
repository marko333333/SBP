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
    public static class FotografijaDataProvider
    {
        public static async Task<Result<List<FotografijaView>, ErrorMessage>> VratiSveFotografijeAsync()
        {
            List<FotografijaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Fotografija>().ListAsync())
                    .Select(f => new FotografijaView(f))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja fotografija".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<FotografijaView>, ErrorMessage>> VratiFotografijeNapretkaAsync(int idNapretka)
        {
            List<FotografijaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Fotografija>()
                    .Where(f => f.Napredak.Id == idNapretka)
                    .ListAsync())
                    .Select(f => new FotografijaView(f))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Osoba nema angazovanja.".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja fotografije napretka".ToError(400);
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
