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
    public class PosebnaKlauzulaDTOManager
    {
        #region PosebneKlauzule

        public static List<PosebnaKlauzulaBasic> vratiPosebneKlauzule(int idUgovora)
        {
            List<PosebnaKlauzulaBasic> klauzule = new List<PosebnaKlauzulaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<PosebnaKlauzula> sveKlauzule =
                    from k in s.Query<PosebnaKlauzula>()
                    where k.Ugovor.Id == idUgovora
                    select k;

                foreach (PosebnaKlauzula k in sveKlauzule)
                {
                    klauzule.Add(new PosebnaKlauzulaBasic(
                            k.Id, k.Ugovor.Id, k.TekstKlauzule
                        )
                    );
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return klauzule;
        }

        public static PosebnaKlauzulaBasic vratiPosebnuKlauzulu(int id)
        {
            PosebnaKlauzulaBasic klauzula = null;

            try
            {
                ISession s = DataLayer.GetSession();

                PosebnaKlauzula k = s.Load<PosebnaKlauzula>(id);

                klauzula = new PosebnaKlauzulaBasic(
                    k.Id, k.Ugovor.Id, k.TekstKlauzule
                );

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return klauzula;
        }

        public static void dodajPosebnuKlauzulu(PosebnaKlauzulaBasic k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ugovor ugovor = s.Load<Ugovor>(k.IdUgovor);

                PosebnaKlauzula klauzula = new PosebnaKlauzula();

                klauzula.Ugovor = ugovor;
                klauzula.TekstKlauzule = k.TekstKlauzule;

                s.Save(klauzula);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniPosebnuKlauzulu(PosebnaKlauzulaBasic k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PosebnaKlauzula klauzula = s.Load<PosebnaKlauzula>(k.Id);

                klauzula.TekstKlauzule = k.TekstKlauzule;

                s.Update(klauzula);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiPosebnuKlauzulu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PosebnaKlauzula klauzula = s.Load<PosebnaKlauzula>(id);

                s.Delete(klauzula);
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
