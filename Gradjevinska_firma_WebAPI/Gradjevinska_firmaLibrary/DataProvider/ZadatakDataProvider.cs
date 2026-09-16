using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firmaLibrary.Data;
using Gradjevinska_firmaLibrary.DTOs;
using Gradjevinska_firmaLibrary.Entiteti;
using NHibernate;
using NHibernate.Engine;

namespace Gradjevinska_firmaLibrary.DataProvider
{
    public static class ZadatakDataProvider
    {
        public static async Task<Result<List<ZadatakView>, ErrorMessage>> VratiSveZadatkeAsync()
        {
            List<ZadatakView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Zadatak>().ListAsync())
                    .Select(l => new ZadatakView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja zadataka".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<ZadatakView, ErrorMessage>> vratiZadatakAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Zadatak? zadatak = await s.QueryOver<Zadatak>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (zadatak == null)
                    return "Zadatak ne postoji.".ToError(404);

                return new ZadatakView(zadatak);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja zadatka.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<ZadatakView, ErrorMessage>> DodajZadatakAsync(ZadatakView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Faza? faza = await s.QueryOver<Faza>()
                    .Where(x => x.Id == f.FazaId)
                    .SingleOrDefaultAsync();
                if (faza == null)
                    return "Nepostojeca faza".ToError();

                Zadatak? roditeljZadatak = await s.QueryOver<Zadatak>().Where(x=>x.Id == f.RoditeljId).SingleOrDefaultAsync();
                if (roditeljZadatak == null)
                    return "Nepostojeci roditelj zadatak".ToError();

                Zadatak zadatak = new Zadatak
                {
                    Naziv = f.Naziv,
                    Opis = f.Opis,
                    ProcenjeniTrosak = f.ProcenjeniTrosak,
                    PlaniraniZavrsetak = f.PlaniraniZavrsetak,
                    StvarniZavrsetak = f.StvarniZavrsetak,
                    PlaniraniPocetak = f.PlaniraniPocetak,
                    StvarniPocetak = f.StvarniPocetak,
                    Prioritet = f.Prioritet,
                    Status = f.Status,
                    Faza = faza,
                    Roditelj = roditeljZadatak
                };

                await s.SaveAsync(zadatak);
                await s.FlushAsync();

                return new ZadatakView(zadatak);
            }
            catch (Exception ex)
            {
                return ex.ToString().ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<ZadatakView, ErrorMessage>> izmeniZadatakAsync(ZadatakView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Zadatak? zadatak = await s.QueryOver<Zadatak>().Where(x => x.Id == f.Id).SingleOrDefaultAsync();
                if (zadatak == null)
                    return "Zadatak ne postoji.".ToError();

                Faza? faza = await s.QueryOver<Faza>()
                    .Where(x => x.Id == f.FazaId)
                    .SingleOrDefaultAsync();

                if (faza == null)
                    return "Faza ne postoji.".ToError(404);

                Zadatak? roditeljZadatak = await s.QueryOver<Zadatak>().Where(x => x.Id == f.RoditeljId).SingleOrDefaultAsync();
                if (roditeljZadatak == null)
                    return "Nepostojeci roditelj zadatak".ToError();

                zadatak.Naziv = f.Naziv;
                zadatak.Opis = f.Opis;
                zadatak.ProcenjeniTrosak = f.ProcenjeniTrosak;
                zadatak.PlaniraniZavrsetak = f.PlaniraniZavrsetak;
                zadatak.StvarniZavrsetak = f.StvarniZavrsetak;
                zadatak.PlaniraniPocetak = f.PlaniraniPocetak;
                zadatak.StvarniPocetak = f.StvarniPocetak;
                zadatak.Prioritet = f.Prioritet;
                zadatak.Status = f.Status;
                zadatak.Faza = faza;
                zadatak.Roditelj = roditeljZadatak;


                await s.UpdateAsync(zadatak);
                await s.FlushAsync();

                return new ZadatakView(zadatak);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene zadatka.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiZadatakAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Zadatak? zadatak = await s.QueryOver<Zadatak>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (zadatak == null)
                    return "Zadatak ne postoji.".ToError(404);

                await s.DeleteAsync(zadatak);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja zadatka.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

    }
}
