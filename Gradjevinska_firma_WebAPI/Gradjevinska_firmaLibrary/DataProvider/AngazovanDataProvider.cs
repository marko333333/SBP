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
    public static class AngazovanDataProvider
    {
        public static async Task<Result<List<AngazovanView>, ErrorMessage>> VratiSveAngazovaneAsync()
        {
            List<AngazovanView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Angazovan>()
                    .ListAsync())
                    .Select(a => new AngazovanView(a))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja angazovanja.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<AngazovanView>, ErrorMessage>> VratiAngazovanjaOsobeAsync(int idOsobe)
        {
            List<AngazovanView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Angazovan>()
                    .Where(a => a.Osoba.Id == idOsobe)
                    .ListAsync())
                    .Select(a => new AngazovanView(a))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Osoba nema angazovanja.".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja angazovanja osobe.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<AngazovanView>, ErrorMessage>> VratiAngazovanjaZadatkaAsync(int idZadatka)
        {
            List<AngazovanView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Angazovan>()
                    .Where(a => a.Zadatak.Id == idZadatka)
                    .ListAsync())
                    .Select(a => new AngazovanView(a))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Zadatak nema angazovanih osoba".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja angazovanja zadatka.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<AngazovanView, ErrorMessage>>DodajAngazovanAsync(AngazovanView a)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Zadatak zadatak = await s.LoadAsync<Zadatak>(a.ZadatakId);
                Osoba osoba = await s.LoadAsync<Osoba>(a.OsobaId);

                Angazovan angazovan = new Angazovan
                {
                    Zadatak = zadatak,
                    Osoba = osoba,
                    DatumOd = a.DatumOd,
                    DatumDo = a.DatumDo,
                    StatusAngazovanja = a.StatusAngazovanja
                };

                await s.SaveOrUpdateAsync(angazovan);
                await s.FlushAsync();

                return new AngazovanView(angazovan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanja angazovanja.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<AngazovanView, ErrorMessage>> VratiAngazovanAsync(int zadatakId, int osobaId)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Angazovan? angazovan = await s.QueryOver<Angazovan>()
                    .Where(x => x.Zadatak.Id == zadatakId)
                    .And(x => x.Osoba.Id == osobaId)
                    .SingleOrDefaultAsync();

                if (angazovan == null)
                    return "Angazovanje osobe ne postoji.".ToError(404);

                return new AngazovanView(angazovan);
            }
            catch (Exception)
            {
                return "Greska pri dobijanju podataka.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<AngazovanView, ErrorMessage>>IzmeniAngazovanAsync(AngazovanView a)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Angazovan? angazovan = await s.QueryOver<Angazovan>()
                    .Where(x => x.Zadatak.Id == a.ZadatakId)
                    .And(x => x.Osoba.Id == a.OsobaId)
                    .SingleOrDefaultAsync();

                if (angazovan == null)
                {
                    return "Angazovanje ne postoji.".ToError(404);
                }

                angazovan.DatumOd = a.DatumOd;
                angazovan.DatumDo = a.DatumDo;
                angazovan.StatusAngazovanja = a.StatusAngazovanja;

                await s.UpdateAsync(angazovan);
                await s.FlushAsync();

                return new AngazovanView(angazovan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene angazovanja.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }


        }

        public static async Task<Result<bool, ErrorMessage>>ObrisiAngazovanAsync(int zadatakId, int osobaId)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Angazovan? angazovan = await s.QueryOver<Angazovan>()
                    .Where(x => x.Zadatak.Id == zadatakId)
                    .And(x => x.Osoba.Id == osobaId)
                    .SingleOrDefaultAsync();

                if (angazovan == null)
                {
                    return "Angazovanje ne postoji.".ToError(404);
                }

                await s.DeleteAsync(angazovan);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja angazovanja.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

    }
}
