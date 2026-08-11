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

    public class BezbednosniIncidentBasic()
    {

    }

    #endregion

    #region Faktura

    public class FakturaBasic()
    {

    }

    #endregion

    #region Projekat

    public class ProjekatBasic()
    {

    }

    public class ProjekatPregled()
    {

    }

    #endregion

    #region Materijal

    public class MaterijalBasic()
    {

    }
    public class MaterijalPregled()
    {

    }

    #endregion 
}

