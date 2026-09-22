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
    public class FotografijaDTOManager
    {
        #region Fotografije

        public static List<FotografijaBasic> vratiFotografije(int idNapredak)
        {
            List<FotografijaBasic> fotografije = new List<FotografijaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Fotografija> slike =
                    from f in s.Query<Fotografija>()
                    where f.Napredak.Id == idNapredak
                    select f;

                foreach (Fotografija f in slike)
                {
                    fotografije.Add(new FotografijaBasic(
                            f.Napredak.Id,
                            f.Putanja
                        )
                    );
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return fotografije;
        }

        public static void dodajFotografiju(FotografijaBasic fotografija)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Napredak napredak = s.Load<Napredak>(fotografija.IdNapredak);

                Fotografija f = new Fotografija();

                f.Napredak = napredak;
                f.Putanja = fotografija.Putanja;

                s.Save(f);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiFotografiju(int idNapredak, string putanja)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Fotografija fotografija =
                       (from f in s.Query<Fotografija>()
                        where f.Napredak.Id == idNapredak
                           && f.Putanja == putanja
                        select f).FirstOrDefault();

                //za svaki slucaj proveravamo, ali mislim da nema potrebe
                if (fotografija == null)
                {
                    MessageBox.Show("Fotografija nije pronadjena.");
                    s.Close();
                    return;
                }

                s.Delete(fotografija);
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
