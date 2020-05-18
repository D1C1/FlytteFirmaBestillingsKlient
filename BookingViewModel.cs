using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlytteFirmaBestillingsKlient
{
    public class BookingViewModel
    {
        public BookingViewModel()
        {
            //testdata
            CurrentBooking.BookingId = 1;
            CurrentBooking.BookingBruger.Navn="morten";
        }
        public Booking CurrentBooking { get; set; } = new Booking();
    }
}
