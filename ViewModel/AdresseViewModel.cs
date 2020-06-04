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
        /// <summary>
        /// Gemmer et enkelt booking objekt til disk, bliver her brugt til at opbevare angivet adresse
        /// </summary>
        private async void GemBookingTilDiskAsync()
        {
                await PersistencyService.Gembooking("tempbooking.json", CurrentBooking);
        }

    }
}
