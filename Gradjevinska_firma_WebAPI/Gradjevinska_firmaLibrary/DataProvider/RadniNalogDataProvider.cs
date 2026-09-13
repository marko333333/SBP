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
    public static class RadniNalogDataProvider
    {
        public static async Task<Result<List<RadniNalogView>, ErrorMessage>> VratiRadneNalogeZadatkaAsync(int idZadatka)
        {
            List<RadniNalogView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<RadniNalog>()
                    .Where(k => k.Zadatak.Id == idZadatka)
                    .ListAsync())
                    .Select(k => new RadniNalogView(k))
                    .ToList();

            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja radnih naloga zadatka".ToError(400);
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
