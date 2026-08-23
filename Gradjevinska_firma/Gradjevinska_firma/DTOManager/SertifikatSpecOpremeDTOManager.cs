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
    public class SertifikatSpecOpremeDTOManager
    {
        public static List<SertifikatSpecOpremeBasic> vratiSertifikateSpecOpremeOsobe(int idOsobe)
        {
            List<SertifikatSpecOpremeBasic> sertifikati = new List<SertifikatSpecOpremeBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<SertifikatSpecOpreme> sviSertifikati =
                    from ss in s.Query<SertifikatSpecOpreme>()
                    where ss.FizickoLice.Id == idOsobe
                    select ss;

                foreach (SertifikatSpecOpreme ss in sviSertifikati)
                {
                    sertifikati.Add(new SertifikatSpecOpremeBasic(
                        ss.Id,
                        ss.FizickoLice.Id,
                        ss.Sertifikat));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return sertifikati;
        }

        public static SertifikatSpecOpremeBasic vratiSertifikat(int id)
        {
            SertifikatSpecOpremeBasic sertifkatspec = new SertifikatSpecOpremeBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                SertifikatSpecOpreme sso = s.Load<SertifikatSpecOpreme>(id);

                sertifkatspec = new SertifikatSpecOpremeBasic(
                        sso.Id, sso.FizickoLice.Id, sso.Sertifikat);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return sertifkatspec;
        }

        public static void dodajSertifikatSpecOpreme(SertifikatSpecOpremeBasic sso)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FizickoLice fizicko = s.Load<FizickoLice>(sso.IdFizickoLice);

                SertifikatSpecOpreme sertifikatspec = new SertifikatSpecOpreme();

                sertifikatspec.FizickoLice = fizicko;
                sertifikatspec.Sertifikat = sso.Sertifikat;

                s.Save(sertifikatspec);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniSertifikatSpecOpreme(SertifikatSpecOpremeBasic sso)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SertifikatSpecOpreme sertifikatSpec = s.Load<SertifikatSpecOpreme>(sso.Id);

                sertifikatSpec.Sertifikat = sso.Sertifikat;

                s.Update(sertifikatSpec);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void obrisiSertifikatSpecOpreme(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SertifikatSpecOpreme sertifikatSpec = s.Load<SertifikatSpecOpreme>(id);

                s.Delete(sertifikatSpec);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
