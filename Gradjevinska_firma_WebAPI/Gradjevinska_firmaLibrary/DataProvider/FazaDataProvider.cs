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
    public static class FazaDataProvider
    {
        public static async Task<Result<List<FazaView>, ErrorMessage>> VratiSveFazeAsync()
        {
            List<FazaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Faza>().ListAsync())
                    .Select(f => new FazaView(f))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja faza".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<FazaView, ErrorMessage>>DodajFazuAsync(FazaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Projekat? projekat = await s.QueryOver<Projekat>()
                    .Where(x => x.ID == f.ProjekatId)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                FizickoLice? fizickoLice = await s.QueryOver<FizickoLice>()
                    .Where(x => x.Id == f.FizickoLiceId)
                    .SingleOrDefaultAsync();

                if (fizickoLice == null)
                    return "Fizicko lice ne postoji.".ToError(404);

                Faza? nadFaza = null;

                if (f.NadFazaId.HasValue)
                {
                    nadFaza = await s.QueryOver<Faza>()
                        .Where(x => x.Id == f.NadFazaId.Value)
                        .SingleOrDefaultAsync();

                    if (nadFaza == null)
                        return "Nadfaza ne postoji.".ToError(404);
                }

                Faza faza = new Faza
                {
                    Naziv = f.Naziv,
                    DatumOd = f.DatumOd,
                    DatumDo = f.DatumDo,
                    Status = f.Status,
                    Budzet = f.Budzet,
                    Projekat = projekat,
                    FizickoLice = fizickoLice,
                    NadFaza = nadFaza
                };

                await s.SaveOrUpdateAsync(faza);
                await s.FlushAsync();

                return new FazaView(faza);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanja faze.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<FazaView, ErrorMessage>>VratiFazuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Faza? faza = await s.QueryOver<Faza>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (faza == null)
                    return "Faza ne postoji.".ToError(404);

                return new FazaView(faza);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobijanja faze.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<FazaView, ErrorMessage>>IzmeniFazuAsync(FazaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Faza? faza = await s.QueryOver<Faza>()
                    .Where(x => x.Id == f.Id)
                    .SingleOrDefaultAsync();

                if (faza == null)
                    return "Faza ne postoji.".ToError(404);

                Projekat? projekat = await s.QueryOver<Projekat>()
                    .Where(x => x.ID == f.ProjekatId)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                FizickoLice? fizickoLice = await s.QueryOver<FizickoLice>()
                    .Where(x => x.Id == f.FizickoLiceId)
                    .SingleOrDefaultAsync();

                if (fizickoLice == null)
                    return "Fizicko lice ne postoji.".ToError(404);

                Faza? nadFaza = null;

                if (f.NadFazaId.HasValue)
                {
                    nadFaza = await s.QueryOver<Faza>()
                        .Where(x => x.Id == f.NadFazaId.Value)
                        .SingleOrDefaultAsync();

                    if (nadFaza == null)
                        return "Nadfaza ne postoji.".ToError(404);
                }

                faza.Naziv = f.Naziv;
                faza.DatumOd = f.DatumOd;
                faza.DatumDo = f.DatumDo;
                faza.Status = f.Status;
                faza.Budzet = f.Budzet;
                faza.Projekat = projekat;
                faza.FizickoLice = fizickoLice;
                faza.NadFaza = nadFaza;

                await s.UpdateAsync(faza);
                await s.FlushAsync();

                return new FazaView(faza);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene faze.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>>ObrisiFazuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Faza? faza = await s.QueryOver<Faza>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (faza == null)
                    return "Faza ne postoji.".ToError(404);

                await s.DeleteAsync(faza);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja faze.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<List<FazaView>, ErrorMessage>>VratiFazeProjektaAsync(int projekatId)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                List<FazaView> data =
                    (await s.QueryOver<Faza>()
                        .Where(x => x.Projekat.ID == projekatId)
                        .ListAsync())
                    .Select(x => new FazaView(x))
                    .ToList();

                if (data.Count == 0)
                    return "Projekat nema faze.".ToError(404);

                return data;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobijanja faza projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<List<FazaView>, ErrorMessage>> VratiPodfazeFazeAsync(int fazaId)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                List<FazaView> data =
                    (await s.QueryOver<Faza>()
                        .Where(x => x.NadFaza!.Id == fazaId)
                        .ListAsync())
                    .Select(x => new FazaView(x))
                    .ToList();

                if (data.Count == 0)
                    return "Faza nema podfaze.".ToError(404);

                return data;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobijanja podfaza faze.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<List<FazaView>, ErrorMessage>> VratiFazeFizickogLicaAsync(int liceId)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                List<FazaView> data =
                    (await s.QueryOver<Faza>()
                        .Where(x => x.FizickoLice.Id == liceId)
                        .ListAsync())
                    .Select(x => new FazaView(x))
                    .ToList();

                if (data.Count == 0)
                    return "Fizicko lice nema dodeljenih faza.".ToError(404);

                return data;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobijanja faza fizickog lica.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

    }
}
