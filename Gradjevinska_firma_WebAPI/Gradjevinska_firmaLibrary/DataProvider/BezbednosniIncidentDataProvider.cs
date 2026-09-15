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
    public static class BezbednosniIncidentDataProvider
    {
        public static async Task<Result<List<BezbednosniIncidentView>, ErrorMessage>> VratiSveBezbednosneIncidenteAsync()
        {
            List<BezbednosniIncidentView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguce otvoriti sesiju.".ToError(403);
                }

                data = (await s.QueryOver<BezbednosniIncident>().ListAsync())
                    .Select(f => new BezbednosniIncidentView(f))
                    .ToList();
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom prikupljanja  incidenata".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public static async Task<Result<BezbednosniIncidentView, ErrorMessage>> DodajBezbednosniIncidentAsync(BezbednosniIncidentView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                Projekat? projekat = await s.QueryOver<Projekat>()
                    .Where(x => x.ID == f.ProjekatID)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                Osoba? osoba = await s.QueryOver<Osoba>().Where(x=>x.Id == f.OsobaID).SingleOrDefaultAsync();

                if (osoba == null)
                    return "Osoba ne postoji.".ToError(404);

                BezbednosniIncident incident;
                switch (f.Tip_incidenta)
                {
                    case "Povreda na radu":
                        incident = new PovredaNaRadu();
                        break;

                    case "Kvar opreme":
                        incident = new KvarOpreme();
                        break;

                    case "Nepostovanje procedura":
                        incident = new NepostovanjeProcedura();
                        break;

                    case "Opasna situacija":
                        incident = new OpasnaSituacija();
                        break;

                    case "Ekoloski incident":
                        incident = new EkoloskiIncident();
                        break;

                    default:
                        return "Nepoznat tip incidenta.".ToError(400);
                }

                incident.Opis = f.Opis;
                incident.Datum = f.Datum;
                incident.Lokacija = f.Lokacija;
                incident.Preduzete_mere = f.Preduzete_mere;
                incident.Posledice = f.Posledice;
                incident.Tip_incidenta = f.Tip_incidenta;
                incident.Projekat = projekat;
                incident.Osoba = osoba;



                await s.SaveOrUpdateAsync(incident);
                await s.FlushAsync();

                return new BezbednosniIncidentView(incident);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dodavanja incidenta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<BezbednosniIncidentView, ErrorMessage>> vratiBezbednosniIncidentAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                BezbednosniIncident? incident = await s.QueryOver<BezbednosniIncident>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (incident == null)
                    return "Incident ne postoji.".ToError(404);

                return new BezbednosniIncidentView(incident);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobavljanja bezbednosnog incidenta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<BezbednosniIncidentView, ErrorMessage>> izmeniBezbednosniIncidentAsync(BezbednosniIncidentView f)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                BezbednosniIncident? incident = await s.QueryOver<BezbednosniIncident>()
                    .Where(x => x.ID == f.ID)
                    .SingleOrDefaultAsync();

                if (incident == null)
                    return "Faktura ne postoji.".ToError(404);

                Projekat? projekat = await s.QueryOver<Projekat>()
                    .Where(x => x.ID == f.ProjekatID)
                    .SingleOrDefaultAsync();

                if (projekat == null)
                    return "Projekat ne postoji.".ToError(404);

                Osoba? osoba = await s.QueryOver<Osoba>().Where(x=>x.Id == f.OsobaID).SingleOrDefaultAsync();
                if (osoba == null)
                    return "Osoba ne postoji.".ToError(404);

                incident.Opis = f.Opis;
                incident.Datum = f.Datum;
                incident.Lokacija = f.Lokacija;
                incident.Preduzete_mere = f.Preduzete_mere;
                incident.Posledice = f.Posledice;
                incident.Tip_incidenta = f.Tip_incidenta;
                incident.Projekat = projekat;
                incident.Osoba = osoba;

                await s.UpdateAsync(incident);
                await s.FlushAsync();

                return new BezbednosniIncidentView(incident);
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom izmene fakture.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> ObrisiBezbednosniIncidentAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                BezbednosniIncident? incident = await s.QueryOver<BezbednosniIncident>()
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();

                if (incident == null)
                    return "Incident ne postoji.".ToError(404);

                await s.DeleteAsync(incident);
                await s.FlushAsync();

                return true;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom brisanja incidenta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<List<BezbednosniIncidentView>, ErrorMessage>> VratiBezbednosneIncidenteProjektaAsync(int projekatId)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                    return "Nemoguce otvoriti sesiju.".ToError(403);

                List<BezbednosniIncidentView> data =
                    (await s.QueryOver<BezbednosniIncident>()
                        .Where(x => x.Projekat.ID == projekatId)
                        .ListAsync())
                    .Select(x => new BezbednosniIncidentView(x))
                    .ToList();

                if (data.Count == 0)
                    return "Projekat nema incidente.".ToError(404);

                return data;
            }
            catch (Exception)
            {
                return "Doslo je do greske prilikom dobijanja incidenta projekta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

    }
}
