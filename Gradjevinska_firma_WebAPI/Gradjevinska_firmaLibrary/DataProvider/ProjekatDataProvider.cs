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
    public static class ProjekatDataProvider
    {
        #region Projekat
        public static async Task<Result<List<ProjekatView>, ErrorMessage>> vratiSveProjekte()
        {
            List<ProjekatView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Projekat>().ListAsync())
                    .Select(l => new ProjekatView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja projekata".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<ProjekatView, ErrorMessage>> vratiProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Projekat? projekat = await s.QueryOver<Projekat>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                return new ProjekatView(projekat);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Projekat? projekat = await s.QueryOver<Projekat>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                await s.DeleteAsync(projekat);
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
        #endregion

        #region Stambeni

        public static async Task<Result<List<StambeniView>, ErrorMessage>> vratiSveStambene()
        {
            List<StambeniView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Stambeni>().ListAsync())
                    .Select(l => new StambeniView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja stambenih projekata".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<StambeniView, ErrorMessage>> vratiStambeniProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Stambeni? projekat = await s.QueryOver<Stambeni>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                return new StambeniView(projekat);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja stambenog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<StambeniView, ErrorMessage>> DodajStambeniProjekatAsync(StambeniView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Stambeni stan = new Stambeni
                {
                    Naziv = f.Naziv,
                    Opis = f.Opis,
                    Lokacija = f.Lokacija,
                    Datum_pocetka = f.Datum_pocetka,
                    Budzet = f.Budzet,
                    Status = f.Status,
                    Planirani_Zavrsetak = f.Planirani_Zavrsetak,
                    Stvarni_Zavrsetak = f.Stvarni_Zavrsetak


                };

                await s.SaveOrUpdateAsync(stan);
                await s.FlushAsync();

                return new StambeniView(stan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje stambenog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<StambeniView, ErrorMessage>> izmeniStambeniProjekatAsync(StambeniView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Stambeni? stan = await s.QueryOver<Stambeni>().Where(x => x.ID == f.ID).SingleOrDefaultAsync();
                if (stan == null)
                    return "Nepostojeci projekat".ToError();


                stan.Naziv = f.Naziv;
                stan.Opis = f.Opis;
                stan.Lokacija = f.Lokacija;
                stan.Datum_pocetka = f.Datum_pocetka;
                stan.Budzet = f.Budzet;
                stan.Status = f.Status;
                stan.Planirani_Zavrsetak = f.Planirani_Zavrsetak;
                stan.Stvarni_Zavrsetak = f.Stvarni_Zavrsetak;

                await s.UpdateAsync(stan);
                await s.FlushAsync();

                return new StambeniView(stan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene stambenog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiStambeniProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Stambeni? stan = await s.QueryOver<Stambeni>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (stan == null)
                    return "Stambeni projekat ne postoji.".ToError(404);

                await s.DeleteAsync(stan);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja stambenog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        #endregion

        #region Sanacija

        public static async Task<Result<List<SanacijaView>, ErrorMessage>> vratiSveSanacije()
        {
            List<SanacijaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Sanacija>().ListAsync())
                    .Select(l => new SanacijaView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja sanacija projekata".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<SanacijaView, ErrorMessage>> vratiSanacijuProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Sanacija? projekat = await s.QueryOver<Sanacija>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                return new SanacijaView(projekat);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja sanacije projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<SanacijaView, ErrorMessage>> DodajSanacijaProjekatAsync(SanacijaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Sanacija stan = new Sanacija
                {
                    Naziv = f.Naziv,
                    Opis = f.Opis,
                    Lokacija = f.Lokacija,
                    Datum_pocetka = f.Datum_pocetka,
                    Budzet = f.Budzet,
                    Status = f.Status,
                    Planirani_Zavrsetak = f.Planirani_Zavrsetak,
                    Stvarni_Zavrsetak = f.Stvarni_Zavrsetak


                };

                await s.SaveOrUpdateAsync(stan);
                await s.FlushAsync();

                return new SanacijaView(stan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje stambenog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<SanacijaView, ErrorMessage>> izmeniSanacijaProjekatAsync(SanacijaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Sanacija? stan = await s.QueryOver<Sanacija>().Where(x => x.ID == f.ID).SingleOrDefaultAsync();
                if (stan == null)
                    return "Nepostojeci projekat".ToError();


                stan.Naziv = f.Naziv;
                stan.Opis = f.Opis;
                stan.Lokacija = f.Lokacija;
                stan.Datum_pocetka = f.Datum_pocetka;
                stan.Budzet = f.Budzet;
                stan.Status = f.Status;
                stan.Planirani_Zavrsetak = f.Planirani_Zavrsetak;
                stan.Stvarni_Zavrsetak = f.Stvarni_Zavrsetak;

                await s.UpdateAsync(stan);
                await s.FlushAsync();

                return new SanacijaView(stan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene sanacije projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiSanacijaProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Sanacija? stan = await s.QueryOver<Sanacija>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (stan == null)
                    return "Sanacija projekat ne postoji.".ToError(404);

                await s.DeleteAsync(stan);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja sanacijskog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        #endregion

        #region Rekonstrukcija

        public static async Task<Result<List<RekonstrukcijaView>, ErrorMessage>> vratiSveRekonstrukcije()
        {
            List<RekonstrukcijaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Rekonstrukcija>().ListAsync())
                    .Select(l => new RekonstrukcijaView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja rekonstrukcije projekata".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<RekonstrukcijaView, ErrorMessage>> vratiRekonstrukcijuProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Rekonstrukcija? projekat = await s.QueryOver<Rekonstrukcija>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                return new RekonstrukcijaView(projekat);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja rekonstrukcije projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<RekonstrukcijaView, ErrorMessage>> DodajRekonstrukcijaProjekatAsync(RekonstrukcijaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Rekonstrukcija stan = new Rekonstrukcija
                {
                    Naziv = f.Naziv,
                    Opis = f.Opis,
                    Lokacija = f.Lokacija,
                    Datum_pocetka = f.Datum_pocetka,
                    Budzet = f.Budzet,
                    Status = f.Status,
                    Planirani_Zavrsetak = f.Planirani_Zavrsetak,
                    Stvarni_Zavrsetak = f.Stvarni_Zavrsetak


                };

                await s.SaveOrUpdateAsync(stan);
                await s.FlushAsync();

                return new RekonstrukcijaView(stan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje rekonstrukcije projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<RekonstrukcijaView, ErrorMessage>> izmeniRekonstrukcijuProjekatAsync(RekonstrukcijaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Rekonstrukcija? stan = await s.QueryOver<Rekonstrukcija>().Where(x => x.ID == f.ID).SingleOrDefaultAsync();
                if (stan == null)
                    return "Nepostojeci projekat".ToError();


                stan.Naziv = f.Naziv;
                stan.Opis = f.Opis;
                stan.Lokacija = f.Lokacija;
                stan.Datum_pocetka = f.Datum_pocetka;
                stan.Budzet = f.Budzet;
                stan.Status = f.Status;
                stan.Planirani_Zavrsetak = f.Planirani_Zavrsetak;
                stan.Stvarni_Zavrsetak = f.Stvarni_Zavrsetak;

                await s.UpdateAsync(stan);
                await s.FlushAsync();

                return new RekonstrukcijaView(stan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene rekonstrukcije projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiRekonstrukcijaProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Rekonstrukcija? stan = await s.QueryOver<Rekonstrukcija>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (stan == null)
                    return "Rekonstrukcijski projekat ne postoji.".ToError(404);

                await s.DeleteAsync(stan);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja rekonstrukcijskog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        #endregion

        #region Industrijski

        public static async Task<Result<List<IndustrijskiView>, ErrorMessage>> vratiSveIndustrijskeProjekte()
        {
            List<IndustrijskiView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Industrijski>().ListAsync())
                    .Select(l => new IndustrijskiView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja industrijskih projekata".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<IndustrijskiView, ErrorMessage>> vratiIndustrijskiProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Industrijski? projekat = await s.QueryOver<Industrijski>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                return new IndustrijskiView(projekat);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja industrijskog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<IndustrijskiView, ErrorMessage>> DodajIndustrijskiProjekatAsync(IndustrijskiView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Industrijski stan = new Industrijski
                {
                    Naziv = f.Naziv,
                    Opis = f.Opis,
                    Lokacija = f.Lokacija,
                    Datum_pocetka = f.Datum_pocetka,
                    Budzet = f.Budzet,
                    Status = f.Status,
                    Planirani_Zavrsetak = f.Planirani_Zavrsetak,
                    Stvarni_Zavrsetak = f.Stvarni_Zavrsetak


                };

                await s.SaveOrUpdateAsync(stan);
                await s.FlushAsync();

                return new IndustrijskiView(stan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje industrijskog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<IndustrijskiView, ErrorMessage>> izmeniIndustrijskiProjekatAsync(IndustrijskiView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Industrijski? stan = await s.QueryOver<Industrijski>().Where(x => x.ID == f.ID).SingleOrDefaultAsync();
                if (stan == null)
                    return "Nepostojeci projekat".ToError();


                stan.Naziv = f.Naziv;
                stan.Opis = f.Opis;
                stan.Lokacija = f.Lokacija;
                stan.Datum_pocetka = f.Datum_pocetka;
                stan.Budzet = f.Budzet;
                stan.Status = f.Status;
                stan.Planirani_Zavrsetak = f.Planirani_Zavrsetak;
                stan.Stvarni_Zavrsetak = f.Stvarni_Zavrsetak;

                await s.UpdateAsync(stan);
                await s.FlushAsync();

                return new IndustrijskiView(stan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene industrijskog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiIndustrijskiProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Industrijski? stan = await s.QueryOver<Industrijski>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (stan == null)
                    return "Industrijski projekat ne postoji.".ToError(404);

                await s.DeleteAsync(stan);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja industrijskog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        #endregion

        #region Infrastruktura

        public static async Task<Result<List<InfrastrukturaView>, ErrorMessage>> vratiSveInfrastrukturaProjekte()
        {
            List<InfrastrukturaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Infrastruktura>().ListAsync())
                    .Select(l => new InfrastrukturaView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja infrastrukturnih projekata".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<InfrastrukturaView, ErrorMessage>> vratiInfrastrukturniProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Infrastruktura? projekat = await s.QueryOver<Infrastruktura>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                return new InfrastrukturaView(projekat);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja infrastrukturnog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<InfrastrukturaView, ErrorMessage>> DodajInfrastrukturniProjekatAsync(InfrastrukturaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Infrastruktura stan = new Infrastruktura
                {
                    Naziv = f.Naziv,
                    Opis = f.Opis,
                    Lokacija = f.Lokacija,
                    Datum_pocetka = f.Datum_pocetka,
                    Budzet = f.Budzet,
                    Status = f.Status,
                    Planirani_Zavrsetak = f.Planirani_Zavrsetak,
                    Stvarni_Zavrsetak = f.Stvarni_Zavrsetak


                };

                await s.SaveOrUpdateAsync(stan);
                await s.FlushAsync();

                return new InfrastrukturaView(stan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje infrastrukturnog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<InfrastrukturaView, ErrorMessage>> izmeniInfrastrukturniProjekatAsync(InfrastrukturaView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Infrastruktura? stan = await s.QueryOver<Infrastruktura>().Where(x => x.ID == f.ID).SingleOrDefaultAsync();
                if (stan == null)
                    return "Nepostojeci projekat".ToError();


                stan.Naziv = f.Naziv;
                stan.Opis = f.Opis;
                stan.Lokacija = f.Lokacija;
                stan.Datum_pocetka = f.Datum_pocetka;
                stan.Budzet = f.Budzet;
                stan.Status = f.Status;
                stan.Planirani_Zavrsetak = f.Planirani_Zavrsetak;
                stan.Stvarni_Zavrsetak = f.Stvarni_Zavrsetak;

                await s.UpdateAsync(stan);
                await s.FlushAsync();

                return new InfrastrukturaView(stan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene infrasturkturnog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiInfrastukturniProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Infrastruktura? stan = await s.QueryOver<Infrastruktura>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (stan == null)
                    return "Infrasturkturni projekat ne postoji.".ToError(404);

                await s.DeleteAsync(stan);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja infrastrukturnog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        #endregion

        #region Poslovni

        public static async Task<Result<List<PoslovniView>, ErrorMessage>> vratiSvePoslovneProjekte()
        {
            List<PoslovniView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<Poslovni>().ListAsync())
                    .Select(l => new PoslovniView(l))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja poslovnih projekata".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<PoslovniView, ErrorMessage>> vratiPoslovniProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Poslovni? projekat = await s.QueryOver<Poslovni>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                return new PoslovniView(projekat);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja poslovnog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<PoslovniView, ErrorMessage>> DodajPoslovniProjekatAsync(PoslovniView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                Poslovni stan = new Poslovni
                {
                    Naziv = f.Naziv,
                    Opis = f.Opis,
                    Lokacija = f.Lokacija,
                    Datum_pocetka = f.Datum_pocetka,
                    Budzet = f.Budzet,
                    Status = f.Status,
                    Planirani_Zavrsetak = f.Planirani_Zavrsetak,
                    Stvarni_Zavrsetak = f.Stvarni_Zavrsetak


                };

                await s.SaveOrUpdateAsync(stan);
                await s.FlushAsync();

                return new PoslovniView(stan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanje poslovnog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<PoslovniView, ErrorMessage>> izmeniPoslovniProjekatAsync(PoslovniView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Poslovni? stan = await s.QueryOver<Poslovni>().Where(x => x.ID == f.ID).SingleOrDefaultAsync();
                if (stan == null)
                    return "Nepostojeci projekat".ToError();


                stan.Naziv = f.Naziv;
                stan.Opis = f.Opis;
                stan.Lokacija = f.Lokacija;
                stan.Datum_pocetka = f.Datum_pocetka;
                stan.Budzet = f.Budzet;
                stan.Status = f.Status;
                stan.Planirani_Zavrsetak = f.Planirani_Zavrsetak;
                stan.Stvarni_Zavrsetak = f.Stvarni_Zavrsetak;

                await s.UpdateAsync(stan);
                await s.FlushAsync();

                return new PoslovniView(stan);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene poslovnog projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> obrisiPoslovniProjekatAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Poslovni? stan = await s.QueryOver<Poslovni>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (stan == null)
                    return "Poslovni projekat ne postoji.".ToError(404);

                await s.DeleteAsync(stan);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja poslovnog projekta.".ToError(400);
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
