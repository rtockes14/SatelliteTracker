using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SatelliteTrackerActual.DataAccess.TextHelpers;

namespace SatelliteTrackerActual
{
    public class TextConnector : IDataConnection
    {
        private const string LocationsFile = "LocationModels.csv";
        private const string SatellitesFile = "SatelliteModels.csv";


        // TODO -- Wire up the AddUserInfo for text files. 
        public UserInfo AddUserInfo(UserInfo model)
        {
            model.Id = 1;

            return model;
        }


        public SatelliteInfo AddSatelliteInfo(SatelliteInfo model)
        {
            List<SatelliteInfo> satellites = SatellitesFile.FullFilePath().LoadFile().ConvertToSatelliteModels();

            int currentId = 1;

            if (satellites.Count > 0)
            {
                currentId = satellites.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            // Add the new record with the new ID (max + 1)
            satellites.Add(model);

            // Convert the satellites to a List<string>
            //Save the list<string> to text file
            satellites.SaveToSatelliteFile(SatellitesFile);

            return model;
        }


        public Location AddLocationInfo(Location model)
        {
            // Load the text file and Convert the text to List<Location>
            List<Location> locations = LocationsFile.FullFilePath().LoadFile().ConvertToLocationModels();

            // Find the max ID
            int currentId = 1;
            
            if (locations.Count > 0)
            {
                currentId = locations.OrderByDescending(x => x.Id).First().Id + 1;
            }
                
            model.Id = currentId;
            
            // Add the new record with the new ID (max + 1)
            locations.Add(model);

            // Convert the locations to List<string>
            // Save the list<string> to text file
            locations.SaveToLocationFile(LocationsFile);

            return model;
        }

    }
}
