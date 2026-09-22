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
    public class ZastitnaOpremaDTOManager
    {
        public static List<ZastitnaOpremaBasic> vratiZastitneOpremeOsobe(int idOsobe)
        {
            List<ZastitnaOpremaBasic> opreme = new List<ZastitnaOpremaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ZastitnaOprema> sveOpreme =
                    from zo in s.Query<ZastitnaOprema>()
                    where zo.FizickoLice.Id == idOsobe
                    select zo;

                foreach (ZastitnaOprema zo in sveOpreme)
                {
                    opreme.Add(new ZastitnaOpremaBasic(
                        zo.Id,
                        zo.FizickoLice.Id,
                        zo.NazivOpreme));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return opreme;
        }

        public static ZastitnaOpremaBasic vratiZastitnuOpremu(int id)
        {
            ZastitnaOpremaBasic zastitnaOprema = new ZastitnaOpremaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                ZastitnaOprema zo = s.Load<ZastitnaOprema>(id);

                zastitnaOprema = new ZastitnaOpremaBasic(
                        zo.Id, zo.FizickoLice.Id, zo.NazivOpreme);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return zastitnaOprema;
        }

        public static void dodajZastitnuOpremu(ZastitnaOpremaBasic zo)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FizickoLice fizicko = s.Load<FizickoLice>(zo.IdFizickoLice);

                ZastitnaOprema zastitnaOprema = new ZastitnaOprema();

                zastitnaOprema.FizickoLice = fizicko;
                zastitnaOprema.NazivOpreme = zo.NazivOpreme;

                s.Save(zastitnaOprema);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniZastitnuOpremu(ZastitnaOpremaBasic zo)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZastitnaOprema zastitnaOprema = s.Load<ZastitnaOprema>(zo.Id);

                zastitnaOprema.NazivOpreme = zo.NazivOpreme;

                s.Update(zastitnaOprema);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiZastitnuOpremu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZastitnaOprema zastitnaOprema = s.Load<ZastitnaOprema>(id);

                s.Delete(zastitnaOprema);
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
