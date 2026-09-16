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
    public static class LicencaDataProvider
    {
        public static async Task<Result<List<LicencaView>, ErrorMessage>> VratiSveLicenceAsync()
        {
            List<LicencaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Licenca>().ListAsync())
                    .Select(l => new LicencaView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja licenca".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<LicencaView>, ErrorMessage>> VratiLicenceOsobeAsync(int idOsobe)
        {
            List<LicencaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Licenca>()
                    .Where(l => l.Osoba.Id == idOsobe)
                    .ListAsync())
                    .Select(k => new LicencaView(k))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Osoba nema licence".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja licenca osobe".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<LicencaView, ErrorMessage>> vratiLicencuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Licenca? licenca = await s.QueryOver<Licenca>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (licenca == null)
                    return "Licenca ne postoji.".ToError(404);

                return new LicencaView(licenca);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja licence.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<LicencaView, ErrorMessage>> DodajLicencuAsync(LicencaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Osoba? osoba = await s.QueryOver<Osoba>()
                    .Where(x => x.Id == f.OsobaId)
                    .SingleOrDefaultAsync();

                Licenca licenca = new Licenca
                {
                    Osoba = osoba,
                    NazivLicence = f.NazivLicence
                };

                await s.SaveOrUpdateAsync(licenca);
                await s.FlushAsync();

                return new LicencaView(licenca);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje licence.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<LicencaView, ErrorMessage>> izmeniLicencuAsync(LicencaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Licenca? licenca = await s.QueryOver<Licenca>().Where(x=>x.Id == f.Id).SingleOrDefaultAsync();
                if (licenca == null)
                    return "Licenca ne postoji.".ToError();

                Osoba? osoba = await s.QueryOver<Osoba>()
                    .Where(x => x.Id == f.OsobaId)
                    .SingleOrDefaultAsync();

                if (osoba == null)
                    return "Osoba ne postoji.".ToError(404);

                licenca.Osoba = osoba;
                licenca.NazivLicence = f.NazivLicence;


                await s.UpdateAsync(licenca);
                await s.FlushAsync();

                return new LicencaView(licenca);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene licence.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> ObrisiLicencuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Licenca? licenca = await s.QueryOver<Licenca>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (licenca == null)
                    return "Licenca ne postoji.".ToError(404);

                await s.DeleteAsync(licenca);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja licence.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

    }

}