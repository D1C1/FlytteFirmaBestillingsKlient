using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlytteFirmaBestillingsKlient
{
    /// <summary>
    /// Denne klasse er beskrivelsen af en booking
    /// </summary>
    public class Booking
    {
        Adresse _adresseFra;
        Adresse _adresseTil;
        DateTime _flytteDato;
        Bruger _bookingBruger = new Bruger();
        bool _privatflytning = false;
        private int _bookingId;


        /// <summary>
        /// Denne constuctor instantiere to adresser en fra og en til samt en bruger
        /// </summary>
        public Booking()
        {
            AdresseFra = new Adresse();
            AdresseTil = new Adresse();
            BookingBruger = new Bruger();
            Nedpakning = false;
            Udpakning = false;
        }

        public int BookingId
        {
            get { return _bookingId; }
            set { _bookingId = value; }
        }
        public DateTime FlytteDato { get => _flytteDato; set => _flytteDato = value; }
        public Adresse AdresseFra { get => _adresseFra; set => _adresseFra = value; }
        public Adresse AdresseTil { get => _adresseTil; set => _adresseTil = value; }
        public Bruger BookingBruger { get => _bookingBruger; set => _bookingBruger = value; }
        public string FlyttedatoDetalje
        {
            get { return $"{FlytteDato.ToString("dd MMMM yyyy")}"; }
        }

        public string Detaljer
        {
            get { return ToString(); }
            //set { _detaljer = value; }
        }
        public string AdresseDetaljer
        {
            get { return $"Skal flytte fra adressen:{AdresseFra}\r\nSkal flytte til adressen: {AdresseTil}"; }
            //set { _detaljer = value; }
        }

        // tilvalg og materialer
        public string KommentarTilFlytning { get; set; }
        public bool OpbevarinfAfFlytning { get; set; }
        public bool EgenHjaelpMedFlytning { get; set; }
        public bool Nedpakning { get; set; }
        public bool Udpakning { get; set; }
        public bool Privatflytning { get => _privatflytning; set => _privatflytning = value; }

        /// <summary>
        /// Giver en beskrivelse af denne booking, hvilket tager brug af ToString på andre objekter
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string returnString = $"Booking nr {BookingId}.\r\nBruger detaljer:\r\n{BookingBruger}\r\n" +
                $"Ønsket flyttedato: {FlytteDato.Day.ToString()}/{FlytteDato.Month.ToString()}-{FlytteDato.Year.ToString()}\r\n";
            if (Nedpakning && Udpakning)
            {
                returnString += "Kunde vil gerne have både nedpakning og udpakning.\r\n";
            }
            else if (Nedpakning)
            {
                returnString += "Kunde ønsker kun nedpakning.\r\n";
            }
            else if (Udpakning)
            {
                returnString += "Kunde ønsker kun udpakning.\r\n";
            }
            else
            {
                returnString += "Kunde har ikke specificeret pakning.\r\n";
            }
            returnString += Privatflytning? "Kunde har specificeret dette er en erhvervsflytning.\r\n" : "Kunde har specificeret dette er en privatflytning.\r\n";
            returnString += OpbevarinfAfFlytning ? "Kunde ønsker opbevaring.\r\n" : "Kunde ønsker ikke opbevaring.\r\n";
            returnString += EgenHjaelpMedFlytning ? "Kunde vil gerne hjælpe med flytning.\r\n" : "Kunde ønsker ikke at hjælpe med flytning.\r\n";
            return returnString;
        }
    }
}
