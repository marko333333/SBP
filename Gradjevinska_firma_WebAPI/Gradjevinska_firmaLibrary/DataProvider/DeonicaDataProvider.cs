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
    public class DeonicaDataProvider
    {
            public static async Task<Result<List<DeonicaView>, ErrorMessage>> VratiSveDeoniceAsync()
            {
                List<DeonicaView> data = new();

                ISession? s = null;

                try
                {
                    s = DataLayer.GetSession();

                    if (!(s?.IsConnected ?? false))
                    {
                        return "Nemoguce otvoriti sesiju.".ToError(403);
                    }

                    data = (await s.QueryOver<Deonica>().ListAsync())
                        .Select(f => new DeonicaView(f))
                        .ToList();
                }
                catch (Exception)
                {
                    return "Doslo je do greske prilikom prikupljanja  deonica".ToError(400);
                }
                finally
                {
                    s?.Close();
                    s?.Dispose();
                }

                return data;
            }
        

        public static async Task<Result<DeonicaView, ErrorMessage>> VratiDeonicuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Deonica? deonica = await s.QueryOver<Deonica>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (deonica == null)
                    return "Deonica ne postoji.".ToError(404);

                return new DeonicaView(deonica);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobijanja deonice.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<List<DeonicaView>, ErrorMessage>> VratiDeoniceInfrastruktureAsync(int infraId)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                List<DeonicaView> data =
                    (await s.QueryOver<Deonica>()
                        .Where(x => x.Infrastruktura.ID == infraId)
                        .ListAsync())
                    .Select(x => new DeonicaView(x))
                    .ToList();

                if (data.Count == 0)
                    return "Infrastruktura nema deonice.".ToError(404);

                return data;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobijanja deonica infrastrukture.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<DeonicaView, ErrorMessage>> DodajDeonicuAsync(DeonicaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Infrastruktura? projekat = await s.QueryOver<Infrastruktura>()
                    .Where(x => x.ID == f.infrastrukturaId)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                Deonica deonica = new Deonica
                {
                    Br_deonice = f.Br_deonice,
                    Infrastruktura = projekat
                };

                await s.SaveOrUpdateAsync(deonica);
                await s.FlushAsync();

                return new DeonicaView(deonica);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanja deonice.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<DeonicaView, ErrorMessage>> IzmeniDeonicuAsync(DeonicaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Deonica? deonica = await s.QueryOver<Deonica>()
                    .Where(x => x.Id == f.Id)
                    .SingleOrDefaultAsync();

                if (deonica == null)
                    return "Deonica ne postoji.".ToError(404);

                Infrastruktura? projekat = await s.QueryOver<Infrastruktura>()
                    .Where(x => x.ID == f.infrastrukturaId)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                deonica.Br_deonice = f.Br_deonice;
                deonica.Infrastruktura = projekat;

                await s.UpdateAsync(deonica);
                await s.FlushAsync();

                return new DeonicaView(deonica);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene deonice.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> ObrisiDeonicuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Deonica? deonica = await s.QueryOver<Deonica>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (deonica == null)
                    return "Deonica ne postoji.".ToError(404);

                await s.DeleteAsync(deonica);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja deonice.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

    }
}
