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
    public static class ProjekatDataProvider
    {
        public static async Task<Result<List<ProjekatView>, ErrorMessage>> vratiSveProjekte()
        {
            List<ProjekatView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Projekat>().ListAsync())
                    .Select(l => new ProjekatView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja projekata".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<ProjekatView, ErrorMessage>> vratiProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Projekat? projekat = await s.QueryOver<Projekat>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                return new ProjekatView(projekat);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Projekat? projekat = await s.QueryOver<Projekat>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                await s.DeleteAsync(projekat);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

    }
}
