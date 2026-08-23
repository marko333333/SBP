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
    public class LekPregledDTOManager
    {
        public static List<LekarskiPregledBasic> vratiLekarskePregledeOsobe(int idOsobe)
        {
            List<LekarskiPregledBasic> pregledi = new List<LekarskiPregledBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<LekarskiPregled> sviPregledi =
                    from p in s.Query<LekarskiPregled>()
                    where p.FizickoLice.Id == idOsobe
                    select p;

                foreach (LekarskiPregled p in sviPregledi)
                {
                    pregledi.Add(new LekarskiPregledBasic(
                        p.Id,
                        p.FizickoLice.Id,
                        p.Rezultat,
                        p.Datum));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return pregledi;
        }

        public static LekarskiPregledBasic vratiLekPregled(int id)
        {
            LekarskiPregledBasic lekpregled = new LekarskiPregledBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                LekarskiPregled lp = s.Load<LekarskiPregled>(id);

                lekpregled = new LekarskiPregledBasic(
                        lp.Id, lp.FizickoLice.Id, lp.Rezultat, lp.Datum);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return lekpregled;
        }

        public static void dodajLekPregled(LekarskiPregledBasic lp)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FizickoLice fizicko = s.Load<FizickoLice>(lp.IdFizickoLice);

                LekarskiPregled lekpregled = new LekarskiPregled();


                lekpregled.FizickoLice = fizicko;
                lekpregled.Rezultat = lp.Rezultat;
                lekpregled.Datum = lp.Datum;

                s.Save(lekpregled);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void izmeniLekPregled(LekarskiPregledBasic lp)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LekarskiPregled lekpregled = s.Load<LekarskiPregled>(lp.Id);

                lekpregled.Rezultat = lp.Rezultat;
                lekpregled.Datum = lp.Datum;

                s.Update(lekpregled);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void obrisiLekPregled(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LekarskiPregled lekpregled = s.Load<LekarskiPregled>(id);


                s.Delete(lekpregled);
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
