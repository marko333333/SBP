using Gradjevinska_firma.Data;
using Gradjevinska_firma.DTO;
using Gradjevinska_firma.Entiteti;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.DTOManager
{
    public class BezbednosniIncidentDTOManager
    {
        #region BezbednosniIncident

        public static BezbednosniIncidentBasic vratiBezbednosniIncidentProjekta(int idIncidenta)
        {
            BezbednosniIncidentBasic incident = new BezbednosniIncidentBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                BezbednosniIncident b = s.Get<BezbednosniIncident>(idIncidenta);
                if (b != null)
                {
                    ProjekatBasic projekat = ProjekatDTOManager.vratiProjekat(b.Projekat.ID);
                    OsobaBasic osoba = OsobaDTOManager.vratiOsobu(b.Osoba.Id);

                    incident = new BezbednosniIncidentBasic(
                        b.ID, b.Opis, b.Datum, b.Lokacija, b.Preduzete_mere,
                        b.Posledice, b.Tip_incidenta, projekat, osoba);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return incident;
        }

        public static List<BezbednosniIncidentBasic> vratiBezbednosniIncidenteProjekta(int idProjekta)
        {
            List<BezbednosniIncidentBasic> incidenti = new List<BezbednosniIncidentBasic>();

            try
            {
                ISession s = DataLayer.GetSession();


                IEnumerable<BezbednosniIncident> sviIncidenti =
                         from i in s.Query<BezbednosniIncident>()
                         where i.Projekat.ID == idProjekta
                         select i;

                foreach (BezbednosniIncident i in sviIncidenti)
                {
                    ProjekatBasic projekat = new ProjekatBasic(
                        i.Projekat.ID,
                        i.Projekat.Naziv,
                        i.Projekat.Opis,
                        i.Projekat.Lokacija,
                        i.Projekat.Datum_pocetka,
                        i.Projekat.Budzet,
                        i.Projekat.Status,
                        i.Projekat.Planirani_Zavrsetak,
                        i.Projekat.Stvarni_Zavrsetak
                    );
                    OsobaBasic osoba = new OsobaBasic(
                        i.Osoba.Id,
                        i.Osoba.Jmbg,
                        i.Osoba.Ime,
                        i.Osoba.Prezime,
                        i.Osoba.DatumRodjenja,
                        i.Osoba.Struka
                        );

                    incidenti.Add(new BezbednosniIncidentBasic(i.ID, i.Opis, i.Datum, i.Lokacija, i.Preduzete_mere, i.Posledice, i.Tip_incidenta, projekat, osoba));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return incidenti;
        }

        public static List<BezbednosniIncidentBasic> vratiBezbednosniIncidentOsobe(int idOsobe)
        {
            List<BezbednosniIncidentBasic> incidenti = new List<BezbednosniIncidentBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<BezbednosniIncident> sviIncidenti =
                    from i in s.Query<BezbednosniIncident>()
                    where i.Osoba.Id == idOsobe
                    select i;

                foreach (BezbednosniIncident i in sviIncidenti)
                {
                    ProjekatBasic proj = new ProjekatBasic(
                        i.Projekat.ID,
                        i.Projekat.Naziv,
                        i.Projekat.Opis,
                        i.Projekat.Lokacija,
                        i.Projekat.Datum_pocetka,
                        i.Projekat.Budzet,
                        i.Projekat.Status,
                        i.Projekat.Planirani_Zavrsetak,
                        i.Projekat.Stvarni_Zavrsetak
                    );
                    OsobaBasic osob = new OsobaBasic(
                        i.Osoba.Id,
                        i.Osoba.Jmbg,
                        i.Osoba.Ime,
                        i.Osoba.Prezime,
                        i.Osoba.DatumRodjenja,
                        i.Osoba.Struka
                        );


                    incidenti.Add(new BezbednosniIncidentBasic(i.ID, i.Opis, i.Datum, i.Lokacija, i.Preduzete_mere, i.Posledice, i.Tip_incidenta, proj, osob));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return incidenti;
        }

        public static void obrisiBezbednosniIncident(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BezbednosniIncident inci = s.Load<BezbednosniIncident>(id);

                s.Delete(inci);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void dodajBezbednosniIncident(BezbednosniIncidentBasic d, string tipIncidenta)//proveri
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Osoba osoba = s.Get<Osoba>(d.Osoba.Id);

                if (osoba == null)
                {
                    MessageBox.Show("Osoba ne postoji.");
                    return;
                }

                Projekat projekat = s.Get<Projekat>(d.Projekat.ID);
                if (projekat == null)
                {
                    MessageBox.Show("Projekat ne postoji.");
                    return;
                }


                BezbednosniIncident incident = tipIncidenta switch
                {
                    "PovredaNaRadu" => new PovredaNaRadu(),
                    "KvarOpreme" => new KvarOpreme(),
                    "NepostovanjeProcedura" => new NepostovanjeProcedura(),
                    "OpasnaSituacija" => new OpasnaSituacija(),
                    "EkoloskiIncident" => new EkoloskiIncident(),
                    _ => throw new ArgumentException("Nepoznat tip incidenta.")
                };

                incident.Opis = d.Opis;
                incident.Datum = d.Datum;
                incident.Lokacija = d.Lokacija;
                incident.Preduzete_mere = d.Preduzete_mere;
                incident.Posledice = d.Posledice;
                incident.Tip_incidenta = d.Tip_incidenta;
                incident.Osoba = osoba;
                incident.Projekat = projekat;

                s.Save(incident);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniBezbednosniIncident(BezbednosniIncidentBasic inc)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                BezbednosniIncident b = s.Load<BezbednosniIncident>(inc.ID);

                b.Opis = inc.Opis;
                b.Datum = inc.Datum;
                b.Lokacija = inc.Lokacija;
                b.Preduzete_mere = inc.Preduzete_mere;
                b.Posledice = inc.Posledice;
                b.Tip_incidenta = inc.Tip_incidenta;



                s.Update(b);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion
    }
}
