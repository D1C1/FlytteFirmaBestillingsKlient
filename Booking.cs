using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlytteFirmaBestillingsKlient
{
    public class Booking
    {
        Adresse _adresseFra;
        Adresse _adresseTil;
        DateTime _flytteDato;
        Bruger _bookingBruger;
        private int _bookingId;



        public Booking()
        {

        }

        public int BookingId
        {
            get { return _bookingId; }
            set { _bookingId = value; }
        }

        public DateTime FlytteDato { get => _flytteDato; set => _flytteDato = value; }

        // indsæt tilvalg og materialer
    }
}
