using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Gradjevinska_firma.DTO
{

    #region Osoba

     public class OsobaBasic
     {
         public int Id;
         public long Jmbg;
         public string Ime;
         public string Prezime;
         public DateTime DatumRodjenja;
         public string Struka;
         public virtual IList<KontaktBasic> Kontakti { get; set; }
         public virtual IList<LicencaBasic> Licence { get; set; }
         public virtual IList<AngazovanBasic> Angazovanja { get; set; }
         public virtual IList<ImaUgovornuStranuBasic> UgovorneStrane { get; set; }
         public virtual IList<BezbednosniIncidentBasic> BezbednosniIncidenti { get; set; }

         public OsobaBasic()
         {
             Kontakti = new List<KontaktBasic>();
             Licence = new List<LicencaBasic>();
             Angazovanja = new List<AngazovanBasic>();
             UgovorneStrane = new List<ImaUgovornuStranuBasic>();
            BezbednosniIncidenti = new List<BezbednosniIncidentBasic>();
         }

         public OsobaBasic(int id, long jmbg, string ime,
             string prezime, DateTime datumRodjenja, string struka) : this()
         {
             Id = id;
             Jmbg = jmbg;
             Ime = ime;
             Prezime = prezime;
             DatumRodjenja = datumRodjenja;
             Struka = struka;
         }
     }
    
    public class OsobaPregled
    {
        public int Id;
        public long Jmbg;
        public string Ime;
        public string Prezime;
        public DateTime DatumRodjenja;
        public string Struka;

        public OsobaPregled()
        {

        }

        public OsobaPregled(int id, long jmbg, string ime,
            string prezime, DateTime datumRodjenja, string struka)
        {
            Id = id;
            Jmbg = jmbg;
            Ime = ime;
            Prezime = prezime;
            DatumRodjenja = datumRodjenja;
            Struka = struka;
        }
    }

    #region FizickoLice

    public class FizickoLiceBasic : OsobaBasic
    {
        public bool FlagBK;
        public bool FlagR;
        public string Kvalifikacija;
        public bool FlagI;
        public string OblastRada;
        public string Odgovornosti;
        public bool FlagA;
        public bool FlagP;
        public bool FlagN;
        public bool FlagAO;

        public IList<BezbednosnaObukaBasic> BezbednosneObuke { get; set; }
        public IList<LekarskiPregledBasic> LekarskiPregledi { get; set; }
        public virtual IList<SertifikatSpecOpremeBasic> SertifikatiSpecOpreme { get; set; }
        public virtual IList<ZastitnaOpremaBasic> ZastitneOpreme { get; set; }
        public FizickoLiceBasic()
        {
            BezbednosneObuke = new List<BezbednosnaObukaBasic>();
            LekarskiPregledi = new List<LekarskiPregledBasic>();
            SertifikatiSpecOpreme = new List<SertifikatSpecOpremeBasic>();
            ZastitneOpreme = new List<ZastitnaOpremaBasic>();
        }

        public FizickoLiceBasic(
            int id,long jmbg,string ime,string prezime,DateTime datumRodjenja,string struka,bool flagBK,bool flagR, string kvalifikacija,bool flagI,string oblastRada,string odgovornosti,bool flagA,bool flagP,bool flagN,bool flagAO)
            : base(id, jmbg, ime, prezime, datumRodjenja, struka)
        {
            FlagBK = flagBK;
            FlagR = flagR;
            Kvalifikacija = kvalifikacija;
            FlagI = flagI;
            OblastRada = oblastRada;
            Odgovornosti = odgovornosti;
            FlagA = flagA;
            FlagP = flagP;
            FlagN = flagN;
            FlagAO = flagAO;
        }
    }

    public class FizickoLicePregled : OsobaPregled
    {
        public bool FlagBK;
        public bool FlagR;
        public string Kvalifikacija;
        public bool FlagI;
        public string OblastRada;
        public string Odgovornosti;
        public bool FlagA;
        public bool FlagP;
        public bool FlagN;
        public bool FlagAO;
        public FizickoLicePregled()
        {   

        }

        public FizickoLicePregled(
            int id, long jmbg, string ime, string prezime, DateTime datumRodjenja, string struka, bool flagBK, bool flagR, string kvalifikacija, bool flagI, string oblastRada, string odgovornosti, bool flagA, bool flagP, bool flagN, bool flagAO)
            : base(id, jmbg, ime, prezime, datumRodjenja, struka)
        {
            FlagBK = flagBK;
            FlagR = flagR;
            Kvalifikacija = kvalifikacija;
            FlagI = flagI;
            OblastRada = oblastRada;
            Odgovornosti = odgovornosti;
            FlagA = flagA;
            FlagP = flagP;
            FlagN = flagN;
            FlagAO = flagAO;
        }
    }
    #endregion

    #region PravnaLica

    
    public class PravnaLicaBasic : OsobaBasic
    {
        public bool FlagPB;
        public bool FlagInve;
        public bool FlagIzv;
        public bool FlagP;
        public bool FlagD;
        public bool FlagN;

        public virtual IList<FakturaBasic> IzdateFakture { get; set; }
        public virtual IList<FakturaBasic> PrimljeneFakture { get; set; }
        public PravnaLicaBasic()
        {
            IzdateFakture = new List<FakturaBasic>();
            PrimljeneFakture = new List<FakturaBasic>();
        }

        public PravnaLicaBasic(int id,long jmbg,string ime,string prezime,DateTime datumRodjenja,string struka,bool flagPB,bool flagInve,bool flagIzv,bool flagP,bool flagD,bool flagN)
            : base(id, jmbg, ime, prezime, datumRodjenja, struka)
        {
            FlagPB = flagPB;
            FlagInve = flagInve;
            FlagIzv = flagIzv;
            FlagP = flagP;
            FlagD = flagD;
            FlagN = flagN;
        }
    }
    
    public class PravnaLicaPregled : OsobaPregled
    {
        public bool FlagPB;
        public bool FlagInve;
        public bool FlagIzv;
        public bool FlagP;
        public bool FlagD;
        public bool FlagN;

        public PravnaLicaPregled()
        {
        }

        public PravnaLicaPregled(int id, long jmbg, string ime, string prezime, DateTime datumRodjenja, string struka, bool flagPB, bool flagInve, bool flagIzv, bool flagP, bool flagD, bool flagN)
            : base(id, jmbg, ime, prezime, datumRodjenja, struka)
        {
            FlagPB = flagPB;
            FlagInve = flagInve;
            FlagIzv = flagIzv;
            FlagP = flagP;
            FlagD = flagD;
            FlagN = flagN;
        }
    }
    #endregion

    #endregion
    
    //proveri
    #region Kontakt
    public class KontaktBasic
    {
        public int Id;
        public int IdOsoba;
        public string Broj;

        public KontaktBasic() { }

        public KontaktBasic(int id,int osoba, string broj)
        {
            Id = id;
            IdOsoba = osoba;
            Broj = broj;
        }
    }
    public class KontaktPregled
    {
        public int Id;
        public int IdOsoba;
        public string Broj;

        public KontaktPregled() { }

        public KontaktPregled(int id,int osoba, string broj)
        {
            Id = id;
            IdOsoba = osoba;
            Broj = broj;
        }
    }
    #endregion
    //proveri
    #region Licenca

    public class LicencaBasic
    {
        public int Id;
        public int IdOsoba;
        public string NazivLicence;

        public LicencaBasic() { }
        public LicencaBasic(int id,int osoba, string nazivLicence)
        {
            Id = id;
            IdOsoba = osoba;
            NazivLicence = nazivLicence;
        }
    }
    public class LicencaPregled
    {
        public int Id;
        public int IdOsoba;
        public string NazivLicence;

        public LicencaPregled() { }
        public LicencaPregled(int id,int osoba, string nazivLicence)
        {
            Id = id;
            IdOsoba = osoba;
            NazivLicence = nazivLicence;
        }
    }

    #endregion

    #region Zadatak

    public class ZadatakBasic
    {
        public int Id;
        public string Naziv;
        public string Opis;
        public decimal ProcenjeniTrosak;
        public DateTime? PlaniraniZavrsetak;
        public DateTime? StvarniZavrsetak;
        public DateTime? PlaniraniPocetak;
        public DateTime? StvarniPocetak;
        public int Prioritet;
        public string Status;

        public FazaBasic Faza;
        public ZadatakBasic Roditelj;
        public virtual IList<ZadatakBasic> Podzadaci { get; set; }
        public virtual IList<RadniNalogBasic> RadniNalozi { get; set; }
        public virtual IList<NapredakBasic> Napreci { get; set; }
        public virtual IList<KontrolaKvalitetaBasic> KontroleKvaliteta { get; set; }
        public virtual IList<AngazovanBasic> Angazovani { get; set; }
        public virtual IList<AngazujeBasic> AngazovanaOprema { get; set; }


        public ZadatakBasic()
        {

            Podzadaci = new List<ZadatakBasic>();
            RadniNalozi = new List<RadniNalogBasic>();
            Napreci = new List<NapredakBasic>();
            KontroleKvaliteta = new List<KontrolaKvalitetaBasic>();
            Angazovani = new List<AngazovanBasic>();
            AngazovanaOprema = new List<AngazujeBasic>();
        }

        public ZadatakBasic(int id, string naziv, string opis, decimal procenjeniTrosak, DateTime? planiraniZavrsetak, DateTime? stvarniZavrsetak, DateTime? planiraniPocetak, DateTime? stvarniPocetak, int prioritet, string status, FazaBasic faza, ZadatakBasic roditelj)
        {
            Id = id;
            Naziv = naziv;
            Opis = opis;
            ProcenjeniTrosak = procenjeniTrosak;
            PlaniraniZavrsetak = planiraniZavrsetak;
            StvarniZavrsetak = stvarniZavrsetak;
            PlaniraniPocetak = planiraniPocetak;
            StvarniPocetak = stvarniPocetak;
            Prioritet = prioritet;
            Status = status;
            Faza = faza;
            Roditelj = roditelj;
        }
    }

    public class ZadatakPregled
    {
        public int Id;
        public string Naziv;
        public string Opis;
        public decimal ProcenjeniTrosak;
        public DateTime? PlaniraniZavrsetak;
        public DateTime? StvarniZavrsetak;
        public DateTime? PlaniraniPocetak;
        public DateTime? StvarniPocetak;
        public int Prioritet;
        public string Status;

        public FazaPregled Faza;
        public ZadatakPregled NadZadatak;
        public ZadatakPregled()
        {
        }

        public ZadatakPregled(int id, string naziv, string opis, decimal procenjeniTrosak, DateTime? planiraniZavrsetak, DateTime? stvarniZavrsetak, DateTime? planiraniPocetak, DateTime? stvarniPocetak, int prioritet, string status, FazaPregled faza, ZadatakPregled zadatak)
        {
            Id = id;
            Naziv = naziv;
            Opis = opis;
            ProcenjeniTrosak = procenjeniTrosak;
            PlaniraniZavrsetak = planiraniZavrsetak;
            StvarniZavrsetak = stvarniZavrsetak;
            PlaniraniPocetak = planiraniPocetak;
            StvarniPocetak = stvarniPocetak;
            Prioritet = prioritet;
            Status = status;
            Faza = faza;
            NadZadatak = zadatak;
        }
    }

    #endregion

    #region Angazovan
    public class AngazovanBasic
    {
        public ZadatakBasic Zadatak;
        public OsobaBasic Osoba;
        public DateTime DatumOd;
        public DateTime? DatumDo;
        public string StatusAngazovanja;

        public AngazovanBasic()
        {   

        }
        public AngazovanBasic(ZadatakBasic zadatak, OsobaBasic osoba, DateTime datumOd, DateTime? datumDo, string statusAngazovanja)
        {
            Zadatak = zadatak;
            Osoba = osoba;
            DatumOd = datumOd;
            DatumDo = datumDo;
            StatusAngazovanja = statusAngazovanja;
        }
    }

    public class AngazovanPregled
    {
        public ZadatakPregled Zadatak;
        public OsobaPregled Osoba;
        public DateTime DatumOd;
        public DateTime? DatumDo;
        public string StatusAngazovanja;

        public AngazovanPregled()
        {

        }
        public AngazovanPregled(ZadatakPregled zadatak, OsobaPregled osoba, DateTime datumOd, DateTime? datumDo, string statusAngazovanja)
        {
            Zadatak = zadatak;
            Osoba = osoba;
            DatumOd = datumOd;
            DatumDo = datumDo;
            StatusAngazovanja = statusAngazovanja;
        }
    }

    #endregion

    #region ImaUgovornuStranu
    public class ImaUgovornuStranuBasic
    {
        public OsobaBasic Osoba;
        public UgovorBasic Ugovor;
        public string Uloga;

        public ImaUgovornuStranuBasic()
        {

        }

        public ImaUgovornuStranuBasic(OsobaBasic osoba, UgovorBasic ugovor, string uloga)
        {
            Osoba = osoba;
            Ugovor = ugovor;
            Uloga = uloga;
        }
    }

    public class ImaUgovornuStranuPregled
    {
        public OsobaPregled Osoba;
        public UgovorPregled Ugovor;
        public string Uloga;

        public ImaUgovornuStranuPregled()
        {

        }

        public ImaUgovornuStranuPregled(OsobaPregled osoba, UgovorPregled ugovor, string uloga)
        {
            Osoba = osoba;
            Ugovor = ugovor;
            Uloga = uloga;
        }
    }

    #endregion

    #region Ugovor

    public class UgovorBasic
    {
        public int Id;
        public DateTime DatumPotpisivanja;
        public decimal Vrednost;
        public string PredmetUgovora;
        public string Valuta;
        public DateTime Rok;
        public MaterijalBasic Materijal;
        public ProjekatBasic Projekat;
        public OpremaBasic Oprema;

        public virtual IList<ImaUgovornuStranuBasic> UgovorneStrane { get; set; }
        public virtual IList<PosebnaKlauzulaBasic> PosebneKlauzule { get; set; }
        public UgovorBasic()
        {
            UgovorneStrane = new List<ImaUgovornuStranuBasic>();
            PosebneKlauzule = new List<PosebnaKlauzulaBasic>();
        }
        public UgovorBasic(int id, DateTime datumPotpisivanja, decimal vrednost, string predmetUgovora, string valuta, DateTime rok, MaterijalBasic materijal, ProjekatBasic projekat, OpremaBasic oprema)
        {
            Id = id;
            DatumPotpisivanja = datumPotpisivanja;
            Vrednost = vrednost;
            PredmetUgovora = predmetUgovora;
            Valuta = valuta;
            Rok = rok;
            Materijal = materijal;
            Projekat = projekat;
            Oprema = oprema;
        }
    }

    public class UgovorPregled
    {
        public int Id;
        public DateTime DatumPotpisivanja;
        public decimal Vrednost;
        public string PredmetUgovora;
        public string Valuta;
        public DateTime Rok;
        public MaterijalPregled Materijal;
        public ProjekatPregled Projekat;
        public OpremaPregled Oprema;

        public UgovorPregled()
        {
        }
        public UgovorPregled(int id, DateTime datumPotpisivanja, decimal vrednost, string predmetUgovora, string valuta, DateTime rok, MaterijalPregled materijal, ProjekatPregled projekat, OpremaPregled oprema)
        {
            Id = id;
            DatumPotpisivanja = datumPotpisivanja;
            Vrednost = vrednost;
            PredmetUgovora = predmetUgovora;
            Valuta = valuta;
            Rok = rok;
            Materijal = materijal;
            Projekat = projekat;
            Oprema = oprema;
        }
    }

    #endregion

    #region Angazuje

    public class AngazujeBasic
    {
        public ZadatakBasic Zadatak;
        public OpremaBasic Oprema;

        public DateTime? DatumOd;
        public DateTime? DatumDo;
        public int BrojSati;

        public AngazujeBasic()
        {
        }

        public AngazujeBasic(ZadatakBasic zadatak,OpremaBasic oprema,DateTime? datumOd,DateTime? datumDo,int brojSati)
        {
            Zadatak = zadatak;
            Oprema = oprema;
            DatumOd = datumOd;
            DatumDo = datumDo;
            BrojSati = brojSati;
        }
    }
    public class AngazujePregled
    {
        public ZadatakPregled  Zadatak;
        public OpremaPregled Oprema;

        public DateTime? DatumOd;
        public DateTime? DatumDo;
        public int BrojSati;

        public AngazujePregled()
        {
        }

        public AngazujePregled(ZadatakPregled zadatak, OpremaPregled oprema, DateTime? datumOd, DateTime? datumDo, int brojSati)
        {
            Zadatak = zadatak;
            Oprema = oprema;
            DatumOd = datumOd;
            DatumDo = datumDo;
            BrojSati = brojSati;
        }
    }
    #endregion

    #region Oprema

    public class OpremaBasic
    {
        public int Id;
        public string Naziv;
        public string Tip;
        public DateTime DatumUvoza;
        public string Proizvodjac;
        public DateTime DatumNabavke;
        public string RasponOdrzavanja;
        public string Lokacija;
        public string Status;

        public IList<UgovorBasic> Ugovori;
        public IList<AngazujeBasic> Angazovanja;

        public OpremaBasic()
        {
            Ugovori = new List<UgovorBasic>();
            Angazovanja = new List<AngazujeBasic>();
        }

        public OpremaBasic(int id,string naziv,string tip,DateTime datumUvoza,string proizvodjac,DateTime datumNabavke,string rasponOdrzavanja,string lokacija,string status) : this()
        {
            Id = id;
            Naziv = naziv;
            Tip = tip;
            DatumUvoza = datumUvoza;
            Proizvodjac = proizvodjac;
            DatumNabavke = datumNabavke;
            RasponOdrzavanja = rasponOdrzavanja;
            Lokacija = lokacija;
            Status = status;
        }
    }

    public class OpremaPregled
    {
        public int Id;
        public string Naziv;
        public string Tip;
        public DateTime DatumUvoza;
        public string Proizvodjac;
        public DateTime DatumNabavke;
        public string RasponOdrzavanja;
        public string Lokacija;
        public string Status;

        public OpremaPregled()
        {
        }

        public OpremaPregled(int id,string naziv,string tip,DateTime datumUvoza,string proizvodjac,DateTime datumNabavke,string rasponOdrzavanja,string lokacija,string status)
        {
            Id = id;
            Naziv = naziv;
            Tip = tip;
            DatumUvoza = datumUvoza;
            Proizvodjac = proizvodjac;
            DatumNabavke = datumNabavke;
            RasponOdrzavanja = rasponOdrzavanja;
            Lokacija = lokacija;
            Status = status;
        }
    }

    #endregion
    //proveri
    #region BezbednosnaObuka

    public class BezbednosnaObukaBasic
    {
        public int Id;
        public int IdFizickoLice;
        public string NazivObuke;
        public DateTime Datum;
        public BezbednosnaObukaBasic()
        {
        }
        public BezbednosnaObukaBasic(int id,int idfizickoLice,string nazivObuke,DateTime datum)
        {
            Id = id;
            IdFizickoLice = idfizickoLice;
            NazivObuke = nazivObuke;
            Datum = datum;
        }
    }
    public class BezbednosnaObukaPregled
    {
        public int Id;
        public int IdFizickoLice;
        public string NazivObuke;
        public DateTime Datum;

        public BezbednosnaObukaPregled()
        {
        }

        public BezbednosnaObukaPregled(int id,int idfizickoLice,string nazivObuke,DateTime datum)
        {
            Id = id;
            IdFizickoLice = idfizickoLice;
            NazivObuke = nazivObuke;
            Datum = datum;
        }
    }
    #endregion
    //proveri
    #region LekarskiPregled

    public class LekarskiPregledBasic
    {
        public int Id;
        public int IdFizickoLice;
        public string Rezultat;
        public DateTime Datum;
        public LekarskiPregledBasic()
        {
        }
        public LekarskiPregledBasic(int id,int idfizickoLice,string rezultat,DateTime datum)
        {
            Id = id;
            IdFizickoLice = idfizickoLice;
            Rezultat = rezultat;
            Datum = datum;
        }
    }

    public class LekarskiPregledPregled
    {
        public int Id;
        public int IdFizickoLice;
        public string Rezultat;
        public DateTime Datum;

        public LekarskiPregledPregled()
        {
        }

        public LekarskiPregledPregled(int id,int idfizickoLice,string rezultat,DateTime datum)
        {
            IdFizickoLice = idfizickoLice;
            Rezultat = rezultat;
            Datum = datum;
        }
    }
    #endregion

    #region Faza

    public class FazaBasic
    {
        public string Naziv;
        public string TipFaze;
        public DateTime? DatumOd;
        public DateTime? DatumDo;
        public string Status;
        public int? Budzet;

        public ProjekatBasic Projekat;
        public FizickoLiceBasic FizickoLice;
        public FazaBasic NadFaza;

        public IList<FazaBasic> PodFaze;
        public IList<ZadatakBasic> Zadaci;

        public FazaBasic()
        {
            PodFaze = new List<FazaBasic>();
            Zadaci = new List<ZadatakBasic>();
        }

        public FazaBasic(string naziv,string tipFaze,DateTime? datumOd,DateTime? datumDo,string status,int? budzet,ProjekatBasic projekat,FizickoLiceBasic fizickoLice,FazaBasic nadFaza)
        {
            Naziv = naziv;
            TipFaze = tipFaze;
            DatumOd = datumOd;
            DatumDo = datumDo;
            Status = status;
            Budzet = budzet;
            Projekat = projekat;
            FizickoLice = fizickoLice;
            NadFaza = nadFaza;
        }
    }

    public class FazaPregled
    {
        public string Naziv;
        public string TipFaze;
        public DateTime? DatumOd;
        public DateTime? DatumDo;
        public string Status;
        public int? Budzet;

        public ProjekatPregled Projekat;
        public FizickoLicePregled FizickoLice;
        public FazaPregled NadFaza;

        public FazaPregled()
        {
        }

        public FazaPregled(string naziv,string tipFaze,DateTime? datumOd,DateTime? datumDo,string status,int? budzet,ProjekatPregled projekat,FizickoLicePregled fizickoLice,FazaPregled nadFaza)
        {
            Naziv = naziv;
            TipFaze = tipFaze;
            DatumOd = datumOd;
            DatumDo = datumDo;
            Status = status;
            Budzet = budzet;
            Projekat = projekat;
            FizickoLice = fizickoLice;
            NadFaza = nadFaza;
        }
    }


    #endregion
    //proveri
    #region Fotografija

    public class FotografijaBasic
    {
        public int IdNapredak;
        public string Putanja;

        public FotografijaBasic()
        {
        }
        public FotografijaBasic(int napredak, string putanja)
        {
            IdNapredak = napredak;
            Putanja = putanja;
        }
    }
    public class FotografijaPregled
    {
        public int IdNapredak;
        public string Putanja;

        public FotografijaPregled()
        {
        }
        public FotografijaPregled(int idNapredak, string putanja)
        {
            IdNapredak = idNapredak;
            Putanja = putanja;
        }
    }
    #endregion

    #region KontrolaKvaliteta

    public class KontrolaKvalitetaBasic
    {
        public int Id;
        public DateTime? DatumInspekcije;
        public string PrimedbeNadzora;
        public string Zapisnik;
        public bool ZabranaNastavkaRadova;
        public string RazlogZabrane;
        public string DatumOtklanjanjaZabrane;

        public ZadatakBasic Zadatak;

        public IList<StavkaKontroleBasic> StavkeKontrole;

        public KontrolaKvalitetaBasic()
        {
            StavkeKontrole = new List<StavkaKontroleBasic>();
        }

        public KontrolaKvalitetaBasic(int id,DateTime? datumInspekcije,string primedbeNadzora,string zapisnik,bool zabranaNastavkaRadova,string razlogZabrane,string datumOtklanjanjaZabrane,ZadatakBasic zadatak)
        {
            Id = id;
            DatumInspekcije = datumInspekcije;
            PrimedbeNadzora = primedbeNadzora;
            Zapisnik = zapisnik;
            ZabranaNastavkaRadova = zabranaNastavkaRadova;
            RazlogZabrane = razlogZabrane;
            DatumOtklanjanjaZabrane = datumOtklanjanjaZabrane;
            Zadatak = zadatak;
        }
    }

    public class KontrolaKvalitetaPregled
    {
        public int Id;
        public DateTime? DatumInspekcije;
        public string PrimedbeNadzora;
        public string Zapisnik;
        public bool ZabranaNastavkaRadova;
        public string RazlogZabrane;
        public string DatumOtklanjanjaZabrane;

        public ZadatakPregled Zadatak;

        public KontrolaKvalitetaPregled()
        {
        }

        public KontrolaKvalitetaPregled(int id,DateTime? datumInspekcije,string primedbeNadzora,string zapisnik,bool zabranaNastavkaRadova,string razlogZabrane,string datumOtklanjanjaZabrane,ZadatakPregled zadatak)
        {
            Id = id;
            DatumInspekcije = datumInspekcije;
            PrimedbeNadzora = primedbeNadzora;
            Zapisnik = zapisnik;
            ZabranaNastavkaRadova = zabranaNastavkaRadova;
            RazlogZabrane = razlogZabrane;
            DatumOtklanjanjaZabrane = datumOtklanjanjaZabrane;
            Zadatak = zadatak;
        }
    }

    #endregion

    #region StavkaKontrole

    public class StavkaKontroleBasic
    {
        public int Id;
        public KontrolaKvalitetaBasic Kontrola;
        public int RedniBrojStavke;
        public string Uzorci;
        public string LabNalazi;
        public string RezultatiIspitivanja;
        public string KorektivneMere;
        public DateTime? RokZaOtklanjanje;

        public StavkaKontroleBasic()
        {
        }

        public StavkaKontroleBasic(int id,KontrolaKvalitetaBasic kontrola,int redniBrojStavke,string uzorci,string labNalazi,string rezultatiIspitivanja,string korektivneMere,DateTime? rokZaOtklanjanje)
        {
            Id = id;
            Kontrola = kontrola;
            RedniBrojStavke = redniBrojStavke;
            Uzorci = uzorci;
            LabNalazi = labNalazi;
            RezultatiIspitivanja = rezultatiIspitivanja;
            KorektivneMere = korektivneMere;
            RokZaOtklanjanje = rokZaOtklanjanje;
        }
    }

    public class StavkaKontrolePregled
    {   
        public int Id;
        public KontrolaKvalitetaPregled Kontrola;
        public int RedniBrojStavke;
        public string Uzorci;
        public string LabNalazi;
        public string RezultatiIspitivanja;
        public string KorektivneMere;
        public DateTime? RokZaOtklanjanje;

        public StavkaKontrolePregled()
        {
        }

        public StavkaKontrolePregled(int id, KontrolaKvalitetaPregled kontrola,int redniBrojStavke,string uzorci,string labNalazi,string rezultatiIspitivanja,string korektivneMere,DateTime? rokZaOtklanjanje)
        {   
            Id = id;
            Kontrola = kontrola;
            RedniBrojStavke = redniBrojStavke;
            Uzorci = uzorci;
            LabNalazi = labNalazi;
            RezultatiIspitivanja = rezultatiIspitivanja;
            KorektivneMere = korektivneMere;
            RokZaOtklanjanje = rokZaOtklanjanje;
        }
    }

    #endregion

    #region Napredak
    public class NapredakBasic
    {
        public int Id;
        public DateTime Datum;
        public ZadatakBasic Zadatak;
        public string DnevniIzvestaj;
        public int ProcenatRealizacije;
        public string PrimedbaNadzora;
        public string KorektivnaMera;

        public IList<FotografijaBasic> Fotografije;

        public NapredakBasic()
        {
            Fotografije = new List<FotografijaBasic>();
        }

        public NapredakBasic(int id,DateTime datum,ZadatakBasic zadatak,string dnevniIzvestaj,int procenatRealizacije,string primedbaNadzora,string korektivnaMera)
        {
            Id = id;
            Datum = datum;
            Zadatak = zadatak;
            DnevniIzvestaj = dnevniIzvestaj;
            ProcenatRealizacije = procenatRealizacije;
            PrimedbaNadzora = primedbaNadzora;
            KorektivnaMera = korektivnaMera;
        }
    }

    public class NapredakPregled
    {
        public int Id;
        public DateTime Datum;
        public ZadatakPregled Zadatak;
        public string DnevniIzvestaj;
        public int ProcenatRealizacije;
        public string PrimedbaNadzora;
        public string KorektivnaMera;

        public NapredakPregled()
        {
        }

        public NapredakPregled(int id,DateTime datum,ZadatakPregled zadatak,string dnevniIzvestaj,int procenatRealizacije,string primedbaNadzora,string korektivnaMera)
        {
            Id = id;
            Datum = datum;
            Zadatak = zadatak;
            DnevniIzvestaj = dnevniIzvestaj;
            ProcenatRealizacije = procenatRealizacije;
            PrimedbaNadzora = primedbaNadzora;
            KorektivnaMera = korektivnaMera;
        }
    }
    #endregion
    //proveri
    #region PosebnaKlauzula

    public class PosebnaKlauzulaBasic
    {
        public int Id;
        public int IdUgovor;
        public string TekstKlauzule;

        public PosebnaKlauzulaBasic()
        {
        }

        public PosebnaKlauzulaBasic(int id,int idUgovor, string tekstKlauzule)
        {
            Id = id;
            IdUgovor = idUgovor;
            TekstKlauzule = tekstKlauzule;
        }
    }

    public class PosebnaKlauzulaPregled
    {
        public int Id;
        public int IdUgovor;
        public string TekstKlauzule;

        public PosebnaKlauzulaPregled()
        {
        }

        public PosebnaKlauzulaPregled(int id,int idUgovor, string tekstKlauzule)
        {
            Id = id;
            IdUgovor = idUgovor;
            TekstKlauzule = tekstKlauzule;
        }
    }

    #endregion

    #region RadniNalog

    public class RadniNalogBasic
    {
        public int BrNaloga;
        public ZadatakBasic Zadatak;
        public string Status;
        public DateTime? DatumIzdavanja;

        public RadniNalogBasic()
        {
        }

        public RadniNalogBasic(int brNaloga,ZadatakBasic zadatak,string status,DateTime? datumIzdavanja)
        {
            BrNaloga = brNaloga;
            Zadatak = zadatak;
            Status = status;
            DatumIzdavanja = datumIzdavanja;
        }
    }

    public class RadniNalogPregled
    {
        public int BrNaloga;
        public ZadatakPregled Zadatak;
        public string Status;
        public DateTime? DatumIzdavanja;

        public RadniNalogPregled()
        {
        }

        public RadniNalogPregled(int brNaloga,ZadatakPregled zadatak,string status,DateTime? datumIzdavanja)
        {
            BrNaloga = brNaloga;
            Zadatak = zadatak;
            Status = status;
            DatumIzdavanja = datumIzdavanja;
        }
    }

    #endregion
    //proveri
    #region SertifikatSpecOpreme
    public class SertifikatSpecOpremeBasic
    {
        public int Id;
        public int IdFizickoLice;
        public string Sertifikat;

        public SertifikatSpecOpremeBasic()
        {

        }
        public SertifikatSpecOpremeBasic(int id,int idFizickoLice, string sertifikat)
        {
            Id = id;
            IdFizickoLice = idFizickoLice;
            Sertifikat = sertifikat;
        }
    }

    public class SertifikatSpecOpremePregled
    {
        public int Id;
        public int IdFizickoLice;
        public string Sertifikat;

        public SertifikatSpecOpremePregled()
        {

        }
        public SertifikatSpecOpremePregled(int id,int idFizickoLice, string sertifikat)
        {
            Id = id;
            IdFizickoLice = idFizickoLice;
            Sertifikat = sertifikat;
        }
    }


    #endregion
    //proveri
    #region ZastitnaOprema

    public class ZastitnaOpremaBasic
    {
        public int Id;
        public int IdFizickoLice;
        public string NazivOpreme;

        public ZastitnaOpremaBasic()
        {

        }
        public ZastitnaOpremaBasic(int id,int idFizickoLice, string nazivOpreme)
        {
            Id = Id;
            IdFizickoLice = idFizickoLice;
            NazivOpreme = nazivOpreme;
        }
    }

    public class ZastitnaOpremaPregled
    {
        public int Id;
        public int IdFizickoLice;
        public string NazivOpreme;

        public ZastitnaOpremaPregled()
        {

        }
        public ZastitnaOpremaPregled(int id,int idFizickoLice, string nazivOpreme)
        {
            Id = id;
            IdFizickoLice = idFizickoLice;
            NazivOpreme = nazivOpreme;
        }
    }

    #endregion

    #region BezbednosniIncident

    public class BezbednosniIncidentBasic
    {
        public int ID;
        public string Opis;
        public DateTime Datum;
        public string Lokacija;
        public string Preduzete_mere;
        public string Posledice;
        public string Tip_incidenta;
        public ProjekatBasic Projekat;
        public OsobaBasic Osoba;

        public BezbednosniIncidentBasic() { }
        public BezbednosniIncidentBasic(int iD, string opis, DateTime datum, string lokacija, string preduzete_mere, string posledice, string tip_incidenta, ProjekatBasic projekat, OsobaBasic osoba)
        {
            ID = iD;
            Opis = opis;
            Datum = datum;
            Lokacija = lokacija;
            Preduzete_mere = preduzete_mere;
            Posledice = posledice;
            Tip_incidenta = tip_incidenta;
            Projekat = projekat;
            Osoba = osoba;
        }
    }

    public class PovredaNaRaduBasic : BezbednosniIncidentBasic
    {
        public PovredaNaRaduBasic() { }
        public PovredaNaRaduBasic(int iD, string opis, DateTime datum, string lokacija, string preduzete_mere, string posledice, string tip_incidenta, ProjekatBasic projekat, OsobaBasic osoba) : base(iD, opis, datum, lokacija, preduzete_mere, posledice, tip_incidenta, projekat, osoba)
        {
        }
    }
    public class KvarOpremeBasic : BezbednosniIncidentBasic
    {
        public KvarOpremeBasic() { }
        public KvarOpremeBasic(int iD, string opis, DateTime datum, string lokacija, string preduzete_mere, string posledice, string tip_incidenta, ProjekatBasic projekat, OsobaBasic osoba) : base(iD, opis, datum, lokacija, preduzete_mere, posledice, tip_incidenta, projekat, osoba)
        {
        }
    }
    public class NepostovanjeProceduraBasic : BezbednosniIncidentBasic
    {
        public NepostovanjeProceduraBasic() { }
        public NepostovanjeProceduraBasic(int iD, string opis, DateTime datum, string lokacija, string preduzete_mere, string posledice, string tip_incidenta, ProjekatBasic projekat, OsobaBasic osoba) : base(iD, opis, datum, lokacija, preduzete_mere, posledice, tip_incidenta, projekat, osoba)
        {
        }
    }
    public class OpasnaSituacijaBasic : BezbednosniIncidentBasic
    {
        public OpasnaSituacijaBasic() { }
        public OpasnaSituacijaBasic(int iD, string opis, DateTime datum, string lokacija, string preduzete_mere, string posledice, string tip_incidenta, ProjekatBasic projekat, OsobaBasic osoba) : base(iD, opis, datum, lokacija, preduzete_mere, posledice, tip_incidenta, projekat, osoba)
        {
        }
    }
    public class EkoloskiIncidentBasic : BezbednosniIncidentBasic
    {
        public EkoloskiIncidentBasic() { }
        public EkoloskiIncidentBasic(int iD, string opis, DateTime datum, string lokacija, string preduzete_mere, string posledice, string tip_incidenta, ProjekatBasic projekat, OsobaBasic osoba) : base(iD, opis, datum, lokacija, preduzete_mere, posledice, tip_incidenta, projekat, osoba)
        {
        }
    }
    public class BezbednosniIncidentPregled
    {
        public int ID;
        public string Opis;
        public DateTime Datum;
        public string Lokacija;
        public string Preduzete_mere;
        public string Posledice;
        public string Tip_incidenta;
        public ProjekatPregled Projekat;
        public OsobaPregled Osoba;

        public BezbednosniIncidentPregled() { }

        public BezbednosniIncidentPregled(int iD, string opis, DateTime datum, string lokacija, string preduzete_mere, string posledice, string tip_incidenta, ProjekatPregled projekat, OsobaPregled osoba)
        {
            ID = iD;
            Opis = opis;
            Datum = datum;
            Lokacija = lokacija;
            Preduzete_mere = preduzete_mere;
            Posledice = posledice;
            Tip_incidenta = tip_incidenta;
            Projekat = projekat;
            Osoba = osoba;
        }
    }

    public class PovredaNaRaduPregled : BezbednosniIncidentPregled
    {
        public PovredaNaRaduPregled() { }
        public PovredaNaRaduPregled(int iD, string opis, DateTime datum, string lokacija, string preduzete_mere, string posledice, string tip_incidenta, ProjekatPregled projekat, OsobaPregled osoba) : base(iD, opis, datum, lokacija, preduzete_mere, posledice, tip_incidenta, projekat, osoba)
        {
        }
    }
    public class KvarOpremePregled : BezbednosniIncidentPregled
    {
        public KvarOpremePregled() { }
        public KvarOpremePregled(int iD, string opis, DateTime datum, string lokacija, string preduzete_mere, string posledice, string tip_incidenta, ProjekatPregled projekat, OsobaPregled osoba) : base(iD, opis, datum, lokacija, preduzete_mere, posledice, tip_incidenta, projekat, osoba)
        {
        }
    }
    public class NepostovanjeProceduraPregled : BezbednosniIncidentPregled
    {
        public NepostovanjeProceduraPregled() { }
        public NepostovanjeProceduraPregled(int iD, string opis, DateTime datum, string lokacija, string preduzete_mere, string posledice, string tip_incidenta, ProjekatPregled projekat, OsobaPregled osoba) : base(iD, opis, datum, lokacija, preduzete_mere, posledice, tip_incidenta, projekat, osoba)
        {
        }
    }
    public class OpasnaSituacijaPregled : BezbednosniIncidentPregled
    {
        public OpasnaSituacijaPregled() { }
        public OpasnaSituacijaPregled(int iD, string opis, DateTime datum, string lokacija, string preduzete_mere, string posledice, string tip_incidenta, ProjekatPregled projekat, OsobaPregled osoba) : base(iD, opis, datum, lokacija, preduzete_mere, posledice, tip_incidenta, projekat, osoba)
        {
        }
    }
    public class EkoloskiIncidentPregled : BezbednosniIncidentPregled
    {
        public EkoloskiIncidentPregled() { }
        public EkoloskiIncidentPregled(int iD, string opis, DateTime datum, string lokacija, string preduzete_mere, string posledice, string tip_incidenta, ProjekatPregled projekat, OsobaPregled osoba) : base(iD, opis, datum, lokacija, preduzete_mere, posledice, tip_incidenta, projekat, osoba)
        {
        }
    }
    #endregion

    #region Faktura
    public class FakturaBasic
    {
        public int Br_fakture;
        public int Iznos;
        public string Valuta;
        public bool StatusPlacanja;
        public DateTime Datum;
        public ProjekatBasic Projekat;
        public PravnaLicaBasic PravnoLiceIzdaje;
        public PravnaLicaBasic PravnoLicePrima;

        public FakturaBasic() { }

        public FakturaBasic(int br_fakture, int iznos, string valuta, bool statusPlacanja, DateTime datum, ProjekatBasic projekat, PravnaLicaBasic pravnoLiceIzdaje, PravnaLicaBasic pravnoLicePrima)
        {
            Br_fakture = br_fakture;
            Iznos = iznos;
            Valuta = valuta;
            StatusPlacanja = statusPlacanja;
            Datum = datum;
            Projekat = projekat;
            PravnoLiceIzdaje = pravnoLiceIzdaje;
            PravnoLicePrima = pravnoLicePrima;
        }
    }

    public class FakturaPregled
    {
        public int Br_fakture;
        public int Iznos;
        public string Valuta;
        public bool StatusPlacanja;
        public DateTime Datum;
        public ProjekatPregled Projekat;
        public PravnaLicaPregled PravnoLiceIzdaje;
        public PravnaLicaPregled PravnoLicePrima;

        public FakturaPregled() { }

        public FakturaPregled(int br_fakture, int iznos, string valuta, bool statusPlacanja, DateTime datum, ProjekatPregled projekat, PravnaLicaPregled pravnoLiceIzdaje, PravnaLicaPregled pravnoLicePrima)
        {
            Br_fakture = br_fakture;
            Iznos = iznos;
            Valuta = valuta;
            StatusPlacanja = statusPlacanja;
            Datum = datum;
            Projekat = projekat;
            PravnoLiceIzdaje = pravnoLiceIzdaje;
            PravnoLicePrima = pravnoLicePrima;
        }
    }
    #endregion

    #region Projekat
    public class ProjekatBasic
    {
        public int ID;
        public string Naziv;
        public string Opis;
        public string Lokacija;
        public DateTime Datum_pocetka;
        public int Budzet;
        public bool Status;
        public DateTime Planirani_zavrsetak;
        public DateTime Stvarni_zavrsetak;
        public virtual IList<UgovorBasic> Ugovori { get; set; }
        public virtual IList<BezbednosnaObukaBasic> BezbednosniIncidenti { get; set; }

        public ProjekatBasic() 
        {
            Ugovori = new List<UgovorBasic>();
            BezbednosniIncidenti = new List<BezbednosnaObukaBasic>();
        }

        public ProjekatBasic(int iD, string naziv, string opis, string lokacija, DateTime datum_pocetka, int budzet, bool status, DateTime planirani_zavrsetak, DateTime stvarni_zavrsetak)
        {
            ID = iD;
            Naziv = naziv;
            Opis = opis;
            Lokacija = lokacija;
            Datum_pocetka = datum_pocetka;
            Budzet = budzet;
            Status = status;
            Planirani_zavrsetak = planirani_zavrsetak;
            Stvarni_zavrsetak = stvarni_zavrsetak;
        }
    }
    public class ProjekatPregled
    {
        public int ID;
        public string Naziv;
        public string Opis;
        public string Lokacija;
        public DateTime Datum_pocetka;
        public int Budzet;
        public bool Status;
        public DateTime Planirani_zavrsetak;
        public DateTime Stvarni_zavrsetak;

        public ProjekatPregled() { }

        public ProjekatPregled(int iD, string naziv, string opis, string lokacija, DateTime datum_pocetka, int budzet, bool status, DateTime planirani_zavrsetak, DateTime stvarni_zavrsetak)
        {
            ID = iD;
            Naziv = naziv;
            Opis = opis;
            Lokacija = lokacija;
            Datum_pocetka = datum_pocetka;
            Budzet = budzet;
            Status = status;
            Planirani_zavrsetak = planirani_zavrsetak;
            Stvarni_zavrsetak = stvarni_zavrsetak;
        }
    }

    #endregion

    #region Materijal

    public class MaterijalBasic
    {
        public int ID;
        public string Naziv;
        public string Tip;
        public int Cena;
        public string Proizvodjac;
        public string JedinicaMere;
        public string Sertifikat;
        public string TipMaterijala;
        public virtual IList<UgovorBasic> Ugovori { get; set; }
        public virtual IList<KoristiBasic> Koristi { get; set; }
        public virtual IList<NabavkaMaterijalBasic> NabavkaMaterijal { get; set; }

        public MaterijalBasic()
        {
            Ugovori = new List<UgovorBasic>();
            Koristi = new List<KoristiBasic>();
            NabavkaMaterijal = new List<NabavkaMaterijalBasic>();
        }

        public MaterijalBasic(int iD, string naziv, string tip, int cena, string proizvodjac, string jedinicaMere, string sertifikat, string tipMaterijala)
        {
            ID = iD;
            Naziv = naziv;
            Tip = tip;
            Cena = cena;
            Proizvodjac = proizvodjac;
            JedinicaMere = jedinicaMere;
            Sertifikat = sertifikat;
            TipMaterijala = tipMaterijala;
        }
    }

    public class ZastitniBasic : MaterijalBasic
    {
        public ZastitniBasic() { }
        public ZastitniBasic(int iD, string naziv, string tip, int cena, string proizvodjac, string jedinicaMere, string sertifikat, string tipMaterijala) : base(iD, naziv, tip, cena, proizvodjac, jedinicaMere, sertifikat, tipMaterijala)
        {
        }
    }
    public class MasinskiBasic : MaterijalBasic
    {
        public MasinskiBasic() { }
        public MasinskiBasic(int iD, string naziv, string tip, int cena, string proizvodjac, string jedinicaMere, string sertifikat, string tipMaterijala) : base(iD, naziv, tip, cena, proizvodjac, jedinicaMere, sertifikat, tipMaterijala)
        {
        }
    }
    public class GradjevinskiBasic : MaterijalBasic
    {
        public GradjevinskiBasic() { }
        public GradjevinskiBasic(int iD, string naziv, string tip, int cena, string proizvodjac, string jedinicaMere, string sertifikat, string tipMaterijala) : base(iD, naziv, tip, cena, proizvodjac, jedinicaMere, sertifikat, tipMaterijala)
        {
        }
    }
    public class ElektroBasic : MaterijalBasic
    {
        public ElektroBasic() { }
        public ElektroBasic(int iD, string naziv, string tip, int cena, string proizvodjac, string jedinicaMere, string sertifikat, string tipMaterijala) : base(iD, naziv, tip, cena, proizvodjac, jedinicaMere, sertifikat, tipMaterijala)
        {
        }
    }
    public class ZavrsniBasic : MaterijalBasic
    {
        public ZavrsniBasic() { }
        public ZavrsniBasic(int iD, string naziv, string tip, int cena, string proizvodjac, string jedinicaMere, string sertifikat, string tipMaterijala) : base(iD, naziv, tip, cena, proizvodjac, jedinicaMere, sertifikat, tipMaterijala)
        {
        }
    }

    public class MaterijalPregled
    {
        public int ID;
        public string Naziv;
        public string Tip;
        public int Cena;
        public string Proizvodjac;
        public string JedinicaMere;
        public string Sertifikat;
        public string TipMaterijala;

        public MaterijalPregled() { }
        public MaterijalPregled(int iD, string naziv, string tip, int cena, string proizvodjac, string jedinicaMere, string sertifikat, string tipMaterijala)
        {
            ID = iD;
            Naziv = naziv;
            Tip = tip;
            Cena = cena;
            Proizvodjac = proizvodjac;
            JedinicaMere = jedinicaMere;
            Sertifikat = sertifikat;
            TipMaterijala = tipMaterijala;
        }
    }
    public class ZastitniPregled : MaterijalPregled
    {
        public ZastitniPregled() { }
        public ZastitniPregled(int iD, string naziv, string tip, int cena, string proizvodjac, string jedinicaMere, string sertifikat, string tipMaterijala) : base(iD, naziv, tip, cena, proizvodjac, jedinicaMere, sertifikat, tipMaterijala)
        {
        }
    }
    public class MasinskiPregled : MaterijalPregled
    {
        public MasinskiPregled() { }
        public MasinskiPregled(int iD, string naziv, string tip, int cena, string proizvodjac, string jedinicaMere, string sertifikat, string tipMaterijala) : base(iD, naziv, tip, cena, proizvodjac, jedinicaMere, sertifikat, tipMaterijala)
        {
        }
    }
    public class GradjevinskiPregled : MaterijalPregled
    {
        public GradjevinskiPregled(){ }
        public GradjevinskiPregled(int iD, string naziv, string tip, int cena, string proizvodjac, string jedinicaMere, string sertifikat, string tipMaterijala) : base(iD, naziv, tip, cena, proizvodjac, jedinicaMere, sertifikat, tipMaterijala)
        {
        }
    }
    public class ElektroPregled : MaterijalPregled
    {
        public ElektroPregled(){ }
        public ElektroPregled(int iD, string naziv, string tip, int cena, string proizvodjac, string jedinicaMere, string sertifikat, string tipMaterijala) : base(iD, naziv, tip, cena, proizvodjac, jedinicaMere, sertifikat, tipMaterijala)
        {
        }
    }
    public class ZavrsniPregled : MaterijalPregled
    {
        public ZavrsniPregled(){ }
        public ZavrsniPregled(int iD, string naziv, string tip, int cena, string proizvodjac, string jedinicaMere, string sertifikat, string tipMaterijala) : base(iD, naziv, tip, cena, proizvodjac, jedinicaMere, sertifikat, tipMaterijala)
        {
        }
    }
    #endregion

    #region Koristi
    public class KoristiBasic
    {
        public int ID;
        public int Kolicina;
        public ZadatakBasic Zadatak;
        public MaterijalBasic Materijal;

        public KoristiBasic() { }

        public KoristiBasic(int iD, int kolicina, ZadatakBasic zadatak, MaterijalBasic materijal)
        {
            ID = iD;
            Kolicina = kolicina;
            Zadatak = zadatak;
            Materijal = materijal;
        }
    }

    public class KoristiPregled
    {
        public int ID;
        public int Kolicina;
        public ZadatakPregled Zadatak;
        public MaterijalPregled Materijal;

        public KoristiPregled() { }

        public KoristiPregled(int iD, int kolicina, ZadatakPregled zadatak, MaterijalPregled materijal)
        {
            ID = iD;
            Kolicina = kolicina;
            Zadatak = zadatak;
            Materijal = materijal;
        }
    }

    #endregion

    #region NabavkaMaterijal
    public class NabavkaMaterijalBasic
    {
        public int ID;
        public int Kolicina;
        public int Cena;
        public bool Status_isporuke;
        public MaterijalBasic Materijal;
        public NabavkeBasic Nabavke;

        public NabavkaMaterijalBasic() { }
        public NabavkaMaterijalBasic(int iD, int kolicina, int cena, bool status_isporuke, MaterijalBasic materijal, NabavkeBasic nabavke)
        {
            ID = iD;
            Kolicina = kolicina;
            Cena = cena;
            Status_isporuke = status_isporuke;
            Materijal = materijal;
            Nabavke = nabavke;
        }
    }

    public class NabavkaMaterijalPregled
    {
        public int ID;
        public int Kolicina;
        public int Cena;
        public bool Status_isporuke;
        public MaterijalBasic Materijal;
        public NabavkeBasic Nabavke;

        public NabavkaMaterijalPregled() { }

        public NabavkaMaterijalPregled(int iD, int kolicina, int cena, bool status_isporuke, MaterijalBasic materijal, NabavkeBasic nabavke)
        {
            ID = iD;
            Kolicina = kolicina;
            Cena = cena;
            Status_isporuke = status_isporuke;
            Materijal = materijal;
            Nabavke = nabavke;
        }
    }

    #endregion

    #region Nabavke
    public class NabavkeBasic 
    {
        public int Br_nabavke;
        public DateTime Datum;
        public ProjekatBasic Projekat;
        public virtual IList<NabavkaMaterijalBasic> NabavkaMaterijal { get; set; }
        public virtual IList<NabavkaOpremaBasic> NabavkaOprema { get; set; }

        public NabavkeBasic() 
        {
            NabavkaMaterijal = new List<NabavkaMaterijalBasic>();
            NabavkaOprema = new List<NabavkaOpremaBasic>();    
        }

        public NabavkeBasic(int br_nabavke, DateTime datum, ProjekatBasic projekat)
        {
            Br_nabavke = br_nabavke;
            Datum = datum;
            Projekat = projekat;
        }
    }

    public class NabavkePregled 
    {
        public int Br_nabavke;
        public DateTime Datum;
        public ProjekatBasic Projekat;

        public NabavkePregled() { }
        public NabavkePregled(int br_nabavke, DateTime datum, ProjekatBasic projekat)
        {
            Br_nabavke = br_nabavke;
            Datum = datum;
            Projekat = projekat;
        }
    }
    #endregion

    #region NabavkaOprema

     //public virtual int ID { get; protected set; }
     //   public virtual int Kolicina { get; set; }
     //   public virtual int Cena { get; set; }
     //   public virtual bool Status_isporuke { get; set; }

     //   public virtual Oprema Oprema { get; set; }
     //   public virtual Nabavke Nabavka { get; set; }
    public class NabavkaOpremaBasic 
    {
        public int ID;
        public int Kolicina;
        public int Cena;
        public bool Status_isporuke;
        public OpremaBasic Oprema;
        public NabavkeBasic Nabavka;

        public NabavkaOpremaBasic() { }

        public NabavkaOpremaBasic(int iD, int kolicina, int cena, bool status_isporuke, OpremaBasic oprema, NabavkeBasic nabavka)
        {
            ID = iD;
            Kolicina = kolicina;
            Cena = cena;
            Status_isporuke = status_isporuke;
            Oprema = oprema;
            Nabavka = nabavka;
        }
    }

    public class NabavkaOpremaPregled 
    {
        public int ID;
        public int Kolicina;
        public int Cena;
        public bool Status_isporuke;
        public OpremaPregled Oprema;
        public NabavkePregled Nabavka;

        public NabavkaOpremaPregled() { }
        public NabavkaOpremaPregled(int iD, int kolicina, int cena, bool status_isporuke, OpremaPregled oprema, NabavkePregled nabavka)
        {
            ID = iD;
            Kolicina = kolicina;
            Cena = cena;
            Status_isporuke = status_isporuke;
            Oprema = oprema;
            Nabavka = nabavka;
        }
    }
    #endregion

    #region Deonica
    public class DeonicaBasic
    {
        public int ID;
        public int Br_deonice;
        public InfrastrukturaBasic Infrastruktura;

        public DeonicaBasic() { }

        public DeonicaBasic(int iD, int br_deonice, InfrastrukturaBasic infrastruktura)
        {
            ID = iD;
            Br_deonice = br_deonice;
            Infrastruktura = infrastruktura;
        }
    }

    public class DeonicaPregled
    {
        public int ID;
        public int Br_deonice;
        public InfrastrukturaPregled Infrastruktura;

        public DeonicaPregled() { }

        public DeonicaPregled(int iD, int br_deonice, InfrastrukturaPregled infrastruktura)
        {
            ID = iD;
            Br_deonice = br_deonice;
            Infrastruktura = infrastruktura;
        }
    }

    #endregion

    #region Infrastruktura
    public class InfrastrukturaBasic : ProjekatBasic
    {
        public virtual IList<DeonicaBasic> Deonice { get; set; }

        public InfrastrukturaBasic() 
        {
            Deonice = new List<DeonicaBasic>();
        }

        public InfrastrukturaBasic(int iD, string naziv, string opis, string lokacija, DateTime datum_pocetka, int budzet, bool status, DateTime planiran_zavrsetak, DateTime stvarni_zavrsetak)
            :base(iD, naziv, opis, lokacija, datum_pocetka, budzet, status, planiran_zavrsetak, stvarni_zavrsetak)
        {

        }
    }

    public class InfrastrukturaPregled : ProjekatPregled
    {
        public virtual IList<DeonicaPregled> Deonice { get; set; }

        public InfrastrukturaPregled() 
        {
            Deonice = new List<DeonicaPregled>();
        }

        public InfrastrukturaPregled(int iD, string naziv, string opis, string lokacija, DateTime datum_pocetka, int budzet, bool status, DateTime planiran_zavrsetak, DateTime stvarni_zavrsetak)
            : base(iD, naziv, opis, lokacija, datum_pocetka, budzet, status, planiran_zavrsetak, stvarni_zavrsetak)
        {

        }
    }

    #endregion

    #region Industrijski

    public class IndustrijskiBasic : ProjekatBasic
    {
        public IndustrijskiBasic() { }
        public IndustrijskiBasic(int iD, string naziv, string opis, string lokacija, DateTime datum_pocetka, int budzet, bool status, DateTime planiran_zavrsetak, DateTime stvarni_zavrsetak)
            : base(iD, naziv, opis, lokacija, datum_pocetka, budzet, status, planiran_zavrsetak, stvarni_zavrsetak) { }
    }

    public class IndustrijskiPregled : ProjekatPregled
    {
        public IndustrijskiPregled() { }
        public IndustrijskiPregled(int iD, string naziv, string opis, string lokacija, DateTime datum_pocetka, int budzet, bool status, DateTime planiran_zavrsetak, DateTime stvarni_zavrsetak)
            : base(iD, naziv, opis, lokacija, datum_pocetka, budzet, status, planiran_zavrsetak, stvarni_zavrsetak) { }
    }

    #endregion

    #region Sanacija

    public class SanacijaBasic : ProjekatBasic
    {
        public SanacijaBasic() { }
        public SanacijaBasic(int iD, string naziv, string opis, string lokacija, DateTime datum_pocetka, int budzet, bool status, DateTime planiran_zavrsetak, DateTime stvarni_zavrsetak)
            : base(iD, naziv, opis, lokacija, datum_pocetka, budzet, status, planiran_zavrsetak, stvarni_zavrsetak) { }
    }

    public class SanacijaPregled : ProjekatPregled
    {
        public SanacijaPregled() { }
        public SanacijaPregled(int iD, string naziv, string opis, string lokacija, DateTime datum_pocetka, int budzet, bool status, DateTime planiran_zavrsetak, DateTime stvarni_zavrsetak)
            : base(iD, naziv, opis, lokacija, datum_pocetka, budzet, status, planiran_zavrsetak, stvarni_zavrsetak) { }
    }

    #endregion

    #region Rekonstrukcija

    public class RekonstrukcijaBasic : ProjekatBasic 
    {
        public RekonstrukcijaBasic() { }
        public RekonstrukcijaBasic(int iD, string naziv, string opis, string lokacija, DateTime datum_pocetka, int budzet, bool status, DateTime planiran_zavrsetak, DateTime stvarni_zavrsetak)
            : base(iD, naziv, opis, lokacija, datum_pocetka, budzet, status, planiran_zavrsetak, stvarni_zavrsetak) { }
    }

    public class RekonstrukcijaPregled : ProjekatPregled
    {
        public RekonstrukcijaPregled() { }
        public RekonstrukcijaPregled(int iD, string naziv, string opis, string lokacija, DateTime datum_pocetka, int budzet, bool status, DateTime planiran_zavrsetak, DateTime stvarni_zavrsetak)
            : base(iD, naziv, opis, lokacija, datum_pocetka, budzet, status, planiran_zavrsetak, stvarni_zavrsetak) { }
    }

    #endregion

    #region Poslovni

    public class PoslovniBasic : ProjekatBasic 
    {
        public virtual IList<ObjekatPoslovniBasic> Objekti { get; set; }
        public PoslovniBasic() 
        {
            Objekti = new List<ObjekatPoslovniBasic>();
        }
        public PoslovniBasic(int iD, string naziv, string opis, string lokacija, DateTime datum_pocetka, int budzet, bool status, DateTime planiran_zavrsetak, DateTime stvarni_zavrsetak)
            : base(iD, naziv, opis, lokacija, datum_pocetka, budzet, status, planiran_zavrsetak, stvarni_zavrsetak) { }
    }

    public class PoslovniPregled : ProjekatPregled 
    {
        public virtual IList<ObjekatPoslovniPregled> Objekti { get; set; }
        public PoslovniPregled()
        {
            Objekti = new List<ObjekatPoslovniPregled>();
        }
        public PoslovniPregled(int iD, string naziv, string opis, string lokacija, DateTime datum_pocetka, int budzet, bool status, DateTime planiran_zavrsetak, DateTime stvarni_zavrsetak)
            : base(iD, naziv, opis, lokacija, datum_pocetka, budzet, status, planiran_zavrsetak, stvarni_zavrsetak) { }
    }
    #endregion

    #region ObjekatPoslovni
    public class ObjekatPoslovniBasic 
    {
        public int ID;
        public int Br_objekta;
        public int Spratnost;
        public int Br_jedinica;
        public PoslovniBasic Poslovni;

        public ObjekatPoslovniBasic() { }
        public ObjekatPoslovniBasic(int iD, int br_objekta, int spratnost, int br_jedinica, PoslovniBasic poslovni)
        {
            ID = iD;
            Br_objekta = br_objekta;
            Spratnost = spratnost;
            Br_jedinica = br_jedinica;
            Poslovni = poslovni;
        }
    }

    public class ObjekatPoslovniPregled 
    {
        public int ID;
        public int Br_objekta;
        public int Spratnost;
        public int Br_jedinica;
        public PoslovniPregled Poslovni;

        public ObjekatPoslovniPregled() { }

        public ObjekatPoslovniPregled(int iD, int br_objekta, int spratnost, int br_jedinica, PoslovniPregled poslovni)
        {
            ID = iD;
            Br_objekta = br_objekta;
            Spratnost = spratnost;
            Br_jedinica = br_jedinica;
            Poslovni = poslovni;
        }
    }

    #endregion

    #region Stambeni

    public class StambeniBasic : ProjekatBasic
    {
        public virtual IList<ObjekatStambeniBasic> Objekti { get; set; }
        public StambeniBasic()
        {
            Objekti = new List<ObjekatStambeniBasic>();
        }
        public StambeniBasic(int iD, string naziv, string opis, string lokacija, DateTime datum_pocetka, int budzet, bool status, DateTime planiran_zavrsetak, DateTime stvarni_zavrsetak)
            : base(iD, naziv, opis, lokacija, datum_pocetka, budzet, status, planiran_zavrsetak, stvarni_zavrsetak)
        {

        }
    }

    public class StambeniPregled : ProjekatPregled
    {
        public virtual IList<ObjekatStambeniPregled> Objekti { get; set; }
        public StambeniPregled()
        {
            Objekti = new List<ObjekatStambeniPregled>();
        }
        public StambeniPregled(int iD, string naziv, string opis, string lokacija, DateTime datum_pocetka, int budzet, bool status, DateTime planiran_zavrsetak, DateTime stvarni_zavrsetak)
            : base(iD, naziv, opis, lokacija, datum_pocetka, budzet, status, planiran_zavrsetak, stvarni_zavrsetak)
        {

        }
    }
    #endregion

    #region ObjekatStambeni
     //public virtual int Id { get; protected set; }
     //   public virtual int Br_objekta { get; set; }
     //   public virtual int Spratnost { get; set; }
     //   public virtual int Br_jedinica { get; set; }
     //   public virtual Stambeni Stambeni { get; set; }
    public class ObjekatStambeniBasic 
    {
        public int ID;
        public int Br_objekta;
        public int Spratnost;
        public int Br_jedinica;
        public StambeniBasic Stambeni;

        public ObjekatStambeniBasic() { }
        public ObjekatStambeniBasic(int iD, int br_objekta, int spratnost, int br_jedinica, StambeniBasic stambeni)
        {
            ID = iD;
            Br_objekta = br_objekta;
            Spratnost = spratnost;
            Br_jedinica = br_jedinica;
            Stambeni = stambeni;
        }
    }

    public class ObjekatStambeniPregled 
    {
        public int ID;
        public int Br_objekta;
        public int Spratnost;
        public int Br_jedinica;
        public StambeniPregled Stambeni;

        public ObjekatStambeniPregled() { }
        public ObjekatStambeniPregled(int iD, int br_objekta, int spratnost, int br_jedinica, StambeniPregled stambeni)
        {
            ID = iD;
            Br_objekta = br_objekta;
            Spratnost = spratnost;
            Br_jedinica = br_jedinica;
            Stambeni = stambeni;
        }
    }
    #endregion

    
}
