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
        string environmentFqdn = "67b12250-9526-4f65-9090-0b4ca2ed58e8.env.timeseries.azure.com";
        string clientId = "ee17fb78-5793-4912-9cad-73bd1c3d20c7";
        string clientSecret = "*6Kgf#h42O3p\"g59SL.ZQ>W%";
        string tenantId = "b673531a-9a34-49f8-be84-93aa133d276b";
        public async Task<string> LoginAsync()
        {
           
            //https://login.microsoftonline.com/{tenant} 
            var authority = $"https://login.microsoftonline.com/{tenantId}";
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
