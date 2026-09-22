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
    public class FakturaDTOManager
    {
        #region Faktura

        //public virtual int Br_fakture { get; set; }
        //public virtual int Iznos { get; set; }
        //public virtual string Valuta { get; set; }
        //public virtual bool statusPlacanja { get; set; }
        //public virtual DateTime Datum { get; set; }

        //public virtual Projekat IDProjekta { get; set; }
        //public virtual PravnaLica PravnoLiceIzdaje { get; set; }
        //public virtual PravnaLica PravnoLicePrima { get; set; }
        public static FakturaBasic vratiFakturuProjekta(int idFakture)
        {
            FakturaBasic faktura = new FakturaBasic();

            try
            {
                ISession s = DataLayer.GetSession();

                Faktura f = s.Get<Faktura>(idFakture);
                if (f != null)
                {
                    ProjekatBasic projekat = ProjekatDTOManager.vratiProjekat(f.IDProjekta.ID);
                    PravnaLicaBasic izdavalac = OsobaDTOManager.vratiPravnoLice(f.PravnoLiceIzdaje.Id);
                    PravnaLicaBasic primalac = OsobaDTOManager.vratiPravnoLice(f.PravnoLicePrima.Id);


                    faktura = new FakturaBasic(f.Br_fakture,f.Iznos,f.Valuta,f.statusPlacanja,f.Datum,projekat,izdavalac,primalac);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
            return faktura;
        }
        public static List<FakturaBasic> vratiFaktureProjekta(int idProjekta)
        {
            List<FakturaBasic> fakture = new List<FakturaBasic>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Faktura> sveFakture =
                    from f in s.Query<Faktura>()
                    where f.IDProjekta.ID == idProjekta
                    select f;

                foreach (Faktura f in sveFakture)
                {
                    ProjekatBasic projekat = null;
                    if (f.IDProjekta != null)
                    {
                        projekat = new ProjekatBasic(
                            f.IDProjekta.ID,
                            f.IDProjekta.Naziv,
                            f.IDProjekta.Opis,
                            f.IDProjekta.Lokacija,
                            f.IDProjekta.Datum_pocetka,
                            f.IDProjekta.Budzet,
                            f.IDProjekta.Status,
                            f.IDProjekta.Planirani_Zavrsetak,
                            f.IDProjekta.Stvarni_Zavrsetak
                        );
                    }
                    PravnaLicaBasic pravnoLiceIzdaje = null;
                    if (f.PravnoLiceIzdaje != null)
                    {
                        pravnoLiceIzdaje = new PravnaLicaBasic(
                            f.PravnoLiceIzdaje.Id,
                            f.PravnoLiceIzdaje.Jmbg,
                            f.PravnoLiceIzdaje.Ime,
                            f.PravnoLiceIzdaje.Prezime,
                            f.PravnoLiceIzdaje.DatumRodjenja,
                            f.PravnoLiceIzdaje.Struka,
                            f.PravnoLiceIzdaje.FlagPB,
                            f.PravnoLiceIzdaje.FlagInve,
                            f.PravnoLiceIzdaje.FlagIzv,
                            f.PravnoLiceIzdaje.FlagP,
                            f.PravnoLiceIzdaje.FlagD,
                            f.PravnoLiceIzdaje.FlagN
                        );
                    }
                    PravnaLicaBasic pravnoLicePrima = null;
                    if (f.PravnoLicePrima != null)
                    {
                        pravnoLiceIzdaje = new PravnaLicaBasic(
                            f.PravnoLiceIzdaje.Id,
                            f.PravnoLiceIzdaje.Jmbg,
                            f.PravnoLiceIzdaje.Ime,
                            f.PravnoLiceIzdaje.Prezime,
                            f.PravnoLiceIzdaje.DatumRodjenja,
                            f.PravnoLiceIzdaje.Struka,
                            f.PravnoLiceIzdaje.FlagPB,
                            f.PravnoLiceIzdaje.FlagInve,
                            f.PravnoLiceIzdaje.FlagIzv,
                            f.PravnoLiceIzdaje.FlagP,
                            f.PravnoLiceIzdaje.FlagD,
                            f.PravnoLiceIzdaje.FlagN
                        );
                    }

                    fakture.Add(new FakturaBasic(f.Br_fakture, f.Iznos, f.Valuta, f.statusPlacanja, f.Datum, projekat, pravnoLiceIzdaje, pravnoLicePrima));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }

            return fakture;
        }

        public static void dodajFakturu(FakturaBasic f)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Projekat projekat = s.Get<Projekat>(f.Projekat.ID);
                PravnaLica primalac = s.Get<PravnaLica>(f.PravnoLicePrima.Id);
                PravnaLica izdavalac = s.Get<PravnaLica>(f.PravnoLiceIzdaje.Id);
                if (projekat == null)
                {
                    MessageBox.Show("Projekat ne postoji.");
                    return;
                }
                if (primalac == null)
                {
                    MessageBox.Show("Primalac ne postoji.");
                    return;
                }
                if (izdavalac == null)
                {
                    MessageBox.Show("Izdavalac ne postoji.");
                    return;
                }

                Faktura fakt = new Faktura();

                fakt.Iznos = f.Iznos;
                fakt.Valuta = f.Valuta;
                fakt.statusPlacanja = f.StatusPlacanja;
                fakt.Datum = f.Datum;
                fakt.IDProjekta = projekat;
                fakt.PravnoLiceIzdaje = izdavalac;
                fakt.PravnoLicePrima = primalac;

                s.Save(fakt);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void obrisiFakturu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Faktura faktura = s.Get<Faktura>(id);
                if (faktura == null)
                {
                    MessageBox.Show("Faktura ne postoji.");
                    return;
                }

                s.Delete(faktura);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HandleError());

            }
        }

        public static void izmeniFakturu(FakturaBasic f)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Faktura faktura = s.Get<Faktura>(f.Br_fakture);
                if (faktura == null)
                {
                    MessageBox.Show("Faktura ne postoji.");
                    return;
                }
                faktura.Iznos = f.Iznos;
                faktura.Valuta = f.Valuta;
                faktura.statusPlacanja = f.StatusPlacanja;
                faktura.Datum = f.Datum;

                s.Update(faktura);
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
