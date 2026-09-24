using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradjevinska_firmaLibrary.Entiteti;

namespace Gradjevinska_firmaLibrary.DTOs
{
    public class BezbednosniIncidentView
    {
        public int ID { get; set; }
        public string Opis { get; set; }
        public  DateTime Datum { get; set; }
        public  string Lokacija { get; set; }
        public  string? Preduzete_mere { get; set; }
        public  string? Posledice { get; set; }
        public string Tip_incidenta { get; set; }
        public int ProjekatID { get; set; }
        public int OsobaID { get; set; }

        public BezbednosniIncidentView() { }

        internal BezbednosniIncidentView(BezbednosniIncident incident)
        {
            ID = incident.ID;
            Opis = incident.Opis;
            Datum = incident.Datum;
            Lokacija = incident.Lokacija;
            Preduzete_mere = incident.Preduzete_mere;
            Posledice = incident.Posledice;
            Tip_incidenta = incident.Tip_incidenta;
            ProjekatID = incident.Projekat.ID;
            OsobaID = incident.Osoba.Id;
        }
    }
}
