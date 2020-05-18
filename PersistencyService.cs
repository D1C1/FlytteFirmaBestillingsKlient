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
            string jsonText = GetJsonPS(booking);
            StorageFolder localfolder = ApplicationData.Current.LocalFolder;

            StorageFile file = await localfolder.CreateFileAsync(filNavn, CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(file, jsonText);
        }

        public static string GetJsonPS(Booking booking)
        {
            string json = JsonConvert.SerializeObject(booking);
            return json;
        }
    }
}
