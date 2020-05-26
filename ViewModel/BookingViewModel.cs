﻿using System;
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
        /// Sætter informationen som bliver indtastet i vores view til den gemte booking objekt
        /// </summary>
        private void SetInformation()
        {
            CurrentBooking.BookingBruger.Navn = NavnView;
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
                PersistencyService.Makefile();
                await PersistencyService.GemDataTilDiskAsyncPS(CurrentBooking);
            }
            
        }

    }
}