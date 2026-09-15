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
    public static class LekPregledDataProvider
    {
        public static async Task<Result<List<LekPregledView>, ErrorMessage>> VratiSveLekPregledeAsync()
        {
            List<LekPregledView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<LekarskiPregled>().ListAsync())
                    .Select(l => new LekPregledView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja lekarski pregleda".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<LekPregledView>, ErrorMessage>> VratiLekPregledFizickogLicaAsync(int idFizicko)
        {
            List<LekPregledView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<LekarskiPregled>()
                    .Where(l => l.FizickoLice.Id == idFizicko)
                    .ListAsync())
                    .Select(l => new LekPregledView(l))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Fizicko lice nema lekarske preglede".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja lekarski pregleda osobe".ToError(400);
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
