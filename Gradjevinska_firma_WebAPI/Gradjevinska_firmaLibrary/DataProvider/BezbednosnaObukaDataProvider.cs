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
    public static class BezbednosnaObukaDataProvider
    {
        public static async Task<Result<List<BezbednosnaObukaView>, ErrorMessage>> VratiSveBezbednosneObukeAsync()
        {
            List<BezbednosnaObukaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<BezbednosnaObuka>().ListAsync())
                    .Select(l => new BezbednosnaObukaView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja bezbednosnih obuka".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<BezbednosnaObukaView>, ErrorMessage>> VratiBezObukuFizickogLicaAsync(int idFizicko)
        {
            List<BezbednosnaObukaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<BezbednosnaObuka>()
                    .Where(l => l.FizickoLice.Id == idFizicko)
                    .ListAsync())
                    .Select(l => new BezbednosnaObukaView(l))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Fizicko lice nema obuku".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja bezbednosnih obuka osobe".ToError(400);
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
