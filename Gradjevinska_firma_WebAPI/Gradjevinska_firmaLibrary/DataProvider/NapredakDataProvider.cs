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
    public static class NapredakDataProvider
    {
        public static async Task<Result<List<NapredakView>, ErrorMessage>> VratiNapretkeZadatkaAsync(int idZadatka)
        {
            List<NapredakView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Napredak>()
                    .Where(k => k.Zadatak.Id== idZadatka)
                    .ListAsync())
                    .Select(k => new NapredakView(k))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Zadatak nema napretke".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja napretka zadatka".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<NapredakView>, ErrorMessage>> VratiSveNapretkeAsync()
        {
            List<NapredakView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Napredak>().ListAsync())
                    .Select(f => new NapredakView(f))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja napredaka".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<NapredakView, ErrorMessage>> DodajNapredakAsync(NapredakView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Zadatak? zadatak = await s.QueryOver<Zadatak>()
                    .Where(x => x.Id == f.ZadatakId)
                    .SingleOrDefaultAsync();

                Napredak napredak = new Napredak
                {
                    Datum = f.Datum,
                    Zadatak = zadatak,
                    DnevniIzvestaj = f.DnevniIzvestaj,
                    ProcenatRealizacije = f.ProcenatRealizacije,
                    PrimedbaNadzora = f.PrimedbaNadzora,
                    KorektivnaMera = f.KorektivnaMera
                };

                await s.SaveOrUpdateAsync(napredak);
                await s.FlushAsync();

                return new NapredakView(napredak);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanja napretka.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<NapredakView, ErrorMessage>> vratiNapredakAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Napredak? napredak = await s.QueryOver<Napredak>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (napredak == null)
                    return "Incident ne postoji.".ToError(404);

                return new NapredakView(napredak);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja napretka.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<NapredakView, ErrorMessage>> izmeniNapredakAsync(NapredakView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Napredak? napredak = await s.QueryOver<Napredak>()
                    .Where(x => x.Id == f.Id)
                    .SingleOrDefaultAsync();

                if (napredak == null)
                    return "Napredak ne postoji.".ToError(404);

                Zadatak? zadatak = await s.QueryOver<Zadatak>()
                    .Where(x => x.Id == f.ZadatakId)
                    .SingleOrDefaultAsync();

                if (zadatak == null)
                    return "Zadatak ne postoji.".ToError(404);

                napredak.Datum = f.Datum;
                napredak.Zadatak = zadatak;
                napredak.DnevniIzvestaj = f.DnevniIzvestaj;
                napredak.ProcenatRealizacije = f.ProcenatRealizacije;
                napredak.PrimedbaNadzora = f.PrimedbaNadzora;
                napredak.KorektivnaMera = f.KorektivnaMera;


                await s.UpdateAsync(napredak);
                await s.FlushAsync();

                return new NapredakView(napredak);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene napretka.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> ObrisiNapredakAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Napredak? napredak = await s.QueryOver<Napredak>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (napredak == null)
                    return "Napredak ne postoji.".ToError(404);

                await s.DeleteAsync(napredak);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja napretka.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

    }
}
