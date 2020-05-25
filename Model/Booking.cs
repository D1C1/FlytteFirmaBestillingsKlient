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
        private int _bookingId;


        /// <summary>
        /// Denne constuctor instantiere to adresser en fra og en til samt en bruger
        /// </summary>
        public Booking()
        {
            AdresseFra = new Adresse();
            AdresseTil = new Adresse();
            BookingBruger = new Bruger();
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
        public string Detaljer
        {
            get { return ToString(); }
            //set { _detaljer = value; }
        }



        // indsæt tilvalg og materialer

        /// <summary>
        /// Giver en beskrivelse af denne booking, hvilket tager brug af ToString på andre objekter
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Booking nr {BookingId} Bruger detaljer: {BookingBruger}" +
                $" Skal flytte fra adressen:  til adressen :  " +
                $"på datoen: {FlytteDato}";
        }
    }
}
