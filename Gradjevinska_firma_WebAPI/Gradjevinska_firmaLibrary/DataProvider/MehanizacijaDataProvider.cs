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
    public static class MehanizacijaDataProvider
    {
        public static async Task<Result<List<MehanizacijaView>, ErrorMessage>> VratiMehanizacijeAsync()
        {
            List<MehanizacijaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Mehanizacija>().ListAsync())
                    .Select(l => new MehanizacijaView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja mehanizacije".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<MehanizacijaView, ErrorMessage>> vratiMehnizacijuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Mehanizacija? meh = await s.QueryOver<Mehanizacija>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (meh == null)
                    return "Mehanizacija ne postoji.".ToError(404);

                return new MehanizacijaView(meh);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja mehanizacije.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<MehanizacijaView, ErrorMessage>> DodajMehanizacijuAsync(MehanizacijaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Mehanizacija meh = new Mehanizacija
                {
                    Naziv = f.Naziv,
                    Tip = f.Tip,
                    DatumUvoza = f.DatumUvoza,
                    Proizvodjac = f.Proizvodjac,
                    RasponOdrzavanja = f.RasponOdrzavanja,
                    Lokacija = f.Lokacija,
                    Status = f.Status,
                    TipMehanizacije = f.TipMehanizacije
                    
                };

                await s.SaveOrUpdateAsync(meh);
                await s.FlushAsync();

                return new MehanizacijaView(meh);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje mehanizacije.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<MehanizacijaView, ErrorMessage>> izmeniMehanizacijuAsync(MehanizacijaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Mehanizacija? oprema = await s.QueryOver<Mehanizacija>().Where(x => x.Id == f.Id).SingleOrDefaultAsync();
                if (oprema == null)
                    return "Oprema ne postoji.".ToError();

                oprema.Naziv = f.Naziv;
                oprema.Tip = f.Tip;
                oprema.DatumUvoza = f.DatumUvoza;
                oprema.Proizvodjac = f.Proizvodjac;
                oprema.RasponOdrzavanja = f.RasponOdrzavanja;
                oprema.Lokacija = f.Lokacija;
                oprema.Status = f.Status;
                oprema.TipMehanizacije = f.TipMehanizacije;


                await s.UpdateAsync(oprema);
                await s.FlushAsync();

                return new MehanizacijaView(oprema);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene mehanizacije.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> ObrisiMehanizacijuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Mehanizacija? oprema = await s.QueryOver<Mehanizacija>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (oprema == null)
                    return "Mehanizacija ne postoji.".ToError(404);

                await s.DeleteAsync(oprema);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja opreme.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
    }
}
