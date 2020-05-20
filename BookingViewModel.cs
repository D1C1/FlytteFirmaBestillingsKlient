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
            //testdata

            GemDataButton = new RelayCommand(GemDataTilDiskAsync);
        }
        public Booking CurrentBooking { get; set; } = new Booking();
        public RelayCommand GemDataButton { get; set; }
        //brugerdetaljer start
        public string NavnView { get; set; }
        public string EmailView { get; set; }
        public int TlfnrView { get; set; }
        //brugerdetaljer slut
        public DateTimeOffset MovingDateView { get; set; }

        private void SetInformation()
        {
            CurrentBooking.BookingBruger.Navn = NavnView;
            CurrentBooking.BookingBruger.Email = EmailView;
            CurrentBooking.BookingBruger.TlfNr = TlfnrView;
            CurrentBooking.FlytteDato = MovingDateView.Date;
        }
        private async void GemDataTilDiskAsync()
        {
            SetInformation();
            try
            {
                await PersistencyService.GemDataTilDiskAsyncPS(CurrentBooking);
            }
            catch (Exception)
            {
                PersistencyService.Makefile();
                await PersistencyService.GemDataTilDiskAsyncPS(CurrentBooking);
            }
            
        }

    }
}
