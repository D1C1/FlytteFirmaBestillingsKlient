using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlytteFirmaBestillingsKlient
{
    public class AdresseViewModel
    {
        public AdresseViewModel()
        {
            CurrentBooking = new Booking();
            //testdata
            CurrentBooking.AdresseFra.Adresselinje = "testadresse 1 ";
            CurrentBooking.AdresseTil.Adresselinje = "testadresse 2 ";
            //testdata
            GemBookingKnap = new RelayCommand(GemBookingTilDiskAsync);
        }
        public Booking CurrentBooking { get; set; }
        public RelayCommand GemBookingKnap { get; set; }

        private async void GemBookingTilDiskAsync()
        {
            
            try
            {
                await PersistencyService.Gembooking("tempbooking.json", CurrentBooking);
            }
            catch (Exception)
            {
                PersistencyService.Makefile("tempbooking.json");
                await PersistencyService.Gembooking("tempbooking.json", CurrentBooking);
            }

        }

    }
}
