using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WheaterApp.Model;

namespace WheaterApp.ViewModel.Helpers
{
    public class AccuWheaterHelper
    {
        // example url http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey=0J7Jx0hnDWkIUEDkkOPv6p63z69e5gQN&q=horto
        
        public const string BaseUrl = "http://dataservice.accuweather.com/";
        public const string AutocompleteEndpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string ApiKey = "0J7Jx0hnDWkIUEDkkOPv6p63z69e5gQN";
        public const string CurrentConditionsEndpoint = "currentconditions/v1/{0}?apikey={1}";

        public static async Task<List<City>> GetCities(string query)
        {
            List<City> cities = new List<City>();
            string url = BaseUrl + string.Format(AutocompleteEndpoint, ApiKey, query);
            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }

        public static async Task<CurrentConditions> GetCurrentConditions(string cityKey)
        {
            CurrentConditions currentConditions = new CurrentConditions();

            string url = BaseUrl + string.Format(CurrentConditionsEndpoint, cityKey, ApiKey);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                currentConditions = JsonConvert.DeserializeObject<List<CurrentConditions>>(json).FirstOrDefault();
            }

            return currentConditions;
        }
    }
}
