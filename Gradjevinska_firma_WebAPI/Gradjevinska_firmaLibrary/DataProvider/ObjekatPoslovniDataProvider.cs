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
    public static class ObjekatPoslovniDataProvider
    {
        public static async Task<Result<List<ObjekatPoslovniView>, ErrorMessage>> VratiObjekteAsync()
        {
            List<ObjekatPoslovniView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<ObjekatPoslovni>().ListAsync())
                    .Select(l => new ObjekatPoslovniView(l))
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

        public static async Task<Result<List<ObjekatPoslovniView>, ErrorMessage>> VratiObjektePoslovnogProjektaAsync(int poslovniId)
        {
            List<ObjekatPoslovniView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<ObjekatPoslovni>()
                    .Where(l => l.Poslovni.ID == poslovniId)
                    .ListAsync())
                    .Select(k => new ObjekatPoslovniView(k))
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

        public static async Task<Result<ObjekatPoslovniView, ErrorMessage>> vratiObjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                ObjekatPoslovni? objekat = await s.QueryOver<ObjekatPoslovni>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (objekat == null)
                    return "Objekat ne postoji.".ToError(404);

                return new ObjekatPoslovniView(objekat);
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

        public static async Task<Result<ObjekatPoslovniView, ErrorMessage>> DodajObjekatAsync(ObjekatPoslovniView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Poslovni? projekat = await s.QueryOver<Poslovni>()
                    .Where(x => x.ID == f.PoslovniId)
                    .SingleOrDefaultAsync();

                ObjekatPoslovni objekat = new ObjekatPoslovni
                {
                    Br_objekta = f.Br_objekta,
                    Spratnost = f.Spratnost,
                    Br_jedinica = f.Br_jedinica,
                    Poslovni = projekat
                };

                await s.SaveOrUpdateAsync(objekat);
                await s.FlushAsync();

                return new ObjekatPoslovniView(objekat);
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

        public static async Task<Result<ObjekatPoslovniView, ErrorMessage>> izmeniObjekatAsync(ObjekatPoslovniView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                ObjekatPoslovni? objekat = await s.QueryOver<ObjekatPoslovni>().Where(x => x.Id == f.Id).SingleOrDefaultAsync();
                if (objekat == null)
                    return "Objekat ne postoji.".ToError();
                Poslovni? projekat = await s.QueryOver<Poslovni>().Where(x=>x.ID == f.PoslovniId).SingleOrDefaultAsync();

                objekat.Br_objekta = f.Br_objekta;
                objekat.Spratnost = f.Spratnost;
                objekat.Br_jedinica = f.Br_jedinica;
                objekat.Poslovni = projekat;


                await s.UpdateAsync(objekat);
                await s.FlushAsync();

                return new ObjekatPoslovniView(objekat);
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

                ObjekatPoslovni? objekat = await s.QueryOver<ObjekatPoslovni>()
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
