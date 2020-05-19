using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace FlytteFirmaBestillingsKlient
{
    class PersistencyService
    {
        private static string filNavn = "Booking1.json";

        public static async Task GemDataTilDiskAsyncPS(Booking booking)
        {
            ObservableCollection<Booking> bookings = await HentDataFraDiskAsyncPS(); // henter den nuværende liste fra disken
            try
            {
                booking.BookingId = bookings.Count + 1;
                bookings.Add(booking);// indsætter den nye booking i listen
            }
            catch (Exception)
            {

                bookings = new ObservableCollection<Booking>();
                bookings.Add(booking);// indsætter den nye booking i listen
            }

            // laver en ny booking liste med den indsatte nye booking
            string jsonText = GetJsonPS(bookings);
            StorageFolder localfolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localfolder.CreateFileAsync(filNavn, CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(file, jsonText);
        }

        public static string GetJsonPS(ObservableCollection<Booking> booking)
        {
            string json = JsonConvert.SerializeObject(booking);
            return json;
        }

        private static ObservableCollection<Booking> DeserialiserJson(string jsonText)
        {
            ObservableCollection<Booking> nyBooking = JsonConvert.DeserializeObject<ObservableCollection<Booking>>(jsonText);
            return nyBooking;
        }

        public static async Task<ObservableCollection<Booking>> HentDataFraDiskAsyncPS()
        {
            StorageFolder localfolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localfolder.GetFileAsync(filNavn);
            string jsonText = await FileIO.ReadTextAsync(file);
            ObservableCollection<Booking> tempBookings = new ObservableCollection<Booking>();
            tempBookings = DeserialiserJson(jsonText);

            return tempBookings;
        }
        public static async void Makefile()
        {
            StorageFolder localfolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localfolder.CreateFileAsync(filNavn, CreationCollisionOption.ReplaceExisting);
        }
    }
}
