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
    public static class MaterijalDataProvider
    {
        public static async Task<Result<List<MaterijalView>, ErrorMessage>> vratiSveMaterijale()
        {
            List<MaterijalView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Materijal>().ListAsync())
                    .Select(l => new MaterijalView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja materijala".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<MaterijalView, ErrorMessage>> vratiMaterijalAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Materijal? mat = await s.QueryOver<Materijal>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (mat == null)
                    return "Materijal ne postoji.".ToError(404);

                return new MaterijalView(mat);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja materijala.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiMaterijalAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Materijal? mat = await s.QueryOver<Materijal>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (mat == null)
                    return "Materijal ne postoji.".ToError(404);

                await s.DeleteAsync(mat);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }


        #region Zastitni

        public static async Task<Result<List<ZastitniView>, ErrorMessage>> vratiSveZastitne()
        {
            List<ZastitniView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Zastitni>().ListAsync())
                    .Select(l => new ZastitniView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja zastitnih materijala".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<ZastitniView, ErrorMessage>> vratiZastitniMaterijalAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Zastitni? zas = await s.QueryOver<Zastitni>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (zas == null)
                    return "Zastitni materijal ne postoji.".ToError(404);

                return new ZastitniView(zas);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja zastitnog materijala.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<ZastitniView, ErrorMessage>> DodajZastitniMaterijalAsync(ZastitniView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Zastitni zas = new Zastitni
                {
                    Naziv = f.Naziv,
                    Cena = f.Cena,
                    Proizvodjac = f.Proizvodjac,
                    JedinicaMere = f.JedinicaMere,
                    Sertifikat = f.Sertifikat,
                    Tip = f.Tip
                };

                await s.SaveOrUpdateAsync(zas);
                await s.FlushAsync();

                return new ZastitniView(zas);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje zastitnog materijala.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<ZastitniView, ErrorMessage>> izmeniZastitniMaterijalAsync(ZastitniView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Zastitni? zas = await s.QueryOver<Zastitni>().Where(x => x.ID == f.ID).SingleOrDefaultAsync();
                if (zas == null)
                    return "Nepostojeci zastitni materijal".ToError();


                zas.Naziv = f.Naziv;
                zas.Cena = f.Cena;
                zas.Proizvodjac = f.Proizvodjac;
                zas.JedinicaMere = f.JedinicaMere;
                zas.Sertifikat = f.Sertifikat;
                zas.Tip = f.Tip;

                await s.UpdateAsync(zas);
                await s.FlushAsync();

                return new ZastitniView(zas);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene zastitnog materijala.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        #endregion


        #region Masinski

        public static async Task<Result<List<MasinskiView>, ErrorMessage>> vratiSveMasinske()
        {
            List<MasinskiView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Masinski>().ListAsync())
                    .Select(l => new MasinskiView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja masinskih materijala".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<MasinskiView, ErrorMessage>> vratiMasinskiMaterijalAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Masinski? mas = await s.QueryOver<Masinski>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (mas == null)
                    return "Masinski materijal ne postoji.".ToError(404);

                return new MasinskiView(mas);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja masinskog materijala.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<MasinskiView, ErrorMessage>> DodajMasinskiMaterijalAsync(MasinskiView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Masinski zas = new Masinski
                {
                    Naziv = f.Naziv,
                    Cena = f.Cena,
                    Proizvodjac = f.Proizvodjac,
                    JedinicaMere = f.JedinicaMere,
                    Sertifikat = f.Sertifikat,
                    Tip = f.Tip
                };

                await s.SaveOrUpdateAsync(zas);
                await s.FlushAsync();

                return new MasinskiView(zas);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje masinskog materijala.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<MasinskiView, ErrorMessage>> izmeniMasinskiMaterijalAsync(MasinskiView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Masinski? zas = await s.QueryOver<Masinski>().Where(x => x.ID == f.ID).SingleOrDefaultAsync();
                if (zas == null)
                    return "Nepostojeci masinski materijal".ToError();


                zas.Naziv = f.Naziv;
                zas.Cena = f.Cena;
                zas.Proizvodjac = f.Proizvodjac;
                zas.JedinicaMere = f.JedinicaMere;
                zas.Sertifikat = f.Sertifikat;
                zas.Tip = f.Tip;

                await s.UpdateAsync(zas);
                await s.FlushAsync();

                return new MasinskiView(zas);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene masinskog materijala.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        #endregion

        #region Gradjevinski

        public static async Task<Result<List<GradjevinskiView>, ErrorMessage>> vratiSveGradjevinske()
        {
            List<GradjevinskiView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Gradjevinski>().ListAsync())
                    .Select(l => new GradjevinskiView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja gradjevinskih materijala".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<GradjevinskiView, ErrorMessage>> vratiGradjevinskiMaterijalAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Gradjevinski? zas = await s.QueryOver<Gradjevinski>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (zas == null)
                    return "Gradjevinski materijal ne postoji.".ToError(404);

                return new GradjevinskiView(zas);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja gradjevinskog materijala.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<GradjevinskiView, ErrorMessage>> DodajGradjevinskiMaterijalAsync(GradjevinskiView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Gradjevinski zas = new Gradjevinski
                {
                    Naziv = f.Naziv,
                    Cena = f.Cena,
                    Proizvodjac = f.Proizvodjac,
                    JedinicaMere = f.JedinicaMere,
                    Sertifikat = f.Sertifikat,
                    Tip = f.Tip
                };

                await s.SaveOrUpdateAsync(zas);
                await s.FlushAsync();

                return new GradjevinskiView(zas);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje gradjevinskog materijala.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<GradjevinskiView, ErrorMessage>> izmeniGradjevinskiMaterijalAsync(GradjevinskiView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Gradjevinski? zas = await s.QueryOver<Gradjevinski>().Where(x => x.ID == f.ID).SingleOrDefaultAsync();
                if (zas == null)
                    return "Nepostojeci gradjevinski materijal".ToError();


                zas.Naziv = f.Naziv;
                zas.Cena = f.Cena;
                zas.Proizvodjac = f.Proizvodjac;
                zas.JedinicaMere = f.JedinicaMere;
                zas.Sertifikat = f.Sertifikat;
                zas.Tip = f.Tip;

                await s.UpdateAsync(zas);
                await s.FlushAsync();

                return new GradjevinskiView(zas);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene gradjevinskog materijala.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        #endregion

        #region Elektro

        public static async Task<Result<List<ElektroView>, ErrorMessage>> vratiSveElektro()
        {
            List<ElektroView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Elektro>().ListAsync())
                    .Select(l => new ElektroView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja elektro materijala".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<ElektroView, ErrorMessage>> vratiElektroMaterijalAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Elektro? zas = await s.QueryOver<Elektro>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (zas == null)
                    return "Elektro materijal ne postoji.".ToError(404);

                return new ElektroView(zas);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja elektro materijala.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<ElektroView, ErrorMessage>> DodajElektroMaterijalAsync(ElektroView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Elektro zas = new Elektro
                {
                    Naziv = f.Naziv,
                    Cena = f.Cena,
                    Proizvodjac = f.Proizvodjac,
                    JedinicaMere = f.JedinicaMere,
                    Sertifikat = f.Sertifikat,
                    Tip = f.Tip
                };

                await s.SaveOrUpdateAsync(zas);
                await s.FlushAsync();

                return new ElektroView(zas);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje elektro materijala.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<ElektroView, ErrorMessage>> izmeniElektroMaterijalAsync(ElektroView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Elektro? zas = await s.QueryOver<Elektro>().Where(x => x.ID == f.ID).SingleOrDefaultAsync();
                if (zas == null)
                    return "Nepostojeci elektro materijal".ToError();


                zas.Naziv = f.Naziv;
                zas.Cena = f.Cena;
                zas.Proizvodjac = f.Proizvodjac;
                zas.JedinicaMere = f.JedinicaMere;
                zas.Sertifikat = f.Sertifikat;
                zas.Tip = f.Tip;

                await s.UpdateAsync(zas);
                await s.FlushAsync();

                return new ElektroView(zas);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene elektro materijala.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        #endregion

        #region Zavrsni

        public static async Task<Result<List<ZavrsniView>, ErrorMessage>> vratiSveZavrsne()
        {
            List<ZavrsniView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Zavrsni>().ListAsync())
                    .Select(l => new ZavrsniView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja zavrsnih materijala".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<ZavrsniView, ErrorMessage>> vratiZavrsniMaterijalAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Zavrsni? zas = await s.QueryOver<Zavrsni>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (zas == null)
                    return "Zavrsni materijal ne postoji.".ToError(404);

                return new ZavrsniView(zas);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja zastitnog materijala.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<ZavrsniView, ErrorMessage>> DodajZavrsniMaterijalAsync(ZavrsniView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Zavrsni zas = new Zavrsni
                {
                    Naziv = f.Naziv,
                    Cena = f.Cena,
                    Proizvodjac = f.Proizvodjac,
                    JedinicaMere = f.JedinicaMere,
                    Sertifikat = f.Sertifikat,
                    Tip = f.Tip
                };

                await s.SaveOrUpdateAsync(zas);
                await s.FlushAsync();

                return new ZavrsniView(zas);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje zavrsnog materijala.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<ZavrsniView, ErrorMessage>> izmeniZavrsniMaterijalAsync(ZavrsniView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Zavrsni? zas = await s.QueryOver<Zavrsni>().Where(x => x.ID == f.ID).SingleOrDefaultAsync();
                if (zas == null)
                    return "Nepostojeci zavrsni materijal".ToError();


                zas.Naziv = f.Naziv;
                zas.Cena = f.Cena;
                zas.Proizvodjac = f.Proizvodjac;
                zas.JedinicaMere = f.JedinicaMere;
                zas.Sertifikat = f.Sertifikat;
                zas.Tip = f.Tip;

                await s.UpdateAsync(zas);
                await s.FlushAsync();

                return new ZavrsniView(zas);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene zavrsnog materijala.".ToError(400);
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
