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

        public static async Task<Result<BezbednosnaObukaView, ErrorMessage>>VratiBezbednosnuObukuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                BezbednosnaObuka? obuka =
                    await s.QueryOver<BezbednosnaObuka>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (obuka == null)
                    return "Bezbednosna obuka ne postoji.".ToError(404);

                return new BezbednosnaObukaView(obuka);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobijanja bezbednosne obuke.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<BezbednosnaObukaView, ErrorMessage>>DodajBezbednosnuObukuAsync(BezbednosnaObukaView b)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                FizickoLice? fizickoLice =
                    await s.QueryOver<FizickoLice>()
                    .Where(x => x.Id == b.FizickoLiceId)
                    .SingleOrDefaultAsync();

                if (fizickoLice == null)
                    return "Fizicko lice ne postoji.".ToError(404);

                BezbednosnaObuka obuka = new BezbednosnaObuka
                {
                    FizickoLice = fizickoLice,
                    NazivObuke = b.NazivObuke,
                    Datum = b.Datum
                };

                await s.SaveOrUpdateAsync(obuka);
                await s.FlushAsync();

                return new BezbednosnaObukaView(obuka);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanja bezbednosne obuke.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<BezbednosnaObukaView, ErrorMessage>>IzmeniBezbednosnuObukuAsync(BezbednosnaObukaView b)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                BezbednosnaObuka? obuka =
                    await s.QueryOver<BezbednosnaObuka>()
                    .Where(x => x.Id == b.Id)
                    .SingleOrDefaultAsync();

                if (obuka == null)
                    return "Bezbednosna obuka ne postoji.".ToError(404);

                FizickoLice? fizickoLice =
                    await s.QueryOver<FizickoLice>()
                    .Where(x => x.Id == b.FizickoLiceId)
                    .SingleOrDefaultAsync();

                if (fizickoLice == null)
                    return "Fizicko lice ne postoji.".ToError(404);

                obuka.FizickoLice = fizickoLice;
                obuka.NazivObuke = b.NazivObuke;
                obuka.Datum = b.Datum;

                await s.UpdateAsync(obuka);
                await s.FlushAsync();

                return new BezbednosnaObukaView(obuka);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene bezbednosne obuke.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>>ObrisiBezbednosnuObukuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                BezbednosnaObuka? obuka =
                    await s.QueryOver<BezbednosnaObuka>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (obuka == null)
                    return "Bezbednosna obuka ne postoji.".ToError(404);

                await s.DeleteAsync(obuka);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja bezbednosne obuke.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

    }
}
