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
        // TODO - Make the AddUser methode actually save to the database
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
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("SavedSatellites")))
            {
                var p = new DynamicParameters();

                p.Add("@LocationName", model.Name);
                p.Add("@Latitude", model.ObserverLat);
                p.Add("@Longitude", model.ObserverLon);
                p.Add("@Altitude", model.ObserverAltitude);               
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spLocations_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
        }
    }
}
