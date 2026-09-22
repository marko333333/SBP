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
    public class BezbednosnaObukaDTOManager
    {
        public static List<BezbednosnaObukaBasic> vratiBezbednosneObukeOsobe(int idOsobe)
        {
            List<BezbednosnaObukaBasic> obuke = new List<BezbednosnaObukaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<BezbednosnaObuka> sveObuke =
                    from b in s.Query<BezbednosnaObuka>()
                    where b.FizickoLice.Id == idOsobe
                    select b;

                foreach (BezbednosnaObuka b in sveObuke)
                {
                    obuke.Add(new BezbednosnaObukaBasic(
                        b.Id,
                        b.FizickoLice.Id,
                        b.NazivObuke,
                        b.Datum));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return obuke;
        }

        public static BezbednosnaObukaBasic vratiObuku(int id)
        {
            BezbednosnaObukaBasic obuka = new BezbednosnaObukaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                BezbednosnaObuka b = s.Load<BezbednosnaObuka>(id);

                obuka = new BezbednosnaObukaBasic(
                        b.Id, b.FizickoLice.Id, b.NazivObuke, b.Datum);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return obuka;
        }

        public static void dodajBezbednosnuObuku(BezbednosnaObukaBasic bezObuka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FizickoLice lice = s.Load<FizickoLice>(bezObuka.IdFizickoLice);

                BezbednosnaObuka obuka = new BezbednosnaObuka();

                obuka.FizickoLice = lice;
                obuka.NazivObuke = bezObuka.NazivObuke;
                obuka.Datum = bezObuka.Datum;

                s.Save(obuka);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());


            }
        }

        public static void izmeniBezbednosnuObuku(BezbednosnaObukaBasic bo)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BezbednosnaObuka bezobuka = s.Load<BezbednosnaObuka>(bo.Id);

                bezobuka.NazivObuke = bo.NazivObuke;
                bezobuka.Datum = bo.Datum;

                s.Update(bezobuka);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiBezbednosnuObuku(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BezbednosnaObuka bezobuka = s.Load<BezbednosnaObuka>(id);

                s.Delete(bezobuka);
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
