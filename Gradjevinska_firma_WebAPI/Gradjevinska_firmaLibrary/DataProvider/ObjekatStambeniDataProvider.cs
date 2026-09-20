using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firmaLibrary.Data;
using Gradjevinska_firmaLibrary.DTOs;
using Gradjevinska_firmaLibrary.Entiteti;
using NHibernate;

namespace Gradjevinska_firmaLibrary.DataProvider
{
    public static class ObjekatStambeniDataProvider
    {
        public static async Task<Result<List<ObjekatStambeniView>, ErrorMessage>> VratiObjekteAsync()
        {
            List<ObjekatStambeniView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<ObjekatStambeni>().ListAsync())
                    .Select(l => new ObjekatStambeniView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja objekata".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<ObjekatStambeniView>, ErrorMessage>> VratiObjekteStambenogProjektaAsync(int stambeniId)
        {
            List<ObjekatStambeniView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<ObjekatStambeni>()
                    .Where(l => l.Stambeni.ID == stambeniId)
                    .ListAsync())
                    .Select(k => new ObjekatStambeniView(k))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Projekat nema objekte".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja objekata projekta".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<ObjekatStambeniView, ErrorMessage>> vratiObjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                ObjekatStambeni? objekat = await s.QueryOver<ObjekatStambeni>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (objekat == null)
                    return "Objekat ne postoji.".ToError(404);

                return new ObjekatStambeniView(objekat);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja objekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<ObjekatStambeniView, ErrorMessage>> DodajObjekatAsync(ObjekatStambeniView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Stambeni? projekat = await s.QueryOver<Stambeni>()
                    .Where(x => x.ID == f.StambeniId)
                    .SingleOrDefaultAsync();

                ObjekatStambeni objekat = new ObjekatStambeni
                {
                    Br_objekta = f.Br_objekta,
                    Spratnost = f.Spratnost,
                    Br_jedinica = f.Br_jedinica,
                    Stambeni = projekat
                };

                await s.SaveOrUpdateAsync(objekat);
                await s.FlushAsync();

                return new ObjekatStambeniView(objekat);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje objekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<ObjekatStambeniView, ErrorMessage>> izmeniObjekatAsync(ObjekatStambeniView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                ObjekatStambeni? objekat = await s.QueryOver<ObjekatStambeni>().Where(x => x.Id == f.Id).SingleOrDefaultAsync();
                if (objekat == null)
                    return "Objekat ne postoji.".ToError();
                Stambeni? projekat = await s.QueryOver<Stambeni>().Where(x => x.ID == f.StambeniId).SingleOrDefaultAsync();

                objekat.Br_objekta = f.Br_objekta;
                objekat.Spratnost = f.Spratnost;
                objekat.Br_jedinica = f.Br_jedinica;
                objekat.Stambeni = projekat;


                await s.UpdateAsync(objekat);
                await s.FlushAsync();

                return new ObjekatStambeniView(objekat);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene objekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> ObrisiObjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                ObjekatStambeni? objekat = await s.QueryOver<ObjekatStambeni>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (objekat == null)
                    return "Objekat ne postoji.".ToError(404);

                await s.DeleteAsync(objekat);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja objekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
    }
}
