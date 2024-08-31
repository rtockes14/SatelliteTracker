using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SatelliteTrackerActual
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var user = new UserInfo();
            var parser = new ParseJson();
            var info = new Info();
            var position = new Position();

            Console.WriteLine("Enter your satellites ID");
            user.SatID = Console.ReadLine();


            var uri = "https://api.n2yo.com/rest/v1/satellite/tle/" + user.SatID + "&apiKey=" + user.ApiKey;
            var uri2 = "https://api.n2yo.com/rest/v1/satellite/positions/" + user.SatID + "/" + user.ObserverLat + "/" + user.ObserverLng + "/" + user.Altitude + "/" + 1 + "/&apiKey=" + user.ApiKey;

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri(uri2),
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);

                info.satname = parser.JMethodString(body);
                info.satid = parser.JMethodDub(body);
                var list = parser.JMethodList(body);
                Console.WriteLine(info.satname);
                Console.WriteLine(info.satid);
                
                foreach (var items in list)
                {
                    position.azimuth = items.azimuth;
                    Console.WriteLine(items.azimuth);
                }
            }

        }
    }
}
