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
    public class DeonicaDTOManager
    {
        #region Deonice

        public static List<DeonicaBasic> vratiDeoniceInfrastrukture(int idProjekta)
        {
            List<DeonicaBasic> deonice = new List<DeonicaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Deonica> sveDeonice =
                    from d in s.Query<Deonica>()
                    where d.Infrastruktura.ID == idProjekta
                    select d;

                foreach (Deonica d in sveDeonice)
                {
                    InfrastrukturaBasic infra = new InfrastrukturaBasic(
                        d.Infrastruktura.ID,
                        d.Infrastruktura.Naziv,
                        d.Infrastruktura.Opis,
                        d.Infrastruktura.Lokacija,
                        d.Infrastruktura.Datum_pocetka,
                        d.Infrastruktura.Budzet,
                        d.Infrastruktura.Status,
                        d.Infrastruktura.Planirani_Zavrsetak,
                        d.Infrastruktura.Stvarni_Zavrsetak
                        );

                    deonice.Add(new DeonicaBasic(d.Id, d.Br_deonice, infra));

                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return deonice;
        }

        public static DeonicaBasic vratiDeonicu(int id)
        {
            DeonicaBasic deonica = new DeonicaBasic();


            try
            {
                ISession s = DataLayer.GetSession();

                Deonica d = s.Load<Deonica>(id);

                InfrastrukturaBasic infra = new InfrastrukturaBasic(
                    d.Infrastruktura.ID,
                    d.Infrastruktura.Naziv,
                    d.Infrastruktura.Opis,
                    d.Infrastruktura.Lokacija,
                    d.Infrastruktura.Datum_pocetka,
                    d.Infrastruktura.Budzet,
                    d.Infrastruktura.Status,
                    d.Infrastruktura.Planirani_Zavrsetak,
                    d.Infrastruktura.Stvarni_Zavrsetak
                    );

                deonica = new DeonicaBasic(d.Id, d.Br_deonice, infra);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return deonica;
        }

        public static void dodajDeonicu(DeonicaBasic d)//proveri
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Infrastruktura infra = s.Get<Infrastruktura>(d.Infrastruktura.ID);

                if (infra == null)
                {
                    MessageBox.Show("Infrastuktura ne postoji.");
                    return;
                }

                Deonica deonica = new Deonica();

                deonica.Br_deonice = d.Br_deonice;
                deonica.Infrastruktura = infra;

                s.Save(deonica);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniDeonicu(DeonicaBasic d)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Deonica deonica = s.Load<Deonica>(d.ID);

                deonica.Br_deonice = d.Br_deonice;

                s.Update(deonica);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiDeonicu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Deonica deonica = s.Load<Deonica>(id);

                s.Delete(deonica);
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
