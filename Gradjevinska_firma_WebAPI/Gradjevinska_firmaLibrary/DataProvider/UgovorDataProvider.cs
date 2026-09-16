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
    public static class UgovorDataProvider
    {
        public static async Task<Result<List<UgovorView>, ErrorMessage>> VratiSveUgovoreAsync()
        {
            List<UgovorView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Ugovor>().ListAsync())
                    .Select(l => new UgovorView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja ugovora".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<UgovorView, ErrorMessage>> vratiUgovorAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Ugovor? ugovor = await s.QueryOver<Ugovor>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (ugovor == null)
                    return "Licenca ne postoji.".ToError(404);

                return new UgovorView(ugovor);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja ugovora.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<UgovorView, ErrorMessage>> DodajUgovorAsync(UgovorView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Materijal? materijal = await s.QueryOver<Materijal>()
                    .Where(x => x.ID == f.MaterijalId)
                    .SingleOrDefaultAsync();

                Oprema? oprema = await s.QueryOver<Oprema>().Where(x=>x.Id == f.OpremaId).SingleOrDefaultAsync();
                Projekat? projekat = await s.QueryOver<Projekat>().Where(x => x.ID == f.ProjekatId).SingleOrDefaultAsync();

                Ugovor ugovor = new Ugovor
                {
                    DatumPotpisivanja = f.DatumPotpisivanja,
                    Vrednost = f.Vrednost,
                    PredmetUgovora = f.PredmetUgovora,
                    Valuta = f.Valuta,
                    Rok = f.Rok,
                    Materijal = materijal,
                    Projekat = projekat,
                    Oprema = oprema

                };

                await s.SaveOrUpdateAsync(ugovor);
                await s.FlushAsync();

                return new UgovorView(ugovor);
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

        public static async Task<Result<UgovorView, ErrorMessage>> izmeniUgovorAsync(UgovorView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Ugovor? ugovor = await s.QueryOver<Ugovor>().Where(x => x.Id == f.Id).SingleOrDefaultAsync();

                Materijal? materijal = await s.QueryOver<Materijal>()
                    .Where(x => x.ID == f.MaterijalId)
                    .SingleOrDefaultAsync();

                Oprema? oprema = await s.QueryOver<Oprema>().Where(x => x.Id == f.OpremaId).SingleOrDefaultAsync();
                Projekat? projekat = await s.QueryOver<Projekat>().Where(x => x.ID == f.ProjekatId).SingleOrDefaultAsync();

                ugovor.DatumPotpisivanja = f.DatumPotpisivanja;
                ugovor.Vrednost = f.Vrednost;
                ugovor.PredmetUgovora = f.PredmetUgovora;
                ugovor.Valuta = f.Valuta;
                ugovor.Rok = f.Rok;
                ugovor.Materijal = materijal;
                ugovor.Projekat = projekat;
                ugovor.Oprema = oprema;


                await s.UpdateAsync(ugovor);
                await s.FlushAsync();

                return new UgovorView(ugovor);
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

        public static async Task<Result<bool, ErrorMessage>> ObrisiUgovorAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Ugovor? ugovor = await s.QueryOver<Ugovor>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (ugovor == null)
                    return "Ugovor ne postoji.".ToError(404);

                await s.DeleteAsync(ugovor);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja ugovora.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
    }
}
