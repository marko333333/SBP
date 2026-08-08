using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public OsobaBasic()
        {
            Kontakti = new List<KontaktBasic>();
            Licence = new List<LicencaBasic>();
            Angazovanja = new List<AngazovanBasic>();
            UgovorneStrane = new List<ImaUgovornuStranuBasic>();
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

        public PravnaLicaBasic()
        {
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

    #region Kontakt
    public class KontaktBasic
    {
        public int IdOsoba;
        public string Broj;

        public KontaktBasic() { }

        public KontaktBasic(int osoba, string broj)
        {   
            IdOsoba = osoba;
            Broj = broj;
        }
    }
    public class KontaktPregled
    {
        public int IdOsoba;
        public string Broj;

        public KontaktPregled() { }

        public KontaktPregled(int osoba, string broj)
        {
            IdOsoba = osoba;
            Broj = broj;
        }
    }
    #endregion

    #region Licenca

    public class LicencaBasic
    {
        public int IdOsoba;
        public string NazivLicence;

        public LicencaBasic() { }
        public LicencaBasic(int osoba, string nazivLicence)
        {
            IdOsoba = osoba;
            NazivLicence = nazivLicence;
        }
    }
    public class LicencaPregled
    {
        public int IdOsoba;
        public string NazivLicence;

        public LicencaPregled() { }
        public LicencaPregled(int osoba, string nazivLicence)
        {
            IdOsoba = osoba;
            NazivLicence = nazivLicence;
        }
    }

    #endregion

    //proveri
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

        //ne znam da li da stavim ovako
        public string NazivFaze;
        public int IdProjekta;
        public int? IdZadatakRoditelj;

        //ili ovako
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

        public string NazivFaze;
        public int IdProjekta;
        public int? IdZadatakRoditelj;


        public ZadatakPregled()
        {
        }

        public ZadatakPregled(int id, string naziv, string opis, decimal procenjeniTrosak, DateTime? planiraniZavrsetak, DateTime? stvarniZavrsetak, DateTime? planiraniPocetak, DateTime? stvarniPocetak, int prioritet, string status, string nazivFaze,int idProjekta, int? idZadatakRoditelj)
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
            NazivFaze = nazivFaze;
            IdProjekta = idProjekta;
            IdZadatakRoditelj = idZadatakRoditelj;
        }
    }

    #endregion

    //proveri
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

    //proveri
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

    //proveri
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
        public UgovorBasic(int id, DateTime datumPotpisivanja, decimal vrednost, string predmetUgovora, string valuta, DateTime rok, Materijal materijal, Projekat projekat, Oprema oprema, IList<ImaUgovornuStranuBasic> ugovorneStrane, IList<PosebnaKlauzulaBasic> posebneKlauzule)
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
        public UgovorPregled(int id, DateTime datumPotpisivanja, decimal vrednost, string predmetUgovora, string valuta, DateTime rok, Materijal materijal, Projekat projekat, Oprema oprema, IList<ImaUgovornuStranuBasic> ugovorneStrane, IList<PosebnaKlauzulaBasic> posebneKlauzule)
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
        public ZadatakBasic Zadatak;
        public OpremaBasic Oprema;

        public DateTime? DatumOd;
        public DateTime? DatumDo;
        public int BrojSati;

        public AngazujePregled()
        {
        }

        public AngazujePregled(ZadatakBasic zadatak, OpremaBasic oprema, DateTime? datumOd, DateTime? datumDo, int brojSati)
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
}
