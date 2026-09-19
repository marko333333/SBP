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
    public static class OsobaDataProvider
    {
        #region Osoba
        public static async Task<Result<List<OsobaView>, ErrorMessage>>VratiSveOsobeAsync()
        {
            List<OsobaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Osoba>().ListAsync())
                    .Select(o => new OsobaView(o))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja osoba.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<OsobaView, ErrorMessage>> VratiOsobuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Osoba? osoba = await s.QueryOver<Osoba>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (osoba == null)
                    return "Osoba ne postoji.".ToError(404);

                if (osoba is FizickoLice fizickoLice)
                    return new FizickoLiceView(fizickoLice);

                if (osoba is PravnaLica pravnaLica)
                    return new PravnaLicaView(pravnaLica);

                return new OsobaView(osoba);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobijanja osobe.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>>ObrisiOsobuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Osoba osoba = await s.LoadAsync<Osoba>(id);

                await s.DeleteAsync(osoba);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja osobe.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        #endregion

        #region FizickoLice

        public static async Task<Result<List<FizickoLiceView>, ErrorMessage>> VratiSvaFizickaLicaAsync()
        {
            List<FizickoLiceView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<FizickoLice>().ListAsync())
                    .Select(f => new FizickoLiceView(f))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja fizickih lica.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<FizickoLiceView, ErrorMessage>> vratiFizickoLiceAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                FizickoLice? lice = await s.QueryOver<FizickoLice>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (lice == null)
                    return "Fizicko licene postoji.".ToError(404);

                return new FizickoLiceView(lice);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja fizickog lica.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<FizickoLiceView, ErrorMessage>>DodajFizickoLiceAsync(FizickoLiceView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                FizickoLice fizickoLice = new FizickoLice
                {
                    Jmbg = f.Jmbg,
                    Ime = f.Ime,
                    Prezime = f.Prezime,
                    DatumRodjenja = f.DatumRodjenja,
                    Struka = f.Struka,

                    FlagBK = f.FlagBK,
                    FlagR = f.FlagR,
                    Kvalifikacija = f.Kvalifikacija,
                    FlagI = f.FlagI,
                    OblastRada = f.OblastRada,
                    Odgovornosti = f.Odgovornosti,
                    FlagA = f.FlagA,
                    FlagP = f.FlagP,
                    FlagN = f.FlagN,
                    FlagAO = f.FlagAO
                };

                await s.SaveOrUpdateAsync(fizickoLice);
                await s.FlushAsync();

                return new FizickoLiceView(fizickoLice);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanja fizickog lica.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<FizickoLiceView, ErrorMessage>>IzmeniFizickoLiceAsync(FizickoLiceView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                FizickoLice fizickoLice = await s.LoadAsync<FizickoLice>(f.Id);

                fizickoLice.Jmbg = f.Jmbg;
                fizickoLice.Ime = f.Ime;
                fizickoLice.Prezime = f.Prezime;
                fizickoLice.DatumRodjenja = f.DatumRodjenja;
                fizickoLice.Struka = f.Struka;

                fizickoLice.FlagBK = f.FlagBK;
                fizickoLice.FlagR = f.FlagR;
                fizickoLice.Kvalifikacija = f.Kvalifikacija;
                fizickoLice.FlagI = f.FlagI;
                fizickoLice.OblastRada = f.OblastRada;
                fizickoLice.Odgovornosti = f.Odgovornosti;
                fizickoLice.FlagA = f.FlagA;
                fizickoLice.FlagP = f.FlagP;
                fizickoLice.FlagN = f.FlagN;
                fizickoLice.FlagAO = f.FlagAO;

                await s.UpdateAsync(fizickoLice);
                await s.FlushAsync();

                return new FizickoLiceView(fizickoLice);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene fizickog lica.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiFizickoLiceAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                FizickoLice? lice = await s.QueryOver<FizickoLice>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (lice == null)
                    return "Fizicko lice ne postoji.".ToError(404);

                await s.DeleteAsync(lice);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja fizickog lica.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }


        #endregion

        #region PravnaLica

        public static async Task<Result<List<PravnaLicaView>, ErrorMessage>> VratiSvaPravnaLicaAsync()
        {
            List<PravnaLicaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<PravnaLica>().ListAsync())
                    .Select(p => new PravnaLicaView(p))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja pravnih lica.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<PravnaLicaView, ErrorMessage>> vratiPravnoLiceAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                PravnaLica? lice = await s.QueryOver<PravnaLica>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (lice == null)
                    return "Pravno licene postoji.".ToError(404);

                return new PravnaLicaView(lice);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja pravnog lica.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<PravnaLicaView, ErrorMessage>>DodajPravnoLiceAsync(PravnaLicaView p)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                PravnaLica pravnoLice = new PravnaLica
                {
                    Jmbg = p.Jmbg,
                    Ime = p.Ime,
                    Prezime = p.Prezime,
                    DatumRodjenja = p.DatumRodjenja,
                    Struka = p.Struka,

                    FlagPB = p.FlagPB,
                    FlagInve = p.FlagInve,
                    FlagIzv = p.FlagIzv,
                    FlagP = p.FlagP,
                    FlagD = p.FlagD,
                    FlagN = p.FlagN
                };

                await s.SaveOrUpdateAsync(pravnoLice);
                await s.FlushAsync();

                return new PravnaLicaView(pravnoLice);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanja pravnog lica.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<PravnaLicaView, ErrorMessage>>IzmeniPravnoLiceAsync(PravnaLicaView p)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                PravnaLica pravnoLice = await s.LoadAsync<PravnaLica>(p.Id);

                pravnoLice.Jmbg = p.Jmbg;
                pravnoLice.Ime = p.Ime;
                pravnoLice.Prezime = p.Prezime;
                pravnoLice.DatumRodjenja = p.DatumRodjenja;
                pravnoLice.Struka = p.Struka;

                pravnoLice.FlagPB = p.FlagPB;
                pravnoLice.FlagInve = p.FlagInve;
                pravnoLice.FlagIzv = p.FlagIzv;
                pravnoLice.FlagP = p.FlagP;
                pravnoLice.FlagD = p.FlagD;
                pravnoLice.FlagN = p.FlagN;

                await s.UpdateAsync(pravnoLice);
                await s.FlushAsync();

                return new PravnaLicaView(pravnoLice);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene pravnog lica.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiPravnoLiceAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                PravnaLica? lice = await s.QueryOver<PravnaLica>()
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (lice == null)
                    return "Pravno lice ne postoji.".ToError(404);

                await s.DeleteAsync(lice);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja pravnog lica.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }


        #endregion
    }

}
