using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteTrackerActual
{
    public class RelevantData
    {
        public string SatName { get; set; }
        public int SatId { get; set; }
        public double SatElevation { get; set; }
        public double SatAzimuth { get; set; }
        public double SatLatitude { get; set; }
        public double SatLongitude { get; set; }
        public DateTime Date { get; set; }

        public RelevantData(string satName, int satId, double elevation, double azimuth, double satLatitude, double satLongitude, DateTime date)
        {
            SatName = satName;
            SatId = satId;
            SatElevation = elevation;
            SatAzimuth = azimuth;
            SatLatitude = satLatitude;
            SatLongitude = satLongitude;
            Date = date;
        }
    }
}
