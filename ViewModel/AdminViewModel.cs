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
        }

        public ObservableCollection<Booking> OC_Bookings { get; set; } = new ObservableCollection<Booking>();
        public RelayCommand HentDataButton { get; set; }

        /// <summary>
        /// Henter en liste fra disken
        /// </summary>
        private async void HentDataFraDiskAsync()
        {
            ObservableCollection<Booking> templist = await PersistencyService.HentDataFraDiskAsyncPS();
            foreach (var booking in templist)
            {
                OC_Bookings.Add(booking);
            }
        }

        private async void GemListeTilDiskAsync()
        {
            await PersistencyService.GemListe(OC_Bookings);
        }
    }
}
