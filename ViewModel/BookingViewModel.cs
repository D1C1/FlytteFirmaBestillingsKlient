using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlytteFirmaBestillingsKlient
{
    /// <summary>
    /// Denne klasse er den viewmodel som bliver brugt til bestilling af en booking
    /// </summary>
    public class BookingViewModel
    {
        /// <summary>
        /// Constructor som initiere noget testdata samt en relaycommand til knapper på vores view
        /// </summary>
        public BookingViewModel()
        {
            MovingDateView = DateTimeOffset.Now;
            GemDataButton = new RelayCommand(GemDataTilDiskAsync);
        }

        //Properties
        public Booking CurrentBooking { get; set; } = new Booking();
        public RelayCommand GemDataButton { get; set; }
        //Brugerdetaljer start
        public string NavnView { get; set; }
        public string EmailView { get; set; }
        public int TlfnrView { get; set; }
        //Brugerdetaljer slut
        //Adressedetaljer

        //Adressedetaljer slut
        public DateTimeOffset MovingDateView { get; set; }// Flyttedato sat af calender date picker
        //Properties slut

        /// <summary>
        /// Sætter informationen som bliver indtastet i vores view til den gemte booking objekt, samt henter adresser fra midlertidig booking som bliver lavet i adresseview
        /// </summary>
        private async void SetInformation()
        {

            Booking tempbooking = await PersistencyService.HentBooking("tempbooking");
            CurrentBooking.AdresseFra = tempbooking.AdresseFra;
            CurrentBooking.AdresseTil = tempbooking.AdresseTil;
            CurrentBooking.BookingBruger.ForNavn = NavnView;
            CurrentBooking.BookingBruger.Email = EmailView;
            CurrentBooking.BookingBruger.TlfNr = TlfnrView;
            CurrentBooking.FlytteDato = MovingDateView.Date;
        }
        
        /// <summary>
        /// Gemmer vores booking objekt til en liste på vores disk, hvis listen ikke findes laver den først listen og prøver igen
        /// </summary>
        private async void GemDataTilDiskAsync()
        {
            SetInformation();
            try
            {
                await PersistencyService.GemDataTilDiskAsyncPS(CurrentBooking);
            }
            catch (Exception)
            {
                PersistencyService.Makefile("Booking1.json");
                await PersistencyService.GemDataTilDiskAsyncPS(CurrentBooking);
            }
            
        }

    }
}
