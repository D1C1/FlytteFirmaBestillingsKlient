using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlytteFirmaBestillingsKlient
{
    public class AdminViewModel
    {
        public AdminViewModel()
        {

            HentDataButton = new RelayCommand(HentDataFraDiskAsync);
        }
        public ObservableCollection<Booking> OC_Bookings { get; set; } = new ObservableCollection<Booking>();
        public RelayCommand HentDataButton { get; set; }


        private async void HentDataFraDiskAsync()
        {
            ObservableCollection<Booking> templist = await PersistencyService.HentDataFraDiskAsyncPS();
            foreach (var booking in templist)
            {
                OC_Bookings.Add(booking);
            }
        }
    }
}
