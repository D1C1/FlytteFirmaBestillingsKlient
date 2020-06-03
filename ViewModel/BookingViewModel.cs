using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlytteFirmaBestillingsKlient
{
    /// <summary>
    /// Denne klasse er den viewmodel som bliver brugt til bestilling af en booking
    /// </summary>
    public class BookingViewModel : INotifyPropertyChanged
    {
        private string _advarsler;
        private bool canSave = false;// tjekker om vi har alle de nødvendige data for at gemme til disk

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

        public string Advarsler
        {
            get { return _advarsler; }
            set
            {
                _advarsler = value;
                NotifyPropertyChanged();
            }
        }
        public bool CanSave { get => canSave; set => canSave = value; }
        public DateTimeOffset MovingDateView { get; set; }// Flyttedato sat af calender date picker
        //Properties slut
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Sætter informationen som bliver indtastet i vores view til den gemte booking objekt, samt henter adresser fra midlertidig booking som bliver lavet i adresseview
        /// </summary>
        private async Task SetInformation()
        {
            try
            {
                Booking tempbooking = await PersistencyService.HentBooking("tempbooking.json");
                if (tempbooking==null)
                {
                    Advarsler = "Adresse ikke sat, gå venligst til adresse side for at sætte adresse";
                    CanSave = false;
                }
                else
                {
                    CurrentBooking.AdresseFra = tempbooking.AdresseFra;
                    CurrentBooking.AdresseTil = tempbooking.AdresseTil;
                    CanSave = true;
                } 
                
            }
            catch (Exception)
            {
                Advarsler = "Adresse ikke sat, gå venligst til adresse side for at sætte adresse";
                CanSave = false;
            }

            CurrentBooking.FlytteDato = MovingDateView.Date;
        }

        /// <summary>
        /// Gemmer vores booking objekt til en liste på vores disk, hvis listen ikke findes laver den først listen og prøver igen
        /// </summary>
        private async void GemDataTilDiskAsync()
        {
            await SetInformation();
            if (CanSave)
            {
                try
                {
                    await PersistencyService.GemDataTilDiskAsyncPS(CurrentBooking);
                    Advarsler = "gem booking succes, sendt til admin side";
                }
                catch (Exception)
                {
                    PersistencyService.Makefile("Booking1.json");
                    await PersistencyService.GemDataTilDiskAsyncPS(CurrentBooking);
                    Advarsler = "gem booking succes sendt til admin side";
                }
            }

        }

    }
}
