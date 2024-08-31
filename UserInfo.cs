using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteTrackerActual
{
    public class UserInfo
    {
      
        private string apiKey = "T8GAF2-BUJBAQ-G4VTV9-5BJJ";
        private string satID = "25544";
        private string observerLat = "43.01912";
        private string observerLng = "-89.82999";
        private int altitude = 400;
            
        public UserInfo() { }

        public string ApiKey
        {
            get 
            {
                return apiKey; 
            }
        }

        public string SatID
        {
            get { return satID; }
            set { satID = value; }
        }

        public string ObserverLat
        {
            get { return observerLat; }
            set { observerLat = value; }
        }
        public string ObserverLng
        {
            get { return observerLng; }
            set { observerLng = value; }
        }

        public int Altitude
        { get { return altitude; } set {  altitude = value; } }
    }
}
