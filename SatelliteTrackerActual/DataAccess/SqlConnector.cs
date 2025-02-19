using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteTrackerActual
{
    public class SqlConnector : IDataConnection
    {
        private const string db = "SavedSatellites";

        // TODO - Make the AddUser method actually save to the database
        /// <summary>
        /// Saves a new user to the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Location information, includes unique identifier</returns>
        public UserInfo AddUserInfo(UserInfo model)
        {
            model.Id = 1;

            return model;
        }

        public Location AddLocationInfo(Location model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();

                p.Add("@LocationName", model.Name);
                p.Add("@Latitude", model.ObserverLat);
                p.Add("@Longitude", model.ObserverLon);
                p.Add("@Altitude", model.ObserverAltitude);               
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spLocation_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
        }

        public SatelliteInfo AddSatelliteInfo(SatelliteInfo model) 
        { 
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();

                p.Add("@Name", model.SatelliteName);
                p.Add("@NoradId", model.NoradId);
                p.Add("@Period", model.Period);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spSatellite_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
                
            }
        }

        public List<Location> GetLocations_All()
        {
            List<Location> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<Location>("dbo.spLocations_GetAll").ToList();
            }

            return output;
        }

        public List<SatelliteInfo> GetSatellites_All()
        {
            List<SatelliteInfo> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<SatelliteInfo>("dbo.spSatellites_GetAll").ToList();
            }

            return output;
        }
    }
}
