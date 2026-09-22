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
    public class RadniNaloziDTOManager
    {
        #region RadniNalozi

        public static List<RadniNalogBasic> vratiRadneNaloge(int idZadatka)
        {
            List<RadniNalogBasic> radniNalozi =
                new List<RadniNalogBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<RadniNalog> sviRadniNalozi =
                    from rn in s.Query<RadniNalog>()
                    where rn.Zadatak.Id == idZadatka
                    select rn;

                foreach (RadniNalog rn in sviRadniNalozi)
                {
                    radniNalozi.Add(new RadniNalogBasic(
                      rn.BrojNaloga, null, rn.Status, rn.DatumIzdavanja));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return radniNalozi;
        }

        public static RadniNalogBasic vratiRadniNalog(int id)
        {
            RadniNalogBasic radniNalog = new RadniNalogBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                RadniNalog rn = s.Load<RadniNalog>(id);

                ZadatakBasic zadatak = null;

                if (rn.Zadatak != null)
                {
                    zadatak = new ZadatakBasic();
                    zadatak.Id = rn.Zadatak.Id;
                    zadatak.Naziv = rn.Zadatak.Naziv;
                }

                radniNalog = new RadniNalogBasic(
                   rn.BrojNaloga, zadatak, rn.Status, rn.DatumIzdavanja);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return radniNalog;
        }

        public static void dodajRadniNalog(RadniNalogBasic radniNalog)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zadatak zadatak = s.Load<Zadatak>(radniNalog.Zadatak.Id);

                RadniNalog rn = new RadniNalog();

                rn.DatumIzdavanja = radniNalog.DatumIzdavanja;
                rn.Status = radniNalog.Status;
                rn.Zadatak = zadatak;

                s.Save(rn);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniRadniNalog(RadniNalogBasic rn)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadniNalog radniNalog = s.Load<RadniNalog>(rn.BrNaloga);

                radniNalog.Status = rn.Status;
                radniNalog.DatumIzdavanja = rn.DatumIzdavanja;

                s.Update(radniNalog);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiRadniNalog(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadniNalog radniNalog = s.Load<RadniNalog>(id);

                s.Delete(radniNalog);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        #endregion

    }
}
