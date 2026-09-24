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
    public static class SertifikatSpecOpremeDataProvider
    {
        public static async Task<Result<List<SertifikatSpecOpremeView>, ErrorMessage>> VratiSveSertifikateAsync()
        {
            List<SertifikatSpecOpremeView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<SertifikatSpecOpreme>().ListAsync())
                    .Select(s => new SertifikatSpecOpremeView(s))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja sertifikata specijalnih oprema".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<SertifikatSpecOpremeView>, ErrorMessage>> VratiSertifikateFizickogLicaAsync(int idFizicko)
        {
            List<SertifikatSpecOpremeView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<SertifikatSpecOpreme>()
                    .Where(l => l.FizickoLice.Id == idFizicko)
                    .ListAsync())
                    .Select(l => new SertifikatSpecOpremeView(l))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Radnik nema sertifikate".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja sertifikata".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<SertifikatSpecOpremeView, ErrorMessage>> vratiSertifikatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                SertifikatSpecOpreme? sertif = await s.QueryOver<SertifikatSpecOpreme>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (sertif == null)
                    return "Sertifikat ne postoji.".ToError(404);

                return new SertifikatSpecOpremeView(sertif);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja sertifikata.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<SertifikatSpecOpremeView, ErrorMessage>> DodajSertifikatAsync(SertifikatSpecOpremeView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                FizickoLice? lice = await s.QueryOver<FizickoLice>()
                    .Where(x => x.Id == f.FizickoLiceId)
                    .And(x => x.FlagR == true)
                    .SingleOrDefaultAsync();

                if (lice == null)
                    return "Izabrano fizicko lice nije radnik.".ToError(404);

                SertifikatSpecOpreme sertif = new SertifikatSpecOpreme
                {
                    FizickoLice = lice,
                    Sertifikat = f.Sertifikat
                };

                await s.SaveOrUpdateAsync(sertif);
                await s.FlushAsync();

                return new SertifikatSpecOpremeView(sertif);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje sertifikata.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<SertifikatSpecOpremeView, ErrorMessage>> izmeniSertifikatAsync(SertifikatSpecOpremeView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                SertifikatSpecOpreme? sertif = await s.QueryOver<SertifikatSpecOpreme>().Where(x => x.Id == f.Id).SingleOrDefaultAsync();
                if (sertif == null)
                    return "Nepostojec sertifikat".ToError();

                FizickoLice? lice = await s.QueryOver<FizickoLice>()
                    .Where(x => x.Id == f.FizickoLiceId)
                    .And(x => x.FlagR == true)
                    .SingleOrDefaultAsync();

                if (lice == null)
                    return "Izabrano fizicko lice nije radnik.".ToError(404);

                sertif.FizickoLice = lice;
                sertif.Sertifikat = f.Sertifikat;


                await s.UpdateAsync(sertif);
                await s.FlushAsync();

                return new SertifikatSpecOpremeView(sertif);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene sertifikata specijalne opreme.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiSertifikatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                SertifikatSpecOpreme? sertif = await s.QueryOver<SertifikatSpecOpreme>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (sertif == null)
                    return "Sertifikat ne postoji.".ToError(404);

                await s.DeleteAsync(sertif);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja sertifikata.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

    }
}
