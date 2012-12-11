using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace DBLayer
{
    public interface IDBBattery
    {
        List<Battery> getAllBatteries();
        Battery searchBatteryID(int id);
        Boolean updateBattery(Battery battery);
        Boolean createBattery(Battery battery);
        Boolean deleteBattery(Battery battery);
    }
}
