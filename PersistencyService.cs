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
    /// <summary>
    /// I denne klasse beskrives vores persistency services hvilke er vores asynkrone metoder
    /// </summary>
    class PersistencyService
    {
        private static string filNavn = "Booking1.json";
        /// <summary>
        /// Denne metode gemmer en booking til listen som ligger på disken, hvis listen er tom får den en exception og opretter en ny liste 
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
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

            await GemListe(bookings);
        }

        /// <summary>
        /// laver en ny booking liste med den indsatte nye booking
        /// </summary>
        /// <param name="bookings"></param>
        /// <returns></returns>
        public static async Task GemListe(ObservableCollection<Booking> bookings)
        {
            string jsonText = GetJsonPS(bookings);
            StorageFolder localfolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localfolder.CreateFileAsync(filNavn, CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(file, jsonText);
        }

        /// <summary>
        /// Denne moetode serialisere en liste med booking objekter til et Json objekt
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public static string GetJsonPS(ObservableCollection<Booking> booking)
        {
            string json = JsonConvert.SerializeObject(booking);
            return json;
        }

        /// <summary>
        /// Denne metode er lavet til at deserialisere et Json objekt
        /// </summary>
        /// <param name="jsonText"></param>
        /// <returns></returns>
        private static ObservableCollection<Booking> DeserialiserJson(string jsonText)
        {
            ObservableCollection<Booking> nyBooking = JsonConvert.DeserializeObject<ObservableCollection<Booking>>(jsonText);
            return nyBooking;
        }

        /// <summary>
        /// Denne metode henter vores Json objekt fra disken og deserialisere den til en liste af booking objekter
        /// </summary>
        /// <returns></returns>
        public static async Task<ObservableCollection<Booking>> HentDataFraDiskAsyncPS()
        {
            StorageFolder localfolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localfolder.GetFileAsync(filNavn);
            string jsonText = await FileIO.ReadTextAsync(file);
            ObservableCollection<Booking> tempBookings = new ObservableCollection<Booking>();
            tempBookings = DeserialiserJson(jsonText);

            return tempBookings;
        }
        /// <summary>
        /// Denne metode er her for at oprette en fil i tilfældet af at den ikke eksistere endnu
        /// </summary>
        public static async void Makefile()
        {
            StorageFolder localfolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localfolder.CreateFileAsync(filNavn, CreationCollisionOption.ReplaceExisting);
        }
    }
}
