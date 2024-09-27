using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SatelliteTrackerActual
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                var user = new UserInfo();
                var parser = new ParseJson();
                var info = new Info();
                var position = new Position();
                var satellite = new SatelliteInfo();
                var location = new Location();

                //Console.WriteLine("Enter your satellites ID");
                //user.SatID = Console.ReadLine();

                var uri = "https://api.n2yo.com/rest/v1/satellite/tle/" + satellite.NoradId + "&apiKey=" + user.ApiKey;
                var uri2 = "https://api.n2yo.com/rest/v1/satellite/positions/" + satellite.NoradId + "/" + location.ObserverLat + "/" + location.ObserverLon + "/" + location.ObserverAltitude + "/" + 1 + "/&apiKey=" + user.ApiKey;

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
                    Console.WriteLine("\n\nSat: \t\t" + info.satname);
                    Console.WriteLine("SatID: \t\t" + info.satid);

                    foreach (var items in list)
                    {
                        position.azimuth = items.azimuth;
                        position.elevation = items.elevation;
                        position.timestamp = items.timestamp;

                        var time = parser.UnixTimeStampToDateTime(position.timestamp);
                        Console.WriteLine("Azimuth: \t" + items.azimuth);
                        Console.WriteLine("Elevation: \t" + items.elevation);
                        //Console.WriteLine(items.timestamp);
                        Console.WriteLine(time + "\n\n");
                    }

                }

                Thread.Sleep(5000);
            }

        }
    }
}
