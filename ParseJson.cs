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
            //var info = new Info();

            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(body);


            //info.satname = myDeserializedClass.info.satname.ToString();
            //info.satid = myDeserializedClass.info.satid;
            //position.positions = myDeserializedClass.positions;

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

            Console.WriteLine("Object Data: ");
            Console.WriteLine(myDeserializedClass.positions);

            return myDeserializedClass.positions.ToList();

        }


    }
}
