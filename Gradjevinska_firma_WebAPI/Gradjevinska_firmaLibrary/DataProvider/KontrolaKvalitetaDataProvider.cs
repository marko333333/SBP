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
    public static class KontrolaKvalitetaDataProvider
    {
        public static async Task<Result<List<KontrolaKvalitetaView>, ErrorMessage>> VratiKontroleKvalitetaZadatkaAsync(int idZadatak)
        {
            List<KontrolaKvalitetaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<KontrolaKvaliteta>()
                    .Where(k => k.Zadatak.Id == idZadatak)
                    .ListAsync())
                    .Select(k => new KontrolaKvalitetaView(k))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Zadatak nema kontrolu kvaliteta".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja kontrole kvaliteta zadatka".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<KontrolaKvalitetaView>, ErrorMessage>> VratiSveKontroleAsync()
        {
            List<KontrolaKvalitetaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<KontrolaKvaliteta>().ListAsync())
                    .Select(f => new KontrolaKvalitetaView(f))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja kontrola".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<KontrolaKvalitetaView, ErrorMessage>> VratiKontroluAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                KontrolaKvaliteta? kontrola = await s.QueryOver<KontrolaKvaliteta>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (kontrola == null)
                    return "Kontrola ne postoji.".ToError(404);

                return new KontrolaKvalitetaView(kontrola);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobijanja kontrole.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<KontrolaKvalitetaView, ErrorMessage>> DodajKontroluAsync(KontrolaKvalitetaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Zadatak? zadatak = await s.QueryOver<Zadatak>()
                    .Where(x => x.Id == f.ZadatakId)
                    .SingleOrDefaultAsync();

                if (zadatak == null)
                    return "zadatak ne postoji.".ToError(404);

                //KontrolaKvaliteta? konotrola = await s.QueryOver<KontrolaKvaliteta>()
                //    .Where(x => x.Id == f.Id)
                //    .SingleOrDefaultAsync();

                //if (konotrola != null)
                //    return "Kontrola vec postoji.".ToError(400);

                KontrolaKvaliteta kontrola = new KontrolaKvaliteta
                {
                    DatumInspekcije = f.DatumInspekcije,
                    PrimedbeNadzora = f.PrimedbeNadzora,
                    Zapisnik = f.Zapisnik,
                    ZabranaNastavkaRadova = f.ZabranaNastavkaRadova,
                    RazlogZabrane = f.RazlogZabrane,
                    DatumOtklanjanjaZabrane = f.DatumOtklanjanjaZabrane,
                    Zadatak = zadatak
                };

                await s.SaveOrUpdateAsync(kontrola);
                await s.FlushAsync();

                return new KontrolaKvalitetaView(kontrola);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanja konotrole.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<KontrolaKvalitetaView, ErrorMessage>> IzmeniKontroluAsync(KontrolaKvalitetaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                KontrolaKvaliteta? kontrola = await s.QueryOver<KontrolaKvaliteta>()
                    .Where(x => x.Id == f.Id)
                    .SingleOrDefaultAsync();

                if (kontrola == null)
                    return "Kontrola ne postoji.".ToError(404);

                Zadatak? zadatak = await s.QueryOver<Zadatak>()
                    .Where(x => x.Id == f.ZadatakId)
                    .SingleOrDefaultAsync();

                if (zadatak == null)
                    return "Zadatak ne postoji.".ToError(404);

                kontrola.DatumInspekcije = f.DatumInspekcije;
                kontrola.PrimedbeNadzora = f.PrimedbeNadzora;
                kontrola.Zapisnik = f.Zapisnik;
                kontrola.ZabranaNastavkaRadova = f.ZabranaNastavkaRadova;
                kontrola.RazlogZabrane = f.RazlogZabrane;
                kontrola.DatumOtklanjanjaZabrane = f.DatumOtklanjanjaZabrane;
                kontrola.Zadatak = zadatak;

                await s.UpdateAsync(kontrola);
                await s.FlushAsync();

                return new KontrolaKvalitetaView(kontrola);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene kontrole.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> ObrisiKontroluAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                KontrolaKvaliteta? kontrola = await s.QueryOver<KontrolaKvaliteta>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (kontrola == null)
                    return "Kontrola ne postoji.".ToError(404);

                await s.DeleteAsync(kontrola);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja kontrole.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

    }
}
