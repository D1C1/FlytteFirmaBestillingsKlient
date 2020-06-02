using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlytteFirmaBestillingsKlient
{
    /// <summary>
    /// Denne viewmodel bliver brugt til vores administrator side 
    /// </summary>
    public class AdminViewModel
    {
        /// <summary>
        /// Denne constructor instantiere relaycommands brugt i admin page
        /// </summary>
        public AdminViewModel()
        {

            HentDataButton = new RelayCommand(HentDataFraDiskAsync);
            SletData = new RelayCommand(RemoveBooking);
            GemData = new RelayCommand(GemListeTilDiskAsync);
        }

        public ObservableCollection<Booking> OC_Bookings { get; set; } = new ObservableCollection<Booking>();
        public Booking SelectedBooking { get; set; }
        public RelayCommand HentDataButton { get; set; }
        public RelayCommand SletData { get; set; }
        public RelayCommand GemData { get; set; }

        /// <summary>
        /// Henter en liste fra disken
        /// </summary>
        private async void HentDataFraDiskAsync()
        {
            ObservableCollection<Booking> templist = await PersistencyService.HentDataFraDiskAsyncPS("Booking1.json");
            foreach (var booking in templist)
            {
                OC_Bookings.Add(booking);
            }
        }
        /// <summary>
        /// fjerner valgte bookning fra listen
        /// </summary>
        private void RemoveBooking()
        {
            OC_Bookings.Remove(SelectedBooking);
        }
        /// <summary>
        /// Gemmer liste efter man er færdig med at redigere den
        /// </summary>
        private async void GemListeTilDiskAsync()
        {
            await PersistencyService.GemListe("Booking1.json",OC_Bookings);
        }
    }
}
