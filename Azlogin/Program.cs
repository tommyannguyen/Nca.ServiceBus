using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Azlogin
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }
        static async Task MainAsync(string[] args)
        {

            //var hubClient = new AppEventHubClient();
            //await hubClient.SendAsync();
            var timeSeririesClient = new AppTimeSeriresClient();
            await timeSeririesClient.GetHierarchiesAsyn();
        }
    }


    public class AppTimeSeriresClient
    {
        string environmentFqdn = "8fa39f51-4dd0-4a9c-ac36-a000c7f864ad.env.timeseries.azure.com";
        string clientId = "ee17fb78-5793-4912-9cad-73bd1c3d20c7";
        string clientSecret = "n_mi1F_7eml16Izv8J~5-LpmmtLrQxAh9c";
        public async Task<string> LoginAsync()
        {
           
            //https://login.microsoftonline.com/{tenant} 
            var authority = "https://login.microsoftonline.com/9ad25b1a-5417-467d-a235-16dc1eb924d9";
            IConfidentialClientApplication app = ConfidentialClientApplicationBuilder.Create(clientId)
                                                      .WithClientSecret(clientSecret)
                                                      .WithAuthority(new Uri(authority))
                                                      .Build();

            var scopes = new List<string>() { "https://api.timeseries.azure.com/.default" };
            var result = await app.AcquireTokenForClient(scopes)
                  .ExecuteAsync();
            return result.AccessToken;
        }

        public async Task GetHierarchiesAsyn()
        {
            string accessToken = await LoginAsync();
            var url = $"https://{environmentFqdn}/timeseries/modelSettings?api-version=2018-11-01-preview";
            
            var request = WebRequest.CreateHttp(new Uri(url));
            request.Method = "GET";
            request.Headers.Add("x-ms-client-request-id", clientId);
            request.Headers.Add("Authorization", "Bearer " + accessToken);
            JToken responseContent = await GetResponseAsync(request);
        }

        private async Task<JToken> GetResponseAsync(HttpWebRequest request)
        {
            using WebResponse webResponse = await request.GetResponseAsync();
            using var sr = new StreamReader(webResponse.GetResponseStream());
            string result = await sr.ReadToEndAsync();
            return JsonConvert.DeserializeObject<JToken>(result);
        }

    }
}
