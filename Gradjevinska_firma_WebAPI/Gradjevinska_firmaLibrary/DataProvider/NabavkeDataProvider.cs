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
    public static class NabavkeDataProvider
    {
        public static async Task<Result<List<NabavkeView>, ErrorMessage>> VratiNabavkeProjektaAsync(int idProjekta)
        {
            List<NabavkeView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Nabavke>()
                    .Where(k => k.Projekat.ID == idProjekta)
                    .ListAsync())
                    .Select(k => new NabavkeView(k))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Projekat nema nabavke".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja nabavka projekta".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<NabavkeView>, ErrorMessage>> VratiSveNabavkeAsync()
        {
            List<NabavkeView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Nabavke>().ListAsync())
                    .Select(l => new NabavkeView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja nabavka".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<NabavkeView, ErrorMessage>> vratiNabavkuAsync(int brNabavke)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Nabavke? nabavka = await s.QueryOver<Nabavke>()
                    .Where(x => x.Br_nabavke == brNabavke)
                    .SingleOrDefaultAsync();

                if (nabavka == null)
                    return "Nabavka ne postoji.".ToError(404);

                return new NabavkeView(nabavka);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja nabavke.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<NabavkeView, ErrorMessage>> DodajNabavkuAsync(NabavkeView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Projekat? projekat = await s.QueryOver<Projekat>()
                    .Where(x => x.ID == f.ProjekatId)
                    .SingleOrDefaultAsync();
                PravnaLica? dobavljac =await s.QueryOver<PravnaLica>()
                   .Where(x => x.Id == f.DobavljacId)
                   .And(x => x.FlagD == true)
                   .SingleOrDefaultAsync();

                if (dobavljac == null)
                {
                    return "Izabrana osoba nije dobavljac.".ToError(404);
                }
                Nabavke nabavka = new Nabavke
                {
                    Datum = f.Datum,
                    Projekat = projekat,
                    Dobavljac= dobavljac
                };

                await s.SaveOrUpdateAsync(nabavka);
                await s.FlushAsync();

                return new NabavkeView(nabavka);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje nabavke.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<NabavkeView, ErrorMessage>> izmeniNabavkuAsync(NabavkeView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Nabavke? nabavka = await s.QueryOver<Nabavke>().Where(x=>x.Br_nabavke == f.Br_nabavke).SingleOrDefaultAsync();
                if (nabavka == null)
                    return "Nepostojeca nabavka".ToError();

                Projekat? projekat = await s.QueryOver<Projekat>().Where(x => x.ID == f.ProjekatId).SingleOrDefaultAsync();
                if (projekat == null)
                    return "Projekat ne postoji.".ToError();
                PravnaLica? dobavljac = await s.QueryOver<PravnaLica>()
                   .Where(x => x.Id == f.DobavljacId)
                   .And(x => x.FlagD == true)
                   .SingleOrDefaultAsync();

                if (dobavljac == null)
                {
                    return "Izabrana osoba nije dobavljac.".ToError(404);
                }


                nabavka.Datum = f.Datum;
                nabavka.Projekat = projekat;
                nabavka.Dobavljac= dobavljac;

                await s.UpdateAsync(nabavka);
                await s.FlushAsync();

                return new NabavkeView(nabavka);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene nabavke.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiNabavkuAsync(int brNabavke)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Nabavke? nabavka = await s.QueryOver<Nabavke>()
                    .Where(x => x.Br_nabavke == brNabavke)
                    .SingleOrDefaultAsync();

                if (nabavka == null)
                    return "nabavka ne postoji.".ToError(404);

                await s.DeleteAsync(nabavka);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja nabavke.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

    }
}
