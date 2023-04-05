using Newtonsoft.Json;
using PostcodesWrapper.Models;
using System.Net.Http.Headers;
using static PostcodesWrapper.Models.Postcode;

namespace PostcodesWrapper.Services
{
    public class PostcodeService : IPostcodeService
    {
        private static string url = "https://api.postcodes.io/postcodes/";

        private readonly IHttpClientFactory _httpClientFactory;

        public PostcodeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<Root> GetPostcode(string postcode)
        {
            var client = GetHttpClient();
            HttpResponseMessage response = await client.GetAsync(url + postcode);
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response.Content.ReadAsStringAsync().Result);

            return myDeserializedClass;
        }

        public async Task<AutoCompletePostcode> GetPostcodeOptions(string postcode)
        {
            var client = GetHttpClient();
            HttpResponseMessage response = await client.GetAsync(url + postcode + "/autocomplete");
            AutoCompletePostcode myDeserializedClass = JsonConvert.DeserializeObject<AutoCompletePostcode>(response.Content.ReadAsStringAsync().Result);
            return myDeserializedClass;
        }
        private HttpClient GetHttpClient()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
