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
    public static class OpremaDataProvider
    {
        public static async Task<Result<List<OpremaView>, ErrorMessage>> VratiOpremeAsync()
        {
            List<OpremaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Oprema>().ListAsync())
                    .Select(l => new OpremaView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja oprema".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<OpremaView, ErrorMessage>> vratiOpremuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Oprema? oprema = await s.QueryOver<Oprema>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (oprema == null)
                    return "Oprema ne postoji.".ToError(404);

                return new OpremaView(oprema);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja opreme.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<OpremaView, ErrorMessage>> DodajOpremuAsync(OpremaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Oprema oprema = new Oprema
                {
                    Naziv = f.Naziv,
                    Tip = f.Tip,
                    DatumUvoza = f.DatumUvoza,
                    Proizvodjac = f.Proizvodjac,
                    RasponOdrzavanja = f.RasponOdrzavanja,
                    Lokacija = f.Lokacija,
                    Status = f.Status
                };

                await s.SaveOrUpdateAsync(oprema);
                await s.FlushAsync();

                return new OpremaView(oprema);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje opreme.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<OpremaView, ErrorMessage>> izmeniOpremuAsync(OpremaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Oprema? oprema = await s.QueryOver<Oprema>().Where(x => x.Id == f.Id).SingleOrDefaultAsync();
                if (oprema == null)
                    return "Oprema ne postoji.".ToError();

                oprema.Naziv = f.Naziv;
                oprema.Tip = f.Tip;
                oprema.DatumUvoza = f.DatumUvoza;
                oprema.Proizvodjac = f.Proizvodjac;
                oprema.RasponOdrzavanja = f.RasponOdrzavanja;
                oprema.Lokacija = f.Lokacija;
                oprema.Status = f.Status;


                await s.UpdateAsync(oprema);
                await s.FlushAsync();

                return new OpremaView(oprema);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene opreme.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> ObrisiOpremuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Oprema? oprema = await s.QueryOver<Oprema>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (oprema == null)
                    return "Oprema ne postoji.".ToError(404);

                await s.DeleteAsync(oprema);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja opreme.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
    }
}
