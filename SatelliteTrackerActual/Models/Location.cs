using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteTrackerActual
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double ObserverLat { get; set; }
        public double ObserverLon { get; set; }
        public decimal ObserverAltitude { get; set; }

        public Location()
        {

        }

        public Location(string name, string observerLat, string observerLon, string altitude)
        {
            Name = name;

            double observerLatValue = 0;
            double.TryParse(observerLat, out observerLatValue);
            ObserverLat = observerLatValue;

            double observerLonValue = 0;
            double.TryParse(observerLon, out observerLonValue);
            ObserverLon = observerLonValue;

            decimal altitudeValue = 0;
            decimal.TryParse(altitude, out altitudeValue);
            ObserverAltitude = altitudeValue;
        }

    }
}
