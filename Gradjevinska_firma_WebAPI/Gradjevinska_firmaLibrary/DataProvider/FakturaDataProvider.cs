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
    public static class FakturaDataProvider
    {
        public static async Task<Result<List<FakturaView>, ErrorMessage>> VratiSveFaktureAsync()
        {
            List<FakturaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Faktura>().ListAsync())
                    .Select(f => new FakturaView(f))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja  faktura".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<FakturaView, ErrorMessage>>DodajFakturuAsync(FakturaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Projekat? projekat = await s.QueryOver<Projekat>()
                    .Where(x => x.ID == f.IDProjekta)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                PravnaLica? pravnoLiceIzdaje = await s.QueryOver<PravnaLica>()
                    .Where(x => x.Id == f.PravnoLiceIzdajeId)
                    .SingleOrDefaultAsync();

                if (pravnoLiceIzdaje == null)
                    return "Pravno lice koje izdaje fakturu ne postoji.".ToError(404);

                PravnaLica? pravnoLicePrima = await s.QueryOver<PravnaLica>()
                    .Where(x => x.Id == f.PravnoLicePrimaId)
                    .SingleOrDefaultAsync();

                if (pravnoLicePrima == null)
                    return "Pravno lice koje prima fakturu ne postoji.".ToError(404);

                Faktura faktura = new Faktura
                {
                    Br_fakture = f.Br_fakture,
                    Iznos = f.Iznos,
                    Valuta = f.Valuta,
                    statusPlacanja = f.statusPlacanja,
                    Datum = f.Datum,
                    IDProjekta = projekat,
                    PravnoLiceIzdaje = pravnoLiceIzdaje,
                    PravnoLicePrima = pravnoLicePrima
                };

                await s.SaveOrUpdateAsync(faktura);
                await s.FlushAsync();

                return new FakturaView(faktura);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanja fakture.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<FakturaView, ErrorMessage>>VratiFakturuAsync(int brFakture)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Faktura? faktura = await s.QueryOver<Faktura>()
                    .Where(x => x.Br_fakture == brFakture)
                    .SingleOrDefaultAsync();

                if (faktura == null)
                    return "Faktura ne postoji.".ToError(404);

                return new FakturaView(faktura);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobijanja fakture.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<FakturaView, ErrorMessage>>IzmeniFakturuAsync(FakturaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Faktura? faktura = await s.QueryOver<Faktura>()
                    .Where(x => x.Br_fakture == f.Br_fakture)
                    .SingleOrDefaultAsync();

                if (faktura == null)
                    return "Faktura ne postoji.".ToError(404);

                Projekat? projekat = await s.QueryOver<Projekat>()
                    .Where(x => x.ID == f.IDProjekta)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                PravnaLica? pravnoLiceIzdaje = await s.QueryOver<PravnaLica>()
                    .Where(x => x.Id == f.PravnoLiceIzdajeId)
                    .SingleOrDefaultAsync();

                if (pravnoLiceIzdaje == null)
                    return "Pravno lice koje izdaje fakturu ne postoji.".ToError(404);

                PravnaLica? pravnoLicePrima = await s.QueryOver<PravnaLica>()
                    .Where(x => x.Id == f.PravnoLicePrimaId)
                    .SingleOrDefaultAsync();

                if (pravnoLicePrima == null)
                    return "Pravno lice koje prima fakturu ne postoji.".ToError(404);

                faktura.Iznos = f.Iznos;
                faktura.Valuta = f.Valuta;
                faktura.statusPlacanja = f.statusPlacanja;
                faktura.Datum = f.Datum;
                faktura.IDProjekta = projekat;
                faktura.PravnoLiceIzdaje = pravnoLiceIzdaje;
                faktura.PravnoLicePrima = pravnoLicePrima;

                await s.UpdateAsync(faktura);
                await s.FlushAsync();

                return new FakturaView(faktura);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene fakture.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>>ObrisiFakturuAsync(int brFakture)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Faktura? faktura = await s.QueryOver<Faktura>()
                    .Where(x => x.Br_fakture == brFakture)
                    .SingleOrDefaultAsync();

                if (faktura == null)
                    return "Faktura ne postoji.".ToError(404);

                await s.DeleteAsync(faktura);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja fakture.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<List<FakturaView>, ErrorMessage>>VratiFaktureProjektaAsync(int projekatId)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                List<FakturaView> data =
                    (await s.QueryOver<Faktura>()
                        .Where(x => x.IDProjekta.ID == projekatId)
                        .ListAsync())
                    .Select(x => new FakturaView(x))
                    .ToList();

                if (data.Count == 0)
                    return "Projekat nema fakture.".ToError(404);

                return data;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobijanja faktura projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<List<FakturaView>, ErrorMessage>> vratiIzdateFakturePravnogLica(int pravnoLiceID)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                List<FakturaView> data =
                    (await s.QueryOver<Faktura>()
                        .Where(x => x.PravnoLiceIzdaje.Id == pravnoLiceID)
                        .ListAsync())
                    .Select(x => new FakturaView(x))
                    .ToList();

                if (data.Count == 0)
                    return "Faktura nema izdate fakture datum pravnom licu.".ToError(404);

                return data;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobijanja faktura.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<List<FakturaView>, ErrorMessage>> vratiPrimljeneFakturePravnogLica(int pravnoLiceID)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                List<FakturaView> data =
                    (await s.QueryOver<Faktura>()
                        .Where(x => x.PravnoLicePrima.Id == pravnoLiceID)
                        .ListAsync())
                    .Select(x => new FakturaView(x))
                    .ToList();

                if (data.Count == 0)
                    return "Faktura nema date fakture datum pravnom licu.".ToError(404);

                return data;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobijanja faktura.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

    }
}
