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
    public static class RadniNalogDataProvider
    {
        public static async Task<Result<List<RadniNalogView>, ErrorMessage>> VratiRadneNalogeZadatkaAsync(int idZadatka)
        {
            List<RadniNalogView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<RadniNalog>()
                    .Where(k => k.Zadatak.Id == idZadatka)
                    .ListAsync())
                    .Select(k => new RadniNalogView(k))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Zadatak nema radne naloge".ToError(404);
                }

            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja radnih naloga zadatka".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<RadniNalogView>, ErrorMessage>> VratiSveRadneNalogeAsync()
        {
            List<RadniNalogView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<RadniNalog>().ListAsync())
                    .Select(l => new RadniNalogView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja radnih naloga".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<RadniNalogView, ErrorMessage>> vratiRadinNalogAsync(int brojNaloga)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                RadniNalog? nalog = await s.QueryOver<RadniNalog>()
                    .Where(x => x.BrojNaloga == brojNaloga)
                    .SingleOrDefaultAsync();

                if (nalog == null)
                    return "Radni nalog ne postoji.".ToError(404);

                return new RadniNalogView(nalog);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja radnog naloga.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<RadniNalogView, ErrorMessage>> DodajRadniNalogAsync(RadniNalogView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Zadatak? zadatak = await s.QueryOver<Zadatak>()
                    .Where(x => x.Id == f.ZadatakId)
                    .SingleOrDefaultAsync();

                RadniNalog nalog = new RadniNalog
                {
                    Status = f.Status,
                    DatumIzdavanja = f.DatumIzdavanja,
                    Zadatak = zadatak
                };

                await s.SaveOrUpdateAsync(nalog);
                await s.FlushAsync();

                return new RadniNalogView(nalog);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje radnog naloga.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<RadniNalogView, ErrorMessage>> izmeniRadniNalogAsync(RadniNalogView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                RadniNalog? nalog = await s.QueryOver<RadniNalog>().Where(x => x.BrojNaloga == f.BrojNaloga).SingleOrDefaultAsync();
                if (nalog == null)
                    return "Radni nalog ne postoji.".ToError();

                Zadatak? zadatak = await s.QueryOver<Zadatak>()
                    .Where(x => x.Id == f.ZadatakId)
                    .SingleOrDefaultAsync();

                if (zadatak == null)
                    return "Zadatak ne postoji.".ToError(404);

                nalog.Status = f.Status;
                nalog.DatumIzdavanja = f.DatumIzdavanja;
                nalog.Zadatak = zadatak;


                await s.UpdateAsync(nalog);
                await s.FlushAsync();

                return new RadniNalogView(nalog);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene radnog naloga.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> ObrisiRadniNalogAsync(int brojNaloga)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                RadniNalog? nalog = await s.QueryOver<RadniNalog>()
                    .Where(x => x.BrojNaloga == brojNaloga)
                    .SingleOrDefaultAsync();

                if (nalog == null)
                    return "Radni nalog ne postoji.".ToError(404);

                await s.DeleteAsync(nalog);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja radnog naloga.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
    }
}
