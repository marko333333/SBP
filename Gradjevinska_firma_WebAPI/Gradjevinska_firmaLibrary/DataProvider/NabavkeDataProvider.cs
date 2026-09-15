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
    public static class NabavkeDataProvider
    {
        public static async Task<Result<List<NabavkeView>, ErrorMessage>> VratiNabavkeProjektaAsync(int idProjekta)
        {
            List<NabavkeView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Nabavke>()
                    .Where(k => k.Projekat.ID == idProjekta)
                    .ListAsync())
                    .Select(k => new NabavkeView(k))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Projekat nema nabavke".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja nabavka projekta".ToError(400);
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
