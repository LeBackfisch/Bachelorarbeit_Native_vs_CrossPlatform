using System;
using System.Net.Http;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;
using Xamarin.iOS_BAC_.Models;

namespace Xamarin.iOS_BAC_.Services
{
    public class StarshipService
    {
        public async Task<dynamic> GetStarshipModels()
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
