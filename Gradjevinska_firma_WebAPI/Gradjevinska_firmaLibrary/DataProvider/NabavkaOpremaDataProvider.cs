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
    public static class NabavkaOpremaDataProvider
    {
        public static async Task<Result<List<NabavkaOpremaView>, ErrorMessage>> VratiNabavkeOpremaNabavkiAsync(int brNabavke)
        {
            List<NabavkaOpremaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<NabavkaOprema>()
                    .Where(k => k.Nabavka.Br_nabavke == brNabavke)
                    .ListAsync())
                    .Select(k => new NabavkaOpremaView(k))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Nabavka nema nabavku oprema".ToError(404);
                }

            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja nabavki oprema nabavki".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<NabavkaOpremaView>, ErrorMessage>> VratiSveNabavkeOpremaAsync()
        {
            List<NabavkaOpremaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<NabavkaOprema>().ListAsync())
                    .Select(l => new NabavkaOpremaView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja nabavki oprema".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<NabavkaOpremaView, ErrorMessage>> vratiNabavkuOpremeAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                NabavkaOprema? op = await s.QueryOver<NabavkaOprema>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (op == null)
                    return "Nabavka opreme ne postoji.".ToError(404);

                return new NabavkaOpremaView(op);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja nabavki opreme.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<NabavkaOpremaView, ErrorMessage>> DodajNabavkuOpremeAsync(NabavkaOpremaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Oprema? oprema = await s.QueryOver<Oprema>()
                    .Where(x => x.Id == f.OpremaId)
                    .SingleOrDefaultAsync();
                if (oprema == null)
                    return "Oprema ne postoji.".ToError(404);
                Nabavke? nabavka = await s.QueryOver<Nabavke>().Where(x=>x.Br_nabavke == f.NabavkaId).SingleOrDefaultAsync();
                if (nabavka == null)
                    return "Nabavka ne postoji.".ToError(404);

                NabavkaOprema op = new NabavkaOprema
                {
                    Kolicina = f.Kolicina,
                    Cena = f.Cena,
                    Status_isporuke = f.Status_isporuke,
                    Oprema = oprema,
                    Nabavka = nabavka
                };

                await s.SaveOrUpdateAsync(op);
                await s.FlushAsync();

                return new NabavkaOpremaView(op);
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

        public static async Task<Result<NabavkaOpremaView, ErrorMessage>> izmeniNabavkuOpremeAsync(NabavkaOpremaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                NabavkaOprema? op = await s.QueryOver<NabavkaOprema>().Where(x => x.ID == f.ID).SingleOrDefaultAsync();
                if (op == null)
                    return "Nabavka opreme ne postoji.".ToError();

                Nabavke? nabavka = await s.QueryOver<Nabavke>()
                    .Where(x => x.Br_nabavke == f.NabavkaId)
                    .SingleOrDefaultAsync();

                if (nabavka == null)
                    return "Nabavka ne postoji.".ToError(404);

                Oprema? oprema = await s.QueryOver<Oprema>().Where(x=>x.Id == f.OpremaId).SingleOrDefaultAsync();

                op.Kolicina = f.Kolicina;
                op.Cena = f.Cena;
                op.Status_isporuke = f.Status_isporuke;
                op.Oprema = oprema;
                op.Nabavka = nabavka;


                await s.UpdateAsync(op);
                await s.FlushAsync();

                return new NabavkaOpremaView(op);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene nabavke opreme.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> ObrisiNabavkuOpremeAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                NabavkaOprema? op = await s.QueryOver<NabavkaOprema>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (op == null)
                    return "Nabavka opreme ne postoji.".ToError(404);

                await s.DeleteAsync(op);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja nabavke opreme.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
    }
}
