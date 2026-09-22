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
    public class ProjekatDTOManager
    {
        #region Projekat
        public static int IzracunajTrosakProjekta(int idProjekta)
        {
            int trosak = 0;
            try
            {
                ISession s = DataLayer.GetSession();

                List<NabavkaMaterijal> sviMaterijali = s.Query<NabavkaMaterijal>().ToList();
                int sumaMaterijala = sviMaterijali
                    .Where(nm => nm.Nabavke.Projekat.ID == idProjekta)
                    .Sum(nm => nm.Cena);

                List<NabavkaOprema> svaOprema = s.Query<NabavkaOprema>().ToList();
                int sumaOpreme = svaOprema
                    .Where(no => no.Nabavka.Projekat.ID == idProjekta)
                    .Sum(no => no.Cena);

                List<Faktura> sveFakture = s.Query<Faktura>().ToList();
                int sumaFaktura = sveFakture
                    .Where(f => f.IDProjekta.ID == idProjekta)
                    .Sum(f => f.Iznos);

                trosak = sumaMaterijala + sumaOpreme + sumaFaktura;

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return trosak;
        }
        public static List<ProjekatPregled> vratiSveProjekte()
        {
            List<ProjekatPregled> projekti = new List<ProjekatPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Projekat> sviProjekti = from p in s.Query<Projekat>() select p;
                foreach (Projekat p in sviProjekti)
                {
                    ProjekatPregled pregled = new ProjekatPregled(
                    p.ID, p.Naziv, p.Opis, p.Lokacija, p.Datum_pocetka,
                    p.Budzet, p.Status, p.Planirani_Zavrsetak, p.Stvarni_Zavrsetak);
                    pregled.Trosak = IzracunajTrosakProjekta(p.ID);

                    projekti.Add(pregled);
                }
                s.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return projekti;
        }

        public static ProjekatBasic vratiProjekat(int id)
        {
            ProjekatBasic projekat = new ProjekatBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Projekat p = s.Load<Projekat>(id);

                projekat = new ProjekatBasic(p.ID, p.Naziv, p.Opis, p.Lokacija, p.Datum_pocetka, p.Budzet, p.Status, p.Planirani_Zavrsetak, p.Stvarni_Zavrsetak);

                projekat.Trosak = IzracunajTrosakProjekta(id);
                projekat.Ugovori = UgovorDTOManager.vratiUgovoreProjekta(id);
                projekat.BezbednosniIncidenti = BezbednosniIncidentDTOManager.vratiBezbednosniIncidenteProjekta(id);
                projekat.Faze = FazaDTOManager.vratiFazeProjekta(id);
                projekat.Nabavke = NabavkeDTOManager.vratiNabavkeProjekta(id);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return projekat;
        }

        public static void obrisiProjekat(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Projekat p = s.Load<Projekat>(id);

                s.Delete(p);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }


        #region Infrastruktura

        public static List<InfrastrukturaPregled> vratiSveInfrasrukture()
        {
            List<InfrastrukturaPregled> infrastrukture = new List<InfrastrukturaPregled>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Infrastruktura> sveInfrastrukture =
                    from i in s.Query<Infrastruktura>()
                    select i;

                foreach (Infrastruktura i in sveInfrastrukture)
                {
                    InfrastrukturaPregled pregled = new InfrastrukturaPregled(
                     i.ID, i.Naziv, i.Opis, i.Lokacija, i.Datum_pocetka,
                     i.Budzet, i.Status, i.Planirani_Zavrsetak, i.Stvarni_Zavrsetak);

                    pregled.Trosak = IzracunajTrosakProjekta(i.ID);

                    infrastrukture.Add(pregled);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return infrastrukture;
        }

        public static InfrastrukturaBasic vratiInfrastrukturu(int id)
        {
            InfrastrukturaBasic infra = new InfrastrukturaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Infrastruktura i = s.Get<Infrastruktura>(id);
                if (i != null)
                {
                    infra = new InfrastrukturaBasic(i.ID, i.Naziv, i.Opis, i.Lokacija, i.Datum_pocetka, i.Budzet, i.Status, i.Planirani_Zavrsetak, i.Stvarni_Zavrsetak);
                    infra.Trosak = IzracunajTrosakProjekta(i.ID);

                    infra.Deonice = DeonicaDTOManager.vratiDeoniceInfrastrukture(id);
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return infra;
        }

        public static void dodajInfrastrukturu(InfrastrukturaBasic infra)//Deonice se dodaju odvojeno iako Entitet ima listu Deonica
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Infrastruktura i = new Infrastruktura();

                i.Naziv = infra.Naziv;
                i.Opis = infra.Opis;
                i.Lokacija = infra.Lokacija;
                i.Datum_pocetka = infra.Datum_pocetka;
                i.Budzet = infra.Budzet;
                i.Status = infra.Status;
                i.Planirani_Zavrsetak = infra.Planirani_zavrsetak;
                i.Stvarni_Zavrsetak = infra.Stvarni_zavrsetak;


                s.Save(i);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniInfrastrukturu(InfrastrukturaBasic infra)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Infrastruktura i = s.Load<Infrastruktura>(infra.ID);

                i.Naziv = infra.Naziv;
                i.Opis = infra.Opis;
                i.Lokacija = infra.Lokacija;
                i.Datum_pocetka = infra.Datum_pocetka;
                i.Budzet = infra.Budzet;
                i.Status = infra.Status;
                i.Planirani_Zavrsetak = infra.Planirani_zavrsetak;
                i.Stvarni_Zavrsetak = infra.Stvarni_zavrsetak;

                s.Update(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        #endregion

        #region Industrijski

        public static List<IndustrijskiPregled> vratiSveIndustrijske()
        {
            List<IndustrijskiPregled> ind = new List<IndustrijskiPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Industrijski> sviIndustrijski =
                   from inds in s.Query<Industrijski>()
                   select inds;

                foreach (Industrijski inds in sviIndustrijski)
                {
                    IndustrijskiPregled pregled = new IndustrijskiPregled(
                     inds.ID, inds.Naziv, inds.Opis, inds.Lokacija, inds.Datum_pocetka,
                     inds.Budzet, inds.Status, inds.Planirani_Zavrsetak, inds.Stvarni_Zavrsetak);

                    pregled.Trosak = IzracunajTrosakProjekta(inds.ID);

                    ind.Add(pregled);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return ind;
        }
        public static IndustrijskiBasic vratiIndustrijski(int id)
        {
            IndustrijskiBasic ind = new IndustrijskiBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Industrijski inds = s.Get<Industrijski>(id);
                if (inds != null)
                {
                    ind = new IndustrijskiBasic(inds.ID, inds.Naziv, inds.Opis, inds.Lokacija, inds.Datum_pocetka, inds.Budzet, inds.Status, inds.Planirani_Zavrsetak, inds.Stvarni_Zavrsetak);
                    ind.Trosak = IzracunajTrosakProjekta(id);
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return ind;
        }

        public static void dodajIndustrijski(IndustrijskiBasic ind)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Industrijski inds = new Industrijski();

                inds.Naziv = ind.Naziv;
                inds.Opis = ind.Opis;
                inds.Lokacija = ind.Lokacija;
                inds.Datum_pocetka = ind.Datum_pocetka;
                inds.Budzet = ind.Budzet;
                inds.Status = ind.Status;
                inds.Planirani_Zavrsetak = ind.Planirani_zavrsetak;
                inds.Stvarni_Zavrsetak = ind.Stvarni_zavrsetak;

                s.Save(inds);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniIndustrijski(IndustrijskiBasic ind)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Industrijski inds = s.Load<Industrijski>(ind.ID);

                inds.Naziv = ind.Naziv;
                inds.Opis = ind.Opis;
                inds.Lokacija = ind.Lokacija;
                inds.Datum_pocetka = ind.Datum_pocetka;
                inds.Budzet = ind.Budzet;
                inds.Status = ind.Status;
                inds.Planirani_Zavrsetak = ind.Planirani_zavrsetak;
                inds.Stvarni_Zavrsetak = ind.Stvarni_zavrsetak;

                s.Update(inds);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        #endregion

        #region Poslovni

        public static List<PoslovniPregled> vratiSvePoslovne()
        {
            List<PoslovniPregled> posl = new List<PoslovniPregled>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Poslovni> sviPoslovni =
                    from p in s.Query<Poslovni>()
                    select p;

                foreach (Poslovni p in sviPoslovni)
                {
                    PoslovniPregled pregled = new PoslovniPregled(
                     p.ID, p.Naziv, p.Opis, p.Lokacija, p.Datum_pocetka,
                     p.Budzet, p.Status, p.Planirani_Zavrsetak, p.Stvarni_Zavrsetak);

                    pregled.Trosak = IzracunajTrosakProjekta(p.ID);

                    posl.Add(pregled);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return posl;
        }

        public static PoslovniBasic vratiPoslovni(int id)
        {
            PoslovniBasic posl = new PoslovniBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Poslovni p = s.Get<Poslovni>(id);
                if (p != null)
                {
                    posl = new PoslovniBasic(p.ID, p.Naziv, p.Opis, p.Lokacija, p.Datum_pocetka, p.Budzet, p.Status, p.Planirani_Zavrsetak, p.Stvarni_Zavrsetak);
                    posl.Trosak = IzracunajTrosakProjekta (p.ID);

                    posl.Objekti = vratiObjektePoslovne(id);
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return posl;
        }

        public static void dodajPoslovni(PoslovniBasic posl)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Poslovni p = new Poslovni();

                p.Naziv = posl.Naziv;
                p.Opis = posl.Opis;
                p.Lokacija = posl.Lokacija;
                p.Datum_pocetka = posl.Datum_pocetka;
                p.Budzet = posl.Budzet;
                p.Status = posl.Status;
                p.Planirani_Zavrsetak = posl.Planirani_zavrsetak;
                p.Stvarni_Zavrsetak = posl.Stvarni_zavrsetak;

                s.Save(p);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniPoslovni(PoslovniBasic posl)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Poslovni p = s.Load<Poslovni>(posl.ID);

                p.Naziv = posl.Naziv;
                p.Opis = posl.Opis;
                p.Lokacija = posl.Lokacija;
                p.Datum_pocetka = posl.Datum_pocetka;
                p.Budzet = posl.Budzet;
                p.Status = posl.Status;
                p.Planirani_Zavrsetak = posl.Planirani_zavrsetak;
                p.Stvarni_Zavrsetak = posl.Stvarni_zavrsetak;

                s.Update(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        #region ObjekatPoslovni

        public static List<ObjekatPoslovniBasic> vratiObjektePoslovne(int idProjekta)
        {
            List<ObjekatPoslovniBasic> obj = new List<ObjekatPoslovniBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ObjekatPoslovni> sviPoslovni =
                         from p in s.Query<ObjekatPoslovni>()
                         where p.Poslovni.ID == idProjekta
                         select p;

                foreach (ObjekatPoslovni p in sviPoslovni)
                {
                    PoslovniBasic poslovni = new PoslovniBasic(
                        p.Poslovni.ID,
                        p.Poslovni.Naziv,
                        p.Poslovni.Opis,
                        p.Poslovni.Lokacija,
                        p.Poslovni.Datum_pocetka,
                        p.Poslovni.Budzet,
                        p.Poslovni.Status,
                        p.Poslovni.Planirani_Zavrsetak,
                        p.Poslovni.Stvarni_Zavrsetak
                    );
                    poslovni.Trosak = IzracunajTrosakProjekta(p.Poslovni.ID);
                    obj.Add(new ObjekatPoslovniBasic(p.Id, p.Br_objekta, p.Spratnost, p.Br_jedinica, poslovni));
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return obj;
        }

        public static void dodajObjekatPoslovni(ObjekatPoslovniBasic p)//proveri
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Poslovni objP = s.Get<Poslovni>(p.Poslovni.ID);

                if (p == null || p.Poslovni == null)
                {
                    MessageBox.Show("Podaci nisu ispravni.");
                    return;
                }

                if (objP == null)
                {
                    MessageBox.Show("ObjekatPoslovni ne postoji.");
                    return;
                }

                ObjekatPoslovni objPoslovni = new ObjekatPoslovni();

                objPoslovni.Br_objekta = p.Br_objekta;
                objPoslovni.Spratnost = p.Spratnost;
                objPoslovni.Br_jedinica = p.Br_jedinica;
                objPoslovni.Poslovni = objP;

                s.Save(objPoslovni);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static ObjekatPoslovniBasic vratiObjekatPoslovni(int id)
        {
            ObjekatPoslovniBasic objekat = new ObjekatPoslovniBasic();

            try
            {
                ISession s = DataLayer.GetSession();
                ObjekatPoslovni o = s.Get<ObjekatPoslovni>(id);

                if (o != null)
                {
                    PoslovniBasic poslovni = vratiPoslovni(o.Poslovni.ID);

                    objekat = new ObjekatPoslovniBasic(
                        o.Id,
                        o.Br_objekta,
                        o.Spratnost,
                        o.Br_jedinica,
                        poslovni
                    );
                }
                else
                {
                    MessageBox.Show($"Ne postoji objekatPoslovni sa ID = {id}");
                }



                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return objekat;
        }

        public static void izmeniObjekatPoslovni(ObjekatPoslovniBasic stan)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ObjekatPoslovni st = s.Load<ObjekatPoslovni>(stan.ID);

                st.Br_objekta = stan.Br_objekta;
                st.Spratnost = stan.Spratnost;
                st.Br_jedinica = stan.Br_jedinica;

                s.Update(st);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiPoslovniObjekat(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ObjekatPoslovni p = s.Load<ObjekatPoslovni>(id);

                s.Delete(p);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        #endregion

        #region Stambeni

        public static List<StambeniPregled> vratiSveStambene()
        {
            List<StambeniPregled> stam = new List<StambeniPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Stambeni> sviStambeni =
                   from st in s.Query<Stambeni>()
                   select st;

                foreach (Stambeni st in sviStambeni)
                {
                    StambeniPregled pregled = new StambeniPregled(
                      st.ID, st.Naziv, st.Opis, st.Lokacija, st.Datum_pocetka,
                      st.Budzet, st.Status, st.Planirani_Zavrsetak, st.Stvarni_Zavrsetak);

                    pregled.Trosak = IzracunajTrosakProjekta(st.ID);

                    stam.Add(pregled);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return stam;
        }

        public static StambeniBasic vratiStambeni(int id)
        {
            StambeniBasic stam = new StambeniBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Stambeni st = s.Get<Stambeni>(id);
                if (st != null)
                {
                    stam = new StambeniBasic(st.ID, st.Naziv, st.Opis, st.Lokacija, st.Datum_pocetka, st.Budzet, st.Status, st.Planirani_Zavrsetak, st.Stvarni_Zavrsetak);
                    stam.Trosak = IzracunajTrosakProjekta (st.ID);

                    stam.Objekti = vratiObjekteStambene(id);
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return stam;
        }

        public static void dodajStambeni(StambeniBasic stam)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Stambeni st = new Stambeni();

                st.Naziv = stam.Naziv;
                st.Opis = stam.Opis;
                st.Lokacija = stam.Lokacija;
                st.Datum_pocetka = stam.Datum_pocetka;
                st.Budzet = stam.Budzet;
                st.Status = stam.Status;
                st.Planirani_Zavrsetak = stam.Planirani_zavrsetak;
                st.Stvarni_Zavrsetak = stam.Stvarni_zavrsetak;

                s.Save(st);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniStambeni(StambeniBasic stam)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Stambeni st = s.Load<Stambeni>(stam.ID);

                st.Naziv = stam.Naziv;
                st.Opis = stam.Opis;
                st.Lokacija = stam.Lokacija;
                st.Datum_pocetka = stam.Datum_pocetka;
                st.Budzet = stam.Budzet;
                st.Status = stam.Status;
                st.Planirani_Zavrsetak = stam.Planirani_zavrsetak;
                st.Stvarni_Zavrsetak = stam.Stvarni_zavrsetak;

                s.Update(st);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }


        #region ObjekatStambeni


        public static void obrisiStambeniObjekat(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ObjekatStambeni p = s.Load<ObjekatStambeni>(id);

                s.Delete(p);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniObjekatStambeni(ObjekatStambeniBasic stam)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ObjekatStambeni st = s.Load<ObjekatStambeni>(stam.ID);

                st.Br_objekta = stam.Br_objekta;
                st.Spratnost = stam.Spratnost;
                st.Br_jedinica = stam.Br_jedinica;

                s.Update(st);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static List<ObjekatStambeniBasic> vratiObjekteStambene(int idProjekta)
        {
            List<ObjekatStambeniBasic> obj = new List<ObjekatStambeniBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ObjekatStambeni> sviStambeni =
                        from ss in s.Query<ObjekatStambeni>()
                        where ss.Stambeni.ID == idProjekta
                        select ss;

                foreach (ObjekatStambeni ss in sviStambeni)
                {
                    StambeniBasic stambeni = new StambeniBasic(
                        ss.Stambeni.ID,
                        ss.Stambeni.Naziv,
                        ss.Stambeni.Opis,
                        ss.Stambeni.Lokacija,
                        ss.Stambeni.Datum_pocetka,
                        ss.Stambeni.Budzet,
                        ss.Stambeni.Status,
                        ss.Stambeni.Planirani_Zavrsetak,
                        ss.Stambeni.Stvarni_Zavrsetak
                    );
                    stambeni.Trosak = IzracunajTrosakProjekta(ss.Stambeni.ID);
                    obj.Add(new ObjekatStambeniBasic(ss.Id, ss.Br_objekta, ss.Spratnost, ss.Br_jedinica, stambeni));
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return obj;
        }

        public static void dodajObjekatStambeni(ObjekatStambeniBasic os)//proveri
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Stambeni objS = s.Get<Stambeni>(os.Stambeni.ID);

                if (os == null || os.Stambeni == null)
                {
                    MessageBox.Show("Podaci nisu ispravni.");
                    return;
                }

                if (objS == null)
                {
                    MessageBox.Show("ObjekatPoslovni ne postoji.");
                    return;
                }

                ObjekatStambeni objStambeni = new ObjekatStambeni();

                objStambeni.Br_objekta = os.Br_objekta;
                objStambeni.Spratnost = os.Spratnost;
                objStambeni.Br_jedinica = os.Br_jedinica;
                objStambeni.Stambeni = objS;

                s.Save(objStambeni);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static ObjekatStambeniBasic vratiObjekatStambeni(int id)
        {
            ObjekatStambeniBasic objekat = new ObjekatStambeniBasic();

            try
            {
                ISession s = DataLayer.GetSession();
                ObjekatStambeni o = s.Get<ObjekatStambeni>(id);

                if (o != null)
                {
                    StambeniBasic stambeni = vratiStambeni(o.Stambeni.ID);

                    objekat = new ObjekatStambeniBasic(
                        o.Id,
                        o.Br_objekta,
                        o.Spratnost,
                        o.Br_jedinica,
                        stambeni
                    );
                }
                else
                {
                    MessageBox.Show($"Ne postoji ObjekatStambeni sa ID = {id}");
                }



                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return objekat;
        }

        #endregion

        #endregion

        #region Sanacija

        public static List<SanacijaPregled> vratiSveSanacije()
        {
            List<SanacijaPregled> sanac = new List<SanacijaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Sanacija> sveSanacije =
                   from sa in s.Query<Sanacija>()
                   select sa;

                foreach (Sanacija sa in sveSanacije)
                {
                    SanacijaPregled pregled = new SanacijaPregled(
                     sa.ID, sa.Naziv, sa.Opis, sa.Lokacija, sa.Datum_pocetka,
                     sa.Budzet, sa.Status, sa.Planirani_Zavrsetak, sa.Stvarni_Zavrsetak);

                    pregled.Trosak = IzracunajTrosakProjekta(sa.ID);

                    sanac.Add(pregled);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return sanac;
        }
        public static SanacijaBasic vratiSanaciju(int id)
        {
            SanacijaBasic sanac = new SanacijaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Sanacija sa = s.Get<Sanacija>(id);
                if (sa != null)
                {
                    sanac = new SanacijaBasic(sa.ID, sa.Naziv, sa.Opis, sa.Lokacija, sa.Datum_pocetka, sa.Budzet, sa.Status, sa.Planirani_Zavrsetak, sa.Stvarni_Zavrsetak);
                    sanac.Trosak = IzracunajTrosakProjekta(id);
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return sanac;
        }

        public static void dodajSanaciju(SanacijaBasic sanac)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sanacija sa = new Sanacija();

                sa.Naziv = sanac.Naziv;
                sa.Opis = sanac.Opis;
                sa.Lokacija = sanac.Lokacija;
                sa.Datum_pocetka = sanac.Datum_pocetka;
                sa.Budzet = sanac.Budzet;
                sa.Status = sanac.Status;
                sa.Planirani_Zavrsetak = sanac.Planirani_zavrsetak;
                sa.Stvarni_Zavrsetak = sanac.Stvarni_zavrsetak;

                s.Save(sa);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniSanaciju(SanacijaBasic sanac)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sanacija sa = s.Load<Sanacija>(sanac.ID);

                sa.Naziv = sanac.Naziv;
                sa.Opis = sanac.Opis;
                sa.Lokacija = sanac.Lokacija;
                sa.Datum_pocetka = sanac.Datum_pocetka;
                sa.Budzet = sanac.Budzet;
                sa.Status = sanac.Status;
                sa.Planirani_Zavrsetak = sanac.Planirani_zavrsetak;
                sa.Stvarni_Zavrsetak = sanac.Stvarni_zavrsetak;

                s.Update(sa);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        #endregion

        #region Rekonstrukcija

        public static List<RekonstrukcijaPregled> vratiSveRekonstrukcije()
        {
            List<RekonstrukcijaPregled> rek = new List<RekonstrukcijaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Rekonstrukcija> sveRekonstrukcije =
                   from re in s.Query<Rekonstrukcija>()
                   select re;

                foreach (Rekonstrukcija re in sveRekonstrukcije)
                {
                    RekonstrukcijaPregled pregled = new RekonstrukcijaPregled(
                      re.ID, re.Naziv, re.Opis, re.Lokacija, re.Datum_pocetka,
                      re.Budzet, re.Status, re.Planirani_Zavrsetak, re.Stvarni_Zavrsetak);

                    pregled.Trosak = IzracunajTrosakProjekta(re.ID);

                    rek.Add(pregled);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return rek;
        }
        public static RekonstrukcijaBasic vratiRekonstrukciju(int id)
        {
            RekonstrukcijaBasic rek = new RekonstrukcijaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Rekonstrukcija re = s.Get<Rekonstrukcija>(id);
                if (re != null)
                {
                    rek = new RekonstrukcijaBasic(re.ID, re.Naziv, re.Opis, re.Lokacija, re.Datum_pocetka, re.Budzet, re.Status, re.Planirani_Zavrsetak, re.Stvarni_Zavrsetak);
                    rek.Trosak = IzracunajTrosakProjekta(id);
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return rek;
        }

        public static void dodajRekonstrukciju(RekonstrukcijaBasic rek)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Rekonstrukcija re = new Rekonstrukcija();

                re.Naziv = rek.Naziv;
                re.Opis = rek.Opis;
                re.Lokacija = rek.Lokacija;
                re.Datum_pocetka = rek.Datum_pocetka;
                re.Budzet = rek.Budzet;
                re.Status = rek.Status;
                re.Planirani_Zavrsetak = rek.Planirani_zavrsetak;
                re.Stvarni_Zavrsetak = rek.Stvarni_zavrsetak;

                s.Save(re);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniRekonstrukciju(RekonstrukcijaBasic rek)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Rekonstrukcija re = s.Load<Rekonstrukcija>(rek.ID);

                re.Naziv = rek.Naziv;
                re.Opis = rek.Opis;
                re.Lokacija = rek.Lokacija;
                re.Datum_pocetka = rek.Datum_pocetka;
                re.Budzet = rek.Budzet;
                re.Status = rek.Status;
                re.Planirani_Zavrsetak = rek.Planirani_zavrsetak;
                re.Stvarni_Zavrsetak = rek.Stvarni_zavrsetak;

                s.Update(re);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        #endregion

        #endregion

        #endregion
    }
}
