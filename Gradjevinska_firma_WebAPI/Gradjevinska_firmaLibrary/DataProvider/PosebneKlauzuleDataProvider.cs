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
    public static class PosebneKlauzuleDataProvider
    {
        public static async Task<Result<List<PosebnaKlauzulaView>, ErrorMessage>> VratiPosebneKlauzuleUgovoraAsync(int idUgovor)
        {
            List<PosebnaKlauzulaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<PosebnaKlauzula>()
                    .Where(k => k.Ugovor.Id == idUgovor)
                    .ListAsync())
                    .Select(k => new PosebnaKlauzulaView(k))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Ugovor nema posebne klauzule".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja posebnih klauzula ugovora".ToError(400);
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
