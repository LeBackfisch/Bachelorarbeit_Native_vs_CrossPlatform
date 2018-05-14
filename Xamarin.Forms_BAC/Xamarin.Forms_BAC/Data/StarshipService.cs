using System;
using System.Net.Http;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;
using Xamarin.Forms_BAC.Models;

namespace Xamarin.Forms_BAC.Data
{
    public class StarshipService
    {
        

        public static async Task<dynamic> GetStarshipData()
        {
            string url = "https://swapi.co/api/starships/?format=json";
            try
            {
                HttpClient client = new HttpClient(new NativeMessageHandler());
                var uri = new Uri(string.Format(url, string.Empty));
                var response = await client.GetStringAsync(uri);

                dynamic data = null;
                if (response != null)
                {

                    data = JsonConvert.DeserializeObject<DataModel>(response);

                    
                }
                return data;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
                throw;
            }           
        }
    }
}
