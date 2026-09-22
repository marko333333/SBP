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
    public class LicencaDTOManager
    {
        public static List<LicencaBasic> vratiLicenceOsobe(int idOsobe)
        {
            List<LicencaBasic> licence = new List<LicencaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Licenca> sveLicence =
                    from l in s.Query<Licenca>()
                    where l.Osoba.Id == idOsobe
                    select l;

                foreach (Licenca l in sveLicence)
                {
                    licence.Add(
                        new LicencaBasic(
                            l.Id,
                            l.Osoba.Id,
                            l.NazivLicence));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return licence;
        }

        public static LicencaBasic vratiLicencu(int id)
        {
            LicencaBasic licenca = new LicencaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Licenca l = s.Load<Licenca>(id);

                licenca = new LicencaBasic(
                        l.Id, l.Osoba.Id, l.NazivLicence);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return licenca;
        }
        public static void dodajLicencu(LicencaBasic l)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Osoba osoba = s.Load<Osoba>(l.IdOsoba);

                Licenca licenca = new Licenca();

                licenca.Osoba = osoba;
                licenca.NazivLicence = l.NazivLicence;

                s.Save(licenca);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniLicencu(LicencaBasic l)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Licenca licenca = s.Load<Licenca>(l.Id);

                licenca.NazivLicence = l.NazivLicence;

                s.Update(licenca);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiLicencu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Licenca licenca = s.Load<Licenca>(id);

                s.Delete(licenca);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }
    }
}
