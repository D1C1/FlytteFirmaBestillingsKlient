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

        private async void GemDataTilDiskAsync()
        {
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
