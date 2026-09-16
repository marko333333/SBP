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
    public static class ZastitnaOpremaDataProvider
    {
        public static async Task<Result<List<ZastitnaOpremaView>, ErrorMessage>> VratiSvuZastitnuOpremuAsync()
        {
            List<ZastitnaOpremaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<ZastitnaOprema>().ListAsync())
                    .Select(l => new ZastitnaOpremaView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja zastitnih oprema".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<ZastitnaOpremaView>, ErrorMessage>> VratiZastitneOpremeFizickogLicaAsync(int idFizicko)
        {
            List<ZastitnaOpremaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<ZastitnaOprema>()
                    .Where(l => l.FizickoLice.Id == idFizicko)
                    .ListAsync())
                    .Select(l => new ZastitnaOpremaView(l))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Osoba nema zastitnu opremu".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja zastitne opreme osobe".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<ZastitnaOpremaView, ErrorMessage>> vratiZastitnuOpremuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                ZastitnaOprema? oprema = await s.QueryOver<ZastitnaOprema>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (oprema == null)
                    return "Zastitna oprema ne postoji.".ToError(404);

                return new ZastitnaOpremaView(oprema);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja zastitne opreme.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<ZastitnaOpremaView, ErrorMessage>> DodajZastitnuOpremuAsync(ZastitnaOpremaView f)
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
                    .SingleOrDefaultAsync();

                ZastitnaOprema oprema = new ZastitnaOprema
                {
                    FizickoLice = lice,
                    NazivOpreme = f.NazivOpreme
                };

                await s.SaveOrUpdateAsync(oprema);
                await s.FlushAsync();

                return new ZastitnaOpremaView(oprema);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje zastitne opreme.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<ZastitnaOpremaView, ErrorMessage>> izmeniZastitnuOpremuAsync(ZastitnaOpremaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                ZastitnaOprema? oprema = await s.QueryOver<ZastitnaOprema>().Where(x => x.Id == f.Id).SingleOrDefaultAsync();
                if (oprema == null)
                    return "Zastitna oprema ne postoji.".ToError();

                FizickoLice? lice = await s.QueryOver<FizickoLice>()
                    .Where(x => x.Id == f.FizickoLiceId)
                    .SingleOrDefaultAsync();

                if (lice == null)
                    return "Fizicko lice ne postoji.".ToError(404);

                //oprema.Id = f.Id;
                oprema.FizickoLice = lice;
                oprema.NazivOpreme = f.NazivOpreme;


                await s.UpdateAsync(oprema);
                await s.FlushAsync();

                return new ZastitnaOpremaView(oprema);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene zastitne opreme.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> ObrisiZastitnuOpremuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                ZastitnaOprema? oprema = await s.QueryOver<ZastitnaOprema>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (oprema == null)
                    return "Zastitna oprema ne postoji.".ToError(404);

                await s.DeleteAsync(oprema);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja zastitne opreme.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

    }
}
