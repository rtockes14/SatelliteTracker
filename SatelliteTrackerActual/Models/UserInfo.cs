using System;
using System.Collections.Generic;

namespace SatelliteTrackerActual
{
    public class UserInfo
    {

        private string apiKey = "T8GAF2-BUJBAQ-G4VTV9-5BJJ";

        public List<SatelliteInfo> SavedSats { get; set; }
        public List<Location> Locations { get; set; }

        public DateTime Date { get; set; }
            
        public UserInfo() { }

        
        public int Id {  get; set; }

        public string ApiKey
        {
            get 
            {
                return apiKey; 
            }
        }
    }

}
