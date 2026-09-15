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
    public static class AngazujeDataProvider
    {
        public static async Task<Result<List<AngazujeView>, ErrorMessage>> VratiSvaAngazovanjaAsync()
        {
            List<AngazujeView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Angazuje>().ListAsync())
                    .Select(a => new AngazujeView(a))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja angazovanja opreme na zadatku".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<AngazujeView>, ErrorMessage>>VratiAngazovanjaOpremeAsync(int opremaId)
        {
            List<AngazujeView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                data = (await s.QueryOver<Angazuje>()
                    .Where(a => a.Oprema.Id == opremaId)
                    .ListAsync())
                    .Select(a => new AngazujeView(a))
                    .ToList();

                if (data.Count == 0)
                    return "Oprema nema angazovanja.".ToError(404);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja angazovanja opreme.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<AngazujeView>, ErrorMessage>>VratiAngazovanjaZadatkaAsync(int zadatakId)
        {
            List<AngazujeView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                data = (await s.QueryOver<Angazuje>()
                    .Where(a => a.Zadatak.Id == zadatakId)
                    .ListAsync())
                    .Select(a => new AngazujeView(a))
                    .ToList();

                if (data.Count == 0)
                    return "Zadatak nema angazovanja opreme.".ToError(404);
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

        public static async Task<Result<AngazujeView, ErrorMessage>>DodajAngazujeAsync(AngazujeView a)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Zadatak zadatak = await s.LoadAsync<Zadatak>(a.ZadatakId);
                Oprema oprema = await s.LoadAsync<Oprema>(a.OpremaId);

                Angazuje angazuje = new Angazuje
                {
                    Zadatak = zadatak,
                    Oprema = oprema,
                    DatumOd = a.DatumOd,
                    DatumDo = a.DatumDo,
                    BrojSati = a.BrojSati
                };

                await s.SaveOrUpdateAsync(angazuje);
                await s.FlushAsync();

                return new AngazujeView(angazuje);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanja angazovanja opreme.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<AngazujeView, ErrorMessage>> VratiAngazujeAsync(int zadatakId, int opremaId)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Angazuje? angazuje = await s.QueryOver<Angazuje>()
                    .Where(x => x.Zadatak.Id == zadatakId)
                    .And(x => x.Oprema.Id == opremaId)
                    .SingleOrDefaultAsync();

                if (angazuje == null)
                    return "Angazovanje opreme ne postoji.".ToError(404);

                return new AngazujeView(angazuje);
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

        public static async Task<Result<AngazujeView, ErrorMessage>>IzmeniAngazujeAsync(int zadatakId,int opremaId,AngazujeView a)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Angazuje? angazuje = await s.QueryOver<Angazuje>()
                    .Where(x => x.Zadatak.Id == zadatakId)
                    .And(x => x.Oprema.Id == opremaId)
                    .SingleOrDefaultAsync();

                if (angazuje == null)
                    return "Angazovanje opreme ne postoji.".ToError(404);

                angazuje.DatumOd = a.DatumOd;
                angazuje.DatumDo = a.DatumDo;
                angazuje.BrojSati = a.BrojSati;

                await s.UpdateAsync(angazuje);
                await s.FlushAsync();

                return new AngazujeView(angazuje);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene angazovanja opreme.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>>ObrisiAngazujeAsync(int zadatakId, int opremaId)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Angazuje? angazuje = await s.QueryOver<Angazuje>()
                    .Where(x => x.Zadatak.Id == zadatakId)
                    .And(x => x.Oprema.Id == opremaId)
                    .SingleOrDefaultAsync();

                if (angazuje == null)
                    return "Angazovanje opreme ne postoji.".ToError(404);

                await s.DeleteAsync(angazuje);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja angazovanja opreme.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
    }
}
