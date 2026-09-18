using Gradjevinska_firmaLibrary.Data;
using Gradjevinska_firmaLibrary.DTOs;
using Gradjevinska_firmaLibrary.Entiteti;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firmaLibrary.DataProvider
{
    public static class PosebneKlauzuleDataProvider
    {
        public static async Task<Result<List<PosebnaKlauzulaView>, ErrorMessage>> VratiPosebneKlauzuleUgovoraAsync(int idUgovor)
        {
            List<PosebnaKlauzulaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<PosebnaKlauzula>()
                    .Where(k => k.Ugovor.Id == idUgovor)
                    .ListAsync())
                    .Select(k => new PosebnaKlauzulaView(k))
                    .ToList();

                if (data.Count == 0)
                {
                    return "Ugovor nema posebne klauzule".ToError(404);
                }
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja posebnih klauzula ugovora".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<List<PosebnaKlauzulaView>, ErrorMessage>> VratiKlauzuleAsync()
        {
            List<PosebnaKlauzulaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<PosebnaKlauzula>().ListAsync())
                    .Select(l => new PosebnaKlauzulaView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja posebnih klauzula".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<PosebnaKlauzulaView, ErrorMessage>> vratiKlauzuluAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                PosebnaKlauzula? klauzula = await s.QueryOver<PosebnaKlauzula>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (klauzula == null)
                    return "Klauzula ne postoji.".ToError(404);

                return new PosebnaKlauzulaView(klauzula);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja posebne klauzule.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<PosebnaKlauzulaView, ErrorMessage>> DodajKlauzuluAsync(PosebnaKlauzulaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Ugovor? ugovor = await s.QueryOver<Ugovor>()
                    .Where(x => x.Id == f.UgovorId)
                    .SingleOrDefaultAsync();

                PosebnaKlauzula klkauzula = new PosebnaKlauzula
                {
                    TekstKlauzule = f.TekstKlauzule,
                    Ugovor = ugovor,
                };

                await s.SaveOrUpdateAsync(klkauzula);
                await s.FlushAsync();

                return new PosebnaKlauzulaView(klkauzula);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje radnog naloga.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<PosebnaKlauzulaView, ErrorMessage>> izmeniKlauzuluAsync(PosebnaKlauzulaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                PosebnaKlauzula? klauzula = await s.QueryOver<PosebnaKlauzula>().Where(x => x.Id == f.Id).SingleOrDefaultAsync();
                if (klauzula == null)
                    return "Klauzula ne postoji.".ToError();

                Ugovor? ugovor = await s.QueryOver<Ugovor>()
                    .Where(x => x.Id == f.UgovorId)
                    .SingleOrDefaultAsync();

                if (ugovor == null)
                    return "Ugovor ne postoji.".ToError(404);

                klauzula.TekstKlauzule = f.TekstKlauzule;
                klauzula.Ugovor = ugovor;

                await s.UpdateAsync(klauzula);
                await s.FlushAsync();

                return new PosebnaKlauzulaView(klauzula);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene posebne klauzule.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> ObrisiPosebnuKlauzuluAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                PosebnaKlauzula? kl = await s.QueryOver<PosebnaKlauzula>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (kl == null)
                    return "Klauzula ne postoji.".ToError(404);

                await s.DeleteAsync(kl);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja posebne klauzule.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
    }
}
