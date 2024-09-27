using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SatelliteTrackerActual
{
    public class ParseJson
    {
        public ParseJson() { }

        public string JMethodString(string body)
        {
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(body);

            return myDeserializedClass.info.satname.ToString();
        }

        public int JMethodDub(string body)
        {
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(body);

            return myDeserializedClass.info.satid;
        }

        public List<Position> JMethodList(string body)
        {
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(body);

            return myDeserializedClass.positions.ToList();
        }

        public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
