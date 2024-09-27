using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

// * Load the text file
// * Convert the text to List<Locations>
// Find the max ID
// Add the new record with the new ID (max + 1)
// Convert the locations to List<string>
// Save the list<string> to text file


namespace SatelliteTrackerActual.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName) // LocationModels.csv -- fileName     // C:\Users\Randa\Documents\SatTracker\LocationModel.csv -- filePath returned
        {
            return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ fileName }";
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static List<Location> ConvertToLocationModels(this List<string> lines) 
        {
            List<Location> output = new List<Location>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                Location p = new Location();
                p.Id = int.Parse(cols[0]);
                p.Name = cols[1];
                p.ObserverLat = double.Parse(cols[2]);
                p.ObserverLon = double.Parse(cols[3]);
                p.ObserverAltitude = decimal.Parse(cols[4]);
                output.Add(p);
            }

            return output;
        }

        public static void SaveToLocationFile(this List<Location> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (Location l in models)
            {
                lines.Add($"{l.Id},{l.Name},{l.ObserverLat},{l.ObserverLon},{l.ObserverAltitude}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
    }
}
