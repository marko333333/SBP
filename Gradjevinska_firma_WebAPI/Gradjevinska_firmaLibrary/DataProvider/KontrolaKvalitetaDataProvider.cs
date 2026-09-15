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
    public static class KontrolaKvalitetaDataProvider
    {
        public static async Task<Result<List<KontrolaKvalitetaView>, ErrorMessage>> VratiKontroleKvalitetaZadatkaAsync(int idZadatak)
        {
            List<KontrolaKvalitetaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<KontrolaKvaliteta>()
                    .Where(k => k.Zadatak.Id == idZadatak)
                    .ListAsync())
                    .Select(k => new KontrolaKvalitetaView(k))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Zadatak nema kontrolu kvaliteta".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja kontrole kvaliteta zadatka".ToError(400);
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
