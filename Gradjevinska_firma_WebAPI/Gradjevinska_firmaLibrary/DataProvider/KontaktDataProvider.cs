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
    public static class KontaktDataProvider
    {
        public static async Task<Result<List<KontaktView>, ErrorMessage>> VratiSveKontakteAsync()
        {
            List<KontaktView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Kontakt>().ListAsync())
                    .Select(k => new KontaktView(k))
                    .ToList();
                
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja kontakata.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<KontaktView>, ErrorMessage>> VratiKontakteOsobeAsync(int idOsobe)
        {
            List<KontaktView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Kontakt>()
                    .Where(k => k.Osoba.Id == idOsobe)
                    .ListAsync())
                    .Select(k => new KontaktView(k))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Osoba nema kontakte".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja kontakata osobe.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<KontaktView, ErrorMessage>>DodajKontaktAsync(KontaktView kontaktView)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Osoba? osoba = await s.QueryOver<Osoba>()
                    .Where(x => x.Id == kontaktView.OsobaId)
                    .SingleOrDefaultAsync();

                if (osoba == null)
                    return "Osoba ne postoji.".ToError(404);

                Kontakt kontakt = new Kontakt
                {
                    Osoba = osoba,
                    Broj = kontaktView.Broj
                };

                await s.SaveOrUpdateAsync(kontakt);
                await s.FlushAsync();

                return new KontaktView(kontakt);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanja kontakta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<KontaktView, ErrorMessage>>VratiKontaktAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Kontakt? kontakt = await s.QueryOver<Kontakt>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (kontakt == null)
                    return "Kontakt ne postoji.".ToError(404);

                return new KontaktView(kontakt);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobijanja kontakta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<KontaktView, ErrorMessage>>IzmeniKontaktAsync(KontaktView k)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Kontakt? kontakt = await s.QueryOver<Kontakt>()
                    .Where(x => x.Id == k.Id)
                    .SingleOrDefaultAsync();

                if (kontakt == null)
                    return "Kontakt ne postoji.".ToError(404);

                Osoba? osoba = await s.QueryOver<Osoba>()
                    .Where(x => x.Id == k.OsobaId)
                    .SingleOrDefaultAsync();

                if (osoba == null)
                    return "Osoba ne postoji.".ToError(404);

                kontakt.Osoba = osoba;
                kontakt.Broj = k.Broj;

                await s.UpdateAsync(kontakt);
                await s.FlushAsync();

                return new KontaktView(kontakt);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene kontakta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>>ObrisiKontaktAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Kontakt? kontakt = await s.QueryOver<Kontakt>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (kontakt == null)
                    return "Kontakt ne postoji.".ToError(404);

                await s.DeleteAsync(kontakt);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja kontakta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
    }
}
