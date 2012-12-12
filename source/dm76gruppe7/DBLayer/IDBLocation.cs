using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace DBLayer
{
    public interface IDBLocation
    {
        List<Location> getAllLocations();
        Location searchLocationID(int id);
        Boolean updateLocation(Location Location);
        Boolean createLocation(Location Location);
        Boolean deleteLocation(Location Location);
    }
}
