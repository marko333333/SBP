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
    public static class NabavkaMaterijalDataProvider
    {
        public static async Task<Result<List<NabavkaMaterijalView>, ErrorMessage>> VratiNabavkeMaterijalNabavkiAsync(int brNabavke)
        {
            List<NabavkaMaterijalView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<NabavkaMaterijal>()
                    .Where(k => k.Nabavke.Br_nabavke == brNabavke)
                    .ListAsync())
                    .Select(k => new NabavkaMaterijalView(k))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Nabavka nema nabavku materijala".ToError(404);
                }

            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja nabavki materijala nabavki".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<NabavkaMaterijalView>, ErrorMessage>> VratiNabavkeMaterijalMaterijalaAsync(int idMaterijala)
        {
            List<NabavkaMaterijalView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<NabavkaMaterijal>()
                    .Where(k => k.Materijal.ID == idMaterijala)
                    .ListAsync())
                    .Select(k => new NabavkaMaterijalView(k))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Materijal nema nabavku materijala".ToError(404);
                }

            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja nabavki materijala nabavki".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<NabavkaMaterijalView>, ErrorMessage>> VratiSveNabavkeMaterijalAsync()
        {
            List<NabavkaMaterijalView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<NabavkaMaterijal>().ListAsync())
                    .Select(l => new NabavkaMaterijalView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja nabavki materijala".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<NabavkaMaterijalView, ErrorMessage>> vratiNabavkuMaterijalaAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                NabavkaMaterijal? op = await s.QueryOver<NabavkaMaterijal>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (op == null)
                    return "Nabavka materijala ne postoji.".ToError(404);

                return new NabavkaMaterijalView(op);
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

        public static async Task<Result<NabavkaMaterijalView, ErrorMessage>> DodajNabavkuMaterijalaAsync(NabavkaMaterijalView f)
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
                if (materijal == null)
                    return "Materijal ne postoji.".ToError(404);
                Nabavke? nabavka = await s.QueryOver<Nabavke>().Where(x => x.Br_nabavke == f.NabavkeId).SingleOrDefaultAsync();
                if (nabavka == null)
                    return "Nabavka ne postoji.".ToError(404);

                NabavkaMaterijal op = new NabavkaMaterijal
                {
                    Kolicina = f.Kolicina,
                    Cena = f.Cena,
                    Status_isporuke = f.Status_isporuke,
                    Materijal = materijal,
                    Nabavke = nabavka
                };

                await s.SaveOrUpdateAsync(op);
                await s.FlushAsync();

                return new NabavkaMaterijalView(op);
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

        public static async Task<Result<NabavkaMaterijalView, ErrorMessage>> izmeniNabavkuMaterijalaAsync(NabavkaMaterijalView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                NabavkaMaterijal? op = await s.QueryOver<NabavkaMaterijal>().Where(x => x.ID == f.ID).SingleOrDefaultAsync();
                if (op == null)
                    return "Nabavka materijala ne postoji.".ToError();

                Nabavke? nabavka = await s.QueryOver<Nabavke>()
                    .Where(x => x.Br_nabavke == f.NabavkeId)
                    .SingleOrDefaultAsync();

                if (nabavka == null)
                    return "Nabavka ne postoji.".ToError(404);

                Materijal? materijal = await s.QueryOver<Materijal>().Where(x => x.ID == f.MaterijalId).SingleOrDefaultAsync();

                op.Kolicina = f.Kolicina;
                op.Cena = f.Cena;
                op.Status_isporuke = f.Status_isporuke;
                op.Materijal = materijal;
                op.Nabavke = nabavka;


                await s.UpdateAsync(op);
                await s.FlushAsync();

                return new NabavkaMaterijalView(op);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene nabavke materijala.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> ObrisiNabavkuMaterijalaAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                NabavkaMaterijal? op = await s.QueryOver<NabavkaMaterijal>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (op == null)
                    return "Nabavka materijala ne postoji.".ToError(404);

                await s.DeleteAsync(op);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja nabavke materijala.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
    }
}
