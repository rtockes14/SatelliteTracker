using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteTrackerActual
{
    //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Info
    {
        public string satname { get; set; }
        public int satid { get; set; }
        public int transactionscount { get; set; }
    }

    public class Position
    {
        public double satlatitude { get; set; }
        public double satlongitude { get; set; }
        public double sataltitude { get; set; }
        public double azimuth { get; set; }
        public double elevation { get; set; }
        public double ra { get; set; }
        public double dec { get; set; }
        public int timestamp { get; set; }
        public bool eclipsed { get; set; }
    }

    public class Root
    {
        public Info info { get; set; }
        public List<Position> positions { get; set; }
    }


}
