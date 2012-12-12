using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace DBLayer
{
    public interface IDBStation
    {
        List<Station> getAllStations();
        Station searchStationID(int id);
        Boolean updateStation(Station Station);
        Boolean createStation(Station Station);
        Boolean deleteStation(Station Station);
    }
}
