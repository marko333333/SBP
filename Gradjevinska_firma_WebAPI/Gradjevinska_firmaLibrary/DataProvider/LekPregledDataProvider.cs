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

        public static async Task<Result<LekPregledView, ErrorMessage>> vratiLekPregledAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                LekarskiPregled? pregled = await s.QueryOver<LekarskiPregled>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (pregled == null)
                    return "Lekarski pregled ne postoji.".ToError(404);

                return new LekPregledView(pregled);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja lekarskog pregleda.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<LekPregledView, ErrorMessage>> DodajLekPregledAsync(LekPregledView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                FizickoLice? lice = await s.QueryOver<FizickoLice>()
                    .Where(x => x.Id == f.FizickoLiceId)
                    .And(x => x.FlagR == true)
                    .SingleOrDefaultAsync();

                if (lice == null)
                    return "Izabrano fizicko lice nije radnik.".ToError(404);

                LekarskiPregled pregled = new LekarskiPregled
                {
                    FizickoLice = lice,
                    Rezultat = f.Rezultat,
                    Datum = f.Datum
                };

                await s.SaveAsync(pregled);
                await s.FlushAsync();

                return new LekPregledView(pregled);
            }
            catch (Exception ex)
            {
                return ex.ToString().ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<LekPregledView, ErrorMessage>> izmeniLekPregledAsync(LekPregledView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                LekarskiPregled? pregled = await s.QueryOver<LekarskiPregled>()
                    .Where(x => x.Id == f.Id)
                    .SingleOrDefaultAsync();

                if (pregled == null)
                    return "Pregled ne postoji.".ToError(404);

                FizickoLice? lice = await s.QueryOver<FizickoLice>()
                    .Where(x => x.Id == f.FizickoLiceId)
                    .And(x => x.FlagR == true)
                    .SingleOrDefaultAsync();

                if (lice == null)
                    return "Izabrano fizicko lice nije radnik.".ToError(404);

                pregled.FizickoLice = lice;
                pregled.Rezultat = f.Rezultat;
                pregled.Datum = f.Datum;
                


                await s.UpdateAsync(pregled);
                await s.FlushAsync();

                return new LekPregledView(pregled);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene lekarskog pregleda.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiLekarskiPregledAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                LekarskiPregled? pregled = await s.QueryOver<LekarskiPregled>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (pregled == null)
                    return "Pregled ne postoji.".ToError(404);

                await s.DeleteAsync(pregled);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja zadatka.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }


    }
}
