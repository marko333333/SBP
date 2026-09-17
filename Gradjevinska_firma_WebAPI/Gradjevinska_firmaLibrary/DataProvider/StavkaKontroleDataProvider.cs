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
    public static class StavkaKontroleDataProvider
    {
        public static async Task<Result<List<StavkaKontroleView>, ErrorMessage>> VratiStavkeKontroleAsync(int idKontrola)
        {
            List<StavkaKontroleView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<StavkaKontrole>()
                    .Where(k => k.Kontrola.Id == idKontrola)
                    .ListAsync())
                    .Select(k => new StavkaKontroleView(k))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Kontrola nema stavke".ToError(404);
                }

            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja stavki kontrole".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<StavkaKontroleView>, ErrorMessage>> vratiSveStavkeKontrole()
        {
            List<StavkaKontroleView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<StavkaKontrole>().ListAsync())
                    .Select(l => new StavkaKontroleView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja stavka kontrole".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<StavkaKontroleView, ErrorMessage>> vratiStavkuKontroleAsync(int id)
         {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                StavkaKontrole? stavka = await s.QueryOver<StavkaKontrole>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (stavka == null)
                    return "Stavka kontrole ne postoji.".ToError(404);

                return new StavkaKontroleView(stavka);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja stavke kontrole.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
         }

        public static async Task<Result<StavkaKontroleView, ErrorMessage>> DodajStavkuKontroleAsync(StavkaKontroleView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                KontrolaKvaliteta? kvalitet = await s.QueryOver<KontrolaKvaliteta>()
                    .Where(x => x.Id == f.KontrolaId)
                    .SingleOrDefaultAsync();

                StavkaKontrole stavka = new StavkaKontrole
                {
                    Kontrola = kvalitet,
                    RedniBrojStavke = f.RedniBrojStavke,
                    Uzorci = f.Uzorci,
                    LabNalazi = f.LabNalazi,
                    RezultatiIspitivanja = f.RezultatiIspitivanja,
                    KorektivneMere = f.KorektivneMere,
                    RokZaOtklanjanje = f.RokZaOtklanjanje
                };

                await s.SaveOrUpdateAsync(stavka);
                await s.FlushAsync();

                return new StavkaKontroleView(stavka);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje stavke kontrole.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<StavkaKontroleView, ErrorMessage>> izmeniStavkuKontroleAsync(StavkaKontroleView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                StavkaKontrole? stavka = await s.QueryOver<StavkaKontrole>().Where(x => x.Id == f.Id).SingleOrDefaultAsync();
                if (stavka == null)
                    return "Nepostojeca nabavka".ToError();

                KontrolaKvaliteta? kvalitet = await s.QueryOver<KontrolaKvaliteta>().Where(x => x.Id == f.KontrolaId).SingleOrDefaultAsync();
                if (kvalitet == null)
                    return "Kontrola kvaliteta ne postoji.".ToError();

                stavka.Kontrola = kvalitet;
                stavka.RedniBrojStavke = f.RedniBrojStavke;
                stavka.Uzorci = f.Uzorci;
                stavka.LabNalazi = f.LabNalazi;
                stavka.RezultatiIspitivanja = f.RezultatiIspitivanja;
                stavka.KorektivneMere = f.KorektivneMere;
                stavka.RokZaOtklanjanje = f.RokZaOtklanjanje;


                await s.UpdateAsync(stavka);
                await s.FlushAsync();

                return new StavkaKontroleView(stavka);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene stavke kontrole.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiStavkuKontroleAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                StavkaKontrole? stavka = await s.QueryOver<StavkaKontrole>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (stavka == null)
                    return "Stavka kontrole ne postoji.".ToError(404);

                await s.DeleteAsync(stavka);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja stavke kontrole.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }


    }
}
