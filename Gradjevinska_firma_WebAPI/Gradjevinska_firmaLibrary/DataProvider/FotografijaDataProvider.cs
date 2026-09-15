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
    public static class FotografijaDataProvider
    {
        public static async Task<Result<List<FotografijaView>, ErrorMessage>> VratiSveFotografijeAsync()
        {
            List<FotografijaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Fotografija>().ListAsync())
                    .Select(f => new FotografijaView(f))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja fotografija".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<FotografijaView>, ErrorMessage>> VratiFotografijeNapretkaAsync(int idNapretka)
        {
            List<FotografijaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Fotografija>()
                    .Where(f => f.Napredak.Id == idNapretka)
                    .ListAsync())
                    .Select(f => new FotografijaView(f))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Napredak nema fotografije".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja fotografije napretka".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<FotografijaView, ErrorMessage>>VratiFotografijuAsync(int napredakId, string putanja)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Fotografija? fotografija = await s.QueryOver<Fotografija>()
                    .Where(x => x.Napredak.Id == napredakId)
                    .And(x => x.Putanja == putanja)
                    .SingleOrDefaultAsync();

                if (fotografija == null)
                    return "Fotografija ne postoji.".ToError(404);

                return new FotografijaView(fotografija);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobijanja fotografije.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<FotografijaView, ErrorMessage>>DodajFotografijuAsync(FotografijaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Napredak? napredak = await s.QueryOver<Napredak>()
                    .Where(x => x.Id == f.NapredakId)
                    .SingleOrDefaultAsync();

                if (napredak == null)
                    return "Napredak ne postoji.".ToError(404);

                Fotografija? postoji = await s.QueryOver<Fotografija>()
                    .Where(x => x.Napredak.Id == f.NapredakId)
                    .And(x => x.Putanja == f.Putanja)
                    .SingleOrDefaultAsync();

                if (postoji != null)
                    return "Fotografija vec postoji.".ToError(400);

                Fotografija fotografija = new Fotografija
                {
                    Napredak = napredak,
                    Putanja = f.Putanja
                };

                await s.SaveOrUpdateAsync(fotografija);
                await s.FlushAsync();

                return new FotografijaView(fotografija);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanja fotografije.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<FotografijaView, ErrorMessage>>IzmeniFotografijuAsync(int napredakId,string staraPutanja,FotografijaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Fotografija? fotografija = await s.QueryOver<Fotografija>()
                    .Where(x => x.Napredak.Id == napredakId)
                    .And(x => x.Putanja == staraPutanja)
                    .SingleOrDefaultAsync();

                if (fotografija == null)
                    return "Fotografija ne postoji.".ToError(404);

                Napredak? napredak = await s.QueryOver<Napredak>()
                    .Where(x => x.Id == f.NapredakId)
                    .SingleOrDefaultAsync();

                if (napredak == null)
                    return "Napredak ne postoji.".ToError(404);

                fotografija.Napredak = napredak;
                fotografija.Putanja = f.Putanja;

                await s.UpdateAsync(fotografija);
                await s.FlushAsync();

                return new FotografijaView(fotografija);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene fotografije.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>>ObrisiFotografijuAsync(int napredakId, string putanja)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Fotografija? fotografija = await s.QueryOver<Fotografija>()
                    .Where(x => x.Napredak.Id == napredakId)
                    .And(x => x.Putanja == putanja)
                    .SingleOrDefaultAsync();

                if (fotografija == null)
                    return "Fotografija ne postoji.".ToError(404);

                await s.DeleteAsync(fotografija);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja fotografije.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }


    }
}
