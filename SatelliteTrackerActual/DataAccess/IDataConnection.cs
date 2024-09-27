using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteTrackerActual
{
    public interface IDataConnection
    {
        UserInfo AddUserInfo(UserInfo model);

        Location AddLocationInfo(Location model);
    }
}
