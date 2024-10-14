using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteTrackerActual
{
    public class SatelliteInfo
    {
        // The unique non-Norad identifier for the satellite
        public int Id {  get; set; }
        public string SatelliteName { get; set; }
        public int NoradId { get; set; }
        public decimal Period { get; set; }
    }
}            
